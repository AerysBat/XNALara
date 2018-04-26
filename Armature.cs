using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public delegate void ArmatureEventDelegate();

    public class Armature
    {
        private Model model;

        private Vector3 worldTranslation = Vector3.Zero;
        private Vector3 worldScale = new Vector3(1.0f, 1.0f, 1.0f);
        private Matrix worldMatrix = Matrix.Identity;

        private Bone[] bones = new Bone[0];
        private Matrix[] boneMatrices = new Matrix[0];

        private Dictionary<string, Bone> boneDict = new Dictionary<string, Bone>();
        private List<Bone> rootBones = new List<Bone>();

        public event ArmatureEventDelegate ArmatureEvent;

        public Armature(Model model) {
            this.model = model;
        }

        public Model Model {
            get { return model; }
        }

        public Vector3 WorldTranslation {
            set {
                worldTranslation = value;
                WorldMatrix = 
                    Matrix.CreateScale(worldScale) * 
                    Matrix.CreateTranslation(worldTranslation);
            }
            get { return worldTranslation; }
        }

        public Vector3 WorldScale {
            set {
                worldScale = value;
                WorldMatrix =
                    Matrix.CreateScale(worldScale) *
                    Matrix.CreateTranslation(worldTranslation);
            }
            get { return worldScale; }
        }

        public Matrix WorldMatrix {
            private set {
                worldMatrix = value;
                if (ArmatureEvent != null) {
                    ArmatureEvent();
                }
            }
            get { return worldMatrix; }
        }

        public Bone[] Bones {
            set {
                bones = new Bone[value.Length];
                boneMatrices = new Matrix[bones.Length];
                boneDict.Clear();
                rootBones.Clear();
                for (int boneID = 0; boneID < bones.Length; boneID++) {
                    Bone bone = value[boneID];
                    bones[boneID] = bone;
                    boneDict[bone.name] = bone;
                    if (bone.parent == null) {
                        rootBones.Add(bone);
                    }
                }
                InitMatrices();
            }

            get { return bones; }
        }

        public Bone GetBone(string boneName) {
            Bone bone;
            if (boneDict.TryGetValue(boneName, out bone)) {
                return bone;
            }
            return null;
        }

        public Matrix[] GetBoneMatrices(Mesh mesh) {
            short[] boneIndexMap = mesh.BoneIndexMap;
            Matrix[] matrices = new Matrix[boneIndexMap.Length];
            for (int i = 0; i < matrices.Length; i++) {
                matrices[i] = boneMatrices[boneIndexMap[i]];
            }
            return matrices;
        }

        public Matrix[] BoneMatrices {
            get { return boneMatrices; }
        }

        public void SetBoneTransform(string boneName, Matrix transform) {
            boneDict[boneName].relTransform = transform;
        }

        public void UpdateBoneMatrices() {
            foreach (Bone root in rootBones) {
                CalcAbsTransform(root);
            }
            for (int boneID = 0; boneID < bones.Length; boneID++) {
                Bone bone = bones[boneID];
                boneMatrices[boneID] = bone.invMove * bone.absTransform;
            }
            if (ArmatureEvent != null) {
                ArmatureEvent();
            }
        }

        private void InitMatrices() {
            foreach (Bone bone in bones) {
                bone.relTransform = Matrix.Identity;
                bone.invMove = Matrix.CreateTranslation(-bone.absPosition);
                bone.relMove = bone.parent != null ? 
                    Matrix.CreateTranslation(bone.absPosition - bone.parent.absPosition) : 
                    Matrix.Identity;
            }
            UpdateBoneMatrices();
        }

        private void CalcAbsTransform(Bone bone) {
            Bone parent = bone.parent;
            if (parent != null) {
                bone.absTransform = (bone.relTransform * bone.relMove) * parent.absTransform;
            }
            else {
                bone.absTransform = bone.relTransform;
            }
            foreach (Bone child in bone.children) {
                CalcAbsTransform(child);
            }
        }

        public class Bone
        {
            public Armature armature;

            public int id;
            public string name;
            public Vector3 absPosition;
            public Bone parent;
            public List<Bone> children = new List<Bone>();

            public Matrix invMove;
            public Matrix relMove;

            public Matrix relTransform;
            public Matrix absTransform;
        }
    }
}
