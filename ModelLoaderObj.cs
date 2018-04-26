using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class ModelLoaderObj
    {
        private Game game;
        private int lineCounter = 0;

        public ModelLoaderObj(Game game) {
            this.game = game;
        }

        public Model LoadAndInitModel(string filenameObj, string filenameMtl, VertexFormat vertexFormat) {
            Model model = LoadModel(filenameObj, filenameMtl);
            if (model != null) {
                model.InitMeshes(vertexFormat);
            }
            return model;
        }

        public Model LoadModel(string filenameObj, string filenameMtl) {
            Dictionary<string, Material> materials = LoadMaterials(filenameMtl);
            if (materials == null) {
                return null;
            }
            return LoadModel(filenameObj, materials);
        }

        private Dictionary<string, Material> LoadMaterials(string filenameMtl) {
            StreamReader file = null;
            try {
                file = new StreamReader(filenameMtl);
            }
            catch (Exception){
                MessageBox.Show("Could not open MTL file.",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Dictionary<string, Material> materials = new Dictionary<string, Material>();
            Material material = null;
            while (true) {
                string line = file.ReadLine();
                if (line == null) {
                    break;
                }
                line = line.TrimStart();

                if (line.StartsWith("newmtl ")) {
                    material = new Material();
                    material.name = line.Substring(7).Trim();
                    materials[material.name] = material;
                    continue;
                }

                if (line.StartsWith("map_Kd ")) {
                    if (material != null) {
                        material.textureDiffuse = line.Substring(7).Trim().Replace('/', '\\');
                    }
                    continue;
                }

                if (line.StartsWith("map_Kn ")) {
                    if (material != null) {
                        material.textureNormal = line.Substring(7).Trim().Replace('/', '\\');
                    }
                    continue;
                }

                if (line.StartsWith("map_bump ")) {
                    if (material != null) {
                        material.textureNormal = line.Substring(9).Trim().Replace('/', '\\');
                    }
                    continue;
                }

                if (line.StartsWith("bump ")) {
                    if (material != null) {
                        material.textureNormal = line.Substring(5).Trim().Replace('/', '\\');
                    }
                    continue;
                }

                if (line.StartsWith("map_Ks ")) {
                    if (material != null) {
                        material.textureSpecular = line.Substring(7).Trim().Replace('/', '\\');
                    }
                    continue;
                }

                if (line.StartsWith("Ks ")) {
                    if (material != null) {
                        string[] tokens = line.Substring(3).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length == 1) {
                            float.TryParse(tokens[0], out material.specular);
                        }
                        if (tokens.Length == 3) {
                            float r, g, b;
                            if (float.TryParse(tokens[0], out r) &&
                                float.TryParse(tokens[1], out g) &&
                                float.TryParse(tokens[2], out b)) {
                                material.specular = (r + g + b) / 3;
                            }
                        }
                    }
                    continue;
                }

                if (line.StartsWith("Ka ")) {
                    if (material != null) {
                        string[] tokens = line.Substring(3).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tokens.Length == 1) {
                            float.TryParse(tokens[0], out material.ambient);
                        }
                        if (tokens.Length == 3) {
                            float r, g, b;
                            if (float.TryParse(tokens[0], out r) &&
                                float.TryParse(tokens[1], out g) &&
                                float.TryParse(tokens[2], out b)) {
                                material.ambient = (r + g + b) / 3;
                            }
                        }
                    }
                    continue;
                }
            }
            file.Close();
            return materials;
        }

        private Model LoadModel(string filenameObj, Dictionary<string, Material> materials) {
            StreamReader file = null;
            try {
                file = new StreamReader(filenameObj);
            }
            catch (Exception) {
                MessageBox.Show("Could not open OBJ file.",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try {
                Model model = new Model(game);
                List<Vector3> vertexCoords = new List<Vector3>();
                List<Vector3> vertexNormals = new List<Vector3>();
                List<Vector2> vertexTexCoords = new List<Vector2>();
                List<Vector4> vertexColors = new List<Vector4>();

                List<Vertex> vertexList = new List<Vertex>();
                Dictionary<Vertex, int> vertexDict = new Dictionary<Vertex, int>();
                List<Face> faces = new List<Face>();

                int meshID = 0;
                Material material = null;
                lineCounter = 0;

                while (true) {
                    lineCounter++;
                    string line = file.ReadLine();
                    if (line != null) {
                        line = line.TrimStart();
                    }

                    if (line == null || line.StartsWith("usemtl ")) {
                        if (faces.Count > 0) {
                            if (material == null) {
                                throw new Exception(string.Format("No material assigned (line {0}).", lineCounter));
                            }
                            if (material.textureDiffuse == null) {
                                throw new Exception(string.Format("No diffuse texture defined for material \"{0}\".", material.name));
                            }
                            meshID++;
                            string meshName = string.Format("Mesh{0}", meshID);
                            MeshDesc meshDesc = BuildMeshDesc(meshName, material, vertexList, faces);
                            model.AddMeshDesc(meshDesc);
                            vertexList.Clear();
                            vertexDict.Clear();
                            faces.Clear();
                        }
                        if (line == null) {
                            break;
                        }
                        string materialName = line.Substring(7).Trim();
                        material = materials[materialName];
                    }

                    if (line.StartsWith("v ")) {
                        Vector3 coord = ParseVertexCoord(line.Substring(2));
                        vertexCoords.Add(coord);
                        continue;
                    }
                    if (line.StartsWith("vn ")) {
                        Vector3 normal = ParseVertexNormal(line.Substring(3));
                        normal.Normalize();
                        vertexNormals.Add(normal);
                        continue;
                    }
                    if (line.StartsWith("vt ")) {
                        Vector2 texCoord = ParseVertexTexCoord(line.Substring(3));
                        vertexTexCoords.Add(texCoord);
                        continue;
                    }
                    if (line.StartsWith("vc ")) {
                        Vector4 color = ParseVertexColor(line.Substring(3));
                        vertexColors.Add(color);
                        continue;
                    }
                    if (line.StartsWith("f ")) {
                        Face face = ParseFace(line.Substring(2));
                        try {
                            for (int i = 0; i < face.vertexIndices.Length; i++) {
                                Vertex vertex = new Vertex();
                                int index;
                                index = face.coordIndices[i];
                                vertex.coord = index > 0 ? vertexCoords[index - 1] : vertexCoords[vertexCoords.Count + index];
                                index = face.normalIndices[i];
                                vertex.normal = index > 0 ? vertexNormals[index - 1] : vertexNormals[vertexNormals.Count + index];
                                index = face.texCoordIndices[i];
                                vertex.texCoord = index > 0 ? vertexTexCoords[index - 1] : vertexTexCoords[vertexTexCoords.Count + index];
                                if (face.colorIndices != null) {
                                    index = face.colorIndices[i];
                                    vertex.color = index > 0 ? vertexColors[index - 1] : vertexColors[vertexColors.Count + index];
                                }
                                else {
                                    vertex.color = new Vector4(1, 1, 1, 1);
                                }
                                if (!vertexDict.TryGetValue(vertex, out index)) {
                                    index = vertexList.Count;
                                    vertexList.Add(vertex);
                                    vertexDict[vertex] = index;
                                }
                                face.vertexIndices[i] = index;
                            }
                        }
                        catch (Exception) {
                            throw new Exception(string.Format("Invalid face: invalid vertex index (line {0}).", lineCounter));
                        }
                        if (face.vertexIndices.Length == 3) {
                            FlipTriangularFace(face);
                            faces.Add(face);
                        }
                        else {
                            Face[] triFaces = Triangulate(face);
                            FlipTriangularFace(triFaces[0]);
                            FlipTriangularFace(triFaces[1]);
                            faces.Add(triFaces[0]);
                            faces.Add(triFaces[1]);
                        }
                        continue;
                    }
                }

                Armature armature = new Armature(model);
                Armature.Bone bone = new Armature.Bone();
                bone.armature = armature;
                bone.id = 0;
                bone.name = "root";
                bone.absPosition = Vector3.Zero;
                bone.parent = null;
                armature.Bones = new Armature.Bone[] { bone };
                model.Armature = armature;

                file.Close();
                return model;
            }
            catch (Exception ex) {
                MessageBox.Show("Could not load OBJ file.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void FlipTriangularFace(Face face) {
            int tmp;            
            
            tmp = face.vertexIndices[1];
            face.vertexIndices[1] = face.vertexIndices[2];
            face.vertexIndices[2] = tmp;

            tmp = face.normalIndices[1];
            face.normalIndices[1] = face.normalIndices[2];
            face.normalIndices[2] = tmp;
            
            tmp = face.texCoordIndices[1];
            face.texCoordIndices[1] = face.texCoordIndices[2];
            face.texCoordIndices[2] = tmp;

            if (face.colorIndices != null) {
                tmp = face.colorIndices[1];
                face.colorIndices[1] = face.colorIndices[2];
                face.colorIndices[2] = tmp;
            }
        }

        private Vector3 ParseVertexCoord(string line) {
            line = line.Trim();
            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 3) {
                throw new Exception(string.Format("Invalid vertex coordinates (line {0}).", lineCounter));
            }
            float x, y, z;
            try {
                x = float.Parse(tokens[0]);
                y = float.Parse(tokens[1]);
                z = float.Parse(tokens[2]);
            }
            catch (Exception) {
                throw new Exception(string.Format("Invalid vertex coordinates (line {0}).", lineCounter));
            }
            return new Vector3(x, y, z);
        }

        private Vector3 ParseVertexNormal(string line) {
            line = line.Trim();
            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 3) {
                throw new Exception(string.Format("Invalid vertex normal (line {0}).", lineCounter));
            }
            float x, y, z;
            try {
                x = float.Parse(tokens[0]);
                y = float.Parse(tokens[1]);
                z = float.Parse(tokens[2]);
            }
            catch (Exception) {
                throw new Exception(string.Format("Invalid vertex normal (line {0}).", lineCounter));
            }
            return new Vector3(x, y, z);
        }

        private Vector2 ParseVertexTexCoord(string line) {
            line = line.Trim();
            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2) {
                throw new Exception(string.Format("Invalid vertex texture mapping (line {0}).", lineCounter));
            }
            float u, v;
            try {
                u = float.Parse(tokens[0]);
                v = 1 - float.Parse(tokens[1]);
            }
            catch (Exception) {
                throw new Exception(string.Format("Invalid vertex texture mapping (line {0}).", lineCounter));
            }
            return new Vector2(u, v);
        }

        private Vector4 ParseVertexColor(string line) {
            line = line.Trim();
            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 4) {
                throw new Exception(string.Format("Invalid vertex color (line {0}).", lineCounter));
            }
            float r, g, b, a;
            try {
                r = float.Parse(tokens[0]);
                g = float.Parse(tokens[1]);
                b = float.Parse(tokens[2]);
                a = float.Parse(tokens[3]);
            }
            catch (Exception) {
                throw new Exception(string.Format("Invalid vertex color (line {0}).", lineCounter));
            }
            return new Vector4(r, g, b, a);
        }

        private Face ParseFace(string line) {
            line = line.Trim();
            string[] tokens1 = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens1.Length != 3 && tokens1.Length != 4) {
                throw new Exception(string.Format("Face has an unsupported number of vertices(line {0}).", lineCounter));
            }
            Face face = new Face();
            face.coordIndices = new int[tokens1.Length];
            face.texCoordIndices = new int[tokens1.Length];
            face.normalIndices = new int[tokens1.Length];
            face.vertexIndices = new int[tokens1.Length];
            face.colorIndices = null;
            for (int i = 0; i < tokens1.Length; i++) {
                string[] tokens2 = tokens1[i].Split('/');
                string token;

                if (tokens2.Length == 0) {
                    throw new Exception(string.Format("Invalid face: missing coordinate index (line {0}).", lineCounter));
                }
                token = tokens2[0].Trim();
                if (token.Length == 0) {
                    throw new Exception(string.Format("Invalid face: missing coordinate index (line {0}).", lineCounter));
                }
                try {
                    face.coordIndices[i] = int.Parse(token);
                }
                catch (Exception) {
                    throw new Exception(string.Format("Invalid face: invalid coordinate index (line {0}).", lineCounter));
                }

                if (tokens2.Length == 1) {
                    throw new Exception(string.Format("Invalid face: missing texture mapping index (line {0}).", lineCounter));
                }
                token = tokens2[1].Trim();
                if (token.Length == 0) {
                    throw new Exception(string.Format("Invalid face: missing texture mapping index (line {0}).", lineCounter));
                }
                try {
                    face.texCoordIndices[i] = int.Parse(token);
                }
                catch (Exception) {
                    throw new Exception(string.Format("Invalid face: invalid texture mapping index (line {0}).", lineCounter));
                }

                if (tokens2.Length == 2) {
                    throw new Exception(string.Format("Invalid face: missing normal index (line {0}).", lineCounter));
                }
                token = tokens2[2].Trim();
                if (token.Length == 0) {
                    throw new Exception(string.Format("Invalid face: missing normal index (line {0}).", lineCounter));
                }
                try {
                    face.normalIndices[i] = int.Parse(token);
                }
                catch (Exception) {
                    throw new Exception(string.Format("Invalid face: invalid normal index (line {0}).", lineCounter));
                }

                if (tokens2.Length > 3) {
                    if (face.colorIndices == null) {
                        if (i > 0) {
                            throw new Exception(string.Format("Invalid face: missing color index (line {0}).", lineCounter));
                        }
                        face.colorIndices = new int[tokens1.Length];
                    }
                    token = tokens2[3].Trim();
                    try {
                        face.colorIndices[i] = int.Parse(token);
                    }
                    catch (Exception) {
                        throw new Exception(string.Format("Invalid face: invalid color index (line {0}).", lineCounter));
                    }
                }
                else {
                    if (face.colorIndices != null) {
                        throw new Exception(string.Format("Invalid face: missing color index (line {0}).", lineCounter));
                    }
                }
            }
            return face;
        }

        private Face[] Triangulate(Face face) {
            Face face1 = new Face();
            face1.coordIndices = new int[] { 
                face.coordIndices[0], 
                face.coordIndices[1], 
                face.coordIndices[2] };
            face1.texCoordIndices = new int[] { 
                face.texCoordIndices[0], 
                face.texCoordIndices[1], 
                face.texCoordIndices[2] };
            face1.normalIndices = new int[] { 
                face.normalIndices[0], 
                face.normalIndices[1], 
                face.normalIndices[2] };
            if (face1.colorIndices != null) {
                face1.colorIndices = new int[] { 
                    face.colorIndices[0], 
                    face.colorIndices[1], 
                    face.colorIndices[2] };
            }
            face1.vertexIndices = new int[] { 
                face.vertexIndices[0], 
                face.vertexIndices[1], 
                face.vertexIndices[2] };

            Face face2 = new Face();
            face2.coordIndices = new int[] { 
                face.coordIndices[0], 
                face.coordIndices[2], 
                face.coordIndices[3] };
            face2.texCoordIndices = new int[] { 
                face.texCoordIndices[0], 
                face.texCoordIndices[2], 
                face.texCoordIndices[3] };
            face2.normalIndices = new int[] { 
                face.normalIndices[0], 
                face.normalIndices[2], 
                face.normalIndices[3] };
            if (face2.colorIndices != null) {
                face2.colorIndices = new int[] { 
                    face.colorIndices[0], 
                    face.colorIndices[2], 
                    face.colorIndices[3] };
            }
            face2.vertexIndices = new int[] { 
                face.vertexIndices[0], 
                face.vertexIndices[2], 
                face.vertexIndices[3] };

            return new Face[] { face1, face2 };
        }

        private MeshDesc BuildMeshDesc(string name, Material material, List<Vertex> vertices, List<Face> faces) {
            MeshDesc meshDesc = new MeshDesc();
            meshDesc.name = name;
            meshDesc.vertices = new MeshDesc.Vertex[vertices.Count];
            for (int i = 0; i < vertices.Count; i++) {
                MeshDesc.Vertex v = new MeshDesc.Vertex();
                v.position = vertices[i].coord;
                v.normal = vertices[i].normal;
                v.texCoords = new Vector2[] { vertices[i].texCoord };
                v.color = vertices[i].color;
                v.boneIndicesGlobal = new short[] { 0, 0, 0, 0 };
                v.boneIndicesLocal = new short[] { 0, 0, 0, 0 };
                v.boneWeights = new float[] { 1, 0, 0, 0 };
                meshDesc.vertices[i] = v;
            }
            meshDesc.indices = new ushort[faces.Count * 3];
            int j = 0;
            for (int i = 0; i < faces.Count; i++) {
                meshDesc.indices[j + 0] = (ushort)faces[i].vertexIndices[0];
                meshDesc.indices[j + 1] = (ushort)faces[i].vertexIndices[1];
                meshDesc.indices[j + 2] = (ushort)faces[i].vertexIndices[2];
                j += 3;
            }
            meshDesc.boneIndexMap = new short[] { 0 };
            meshDesc.uvLayerCount = 1;
            CalculateTangents(meshDesc);

            MeshDesc.Texture textureDiffuse = new MeshDesc.Texture();
            textureDiffuse.filename = material.textureDiffuse;
            textureDiffuse.uvLayerIndex = 0;

            MeshDesc.Texture textureLightmap = null;

            MeshDesc.Texture textureNormal = null;
            if (material.textureNormal != null) {
                textureNormal = new MeshDesc.Texture();
                textureNormal.filename = material.textureNormal;
                textureNormal.uvLayerIndex = 0;
            }

            MeshDesc.Texture textureSpecular = null;
            if (material.textureSpecular != null) {
                textureSpecular = new MeshDesc.Texture();
                textureSpecular.filename = material.textureSpecular;
                textureSpecular.uvLayerIndex = 0;
            }

            meshDesc.textures = new MeshDesc.Texture[] { textureDiffuse, textureLightmap, textureNormal, textureSpecular };
            meshDesc.renderParams = new object[] { material.specular };
            meshDesc.isShadeless = material.ambient > 0.99f;
            return meshDesc;
        }

        private void CalculateTangents(MeshDesc meshDesc) {
            Vector3[,] tangentsU = new Vector3[meshDesc.vertices.Length, meshDesc.uvLayerCount];
            Vector3[,] tangentsV = new Vector3[meshDesc.vertices.Length, meshDesc.uvLayerCount];
            for (int vertexID = 0; vertexID < meshDesc.vertices.Length; vertexID++) {
                MeshDesc.Vertex vertex = meshDesc.vertices[vertexID];
                vertex.tangents = new Vector4[meshDesc.uvLayerCount];
                for (int uvLayerID = 0; uvLayerID < meshDesc.uvLayerCount; uvLayerID++) {
                    tangentsU[vertexID, uvLayerID] = Vector3.Zero;
                    tangentsV[vertexID, uvLayerID] = Vector3.Zero;
                }
            }
            for (int uvLayerID = 0; uvLayerID < meshDesc.uvLayerCount; uvLayerID++) {
                for (int i = 0; i < meshDesc.indices.Length; i += 3) {
                    int vertexID0 = meshDesc.indices[i + 0];
                    int vertexID1 = meshDesc.indices[i + 1];
                    int vertexID2 = meshDesc.indices[i + 2];
                    MeshDesc.Vertex v0 = meshDesc.vertices[vertexID0];
                    MeshDesc.Vertex v1 = meshDesc.vertices[vertexID1];
                    MeshDesc.Vertex v2 = meshDesc.vertices[vertexID2];
                    Vector3 p0 = v0.position;
                    Vector3 p1 = v1.position;
                    Vector3 p2 = v2.position;
                    Vector3 q1 = new Vector3(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
                    Vector3 q2 = new Vector3(p2.X - p0.X, p2.Y - p0.Y, p2.Z - p0.Z);
                    float s1 = v1.texCoords[uvLayerID].X - v0.texCoords[uvLayerID].X;
                    float t1 = v1.texCoords[uvLayerID].Y - v0.texCoords[uvLayerID].Y;
                    float s2 = v2.texCoords[uvLayerID].X - v0.texCoords[uvLayerID].X;
                    float t2 = v2.texCoords[uvLayerID].Y - v0.texCoords[uvLayerID].Y;
                    float d = s1 * t2 - s2 * t1;
                    if (d == 0) {
                        continue;
                    }
                    float k = 1 / d;
                    Vector3 faceTangentU = new Vector3(
                        (t2 * q1.X - t1 * q2.X) * k,
                        (t2 * q1.Y - t1 * q2.Y) * k,
                        (t2 * q1.Z - t1 * q2.Z) * k);
                    Vector3 faceTangentV = new Vector3(
                        (s1 * q2.X - s2 * q1.X) * k,
                        (s1 * q2.Y - s2 * q1.Y) * k,
                        (s1 * q2.Z - s2 * q1.Z) * k);
                    if (faceTangentU.Length() > 0) {
                        faceTangentU.Normalize();
                    }
                    if (faceTangentV.Length() > 0) {
                        faceTangentV.Normalize();
                    }
                    tangentsU[vertexID0, uvLayerID] += faceTangentU;
                    tangentsU[vertexID1, uvLayerID] += faceTangentU;
                    tangentsU[vertexID2, uvLayerID] += faceTangentU;
                    tangentsV[vertexID0, uvLayerID] += faceTangentV;
                    tangentsV[vertexID1, uvLayerID] += faceTangentV;
                    tangentsV[vertexID2, uvLayerID] += faceTangentV;
                }
            }
            for (int vertexID = 0; vertexID < meshDesc.vertices.Length; vertexID++) {
                MeshDesc.Vertex vertex = meshDesc.vertices[vertexID];
                vertex.tangents = new Vector4[meshDesc.uvLayerCount];
                Vector3 normal = vertex.normal;
                for (int uvLayerID = 0; uvLayerID < meshDesc.uvLayerCount; uvLayerID++) {
                    Vector3 tangentU = tangentsU[vertexID, uvLayerID];
                    Vector3 tangentV = tangentsV[vertexID, uvLayerID];
                    if (tangentU.Length() > 0) {
                        tangentU.Normalize();
                    }
                    if (tangentV.Length() > 0) {
                        tangentV.Normalize();
                    }
                    Vector3 tangent = tangentU - normal * (normal * tangentU);
                    if (tangent.Length() > 0) {
                        tangent.Normalize();
                    }
                    float w = Vector3.Dot(Vector3.Cross(normal, tangentU), tangentV) > 0 ? 1 : -1;
                    vertex.tangents[uvLayerID] =
                        new Vector4(tangent.X, tangent.Y, tangent.Z, w);
                }
            }
        }

        private class Material
        {
            public string name;
            public string textureDiffuse;
            public string textureNormal;
            public string textureSpecular;
            public float specular = 0.2f;
            public float ambient = 0.0f;
        }

        private class Face
        {
            public int[] coordIndices;
            public int[] normalIndices;
            public int[] texCoordIndices;
            public int[] colorIndices;

            public int[] vertexIndices;
        }

        private class Vertex
        {
            public Vector3 coord;
            public Vector3 normal;
            public Vector2 texCoord;
            public Vector4 color;

            public override bool Equals(object obj) {
                Vertex v = (Vertex)obj;
                return
                    coord == v.coord &&
                    normal == v.normal &&
                    texCoord == v.texCoord &&
                    color == v.color;
            }

            public override int GetHashCode() {
                return
                    coord.GetHashCode() +
                    normal.GetHashCode() * 71 +
                    texCoord.GetHashCode() * 71 * 71 +
                    color.GetHashCode() * 71 * 71 * 71;
            }
        }
    }
}
