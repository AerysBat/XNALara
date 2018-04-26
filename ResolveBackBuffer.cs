using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class ResolveBackBuffer
    {
        private GraphicsDevice graphicsDevice;

        private ResolveTexture2D resolveTexture;
        private int resolveTextureWidth;
        private int resolveTextureHeight;

        public ResolveBackBuffer(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
            resolveTexture = null;
        }

        public ResolveTexture2D GetTexture() {
            PresentationParameters parameters = graphicsDevice.PresentationParameters;
            if (resolveTexture == null ||
                resolveTextureWidth != parameters.BackBufferWidth ||
                resolveTextureHeight != parameters.BackBufferHeight) {
                if (resolveTexture != null) {
                    resolveTexture.Dispose();
                }
                resolveTexture =
                    new ResolveTexture2D(graphicsDevice,
                                         parameters.BackBufferWidth,
                                         parameters.BackBufferHeight, 1,
                                         parameters.BackBufferFormat);
                resolveTextureWidth = parameters.BackBufferWidth;
                resolveTextureHeight = parameters.BackBufferHeight;
            }
            graphicsDevice.ResolveBackBuffer(resolveTexture);
            return resolveTexture;
        }
    }
}
