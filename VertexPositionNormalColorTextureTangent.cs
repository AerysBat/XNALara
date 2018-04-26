using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class VertexPositionNormalColorTextureTangent : VertexFormat
    {
        private struct VertexData
        {
            public Vector3 position;
            public Vector3 normal;
            public Vector4 color;
            public Vector2 texCoords;
            public Vector4 tangent;
        }

        private static VertexElement[] vertexElements = new VertexElement[] {
            new VertexElement(0, 0 * sizeof(float), VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position, 0),
            new VertexElement(0, 3 * sizeof(float), VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Normal, 0),
            new VertexElement(0, 6 * sizeof(float), VertexElementFormat.Vector4, VertexElementMethod.Default, VertexElementUsage.Color, 0),
            new VertexElement(0, 10 * sizeof(float), VertexElementFormat.Vector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(0, 12 * sizeof(float), VertexElementFormat.Vector4, VertexElementMethod.Default, VertexElementUsage.Tangent, 0),
        };

        public override VertexElement[] VertexElements {
            get { return vertexElements; }
        }

        public override int SizeInBytes {
            get { return 16 * sizeof(float); }
        }

        public override VertexBuffer BuildVertexBuffer(GraphicsDevice graphicsDevice, MeshDesc meshDesc) {
            VertexBuffer vertexBuffer = new VertexBuffer(graphicsDevice, meshDesc.vertices.Length * SizeInBytes, BufferUsage.WriteOnly);
            VertexData[] vertexData = new VertexData[meshDesc.vertices.Length];
            for (int i = 0; i < vertexData.Length; i++) {
                vertexData[i].position = meshDesc.vertices[i].position;
                vertexData[i].normal = meshDesc.vertices[i].normal;
                vertexData[i].color = meshDesc.vertices[i].color;
                vertexData[i].texCoords = meshDesc.vertices[i].texCoords[0];
                vertexData[i].tangent = meshDesc.vertices[i].tangents[0];
            }
            vertexBuffer.SetData(vertexData);
            return vertexBuffer;
        }
    }
}
