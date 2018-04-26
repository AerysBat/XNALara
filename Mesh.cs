using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class Mesh
    {
        private GraphicsDevice graphicsDevice;
        private TextureManager textureManager;
        private MeshDesc meshDesc;
        private VertexFormat vertexFormat;

        private string name;
        private bool isVisible;
        private VertexBuffer vertexBuffer;
        private IndexBuffer indexBuffer;
        private VertexDeclaration vertexDeclaration;
        private int vertexCount;
        private int faceCount;
        private int vertexDataSize;
        private Texture2D[] textures;
        private short[] boneIndexMap;
        
        private object[] renderParams;
        private bool isTransparentVertices;
        private bool isTransparentTextures;
        private bool isShadeless;

        private BoundingBox boundingBox;


        public Mesh(GraphicsDevice graphicsDevice, TextureManager textureManager, 
                    MeshDesc meshDesc, VertexFormat vertexFormat) {
            this.graphicsDevice = graphicsDevice;
            this.textureManager = textureManager;
            this.meshDesc = meshDesc;
            this.vertexFormat = vertexFormat;

            this.name = meshDesc.name;
            vertexBuffer = vertexFormat.BuildVertexBuffer(graphicsDevice, meshDesc);
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(ushort), meshDesc.indices.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(meshDesc.indices);
            vertexDeclaration = new VertexDeclaration(graphicsDevice, vertexFormat.VertexElements);
            vertexCount = meshDesc.vertices.Length;
            faceCount = meshDesc.indices.Length / 3;
            vertexDataSize = vertexFormat.SizeInBytes;

            int textureCount = meshDesc.textures.Length;
            textures = new Texture2D[textureCount];
            for (int i = 0; i < textureCount; i++) {
                string textureFilename = meshDesc.textures[i].filename;
                Texture2D texture = textureManager.GetTexture(textureFilename, meshDesc.textures[i].useMipmaps);
                if (texture == null) {
                    Console.WriteLine("Texture \"{0}\" not found!", textureFilename);
                }
                textures[i] = texture;
            }

            isTransparentVertices = false;
            foreach (MeshDesc.Vertex vertex in meshDesc.vertices) {
                if (vertex.color.W < 1.0) {
                    isTransparentVertices = true;
                    break;
                }
            }

            isTransparentTextures = false;
            foreach (Texture2D texture in textures) {
                if (textureManager.IsTransparent(texture)) {
                    isTransparentTextures = true;
                    break;
                }
            }

            boneIndexMap = meshDesc.boneIndexMap;
            if (meshDesc.renderParams != null) {
                renderParams = meshDesc.renderParams;
            }
            isShadeless = meshDesc.isShadeless;
            isVisible = true;
            boundingBox = CalculateBoundingBox(meshDesc);
        }

        public GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }

        public TextureManager TextureManager {
            get { return textureManager; }
        }

        public MeshDesc MeshDesc {
            get { return meshDesc; }
        }

        public VertexFormat VertexFormat {
            get { return vertexFormat; }
        }

        public string Name {
            get { return name; }
        }

        public bool IsVisible {
            set { isVisible = value; }
            get { return isVisible; }
        }

        public BoundingBox BoundingBox {
            get { return boundingBox; }
        }

        public short[] BoneIndexMap {
            get { return boneIndexMap; }
        }

        public Texture2D[] Textures {
            get { return textures; }
        }

        public object[] RenderParams {
            set { renderParams = value; }
            get { return renderParams; }
        }

        public bool IsTransparent {
            get { return isTransparentVertices || isTransparentTextures; }
        }

        public bool IsShadeless {
            get { return isShadeless; }
        }

        public void Render() {
            if (!isVisible || faceCount <= 0) {
                return;
            }
            graphicsDevice.Vertices[0].SetSource(vertexBuffer, 0, vertexDataSize);
            graphicsDevice.Indices = indexBuffer;
            graphicsDevice.VertexDeclaration = vertexDeclaration;
            graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertexCount, 0, faceCount);
        }

        public void RenderSinglePass(Effect effect, params string[] textureParams) {
            if (!isVisible) {
                return;
            }
            for (int i = 0; i < textureParams.Length; i++) {
                effect.Parameters[textureParams[i]].SetValue(textures[i]);
            }
            effect.Begin();
            EffectPass pass = effect.CurrentTechnique.Passes[0];
            pass.Begin();
            Render();
            pass.End();
            effect.End();
        }

        private BoundingBox CalculateBoundingBox(MeshDesc meshDesc) {
            float xMin = float.PositiveInfinity;
            float yMin = float.PositiveInfinity;
            float zMin = float.PositiveInfinity;
            float xMax = float.NegativeInfinity;
            float yMax = float.NegativeInfinity;
            float zMax = float.NegativeInfinity;
            foreach (MeshDesc.Vertex vertex in meshDesc.vertices) {
                Vector3 v = vertex.position;
                if (v.X < xMin) {
                    xMin = v.X;
                }
                if (v.Y < yMin) {
                    yMin = v.Y;
                }
                if (v.Z < zMin) {
                    zMin = v.Z;
                }
                if (v.X > xMax) {
                    xMax = v.X;
                }
                if (v.Y > yMax) {
                    yMax = v.Y;
                }
                if (v.Z > zMax) {
                    zMax = v.Z;
                }
            }
            Vector3 min = new Vector3(xMin, yMin, zMin);
            Vector3 max = new Vector3(xMax, yMax, zMax);
            return new BoundingBox(min, max);
        }
    }
}
