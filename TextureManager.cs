using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class TextureManager
    {
        private static TextureCreationParameters textureCreationParamsMipmaps = 
                            new TextureCreationParameters(0, 0, 0, 1,
                                    SurfaceFormat.Rgba32,
                                    TextureUsage.AutoGenerateMipMap,
                                    Color.White,
                                    FilterOptions.None,
                                    FilterOptions.None);

        private static TextureCreationParameters textureCreationParamsNoMipmaps =
                            new TextureCreationParameters(0, 0, 0, 1,
                                    SurfaceFormat.Rgba32,
                                    TextureUsage.None,
                                    Color.White,
                                    FilterOptions.None,
                                    FilterOptions.None);

        private Game game;
        private GraphicsDevice graphicsDevice;

        private static Dictionary<string, Texture2D> textureDict = new Dictionary<string, Texture2D>();
        private static Dictionary<Texture2D, string> textureDictInv = new Dictionary<Texture2D, string>();
        private static Dictionary<Texture2D, int> textureRefs = new Dictionary<Texture2D, int>();
        private static Dictionary<Texture2D, bool> textureTransparent = new Dictionary<Texture2D, bool>();


        public TextureManager(Game game) {
            this.game = game;
            this.graphicsDevice = game.GraphicsDevice;
        }

        public Texture2D GetTexture(string filename, bool useMipmaps) {
            Texture2D texture;
            if (!textureDict.TryGetValue(filename, out texture)) {
                TextureCreationParameters texParams =
                    useMipmaps || game.UseAlternativeReflection ?
                        textureCreationParamsMipmaps :
                        textureCreationParamsNoMipmaps;
                try {
                    texture = Texture2D.FromFile(graphicsDevice, filename, texParams);
                }
                catch (Exception) {
                    return null;
                }
                textureDict[filename] = texture;
                textureDictInv[texture] = filename;
            }
            if (texture != null) {
                int refs;
                if (!textureRefs.TryGetValue(texture, out refs)) {
                    refs = 0;
                }
                textureRefs[texture] = refs + 1;
            }
            return texture;
        }

        public Texture2D ReloadTexture(Texture2D texture) {
            if (texture == null) {
                return null;
            }
            string filename = textureDictInv[texture];
            if (filename == null) {
                return null;
            }
            Texture2D newTexture;
            try {
                newTexture = Texture2D.FromFile(graphicsDevice, filename, textureCreationParamsMipmaps);
            }
            catch (Exception) {
                textureDict.Remove(filename);
                textureDictInv.Remove(texture);
                textureRefs.Remove(texture);
                textureTransparent.Remove(texture);
                texture.Dispose();
                return null;
            }
            
            textureDict[filename] = newTexture;
     
            textureDictInv.Remove(texture);
            textureDictInv[newTexture] = filename;

            int refs = textureRefs[texture];
            textureRefs.Remove(texture);
            textureRefs[newTexture] = refs;

            textureTransparent.Remove(texture);

            texture.Dispose();

            return newTexture;
        }

        public void HandleMeshRemoved(Mesh mesh) {
            foreach (Texture2D texture in mesh.Textures) {
                if (texture == null) {
                    continue;
                }
                int refs;
                if (textureRefs.TryGetValue(texture, out refs)) {
                    refs--;
                    if (refs > 0) {
                        textureRefs[texture] = refs;
                    }
                    else {
                        string filename = textureDictInv[texture];
                        textureDictInv.Remove(texture);
                        textureDict.Remove(filename);
                        textureRefs.Remove(texture);
                        textureTransparent.Remove(texture);
                        texture.Dispose();
                    }
                }
            }
        }

        public bool IsTransparent(Texture2D texture) {
            if (texture == null) {
                return false;
            }
            bool isTransparent;
            if (textureTransparent.TryGetValue(texture, out isTransparent)) {
                return isTransparent;
            }
            int width = texture.Width;
            int height = texture.Height;
            Color[] pixels = new Color[width * height];
            texture.GetData<Color>(pixels);
            isTransparent = false;
            foreach (Color pixel in pixels) {
                if (pixel.A < 255) {
                    isTransparent = true;
                    break;
                }
            }
            textureTransparent[texture] = isTransparent;
            return isTransparent;
        }
    }
}
