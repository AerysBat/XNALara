using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    class TextureCombiner
    {
        public static Bitmap CombineTextures(Texture2D textureColor, Texture2D textureAlpha) {
            int width = textureColor.Width;
            int height = textureColor.Height;
            if (width != textureAlpha.Width || height != textureAlpha.Height) {
                return null;
            }
            Microsoft.Xna.Framework.Graphics.Color[] dataColor = new Microsoft.Xna.Framework.Graphics.Color[width * height];
            Microsoft.Xna.Framework.Graphics.Color[] dataAlpha = new Microsoft.Xna.Framework.Graphics.Color[width * height];
            textureColor.GetData<Microsoft.Xna.Framework.Graphics.Color>(dataColor);
            textureAlpha.GetData<Microsoft.Xna.Framework.Graphics.Color>(dataAlpha);

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe {
                byte* ptr = (byte*)bitmapData.Scan0.ToPointer();
                int offsetSrc = 0;
                int offsetDestY = 0;
                for (int y = 0; y < height; y++) {
                    int offsetDest = offsetDestY;
                    for (int x = 0; x < width; x++) {
                        Microsoft.Xna.Framework.Graphics.Color color = dataColor[offsetSrc];
                        Microsoft.Xna.Framework.Graphics.Color alpha = dataAlpha[offsetSrc];
                        ptr[offsetDest + 0] = color.B;
                        ptr[offsetDest + 1] = color.G;
                        ptr[offsetDest + 2] = color.R;
                        ptr[offsetDest + 3] = alpha.R;
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
