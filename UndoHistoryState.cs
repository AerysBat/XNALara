namespace XNALara
{
    public abstract class UndoHistoryState
    {
        public abstract void Apply(ControlGUI gui);

        public abstract bool DetermineSignificance(UndoHistoryState prevState);
    }


    public class UndoHistoryStateSelectItem : UndoHistoryState
    {
        private Item selectedItem;

        public UndoHistoryStateSelectItem(Item selectedItem) {
            this.selectedItem = selectedItem;
        }

        public override void Apply(ControlGUI gui) {
            gui.HandleItemSelectedIn3D(selectedItem);
        }

        public override bool DetermineSignificance(UndoHistoryState prevState) {
            if (prevState is UndoHistoryStateSelectItem) {
                UndoHistoryStateSelectItem prevStateCast = (UndoHistoryStateSelectItem)prevState;
                return selectedItem != prevStateCast.selectedItem;
            }
            return true;
        }

        public override string ToString() {
            return string.Format("SelectItem {0}", selectedItem.Type);
        }
    }


    public class UndoHistoryStateSelectBone : UndoHistoryState
    {
        private Armature.Bone selectedBone;

        public UndoHistoryStateSelectBone(Armature.Bone selectedBone) {
            this.selectedBone = selectedBone;
        }

        public override void Apply(ControlGUI gui) {
            gui.HandleBoneSelectedIn3D(selectedBone);
        }

        public override bool DetermineSignificance(UndoHistoryState prevState) {
            if (prevState is UndoHistoryStateSelectBone) {
                UndoHistoryStateSelectBone prevStateCast = (UndoHistoryStateSelectBone)prevState;
                return selectedBone != prevStateCast.selectedBone;
            }
            return true;
        }

        public override string ToString() {
            return string.Format("SelectBone {0}", selectedBone.name);
        }
    }


    public class UndoHistoryStateBoneTransform : UndoHistoryState
    {
        private Armature.Bone bone;
        private ControlGUI.BoneTransform transform;

        public UndoHistoryStateBoneTransform(Armature.Bone bone, ControlGUI.BoneTransform transform) {
            this.bone = bone;
            this.transform = transform.Clone();
        }

        public override void Apply(ControlGUI gui) {
            gui.HandleBoneRotationXChanged(bone, transform.rotX);
            gui.HandleBoneRotationYChanged(bone, transform.rotY);
            gui.HandleBoneRotationZChanged(bone, transform.rotZ);
            gui.HandleBoneTranslationXChanged(bone, transform.moveX);
            gui.HandleBoneTranslationYChanged(bone, transform.moveY);
            gui.HandleBoneTranslationZChanged(bone, transform.moveZ);
        }

        public override bool DetermineSignificance(UndoHistoryState prevState) {
            if (prevState is UndoHistoryStateBoneTransform) {
                UndoHistoryStateBoneTransform prevStateCast = (UndoHistoryStateBoneTransform)prevState;
                if (bone == prevStateCast.bone) {
                    return false;
                }
            }
            return true;
        }

        public override string ToString() {
            return string.Format("BoneTransform ({0} {1} {2}) ({3} {4} {5})",
                transform.rotX, transform.rotY, transform.rotZ,
                transform.moveX, transform.moveY, transform.moveZ);
        }
    }


    public class UndoHistoryStateInterrupt : UndoHistoryState
    {
        public override void Apply(ControlGUI gui) {
        }

        public override bool DetermineSignificance(UndoHistoryState prevState) {
            if (prevState is UndoHistoryStateInterrupt) {
                return false;
            }
            return true;
        }

        public override string ToString() {
            return string.Format("[Interrupt]");
        }
    }
}
