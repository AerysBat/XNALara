using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    class MeshAsciiExporter
    {
        public static void ExportToMeshAscii(Model model, string filename, bool applyPose) {
            StreamWriter file = new StreamWriter(filename);
            Armature armature = model.Armature;
            file.WriteLine("{0} # bones", model.Armature.Bones.Length);
            foreach (Armature.Bone bone in model.Armature.Bones) {
                file.WriteLine("{0}", bone.name);
                file.WriteLine("{0}", bone.parent != null ? bone.parent.id : -1);
                Vector3 position;
                if (!applyPose) {
                    position = bone.absPosition * armature.WorldScale;
                }
                else {
                    position = Utils.GetTransformedBone(bone, armature.WorldMatrix);
                }
                file.WriteLine("{0} {1} {2}", position.X, position.Y, position.Z);
            }
            file.WriteLine("{0} # meshes", model.Meshes.Count);
            foreach (MeshDesc meshDesc in model.MeshDescs) {
                file.WriteLine("{0}", meshDesc.name);
                file.WriteLine("{0} # uv layers", meshDesc.uvLayerCount);
                file.WriteLine("{0} # textures", meshDesc.textures.Length);
                foreach (MeshDesc.Texture texture in meshDesc.textures) {
                    file.WriteLine("{0}", ExtractFilename(texture.filename));
                    file.WriteLine("{0} # uv layer index", texture.uvLayerIndex);
                }
                file.WriteLine("{0} # vertices", meshDesc.vertices.Length);
                foreach (MeshDesc.Vertex vertex in meshDesc.vertices) {
                    Vector3 position;
                    Vector3 normal;
                    if (!applyPose) {
                        position = vertex.position * armature.WorldScale;
                        normal = vertex.normal;
                    }
                    else {
                        Utils.TransformVertex(vertex, 
                            armature.WorldMatrix, armature.BoneMatrices, meshDesc.boneIndexMap, 
                            out position, out normal);
                    }
                    file.WriteLine("{0} {1} {2}", position.X, position.Y, position.Z);
                    file.WriteLine("{0} {1} {2}", normal.X, normal.Y, normal.Z);
                    Color color = VertexColorToColor(vertex.color);
                    file.WriteLine("{0} {1} {2} {3}", color.R, color.G, color.B, color.A);
                    for (int uvLayerID = 0; uvLayerID < meshDesc.uvLayerCount; uvLayerID++) {
                        Vector2 uv = vertex.texCoords[uvLayerID];
                        file.WriteLine("{0} {1}", uv.X, uv.Y);
                    }
                    if (model.Armature.Bones.Length > 0) {
                        file.WriteLine("{0} {1} {2} {3}",
                            vertex.boneIndicesGlobal[0],
                            vertex.boneIndicesGlobal[1],
                            vertex.boneIndicesGlobal[2],
                            vertex.boneIndicesGlobal[3]);
                        file.WriteLine("{0} {1} {2} {3}",
                            vertex.boneWeights[0],
                            vertex.boneWeights[1],
                            vertex.boneWeights[2],
                            vertex.boneWeights[3]);
                    }
                }
                file.WriteLine("{0} # faces", meshDesc.indices.Length / 3);
                for (int i = 0; i < meshDesc.indices.Length; i += 3) {
                    file.WriteLine("{0} {1} {2}", 
                        meshDesc.indices[i + 0], 
                        meshDesc.indices[i + 1], 
                        meshDesc.indices[i + 2]);
                }
            }
            file.Close();
        }

        private static Color VertexColorToColor(Vector4 color) {
            byte r = (byte)Math.Min(Math.Round(color.X * 255), 255);
            byte g = (byte)Math.Min(Math.Round(color.Y * 255), 255);
            byte b = (byte)Math.Min(Math.Round(color.Z * 255), 255);
            byte a = (byte)Math.Min(Math.Round(color.W * 255), 255);
            return new Color(r, g, b, a);
        }

        private static string ExtractFilename(string path) {
            int pos = path.LastIndexOfAny(new char[] { ':', '\\', '/' });
            if (pos < 0) {
                return path;
            }
            return path.Substring(pos + 1);
        }
    }
}
