using Microsoft.Xna.Framework;

namespace XNALara
{
    public class MeshDesc
    {
        public string name;
        public int uvLayerCount;
        public Texture[] textures;
        public Vertex[] vertices;
        public ushort[] indices;
        public short[] boneIndexMap;
        
        public object[] renderParams;
        public bool isShadeless;


        public class Texture
        {
            public string filename;
            public int uvLayerIndex;
            public bool useMipmaps = true;
        }

        public class Vertex
        {
            public Vector3 position;
            public Vector3 normal;
            public Vector4 color;
            public Vector2[] texCoords;
            public Vector4[] tangents;
            public short[] boneIndicesGlobal;
            public short[] boneIndicesLocal;
            public float[] boneWeights;
        }
    }
}
