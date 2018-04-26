using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class VertexPositionNormalTexture2 : VertexFormat
    {
        private struct VertexData
        {
            public Vector3 position;
            public Vector3 normal;
            public Vector2 texCoords1;
            public Vector2 texCoords2;
        }

        private static VertexElement[] vertexElements = new VertexElement[] {
            new VertexElement(0, 0 * sizeof(float), VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position, 0),
            new VertexElement(0, 3 * sizeof(float), VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Normal, 0),
            new VertexElement(0, 6 * sizeof(float), VertexElementFormat.Vector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(0, 8 * sizeof(float), VertexElementFormat.Vector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 1),
        };

        public override VertexElement[] VertexElements {
            get { return vertexElements; }
        }

        public override int SizeInBytes {
            get { return 10 * sizeof(float); }
        }

        public override VertexBuffer BuildVertexBuffer(GraphicsDevice graphicsDevice, MeshDesc meshDesc) {
            VertexBuffer vertexBuffer = new VertexBuffer(graphicsDevice, meshDesc.vertices.Length * SizeInBytes, BufferUsage.WriteOnly);
            VertexData[] vertexData = new VertexData[meshDesc.vertices.Length];
            for (int i = 0; i < vertexData.Length; i++) {
                vertexData[i].position = meshDesc.vertices[i].position;
                vertexData[i].normal = meshDesc.vertices[i].normal;
                vertexData[i].texCoords1 = meshDesc.vertices[i].texCoords[0];
                if (meshDesc.vertices[i].texCoords.Length > 1) {
                    vertexData[i].texCoords2 = meshDesc.vertices[i].texCoords[1];
                }
            }
            vertexBuffer.SetData(vertexData);
            return vertexBuffer;
        }
    }
}
