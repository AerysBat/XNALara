using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class Model
    {
        private GraphicsDevice graphicsDevice;
        private TextureManager textureManager;

        private Armature armature;
        private bool isVisible = true;

        private Dictionary<string, MeshDesc> meshDescDict = new Dictionary<string, MeshDesc>();
        private Dictionary<string, Mesh> meshDict = new Dictionary<string, Mesh>();
        private Dictionary<string, List<Mesh>> groupDict = new Dictionary<string, List<Mesh>>();
        private Dictionary<string, object> visibleGroups = new Dictionary<string, object>();

        private static List<Mesh> emptyGroup = new List<Mesh>();

        public Model(Game game) {
            graphicsDevice = game.GraphicsDevice;
            textureManager = game.TextureManager;
        }

        public Armature Armature {
            set { armature = value; }
            get { return armature; }
        }

        public bool IsVisible {
            set { isVisible = value; }
            get { return isVisible; }
        }

        public ICollection<MeshDesc> MeshDescs {
            get { return meshDescDict.Values; }
        }

        public ICollection<Mesh> Meshes {
            get { return meshDict.Values; }
        }

        public void AddMeshDesc(MeshDesc meshDesc) {
            meshDescDict[meshDesc.name] = meshDesc;
        }

        public void RemoveMeshDesc(string meshName) {
            meshDescDict.Remove(meshName);
        }

        public Mesh InitMesh(string meshName, VertexFormat vertexFormat) {
            MeshDesc meshDesc = meshDescDict[meshName];
            Mesh mesh = new Mesh(graphicsDevice, textureManager, meshDesc, vertexFormat);
            meshDict[meshName] = mesh;
            return mesh;
        }

        public void InitMeshes(VertexFormat vertexFormat) {
            foreach (KeyValuePair<string, MeshDesc> entry in meshDescDict) {
                string meshName = entry.Key;
                MeshDesc meshDesc = entry.Value;
                Mesh mesh = new Mesh(graphicsDevice, textureManager, meshDesc, vertexFormat);
                meshDict[meshName] = mesh;
            }
        }

        public MeshDesc GetMeshDesc(string meshName) {
            MeshDesc meshDesc;
            if (!meshDescDict.TryGetValue(meshName, out meshDesc)) {
                return null;
            }
            return meshDesc;
        }

        public Mesh GetMesh(string meshName) {
            Mesh mesh;
            if (!meshDict.TryGetValue(meshName, out mesh)) {
                return null;
            }
            return mesh;
        }

        public void DefineMeshGroup(string groupName, params string[] meshNames) {
            List<Mesh> group = new List<Mesh>();
            foreach (string meshName in meshNames) {
                Mesh mesh;
                if (!meshDict.TryGetValue(meshName, out mesh)) {
                    //throw new DictionaryKeyNotFoundException(meshName);
                    continue;
                }
                group.Add(mesh);
            }
            groupDict[groupName] = group;
            visibleGroups[groupName] = null;
        }

        public ICollection<string> GetMeshGroupNames() {
            return groupDict.Keys;
        }

        public List<Mesh> GetMeshGroup(string groupName) {
            List<Mesh> group;
            if (!groupDict.TryGetValue(groupName, out group)) {
                return emptyGroup;
            }
            return group;
        }

        public void SetMeshGroupVisible(string groupName, bool isVisible) {
            if (!groupDict.ContainsKey(groupName)) {
                return;
            }
            List<Mesh> meshes = GetMeshGroup(groupName);
            foreach (Mesh mesh in meshes) {
                mesh.IsVisible = isVisible;
            }
            if (isVisible) {
                visibleGroups[groupName] = null;
            }
            else {
                visibleGroups.Remove(groupName);
            }
        }

        public bool IsMeshGroupVisible(string groupName) {
            return visibleGroups.ContainsKey(groupName);
        }

        public Dictionary<Texture2D, Texture2D> ReloadTextures() {
            Dictionary<Texture2D, Texture2D> mapping = new Dictionary<Texture2D, Texture2D>();
            foreach (Mesh mesh in meshDict.Values) {
                Texture2D[] textures = mesh.Textures;
                for (int i = 0; i < textures.Length; i++) {
                    Texture2D oldTexture = textures[i];
                    if (oldTexture == null) {
                        continue;
                    }
                    Texture2D newTexture = null;
                    if (!mapping.TryGetValue(oldTexture, out newTexture)) {
                        newTexture = textureManager.ReloadTexture(oldTexture);
                        mapping[oldTexture] = newTexture;
                    }
                    textures[i] = newTexture;
                }
            }
            return mapping;
        }

        public void ReplaceTexture(Texture2D oldTexture, Texture2D newTexture) {
            foreach (Mesh mesh in meshDict.Values) {
                Texture2D[] textures = mesh.Textures;
                for (int i = 0; i < textures.Length; i++) {
                    if (textures[i] == oldTexture) {
                        textures[i] = newTexture;
                    }
                }
            }
        }
    }
}
