using System.Collections.Generic;
using System.Windows.Forms;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private void MirrorPose() {
            if (selectedItem == null) {
                return;
            }

            Armature armature = selectedItem.Model.Armature;

            List<string> labels = new List<string>();
            foreach (Armature.Bone bone in armature.Bones) {
                int origSide;
                string mirroredName = GetMirroredBoneName(bone.name, out origSide);
                if (mirroredName != null && origSide < 0 && armature.GetBone(mirroredName) != null) {
                    labels.Add("L: " + bone.name);
                }
            }
            foreach (Armature.Bone bone in armature.Bones) {
                int origSide;
                string mirroredName = GetMirroredBoneName(bone.name, out origSide);
                if (mirroredName != null && origSide > 0 && armature.GetBone(mirroredName) != null) {
                    labels.Add("R: " + bone.name);
                }
            }

            PoseFilterDialog dialog = new PoseFilterDialog(game, "Mirror (copy) pose left/right", "Select bones to mirror pose from:", labels, false);
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            DataSet dataSet = dataSetDict[selectedItem];
            foreach (string label in labels) {
                if (!dialog.IsBoneSelected(label)) {
                    continue;
                }

                string boneNameFrom = label.Substring(3);
                Armature.Bone boneFrom = armature.GetBone(boneNameFrom);
                BoneTransform boneTransformFrom = dataSet.boneTransforms[boneFrom.id];

                string boneNameTo = GetMirroredBoneName(boneNameFrom);
                Armature.Bone boneTo = armature.GetBone(boneNameTo);
                BoneTransform boneTransformTo = dataSet.boneTransforms[boneTo.id];

                boneTransformTo.moveX = -boneTransformFrom.moveX;
                boneTransformTo.moveY = +boneTransformFrom.moveY;
                boneTransformTo.moveZ = +boneTransformFrom.moveZ;

                boneTransformTo.rotX = +boneTransformFrom.rotX;
                boneTransformTo.rotY = -boneTransformFrom.rotY;
                boneTransformTo.rotZ = -boneTransformFrom.rotZ;

                ApplyTransformToBone(boneTo, boneTransformTo);
            }
        }

        private string GetMirroredBoneName(string boneName) {
            int origSide;
            return GetMirroredBoneName(boneName, out origSide);
        }

        private string GetMirroredBoneName(string boneName, out int origSide) {
            origSide = -1;
            if (boneName.StartsWith("left ")) {
                return "right " + boneName.Substring(5);
            }
            if (boneName.EndsWith(" left")) {
                return boneName.Substring(0, boneName.Length - 5) + " right";
            }
            if (boneName.Contains(" left ")) {
                return boneName.Replace(" left ", " right ");
            }

            origSide = +1;
            if (boneName.StartsWith("right ")) {
                return "left " + boneName.Substring(6);
            }
            if (boneName.EndsWith(" right")) {
                return boneName.Substring(0, boneName.Length - 6) + " left";
            }
            if (boneName.Contains(" right ")) {
                return boneName.Replace(" right ", " left ");
            }

            origSide = 0;
            return null;
        }
    }
}
