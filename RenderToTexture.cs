using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class RenderToTexture
    {
        private GraphicsDevice graphicsDevice;

        private RenderTarget2D renderTarget;
        private DepthStencilBuffer depthBuffer;
        private DepthStencilBuffer savedDepthBuffer;
        private int renderTargetWidth;
        private int renderTargetHeight;

        public RenderToTexture(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
            renderTarget = null;
        }

        public void Begin() {
            PresentationParameters parameters = graphicsDevice.PresentationParameters;
            Begin(parameters.BackBufferWidth, parameters.BackBufferHeight);
        }

        public void Begin(int backBufferWidth, int backBufferHeight) {
            Begin(backBufferWidth, backBufferHeight, graphicsDevice.DisplayMode.Format, 
                graphicsDevice.PresentationParameters.MultiSampleType);
        }

        public void Begin(int backBufferWidth, int backBufferHeight, SurfaceFormat bufferFormat) {
            Begin(backBufferWidth, backBufferHeight, bufferFormat,
                graphicsDevice.PresentationParameters.MultiSampleType);
        }

        public void Begin(int backBufferWidth, int backBufferHeight, MultiSampleType multiSampleType) {
            Begin(backBufferWidth, backBufferHeight, graphicsDevice.DisplayMode.Format, multiSampleType);
        }

        public void Begin(int backBufferWidth, int backBufferHeight, SurfaceFormat bufferFormat, MultiSampleType multiSampleType) {
            if (renderTarget == null ||
                renderTargetWidth != backBufferWidth ||
                renderTargetHeight != backBufferHeight) {
                if (renderTarget != null) {
                    renderTarget.Dispose();
                    depthBuffer.Dispose();
                }
                renderTarget =
                    new RenderTarget2D(graphicsDevice,
                                       backBufferWidth, backBufferHeight,
                                       1, bufferFormat,
                                       multiSampleType, 0);
                depthBuffer =
                    new DepthStencilBuffer(graphicsDevice,
                                           backBufferWidth, backBufferHeight,
                                           graphicsDevice.DepthStencilBuffer.Format,
                                           multiSampleType, 0);
                renderTargetWidth = backBufferWidth;
                renderTargetHeight = backBufferHeight;
            }
            graphicsDevice.SetRenderTarget(0, renderTarget);
            savedDepthBuffer = graphicsDevice.DepthStencilBuffer;
            graphicsDevice.DepthStencilBuffer = depthBuffer;
        }

        public Texture2D End() {
            return End(false);
        }

        public Texture2D End(bool dispose) {
            graphicsDevice.SetRenderTarget(0, null);
            graphicsDevice.DepthStencilBuffer = savedDepthBuffer;
            Texture2D texture = renderTarget.GetTexture();
            if (dispose) {
                renderTarget.Dispose();
                renderTarget = null;
            }
            return texture;
        }
    }
}
