using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private void LoadScene(string filename, 
                               bool clearScene, bool loadScene,
                               bool loadCamera, bool loadLights, bool loadPostProcess,
                               bool loadWindowSize) {
            try {
                BinaryReader file = new BinaryReader(new FileStream(filename, FileMode.Open));

                if (clearScene) {
                    RemoveAllItems();
                }

                // file format version
                ushort versionMajor = file.ReadUInt16();
                ushort versionMinor = file.ReadUInt16();

                if (!LoadItems(file, versionMajor, versionMinor, loadScene)) {
                    return;
                }
                LoadCamera(file, versionMajor, versionMinor, loadCamera);
                LoadLights(file, versionMajor, versionMinor, loadLights);
                LoadPostProcessParams(file, versionMajor, versionMinor, loadPostProcess);
                LoadBackground(file, versionMajor, versionMinor, loadScene);
                LoadSkydome(file, versionMajor, versionMinor, loadScene);
                LoadWindowSize(file, versionMajor, versionMinor, loadWindowSize);

                file.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show(this, "Could not load scene.",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool LoadItems(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadScene) {
            // items
            int itemCount = file.ReadInt32();
            for (int itemID = 0; itemID < itemCount; itemID++) {

                // create item
                string itemTypeName = file.ReadString();
                string dirName;
                if (versionMajor >= 1 && versionMinor >= 5) {
                    dirName = file.ReadString();
                }
                else {
                    dirName = itemTypeName.ToLower();
                }
                bool isVisible = file.ReadBoolean();
                Vector3 itemScale;
                if (versionMajor >= 1 && versionMinor >= 8) {
                    float itemScaleX = file.ReadSingle();
                    float itemScaleY = file.ReadSingle();
                    float itemScaleZ = file.ReadSingle();
                    itemScale = new Vector3(itemScaleX, itemScaleY, itemScaleZ);
                }
                else {
                    float itemScaleXYZ = file.ReadSingle();
                    itemScale = new Vector3(itemScaleXYZ, itemScaleXYZ, itemScaleXYZ);
                }

                ItemType itemType = ParseItemType(itemTypeName);
                Item item = ItemFactory.GetItem(game, itemType);
                if (!dirName.ToLower().StartsWith("data\\")) {
                    dirName = "data\\" + dirName;
                }
                if (!item.LoadAndInitModel(itemType, dirName)) {
                    return false;
                }
                item.Model.IsVisible = isVisible;

                if (loadScene) {
                    AddItem(item);
                }

                // pose
                Armature armature = item.Model.Armature;
                foreach (Armature.Bone bone in armature.Bones) {
                    float rotX = file.ReadSingle();
                    float rotY = file.ReadSingle();
                    float rotZ = file.ReadSingle();
                    float moveX = 0;
                    float moveY = 0;
                    float moveZ = 0;
                    if (versionMajor >= 1 && versionMinor >= 3) {
                        moveX = file.ReadSingle();
                        moveY = file.ReadSingle();
                        moveZ = file.ReadSingle();
                    }

                    if (loadScene) {
                        DataSet dataSet = dataSetDict[item];
                        BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
                        boneTransform.rotX = rotX;
                        boneTransform.rotY = rotY;
                        boneTransform.rotZ = rotZ;
                        boneTransform.moveX = moveX;
                        boneTransform.moveY = moveY;
                        boneTransform.moveZ = moveZ;
                        ApplyTransformToBone(bone, boneTransform);
                    }
                }

                // position
                Vector3 position = new Vector3();
                position.X = file.ReadSingle();
                position.Y = file.ReadSingle();
                position.Z = file.ReadSingle();

                if (loadScene) {
                    armature.WorldScale = itemScale;
                    HandleScaleChangedInGUI(itemScale);
                    armature.WorldTranslation = position;
                    HandleHeightChanged(position.Y);
                }

                // accessories
                ImportModelParams(file, loadScene ? item.Model : null);
                if (loadScene) {
                    UpdateAccessoriesCheckboxes(item.Model);
                }

                // glow colors
                if (versionMajor >= 1 && versionMinor >= 11) {
                    float r, g, b;                    
                    r = file.ReadSingle();
                    g = file.ReadSingle();
                    b = file.ReadSingle();
                    item.ColorGlowLeft = new Vector4(r, g, b, 1);
                    r = file.ReadSingle();
                    g = file.ReadSingle();
                    b = file.ReadSingle();
                    item.ColorGlowRight = new Vector4(r, g, b, 1);
                }
            }
            
            return true;
        }

        private void LoadCamera(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadCamera) {
            float cameraFov = file.ReadSingle();
            Vector3 cameraTarget = new Vector3();
            cameraTarget.X = file.ReadSingle();
            cameraTarget.Y = file.ReadSingle();
            cameraTarget.Z = file.ReadSingle();
            float cameraDistance = file.ReadSingle();
            float cameraRotationHoriz = file.ReadSingle();
            float cameraRotationVert = file.ReadSingle();

            if (loadCamera) {
                CameraTurnTable camera = game.Camera;
                camera.FieldOfViewHorizontal = cameraFov;
                camera.Target = cameraTarget;
                camera.Distance = cameraDistance;
                camera.SetRotation(cameraRotationHoriz, cameraRotationVert);
            }
        }

        private void LoadLights(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadLights) {
            // light 1
            Vector3 light1Direction = new Vector3();
            light1Direction.X = file.ReadSingle();
            light1Direction.Y = file.ReadSingle();
            light1Direction.Z = file.ReadSingle();
            float light1Intensity = 1.0f;
            if (versionMajor >= 1 && versionMinor >= 2) {
                light1Intensity = file.ReadSingle();
            }
            Color light1Color = Color.White;
            light1Color.R = file.ReadByte();
            light1Color.G = file.ReadByte();
            light1Color.B = file.ReadByte();
            float light1ShadowDepth = file.ReadSingle();

            // light 2
            Vector3 light2Direction = LightingParamsDialog.DefaultLight2Direction;
            float light2Intensity = LightingParamsDialog.DefaultLight2Intensity;
            Color light2Color = LightingParamsDialog.DefaultLight2Color;
            float light2ShadowDepth = LightingParamsDialog.DefaultLight2ShadowDepth;
            if (versionMajor >= 1 && versionMinor >= 4) {
                light2Direction.X = file.ReadSingle();
                light2Direction.Y = file.ReadSingle();
                light2Direction.Z = file.ReadSingle();
                light2Intensity = file.ReadSingle();
                light2Color.R = file.ReadByte();
                light2Color.G = file.ReadByte();
                light2Color.B = file.ReadByte();
                light2ShadowDepth = file.ReadSingle();
            }

            // light 3
            Vector3 light3Direction = LightingParamsDialog.DefaultLight3Direction;
            float light3Intensity = LightingParamsDialog.DefaultLight3Intensity;
            Color light3Color = LightingParamsDialog.DefaultLight3Color;
            float light3ShadowDepth = LightingParamsDialog.DefaultLight3ShadowDepth;
            if (versionMajor >= 1 && versionMinor >= 10) {
                light3Direction.X = file.ReadSingle();
                light3Direction.Y = file.ReadSingle();
                light3Direction.Z = file.ReadSingle();
                light3Intensity = file.ReadSingle();
                light3Color.R = file.ReadByte();
                light3Color.G = file.ReadByte();
                light3Color.B = file.ReadByte();
                light3ShadowDepth = file.ReadSingle();
            }

            if (loadLights) {
                game.Light1Direction = light1Direction;
                game.Light1Intensity = light1Intensity;
                game.Light1Color = light1Color;
                game.Light1ShadowDepth = light1ShadowDepth;

                game.Light2Direction = light2Direction;
                game.Light2Intensity = light2Intensity;
                game.Light2Color = light2Color;
                game.Light2ShadowDepth = light2ShadowDepth;

                game.Light3Direction = light3Direction;
                game.Light3Intensity = light3Intensity;
                game.Light3Color = light3Color;
                game.Light3ShadowDepth = light3ShadowDepth;
            }
        }

        private void LoadBackground(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadScene) {
            bool displayGround = file.ReadBoolean();
            string groundTextureFilename = file.ReadString();
            Color backgroundColor = Game.DefaultBackgroundColor;
            if (versionMajor >= 1 && versionMinor >= 1) {
                backgroundColor.R = file.ReadByte();
                backgroundColor.G = file.ReadByte();
                backgroundColor.B = file.ReadByte();
            }
            string backgroundTextureFilename = file.ReadString();

            if (loadScene) {
                game.DisplayGround = displayGround;
                game.BackgroundColor = backgroundColor;
            }
        }

        private void LoadSkydome(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadScene) {
            bool displaySkyDome = false;
            float skyDomeRotation = 0;
            float skyDomeElevation = 0;
            if (versionMajor >= 1 && versionMinor >= 6) {
                displaySkyDome = file.ReadBoolean();
                string skyDomeType = file.ReadString();
                skyDomeRotation = file.ReadSingle();
                skyDomeElevation = file.ReadSingle();
            }

            if (loadScene) {
                game.DisplaySkyDome = displaySkyDome;
                game.SkyDomeRotation = skyDomeRotation;
                game.SkyDomeElevation = skyDomeElevation;
            }
        }

        private void LoadWindowSize(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadWindowSize) {
            if (versionMajor >= 1 && versionMinor >= 7) {
                bool isFormMaximized = file.ReadBoolean();
                int canvasWidth = file.ReadInt32();
                int canvasHeight = file.ReadInt32();

                if (loadWindowSize) {
                    if (isFormMaximized) {
                        game.GameForm.WindowState = FormWindowState.Maximized;
                    }
                    else {
                        if (canvasWidth > 0 && canvasHeight > 0) {
                            game.CanvasSize = new System.Drawing.Size(canvasWidth, canvasHeight);
                        }
                    }
                }
            }
        }

        private void LoadPostProcessParams(BinaryReader file, ushort versionMajor, ushort versionMinor, bool loadPostProcessParams) {
            float brightness = PostProcessParamsDialog.DefaultBrightness;
            float gamma = PostProcessParamsDialog.DefaultGamma;
            float contrast = PostProcessParamsDialog.DefaultContrast;
            float saturation = PostProcessParamsDialog.DefaultSaturation;

            if (versionMajor >= 1 && versionMinor >= 9) {
                brightness = file.ReadSingle();
                gamma = file.ReadSingle();
                contrast = file.ReadSingle();
                saturation = file.ReadSingle();
            }

            if (loadPostProcessParams) {
                game.PostProcessBrightness = brightness;
                game.PostProcessGamma = gamma;
                game.PostProcessContrast = contrast;
                game.PostProcessSaturation = saturation;
            }
        }

        private void SaveScene(string filename) {
            BinaryWriter file;
            try {
                file = new BinaryWriter(new FileStream(filename, FileMode.Create));
            }
            catch (Exception) {
                MessageBox.Show(this, "Could not save scene.",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // file format version
            file.Write((ushort)1); // major
            file.Write((ushort)11); // minor

            // items
            file.Write(items.Count);
            foreach (Item item in items) {

                // type
                file.Write(item.Type.ToString());
                // directory name
                file.Write(item.DirName);
                // visibility
                file.Write(item.Model.IsVisible);
                // scale
                file.Write(item.Model.Armature.WorldScale.X);
                file.Write(item.Model.Armature.WorldScale.Y);
                file.Write(item.Model.Armature.WorldScale.Z);

                // pose
                Armature armature = item.Model.Armature;
                DataSet dataSet = dataSetDict[item];
                foreach (Armature.Bone bone in armature.Bones) {
                    BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
                    file.Write(boneTransform.rotX);
                    file.Write(boneTransform.rotY);
                    file.Write(boneTransform.rotZ);
                    file.Write(boneTransform.moveX);
                    file.Write(boneTransform.moveY);
                    file.Write(boneTransform.moveZ);
                }

                // position
                Vector3 position = armature.WorldTranslation;
                file.Write(position.X);
                file.Write(position.Y);
                file.Write(position.Z);

                // accessories
                ExportModelParams(file, item.Model);

                // glow colors
                file.Write(item.ColorGlowLeft.X);
                file.Write(item.ColorGlowLeft.Y);
                file.Write(item.ColorGlowLeft.Z);
                file.Write(item.ColorGlowRight.X);
                file.Write(item.ColorGlowRight.Y);
                file.Write(item.ColorGlowRight.Z);
            }

            // camera
            CameraTurnTable camera = game.Camera;
            file.Write(camera.FieldOfViewHorizontal);
            file.Write(camera.Target.X);
            file.Write(camera.Target.Y);
            file.Write(camera.Target.Z);
            file.Write(camera.Distance);
            file.Write(camera.RotationHorizontal);
            file.Write(camera.RotationVertical);

            // light 1
            Vector3 light1Dir = game.Light1Direction;
            file.Write(light1Dir.X);
            file.Write(light1Dir.Y);
            file.Write(light1Dir.Z);
            file.Write(game.Light1Intensity);
            Color light1Color = game.Light1Color;
            file.Write(light1Color.R);
            file.Write(light1Color.G);
            file.Write(light1Color.B);
            file.Write(game.Light1ShadowDepth);

            // light 2
            Vector3 light2Dir = game.Light2Direction;
            file.Write(light2Dir.X);
            file.Write(light2Dir.Y);
            file.Write(light2Dir.Z);
            file.Write(game.Light2Intensity);
            Color light2Color = game.Light2Color;
            file.Write(light2Color.R);
            file.Write(light2Color.G);
            file.Write(light2Color.B);
            file.Write(game.Light2ShadowDepth);

            // light 3
            Vector3 light3Dir = game.Light3Direction;
            file.Write(light3Dir.X);
            file.Write(light3Dir.Y);
            file.Write(light3Dir.Z);
            file.Write(game.Light3Intensity);
            Color light3Color = game.Light3Color;
            file.Write(light3Color.R);
            file.Write(light3Color.G);
            file.Write(light3Color.B);
            file.Write(game.Light3ShadowDepth);

            // post-processing params
            file.Write(game.PostProcessBrightness);
            file.Write(game.PostProcessGamma);
            file.Write(game.PostProcessContrast);
            file.Write(game.PostProcessSaturation);

            // ground texture
            file.Write(game.DisplayGround);
            file.Write("data\\ground.png");

            // background color
            file.Write(game.BackgroundColor.R);
            file.Write(game.BackgroundColor.G);
            file.Write(game.BackgroundColor.B);

            // background image
            file.Write("");

            // skydome
            file.Write(game.DisplaySkyDome);
            file.Write(ItemType.SkyDome_Thailand_Sea.ToString());
            file.Write(game.SkyDomeRotation);
            file.Write(game.SkyDomeElevation);

            // canvas size
            file.Write(game.GameForm.WindowState == FormWindowState.Maximized);
            file.Write(game.GameForm.ClientSize.Width);
            file.Write(game.GameForm.ClientSize.Height);

            file.Close();
        }

        private void ExportModelParams(BinaryWriter file, Model model) {
            file.Write((int)10);
            
            file.Write(MeshGroupNames.HandGunHandLeft);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.HandGunHandLeft));

            file.Write(MeshGroupNames.HandGunHandRight);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.HandGunHandRight));

            file.Write(MeshGroupNames.HandGunHolsterLeft);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.HandGunHolsterLeft));

            file.Write(MeshGroupNames.HandGunHolsterRight);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.HandGunHolsterRight));

            file.Write(MeshGroupNames.ThorGearBelt);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGearBelt));

            file.Write(MeshGroupNames.ThorGearGauntletLeft);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGearGauntletLeft));

            file.Write(MeshGroupNames.ThorGearGauntletRight);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGearGauntletRight));

            file.Write(MeshGroupNames.ThorGlowBelt);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGlowBelt));

            file.Write(MeshGroupNames.ThorGlowGauntletLeft);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft));

            file.Write(MeshGroupNames.ThorGlowGauntletRight);
            file.Write(model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight));
        }

        private void ImportModelParams(BinaryReader file, Model model) {
            int itemCount = file.ReadInt32();
            for (int i = 0; i < itemCount; i++) {
                string groupName = file.ReadString();
                bool isVisible = file.ReadBoolean();

                if (model != null) {
                    switch (groupName) {
                        default:
                            model.SetMeshGroupVisible(groupName, isVisible);
                            break;

                        case "ThorGear":
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGearBelt, isVisible);
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletLeft, isVisible);
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletRight, isVisible);
                            break;

                        case "ThorWireframe":
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowBelt, isVisible);
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft, isVisible);
                            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight, isVisible);
                            break;
                    }
                }
            }
        }

        private ItemType ParseItemType(string itemTypeName) {
            string itemTypeNameLower = itemTypeName.ToLower();
            foreach (ItemType type in Enum.GetValues(typeof(ItemType))) {
                if (type.ToString().ToLower() == itemTypeNameLower) {
                    return type;
                }
            }
            return ItemType.None;
        }
    }
}
