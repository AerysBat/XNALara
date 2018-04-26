using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public abstract class Item
    {
        public static readonly Vector4 ColorGlowDefault = new Vector4(0.40f, 0.70f, 1.0f, 1.0f);

        protected string tag;

        protected ItemType itemType;
        protected string dirName;

        protected GraphicsDevice graphicsDevice;
        protected ModelLoader modelLoader;
        protected ModelLoaderObj modelLoaderObj;
        protected VertexFormat vertexFormat;

        protected Model model;
        
        private List<string> cameraTargetKeys = new List<string>();
        private Dictionary<string, string[]> cameraTargetDict = new Dictionary<string, string[]>();

        private Vector4 colorGlowLeft = ColorGlowDefault;
        private Vector4 colorGlowRight = ColorGlowDefault;


        public Item(Game game) {
            graphicsDevice = game.GraphicsDevice;
            modelLoader = new ModelLoader(game);
            modelLoaderObj = new ModelLoaderObj(game);
            vertexFormat = new VertexPositionColorNormalTextureTangentBones();
        }

        public bool LoadAndInitModel(ItemType itemType, string dirName) {
            this.itemType = itemType;
            this.dirName = dirName;

            LoadModel();
            if (model == null) {
                //MessageBox.Show("Could not load model \"" + dirName + "\".",
                //    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                DefineMeshGroups();
                SetRenderParams();
                DefineCameraTargets();
            }
            catch (DictionaryKeyNotFoundException ex) {
                MessageBox.Show("Could not initialize model \"" + dirName + "\".\nMesh \"" + ex.Message + "\" not found.",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception) {
                MessageBox.Show("Could not initialize model \"" + dirName + "\".",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public string Tag {
            get { return tag; }
            set { tag = value; }
        }

        public ItemType Type {
            get { return itemType; }
        }

        public string DirName {
            get { return dirName; }
        }

        public Vector4 ColorGlowLeft {
            get { return colorGlowLeft; }
            set { colorGlowLeft = value; }
        }

        public Vector4 ColorGlowRight {
            get { return colorGlowRight; }
            set { colorGlowRight = value; }
        }

        protected virtual void LoadModel() {
            LoadModelIntern();
        }

        protected virtual void PostProcessModel(Model model) {
        }

        protected void LoadModelIntern() {
            LoadModelIntern(itemType, dirName);
        }

        protected void LoadModelIntern(ItemType itemType, string dirName) {
            switch (itemType) {

                default: {
                    string filename = string.Format("{0}\\{1}.mesh", dirName, itemType.ToString().ToLower());
                    model = modelLoader.LoadModel(filename);
                    if (model == null) {
                        return;
                    }
                    PostProcessModel(model);
                    if (model.Armature == null) {
                        model.Armature = new Armature(model);
                    }
                    foreach (MeshDesc meshDesc in model.MeshDescs) {
                        foreach (MeshDesc.Texture texture in meshDesc.textures) {
                            texture.filename = ChangeRelativePath(texture.filename, dirName);
                        }
                    }
                    break;
                }

                case ItemType.ExternObj: {
                    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                    FileInfo[] fileInfos = dirInfo.GetFiles("*.obj");
                    string filenameObj = string.Format("{0}\\{1}", dirName, fileInfos[0].Name);
                    string filenameMtl = filenameObj.Substring(0, filenameObj.Length - 4) + ".mtl";
                    model = modelLoaderObj.LoadModel(filenameObj, filenameMtl);
                    if (model == null) {
                        return;
                    }
                    foreach (MeshDesc meshDesc in model.MeshDescs) {

                        // diffuse texture
                        meshDesc.textures[0].filename = ChangeRelativePath(meshDesc.textures[0].filename, dirName);

                        // lightmap
                        if (meshDesc.textures[1] != null) {
                            meshDesc.textures[1].filename = ChangeRelativePath(meshDesc.textures[1].filename, dirName);
                        }
                        else {
                            meshDesc.textures[1] = new MeshDesc.Texture();
                            meshDesc.textures[1].filename = @"data\common\lightmap_white.png";
                            meshDesc.textures[1].uvLayerIndex = 0;
                        }

                        // bumpmap
                        if (meshDesc.textures[2] != null) {
                            meshDesc.textures[2].filename = ChangeRelativePath(meshDesc.textures[2].filename, dirName);
                        }
                        else {
                            meshDesc.textures[2] = new MeshDesc.Texture();
                            meshDesc.textures[2].filename = @"data\common\bumpmap_flat.png";
                            meshDesc.textures[2].uvLayerIndex = 0;
                        }

                        // specular texture
                        if (meshDesc.textures[3] != null) {
                            meshDesc.textures[3].filename = ChangeRelativePath(meshDesc.textures[3].filename, dirName);
                        }
                        else {
                            meshDesc.textures[3] = new MeshDesc.Texture();
                            meshDesc.textures[3].filename = @"data\common\specmap_white.png";
                            meshDesc.textures[3].uvLayerIndex = 0;
                        }
                    }
                    break;
                }
            }

            model.InitMeshes(vertexFormat);
        }

        private string ChangeRelativePath(string filename, string newPath) {
            if (!newPath.EndsWith("\\")) {
                newPath += "\\";
            }
            if (filename != null && newPath != null) {
                int pos1 = filename.LastIndexOf('\\');
                int pos2 = filename.LastIndexOf(':');
                int pos = Math.Max(pos1, pos2);
                if (pos >= 0) {
                    filename = newPath + filename.Substring(pos + 1);
                }
                else {
                    filename = newPath + filename;
                }
            }
            return filename;
        }

        protected abstract void DefineMeshGroups();

        protected abstract void SetRenderParams();

        protected abstract void DefineCameraTargets();

        public Model Model {
            get { return model; }
        }

        public List<string> CameraTargetKeys {
            get { return cameraTargetKeys; }
        }

        public string[] GetCameraTargetBones(string cameraTargetKey) {
            return cameraTargetDict[cameraTargetKey];
        }

        protected void AddCameraTarget(string key, params string[] bones) {
            cameraTargetKeys.Add(key);
            cameraTargetDict[key] = bones;
        }
    }
}
