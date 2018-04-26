using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public class MeshObjExporter
    {
        public static void ExportToObj(List<Model> models, string filename) {
            string objFilename = filename;
            string mtlFilename = filename.ToLower().EndsWith(".obj") ? 
                filename.Substring(0, filename.Length - 4) + ".mtl" : filename + ".mtl";
            StreamWriter objFile = new StreamWriter(objFilename);
            StreamWriter mtlFile = new StreamWriter(mtlFilename);
            int modelID = 0;
            foreach (Model model in models) {
                if (!model.IsVisible) {
                    continue;
                }
                modelID++;
                int materialID = 0;
                Armature armature = model.Armature;
                Matrix worldMatrix = armature.WorldMatrix;
                Matrix[] boneMatrices = armature.BoneMatrices;
                foreach (MeshDesc meshDesc in model.MeshDescs) {
                    Mesh mesh = model.GetMesh(meshDesc.name);
                    if (!mesh.IsVisible) {
                        continue;
                    }
                    materialID++;
                    string materialName = string.Format("Model{0:D3}_Material{1:D3}", modelID, materialID);
                    mtlFile.WriteLine("newmtl {0}", materialName);
                    if (meshDesc.textures.Length > 0) {
                        mtlFile.WriteLine("map_Kd {0}", RemoveFullPath(meshDesc.textures[0].filename));
                    }
                    mtlFile.WriteLine();

                    objFile.WriteLine("mtllib {0}", mtlFilename);
                    objFile.WriteLine("g Model{0:D3}_{1}", modelID, meshDesc.name);
                    objFile.WriteLine("usemtl {0}", materialName);
                    foreach (MeshDesc.Vertex vertex in meshDesc.vertices) {
                        Vector3 position, normal;
                        Utils.TransformVertex(vertex, worldMatrix, boneMatrices, meshDesc.boneIndexMap, out position, out normal);
                        objFile.WriteLine("v {0} {1} {2}", position.X, position.Y, position.Z);
                        objFile.WriteLine("vn {0} {1} {2}", normal.X, normal.Y, normal.Z);
                        objFile.WriteLine("vt {0} {1}", vertex.texCoords[0].X, 1 - vertex.texCoords[0].Y);
                    }
                    for (int i = 0; i < meshDesc.indices.Length; i += 3) {
                        int index1 = meshDesc.indices[i + 0] - meshDesc.vertices.Length;
                        int index2 = meshDesc.indices[i + 1] - meshDesc.vertices.Length;
                        int index3 = meshDesc.indices[i + 2] - meshDesc.vertices.Length;
                        objFile.WriteLine("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", index1, index3, index2);
                    }
                    objFile.WriteLine();
                }
            }
            objFile.Close();
            mtlFile.Close();
        }

        private static string RemoveFullPath(string filename) {
            int pos = filename.LastIndexOfAny(new char[] { ':', '/', '\\' });
            return pos < 0 ? filename : filename.Substring(pos + 1);
        }
    }
}
