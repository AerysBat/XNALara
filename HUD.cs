using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class HUD
    {
        private const double MessageDisplayInterval = 2000.0; // [ms]

        private SpriteBatch spriteBatch;
        private SpriteFont font;

        private double currentTime;

        private string message;
        private double messageDisplayedSince;

        public HUD(Game game) {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            font = game.Content.Load<SpriteFont>("HUDFont");
        }

        public string Message {
            set {
                message = value;
                messageDisplayedSince = message != null ? currentTime : -1;
            }
        }

        public void Update(GameTime gameTime) {
            currentTime = gameTime.TotalGameTime.TotalMilliseconds;

            if (messageDisplayedSince >= 0 && 
                currentTime - messageDisplayedSince > MessageDisplayInterval) {
                Message = null;
            }
        }

        public void Render() {
            if (message != null) {
                spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.SaveState);
                int x = 10;
                int y = 10;
                spriteBatch.DrawString(font, message, new Vector2(x + 1, y + 1), Color.Black);
                spriteBatch.DrawString(font, message, new Vector2(x, y), Color.Yellow);
                spriteBatch.End();
            }
        }
    }
}
