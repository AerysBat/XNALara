using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VertexPosTex = Microsoft.Xna.Framework.Graphics.VertexPositionTexture;

namespace XNALara
{
    public class Billboard
    {
        private GraphicsDevice graphicsDevice;

        private VertexDeclaration vertexDeclaration;
        private VertexPosTex[] vertices;
        private short[] indices;

        public Billboard(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
            vertexDeclaration = new VertexDeclaration(graphicsDevice, VertexPosTex.VertexElements);
            vertices = new VertexPosTex[] {
                new VertexPosTex(Vector3.Zero, new Vector2(0, 0)),
                new VertexPosTex(Vector3.Zero, new Vector2(1, 0)),
                new VertexPosTex(Vector3.Zero, new Vector2(1, 1)),
                new VertexPosTex(Vector3.Zero, new Vector2(0, 1))
            };
            indices = new short[] {
                0, 1, 3,
                3, 1, 2
            };
        }

        public void Render() {
            graphicsDevice.VertexDeclaration = vertexDeclaration;
            graphicsDevice.DrawUserIndexedPrimitives<VertexPosTex>(
                PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, 2);
        }
    }
}
