using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private void LoadPose(string filename) {
            try {
                StreamReader file = new StreamReader(filename);
                List<string> lines = new List<string>();
                while (true) {
                    string line = file.ReadLine();
                    if (line == null) {
                        break;
                    }
                    line = line.Trim();
                    if (line.Length == 0) {
                        continue;
                    }
                    lines.Add(line);
                }
                file.Close();
                if (lines.Count == 0) {
                    return;
                }
                if (lines[0].IndexOf(':') < 0) {
                    LoadPoseOld(lines);
                }
                else {
                    LoadPoseNew(lines);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not load the pose file.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadPoseOld(List<string> lines) {
            Armature armature = selectedItem.Model.Armature;
            DataSet dataSet = dataSetDict[selectedItem];
            if (lines.Count != armature.Bones.Length) {
                MessageBox.Show(this, "Incompatible armatures (bones do not match).", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int boneID = 0;
            foreach (string line in lines) {
                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3) {
                    BoneTransform boneTransform = dataSet.boneTransforms[boneID];
                    boneTransform.rotX = int.Parse(tokens[0]);
                    boneTransform.rotY = int.Parse(tokens[1]);
                    boneTransform.rotZ = int.Parse(tokens[2]);
                    boneTransform.moveX = 0;
                    boneTransform.moveY = 0;
                    boneTransform.moveZ = 0;
                }
                boneID++;
            }
            foreach (Armature.Bone bone in armature.Bones) {
                BoneTransform boneRotation = dataSet.boneTransforms[bone.id];
                ApplyTransformToBone(bone, boneRotation);
            }
        }

        private void LoadPoseNew(List<string> lines) {
            Armature armature = selectedItem.Model.Armature;
            Dictionary<string, BoneTransform> boneTransforms = new Dictionary<string, BoneTransform>();
            foreach (string line in lines) {
                string[] tokens1 = line.Split(':');
                if (tokens1.Length == 2) {
                    string boneName = tokens1[0].Trim();
                    Armature.Bone bone = armature.GetBone(boneName);
                    if (bone != null) {
                        string[] tokens2 = tokens1[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens2.Length == 3 || tokens2.Length == 6) {
                            BoneTransform boneTransform = new BoneTransform();
                            boneTransform.rotX = float.Parse(tokens2[0]);
                            boneTransform.rotY = float.Parse(tokens2[1]);
                            boneTransform.rotZ = float.Parse(tokens2[2]);
                            if (tokens2.Length == 6) {
                                boneTransform.moveX = float.Parse(tokens2[3]);
                                boneTransform.moveY = float.Parse(tokens2[4]);
                                boneTransform.moveZ = float.Parse(tokens2[5]);
                            }
                            else {
                                boneTransform.moveX = 0;
                                boneTransform.moveY = 0;
                                boneTransform.moveZ = 0;
                            }
                            boneTransforms[boneName] = boneTransform;
                        }
                    }
                }
            }

            ICollection<string> boneNames = boneTransforms.Keys;
            PoseFilterDialog dialog = new PoseFilterDialog(game, "Load pose", "Select bones to load:", boneNames, true);
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            DataSet dataSet = dataSetDict[selectedItem];
            foreach (string boneName in boneNames) {
                if (dialog.IsBoneSelected(boneName)) {
                    Armature.Bone bone = armature.GetBone(boneName);
                    BoneTransform boneTransform = boneTransforms[boneName];
                    dataSet.boneTransforms[bone.id] = boneTransform;
                    ApplyTransformToBone(bone, boneTransform);
                }
            }
        }

        private void SavePose(string filename) {
            Armature armature = selectedItem.Model.Armature;
            List<string> boneNames = new List<string>();
            foreach (Armature.Bone bone in armature.Bones) {
                if (!bone.name.StartsWith("unused")) {
                    boneNames.Add(bone.name);
                }
            }

            PoseFilterDialog dialog = new PoseFilterDialog(game, "Save pose", "Select bones to save:", boneNames, true);
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            try {
                DataSet dataSet = dataSetDict[selectedItem];
                StreamWriter file = new StreamWriter(filename);
                foreach (Armature.Bone bone in armature.Bones) {
                    if (!dialog.IsBoneSelected(bone.name)) {
                        continue;
                    }
                    BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
                    file.WriteLine("{0}: {1} {2} {3} {4} {5} {6}", bone.name, 
                        boneTransform.rotX, boneTransform.rotY, boneTransform.rotZ,
                        boneTransform.moveX, boneTransform.moveY, boneTransform.moveZ);
                }
                file.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not save the pose file.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
