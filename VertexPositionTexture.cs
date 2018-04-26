using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class VertexPositionTexture : VertexFormat
    {
        private struct VertexData
        {
            public Vector3 position;
            public Vector2 texCoords;
        }

        private static VertexElement[] vertexElements = new VertexElement[] {
            new VertexElement(0, 0 * sizeof(float), VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position, 0),
            new VertexElement(0, 3 * sizeof(float), VertexElementFormat.Vector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 0),
        };

        public override VertexElement[] VertexElements {
            get { return vertexElements; }
        }

        public override int SizeInBytes {
            get { return 5 * sizeof(float); }
        }

        public override VertexBuffer BuildVertexBuffer(GraphicsDevice graphicsDevice, MeshDesc meshDesc) {
            VertexBuffer vertexBuffer = new VertexBuffer(graphicsDevice, meshDesc.vertices.Length * SizeInBytes, BufferUsage.WriteOnly);
            VertexData[] vertexData = new VertexData[meshDesc.vertices.Length];
            for (int i = 0; i < vertexData.Length; i++) {
                vertexData[i].position = meshDesc.vertices[i].position;
                vertexData[i].texCoords = meshDesc.vertices[i].texCoords[0];
            }
            vertexBuffer.SetData(vertexData);
            return vertexBuffer;
        }
    }
}
