using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class BackgroundImage
    {
        private Texture2D texture;
        private float scaleX;
        private float scaleY;

        public BackgroundImage(Texture2D texture) {
            this.texture = texture;
        }

        public Texture2D Texture {
            get { return texture; }
        }

        public float ScaleX {
            get { return scaleX; }
        }

        public float ScaleY {
            get { return scaleY; }
        }

        public void HandleWindowResized(int width, int height) {
            float aspect = texture.Width / (float)texture.Height;
            float w = width;
            float h = w / aspect;
            if (h > height) {
                h = height;
                w = height * aspect;
            }
            scaleX = w / width;
            scaleY = h / height;
        }
    }
}
