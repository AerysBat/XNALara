using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class FullScreenSprite
    {
        private GraphicsDevice graphicsDevice;
        private VertexDeclaration vertexDeclaration;

        private int bufferWidth;
        private int bufferHeight;

        private Microsoft.Xna.Framework.Graphics.VertexPositionTexture[] vertices;
        private short[] indices;


        public FullScreenSprite(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
            vertexDeclaration = new VertexDeclaration(graphicsDevice, Microsoft.Xna.Framework.Graphics.VertexPositionTexture.VertexElements);

            bufferWidth = -1;
            bufferHeight = -1;

            indices = new short[] {
                0, 1, 3,
                3, 1, 2
            };
        }

        public void Render(int bufferWidth, int bufferHeight) {
            if (bufferWidth != this.bufferWidth || 
                bufferHeight != this.bufferHeight) {
                this.bufferWidth = bufferWidth;
                this.bufferHeight = bufferHeight;
                float x1 = -1;
                float y1 = -1;
                float x2 = +1;
                float y2 = +1;
                if (bufferWidth != 0) {
                    x1 -= 1f / bufferWidth;
                    x2 -= 1f / bufferWidth;
                }
                if (bufferHeight != 0) {
                    y1 += 1f / bufferHeight;
                    y2 += 1f / bufferHeight;
                }
                vertices = new Microsoft.Xna.Framework.Graphics.VertexPositionTexture[] {
                    new Microsoft.Xna.Framework.Graphics.VertexPositionTexture(new Vector3(x1, y2, 0), new Vector2(0, 0)),
                    new Microsoft.Xna.Framework.Graphics.VertexPositionTexture(new Vector3(x2, y2, 0), new Vector2(1, 0)),
                    new Microsoft.Xna.Framework.Graphics.VertexPositionTexture(new Vector3(x2, y1, 0), new Vector2(1, 1)),
                    new Microsoft.Xna.Framework.Graphics.VertexPositionTexture(new Vector3(x1, y1, 0), new Vector2(0, 1))
                };
            }
            
            graphicsDevice.VertexDeclaration = vertexDeclaration;
            graphicsDevice.DrawUserIndexedPrimitives<Microsoft.Xna.Framework.Graphics.VertexPositionTexture>(
                PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, 2);
        }
    }
}
