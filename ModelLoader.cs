using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public class ModelLoader
    {
        private const int MaxBoneCount = 59;

        private Game game;

        public ModelLoader(Game game) {
            this.game = game;
        }

        public Model LoadAndInitModel(string filename, VertexFormat vertexFormat) {
            Model model = LoadModel(filename);
            if (model != null) {
                model.InitMeshes(vertexFormat);
            }
            return model;
        }

        public Model LoadModel(string filename) {
            BinaryReader file = null;
            try {
                file = new BinaryReader(new FileStream(filename, FileMode.Open));
                Model model = new Model(game);
                model.Armature = LoadArmature(file, model);
                int meshCount = file.ReadInt32();
                for (int meshID = 0; meshID < meshCount; meshID++) {
                    MeshDesc mesh = LoadMesh(file, model.Armature != null);
                    if (mesh.boneIndexMap.Length > MaxBoneCount) {
                        MessageBox.Show(string.Format("The mesh \"{0}\" contains more than {1} bones ({2}) and will be ignored.", mesh.name, MaxBoneCount, mesh.boneIndexMap.Length),
                            "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    model.AddMeshDesc(mesh);
                }
                file.Close();
                return model;
            }
            catch (Exception ex) {
                MessageBox.Show(string.Format("Loading model \"{0}\" failed.\n{1}\n\n{2}", filename, ex.Message, ex.StackTrace),
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (file != null) {
                    file.Close();
                }
                return null;
            }
        }

        private Armature LoadArmature(BinaryReader file, Model model) {
            int boneCount = file.ReadInt32();
            if (boneCount == 0) {
                return null;
            }
            Armature armature = new Armature(model);
            Armature.Bone[] bones = new Armature.Bone[boneCount];
            int[] parentIDs = new int[boneCount];
            for (int boneID = 0; boneID < boneCount; boneID++) {
                Armature.Bone bone = new Armature.Bone();
                bone.armature = armature;
                bone.id = boneID;
                bone.name = file.ReadString();
                parentIDs[boneID] = file.ReadInt16();
                float absPosX = file.ReadSingle();
                float absPosY = file.ReadSingle();
                float absPosZ = file.ReadSingle();
                bone.absPosition = new Vector3(absPosX, absPosY, absPosZ);
                bones[boneID] = bone;
            }
            for (int boneID = 0; boneID < boneCount; boneID++) {
                Armature.Bone bone = bones[boneID];
                int parentID = parentIDs[boneID];
                if (parentID >= 0) {
                    Armature.Bone parent = bones[parentID];
                    bone.parent = parent;
                    parent.children.Add(bone);
                }
            }
            armature.Bones = bones;
            return armature;
        }

        private MeshDesc LoadMesh(BinaryReader file, bool hasArmature) {
            MeshDesc mesh = new MeshDesc();
            mesh.name = file.ReadString();
            int uvLayerCount = file.ReadInt32();
            mesh.uvLayerCount = uvLayerCount;
            int textureCount = file.ReadInt32();
            mesh.textures = new MeshDesc.Texture[textureCount];
            for (int textureID = 0; textureID < textureCount; textureID++) {
                MeshDesc.Texture texture = new MeshDesc.Texture();
                texture.filename = file.ReadString();
                texture.uvLayerIndex = file.ReadInt32();
                mesh.textures[textureID] = texture;
            }
            Dictionary<short, short> boneIndexDict = new Dictionary<short, short>();
            List<short> boneIndexMap = new List<short>();
            int vertexCount = file.ReadInt32();
            mesh.vertices = new MeshDesc.Vertex[vertexCount];
            for (int vertexID = 0; vertexID < vertexCount; vertexID++) {
                MeshDesc.Vertex vertex = new MeshDesc.Vertex();
                float positionX = file.ReadSingle();
                float positionY = file.ReadSingle();
                float positionZ = file.ReadSingle();
                vertex.position = new Vector3(positionX, positionY, positionZ);
                float normalX = file.ReadSingle();
                float normalY = file.ReadSingle();
                float normalZ = file.ReadSingle();
                vertex.normal = new Vector3(normalX, normalY, normalZ);
                float colorR = file.ReadByte() / 255.0f;
                float colorG = file.ReadByte() / 255.0f;
                float colorB = file.ReadByte() / 255.0f;
                float colorA = file.ReadByte() / 255.0f;
                vertex.color = new Vector4(colorR, colorG, colorB, 1.0f);
                vertex.texCoords = new Vector2[uvLayerCount];
                for (int uvLayerID = 0; uvLayerID < uvLayerCount; uvLayerID++) {
                    float texCoordX = file.ReadSingle();
                    float texCoordY = file.ReadSingle();
                    vertex.texCoords[uvLayerID] = new Vector2(texCoordX, texCoordY);
                }
                vertex.tangents = new Vector4[uvLayerCount];
                for (int uvLayerID = 0; uvLayerID < uvLayerCount; uvLayerID++) {
                    float tangentX = file.ReadSingle();
                    float tangentY = file.ReadSingle();
                    float tangentZ = file.ReadSingle();
                    float tangentW = file.ReadSingle();
                    vertex.tangents[uvLayerID] = new Vector4(tangentX, tangentY, tangentZ, tangentW);
                }
                if (hasArmature) {
                    vertex.boneIndicesGlobal = new short[4];
                    vertex.boneIndicesLocal = new short[4];
                    for (int i = 0; i < 4; i++) {
                        vertex.boneIndicesGlobal[i] = file.ReadInt16();
                    }
                    vertex.boneWeights = new float[4];
                    float weightSum = 0;
                    for (int i = 0; i < 4; i++) {
                        float weight = file.ReadSingle();
                        vertex.boneWeights[i] = weight;
                        weightSum += weight;
                    }
                    if (weightSum == 0) {
                        vertex.boneWeights[0] = 1.0f;
                    }
                    else {
                        if (weightSum != 1.0f) {
                            for (int i = 0; i < 4; i++) {
                                vertex.boneWeights[i] /= weightSum;
                            }
                        }
                    }
                    short indexDefault = -1;
                    for (int i = 0; i < 4; i++) {
                        if (vertex.boneWeights[i] > 0) {
                            indexDefault = vertex.boneIndicesGlobal[i];
                            break;
                        }
                    }
                    for (int i = 0; i < 4; i++) {
                        short indexGlobal = vertex.boneIndicesGlobal[i];
                        if (vertex.boneWeights[i] == 0) {
                            indexGlobal = indexDefault;
                        }
                        short indexLocal;
                        if (!boneIndexDict.TryGetValue(indexGlobal, out indexLocal)) {
                            indexLocal = (short)boneIndexMap.Count;
                            boneIndexDict[indexGlobal] = indexLocal;
                            boneIndexMap.Add(indexGlobal);
                        }
                        vertex.boneIndicesLocal[i] = indexLocal;
                    }
                }
                mesh.vertices[vertexID] = vertex;
            }
            mesh.boneIndexMap = boneIndexMap.ToArray();
            int faceCount = file.ReadInt32();
            mesh.indices = new ushort[faceCount * 3];
            int index = 0;
            for (int faceID = 0; faceID < faceCount; faceID++) {
                mesh.indices[index + 0] = (ushort)file.ReadInt32();
                mesh.indices[index + 1] = (ushort)file.ReadInt32();
                mesh.indices[index + 2] = (ushort)file.ReadInt32();
                index += 3;
            }
            return mesh;
        }
    }
}
