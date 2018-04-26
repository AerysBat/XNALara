using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public abstract class VertexFormat
    {
        public abstract VertexElement[] VertexElements {
            get;
        }

        public abstract int SizeInBytes {
            get;
        }

        public abstract VertexBuffer BuildVertexBuffer(GraphicsDevice graphicsDevice, MeshDesc mesh);
    }
}
