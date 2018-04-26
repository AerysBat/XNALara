using System.Collections.Generic;
using System.Windows.Forms;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private void FlipPose() {
            if (selectedItem == null) {
                return;
            }

            Armature armature = selectedItem.Model.Armature;

            List<string> labels = new List<string>();
            Dictionary<string, string> labelsToBoneNames = new Dictionary<string, string>();

            foreach (Armature.Bone bone in armature.Bones) {
                int origSide;
                string flippedName = GetFlippedBoneName(bone.name, out origSide);
                if (flippedName != null && origSide < 0 && armature.GetBone(flippedName) != null) {
                    string combinedName = GetCombinedBoneName(bone.name);
                    labels.Add(combinedName);
                    labelsToBoneNames[combinedName] = bone.name;
                }
            }

            PoseFilterDialog dialog = new PoseFilterDialog(game, "Flip (swap) pose left/right", "Select bone pairs whose pose to flip:", labels, false);
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            DataSet dataSet = dataSetDict[selectedItem];
            foreach (string label in labels) {
                if (!dialog.IsBoneSelected(label)) {
                    continue;
                }

                string boneName1 = labelsToBoneNames[label];
                Armature.Bone bone1 = armature.GetBone(boneName1);
                BoneTransform boneTransform1 = dataSet.boneTransforms[bone1.id];

                string boneName2 = GetFlippedBoneName(boneName1);
                Armature.Bone bone2 = armature.GetBone(boneName2);
                BoneTransform boneTransform2 = dataSet.boneTransforms[bone2.id];

                float moveX1 = boneTransform1.moveX;
                float moveY1 = boneTransform1.moveY;
                float moveZ1 = boneTransform1.moveZ;

                float rotX1 = boneTransform1.rotX;
                float rotY1 = boneTransform1.rotY;
                float rotZ1 = boneTransform1.rotZ;

                float moveX2 = boneTransform2.moveX;
                float moveY2 = boneTransform2.moveY;
                float moveZ2 = boneTransform2.moveZ;

                float rotX2 = boneTransform2.rotX;
                float rotY2 = boneTransform2.rotY;
                float rotZ2 = boneTransform2.rotZ;

                boneTransform2.moveX = -moveX1;
                boneTransform2.moveY = +moveY1;
                boneTransform2.moveZ = +moveZ1;

                boneTransform2.rotX = +rotX1;
                boneTransform2.rotY = -rotY1;
                boneTransform2.rotZ = -rotZ1;

                boneTransform1.moveX = -moveX2;
                boneTransform1.moveY = +moveY2;
                boneTransform1.moveZ = +moveZ2;

                boneTransform1.rotX = +rotX2;
                boneTransform1.rotY = -rotY2;
                boneTransform1.rotZ = -rotZ2;

                ApplyTransformToBone(bone1, boneTransform1);
                ApplyTransformToBone(bone2, boneTransform2);
            }
        }

        private string GetFlippedBoneName(string boneName) {
            int origSide;
            return GetFlippedBoneName(boneName, out origSide);
        }

        private string GetFlippedBoneName(string boneName, out int origSide) {
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

        private string GetCombinedBoneName(string boneName) {
            if (boneName.StartsWith("left ")) {
                return boneName.Substring(5);
            }
            if (boneName.EndsWith(" left")) {
                return boneName.Substring(0, boneName.Length - 5);
            }
            if (boneName.Contains(" left ")) {
                return boneName.Replace(" left ", " ");
            }

            if (boneName.StartsWith("right ")) {
                return boneName.Substring(6);
            }
            if (boneName.EndsWith(" right")) {
                return boneName.Substring(0, boneName.Length - 6);
            }
            if (boneName.Contains(" right ")) {
                return boneName.Replace(" right ", " ");
            }

            return null;
        }
    }
}
