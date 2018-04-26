using System;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    class MosaicRenderer
    {
        private const int TileSize = 256;

        private Game game;
        private Renderer renderer;
        private CameraTurnTable camera;

        private RenderToTexture renderToTexture;


        public MosaicRenderer(Game game) {
            this.game = game;
            renderer = game.Renderer;
            camera = renderer.Camera;
            renderToTexture = new RenderToTexture(renderer.GraphicsDevice);
        }

        public Bitmap Render(int imageWidth, int imageHeight, bool saveAlpha) {
            int tileCountX = ((imageWidth + TileSize - 1) / TileSize);
            int tileCountY = ((imageHeight + TileSize - 1) / TileSize);
            int mosaicWidth = tileCountX * TileSize;
            int mosaicHeight = tileCountY * TileSize;
            double planeWidth = 2 * camera.NearPlane * Math.Tan(camera.FieldOfViewHorizontal / 2);
            double planeHeight = 2 * camera.NearPlane * Math.Tan(camera.FieldOfViewVertical / 2);
            double planeWidthExt = (planeWidth * mosaicWidth) / imageWidth;
            double planeHeightExt = (planeHeight * mosaicHeight) / imageHeight;

            float fov = camera.FieldOfViewHorizontal;

            Bitmap mosaic = new Bitmap(mosaicWidth, mosaicHeight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(mosaic);

            bool renderBackgroundImage = !saveAlpha && game.BackgroundImage != null;

            float backgroundScaleX = 0;
            float backgroundScaleY = 0;
            if (renderBackgroundImage) {
                backgroundScaleX = game.BackgroundImage.ScaleX * imageWidth / (float)TileSize;
                backgroundScaleY = game.BackgroundImage.ScaleY * imageHeight / (float)TileSize;
            }

            double tileWidth = planeWidthExt / tileCountX;
            double tileHeight = planeHeightExt / tileCountY;
            for (int j = 0; j < tileCountY; j++) {
                for (int i = 0; i < tileCountX; i++) {
                    double left = -planeWidth / 2 + i * tileWidth;
                    double top = planeHeight / 2 - j * tileHeight;
                    double right = left + tileWidth;
                    double bottom = top - tileHeight;
                    Matrix projection = Matrix.CreatePerspectiveOffCenter(
                        (float)left, (float)right, (float)bottom, (float)top,
                        camera.NearPlane, camera.FarPlane);
                    camera.ProjectionMatrix = projection;

                    renderToTexture.Begin(TileSize, TileSize, SurfaceFormat.Bgr32);

                    game.GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, game.BackgroundColor, 1.0f, 0);

                    if (renderBackgroundImage) {
                        float backgroundOffsetX = (imageWidth - 2 * i * TileSize + 1) / (float)TileSize - 1;
                        float backgroundOffsetY = (2 * j * TileSize - imageHeight - 1) / (float)TileSize + 1;
                        renderer.RenderBackgroundImage(TileSize, TileSize,
                                                       backgroundOffsetX, backgroundOffsetY,
                                                       backgroundScaleX, backgroundScaleY);
                    }

                    if (saveAlpha) { // alpha prepass
                        game.GraphicsDevice.Clear(ClearOptions.DepthBuffer, Microsoft.Xna.Framework.Graphics.Color.Black, 1.0f, 0);
                        renderer.RenderSceneFull(true);
                        game.GraphicsDevice.Clear(ClearOptions.DepthBuffer, Microsoft.Xna.Framework.Graphics.Color.Black, 1.0f, 0);
                    }

                    renderer.RenderSceneFull(false);

                    Texture2D textureColor = renderToTexture.End(true);

                    if (game.IsPostProcessingActive) {
                        renderToTexture.Begin(TileSize, TileSize, SurfaceFormat.Bgr32);
                        game.GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, 
                            Microsoft.Xna.Framework.Graphics.Color.Black, 1.0f, 0);
                        renderer.ApplyPostProcessing(textureColor);
                        textureColor.Dispose();
                        textureColor = renderToTexture.End(true);
                    }

                    Bitmap tile;
                    if (!saveAlpha) {
                        tile = Texture2DToBitmap(textureColor);
                        textureColor.Dispose();
                    }
                    else {
                        renderToTexture.Begin(TileSize, TileSize, SurfaceFormat.Bgr32);
                        game.GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, 
                                                  Microsoft.Xna.Framework.Graphics.Color.Black, 1.0f, 0);
                        renderer.RenderSceneAlpha();
                        Texture2D textureAlpha = renderToTexture.End(true);

                        tile = TextureCombiner.CombineTextures(textureColor, textureAlpha);
                        textureColor.Dispose();
                        textureAlpha.Dispose();
                    }

                    graphics.DrawImageUnscaled(tile, i * TileSize, j * TileSize, TileSize, TileSize);
                    tile.Dispose();
                }
            }
            graphics.Dispose();

            camera.FieldOfViewHorizontal = fov;
            
            Bitmap cropped = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(cropped);
            graphics.DrawImageUnscaled(mosaic, 0, 0, mosaicWidth, mosaicHeight);
            graphics.Dispose();
            mosaic.Dispose();
            return cropped;
        }

        private Bitmap Texture2DToBitmap(Texture2D texture) {
            int width = texture.Width;
            int height = texture.Height;
            Microsoft.Xna.Framework.Graphics.Color[] data = new Microsoft.Xna.Framework.Graphics.Color[width * height];
            texture.GetData<Microsoft.Xna.Framework.Graphics.Color>(data);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe {
                byte* ptr = (byte*)bitmapData.Scan0.ToPointer();
                int offsetSrc = 0;
                int offsetDestY = 0;
                for (int y = 0; y < height; y++) {
                    int offsetDest = offsetDestY;
                    for (int x = 0; x < width; x++) {
                        Microsoft.Xna.Framework.Graphics.Color color = data[offsetSrc];
                        ptr[offsetDest + 0] = color.B;
                        ptr[offsetDest + 1] = color.G;
                        ptr[offsetDest + 2] = color.R;
                        ptr[offsetDest + 3] = 255;
                        offsetSrc++;
                        offsetDest += 4;
                    }
                    offsetDestY += bitmapData.Stride;
                }
            }
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
    }
}
