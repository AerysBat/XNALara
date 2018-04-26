using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class Renderer
    {
        private Game game;
        private GraphicsDevice graphicsDevice;
        private ModelLoader modelLoader;
        private CameraTurnTable camera;

        private Effect effectsFullScreenSprite;
        private Effect effectsArmature;
        private Effect effectsStaticTRL;
        private Effect effectsStaticTRU;
        private Effect effectsAlpha;
        private Effect effectsBillboard;
        private Effect effectsSkyDome;
        private Effect effectsPostProcessing;

        private ShaderDict shaderDict = new ShaderDict();

        private List<Item> items = new List<Item>();
        
        private Model modelGround;
        private Item itemSkyDome;

        private FullScreenSprite fullScreenSprite;

        private Billboard billboard;
        private Texture2D glowTexture;

        private Dictionary<string, ImageCodecInfo> imageCodecs = new Dictionary<string, ImageCodecInfo>();
        private MosaicRenderer mosaicRenderer;
        private ResolveBackBuffer resolveBackBuffer;


        public Renderer(Game game) {
            this.game = game;
            graphicsDevice = game.GraphicsDevice;
            modelLoader = new ModelLoader(game);
            camera = game.Camera;

            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders()) {
                imageCodecs[codec.FormatDescription] = codec;
            }
        }

        public GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }

        public CameraTurnTable Camera {
            get { return camera; }
        }

        public void Init() {
            effectsFullScreenSprite = game.Content.Load<Effect>("EffectsFullScreenSprite");
            effectsArmature = game.Content.Load<Effect>("EffectsArmature");
            effectsStaticTRL = game.Content.Load<Effect>("EffectsStaticTRL");
            effectsStaticTRU = game.Content.Load<Effect>("EffectsStaticTRU");
            effectsAlpha = game.Content.Load<Effect>("EffectsAlpha");
            effectsBillboard = game.Content.Load<Effect>("EffectsBillboard");
            effectsSkyDome = game.Content.Load<Effect>("EffectsSkyDome");
            effectsPostProcessing = game.Content.Load<Effect>("EffectsPostProcessing");

            modelGround = modelLoader.LoadAndInitModel(@"data\common\ground\ground.mesh", new VertexPositionNormalColorTextureTangent());
            if (modelGround == null) {
                System.Windows.Forms.MessageBox.
                    Show("Could not load ground plane model.\nSkipping ...", "Warning!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
            }

            fullScreenSprite = new FullScreenSprite(graphicsDevice);

            billboard = new Billboard(graphicsDevice);

            TextureManager textureManager = new TextureManager(game);
            glowTexture = textureManager.GetTexture("data\\common\\glow.png", true);

            mosaicRenderer = new MosaicRenderer(game);
            resolveBackBuffer = new ResolveBackBuffer(graphicsDevice);
        }

        public void AddItem(Item item) {
            items.Add(item);
        }

        public void RemoveItem(Item item) {
            items.Remove(item);
        }

        public void RenderBackgroundImage(int bufferWidth, int bufferHeight,
                                          float backgroundOffsetX, float backgroundOffsetY,
                                          float backgroundScaleX, float backgroundScaleY) {
            if (game.BackgroundImage == null) {
                return;
            }
            graphicsDevice.RenderState.DepthBufferWriteEnable = false;

            effectsFullScreenSprite.Parameters["Texture"].SetValue(game.BackgroundImage.Texture);
            effectsFullScreenSprite.Parameters["OffsetX"].SetValue(backgroundOffsetX);
            effectsFullScreenSprite.Parameters["OffsetY"].SetValue(backgroundOffsetY);
            effectsFullScreenSprite.Parameters["ScaleX"].SetValue(backgroundScaleX);
            effectsFullScreenSprite.Parameters["ScaleY"].SetValue(backgroundScaleY);
            effectsFullScreenSprite.Begin();
            EffectPass pass = effectsFullScreenSprite.CurrentTechnique.Passes[0];
            pass.Begin();
            fullScreenSprite.Render(bufferWidth, bufferHeight);
            pass.End();
            effectsFullScreenSprite.End();

            graphicsDevice.RenderState.DepthBufferWriteEnable = true;
        }

        private void RenderSkyDome() {
            if (itemSkyDome == null) {
                itemSkyDome = new SkyDomeThailandSea(game);
                itemSkyDome.LoadAndInitModel(ItemType.SkyDome_Thailand_Sea, @"data\skydome_thailand_sea");
            }
            if (itemSkyDome.Model == null) {
                return;
            }

            graphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer,
                                 SkyDomeThailandSea.BackgroundColor, 1.0f, 0);
            graphicsDevice.RenderState.DepthBufferWriteEnable = false;

            Matrix world = Matrix.CreateRotationY(-game.SkyDomeRotation) * 
                           Matrix.CreateTranslation(camera.Position + new Vector3(0, -game.SkyDomeElevation, 0));

            effectsSkyDome.Parameters["DisplayTextures"].SetValue(game.DisplayTextures);
            effectsSkyDome.Parameters["World"].SetValue(world);
            effectsSkyDome.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsSkyDome.Parameters["Projection"].SetValue(camera.ProjectionMatrix);

            effectsSkyDome.CurrentTechnique = effectsSkyDome.Techniques["Dome"];
            foreach (Mesh mesh in itemSkyDome.Model.GetMeshGroup(SkyDomeThailandSea.MeshGroupDome)) {
                mesh.RenderSinglePass(effectsSkyDome, "DiffuseTexture");
            }

            graphicsDevice.RenderState.DepthBufferWriteEnable = true;
        }

        private void RenderGround(Vector4 light1Color, Vector4 light2Color, Vector4 light3Color) {
            if (modelGround == null) {
                return;
            }

            effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques[shaderDict["NextGen"]];
            effectsStaticTRL.Parameters["DisplayTextures"].SetValue(game.DisplayTextures);
            effectsStaticTRL.Parameters["EnableBumpMaps"].SetValue(game.EnableBumpMaps);
            effectsStaticTRL.Parameters["World"].SetValue(Matrix.Identity);
            effectsStaticTRL.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsStaticTRL.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            effectsStaticTRL.Parameters["CameraPos"].SetValue(camera.Position);
            effectsStaticTRL.Parameters["Light1Dir"].SetValue(game.Light1Direction);
            effectsStaticTRL.Parameters["Light1Color"].SetValue(light1Color);
            effectsStaticTRL.Parameters["Light1ShadowDepth"].SetValue(game.Light1ShadowDepth);
            effectsStaticTRL.Parameters["Light2Dir"].SetValue(game.Light2Direction);
            effectsStaticTRL.Parameters["Light2Color"].SetValue(light2Color);
            effectsStaticTRL.Parameters["Light2ShadowDepth"].SetValue(game.Light2ShadowDepth);
            effectsStaticTRL.Parameters["Light3Dir"].SetValue(game.Light3Direction);
            effectsStaticTRL.Parameters["Light3Color"].SetValue(light3Color);
            effectsStaticTRL.Parameters["Light3ShadowDepth"].SetValue(game.Light3ShadowDepth);
            effectsStaticTRL.Parameters["BumpShadowAmount"].SetValue(0.65f);
            effectsStaticTRL.Parameters["BumpSpecularAmount"].SetValue(0.1f);
            effectsStaticTRL.Parameters["BumpSpecularGloss"].SetValue(10.0f);

            foreach (Mesh mesh in modelGround.Meshes) {
                mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture", "BumpTexture");
            }
        }

        public void RenderSceneFull(bool alphaPrepass) {
            graphicsDevice.RenderState.FillMode =
                game.DisplayWireframe ? FillMode.WireFrame : FillMode.Solid;

            Vector4 light1Color = ConvertLightColor(game.Light1Color, game.Light1Intensity);
            Vector4 light2Color = ConvertLightColor(game.Light2Color, game.Light2Intensity);
            Vector4 light3Color = ConvertLightColor(game.Light3Color, game.Light3Intensity);

            shaderDict.IsLight1On = game.Light1Intensity > 0;
            shaderDict.IsLight2On = game.Light2Intensity > 0;
            shaderDict.IsLight3On = game.Light3Intensity > 0;
            shaderDict.SupportsShadersV3 = game.SupportsShadersV3;
            shaderDict.ForceShadersV3 = game.ForceShadersV3;

            graphicsDevice.RenderState.CullMode = game.BackFaceCulling ? CullMode.CullCounterClockwiseFace : CullMode.None;

            if (game.DisplaySkyDome) {
                RenderSkyDome();
            }

            if (game.DisplayGround) {
                RenderGround(light1Color, light2Color, light3Color);
            }

            effectsArmature.Parameters["DisplayTextures"].SetValue(game.DisplayTextures);
            effectsArmature.Parameters["EnableBumpMaps"].SetValue(game.EnableBumpMaps);
            effectsArmature.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsArmature.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            effectsArmature.Parameters["CameraPos"].SetValue(camera.Position);
            effectsArmature.Parameters["Light1Dir"].SetValue(game.Light1Direction);
            effectsArmature.Parameters["Light1Color"].SetValue(light1Color);
            effectsArmature.Parameters["Light1Intensity"].SetValue(game.Light1Intensity);
            effectsArmature.Parameters["Light1ShadowDepth"].SetValue(game.Light1ShadowDepth);
            effectsArmature.Parameters["Light2Dir"].SetValue(game.Light2Direction);
            effectsArmature.Parameters["Light2Color"].SetValue(light2Color);
            effectsArmature.Parameters["Light2Intensity"].SetValue(game.Light2Intensity);
            effectsArmature.Parameters["Light2ShadowDepth"].SetValue(game.Light2ShadowDepth);
            effectsArmature.Parameters["Light3Dir"].SetValue(game.Light3Direction);
            effectsArmature.Parameters["Light3Color"].SetValue(light3Color);
            effectsArmature.Parameters["Light3Intensity"].SetValue(game.Light3Intensity);
            effectsArmature.Parameters["Light3ShadowDepth"].SetValue(game.Light3ShadowDepth);
            effectsArmature.Parameters["BumpShadowAmount"].SetValue(0.65f);
            effectsArmature.Parameters["BumpSpecularGloss"].SetValue(10.0f);
            effectsArmature.Parameters["UseAlternativeReflection"].SetValue(game.UseAlternativeReflection);

            effectsStaticTRL.Parameters["DisplayTextures"].SetValue(game.DisplayTextures);
            effectsStaticTRL.Parameters["EnableBumpMaps"].SetValue(game.EnableBumpMaps);
            effectsStaticTRL.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsStaticTRL.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            effectsStaticTRL.Parameters["CameraPos"].SetValue(camera.Position);
            effectsStaticTRL.Parameters["Light1Dir"].SetValue(game.Light1Direction);
            effectsStaticTRL.Parameters["Light1Color"].SetValue(light1Color);
            effectsStaticTRL.Parameters["Light1ShadowDepth"].SetValue(game.Light1ShadowDepth);
            effectsStaticTRL.Parameters["Light2Dir"].SetValue(game.Light2Direction);
            effectsStaticTRL.Parameters["Light2Color"].SetValue(light2Color);
            effectsStaticTRL.Parameters["Light2ShadowDepth"].SetValue(game.Light2ShadowDepth);
            effectsStaticTRL.Parameters["Light3Dir"].SetValue(game.Light3Direction);
            effectsStaticTRL.Parameters["Light3Color"].SetValue(light3Color);
            effectsStaticTRL.Parameters["Light3ShadowDepth"].SetValue(game.Light3ShadowDepth);
            effectsStaticTRL.Parameters["BumpShadowAmount"].SetValue(0.65f);
            effectsStaticTRL.Parameters["BumpSpecularGloss"].SetValue(10.0f);

            effectsStaticTRU.Parameters["DisplayTextures"].SetValue(game.DisplayTextures);
            effectsStaticTRU.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsStaticTRU.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            effectsStaticTRU.Parameters["Light1Dir"].SetValue(game.Light1Direction);
            effectsStaticTRU.Parameters["Light1Color"].SetValue(light1Color);
            effectsStaticTRU.Parameters["Light1ShadowDepth"].SetValue(game.Light1ShadowDepth);
            effectsStaticTRU.Parameters["Light2Dir"].SetValue(game.Light2Direction);
            effectsStaticTRU.Parameters["Light2Color"].SetValue(light2Color);
            effectsStaticTRU.Parameters["Light2ShadowDepth"].SetValue(game.Light2ShadowDepth);
            effectsStaticTRU.Parameters["Light3Dir"].SetValue(game.Light3Direction);
            effectsStaticTRU.Parameters["Light3Color"].SetValue(light3Color);
            effectsStaticTRU.Parameters["Light3ShadowDepth"].SetValue(game.Light3ShadowDepth);

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                graphicsDevice.RenderState.CullMode = DetermineCullMode(armature);

                Matrix world = armature.WorldMatrix;

                effectsArmature.Parameters["World"].SetValue(world);

                effectsStaticTRL.Parameters["World"].SetValue(world);

                effectsStaticTRU.Parameters["World"].SetValue(world);
                effectsStaticTRU.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup1)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBumpSpecular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup24)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3Specular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup22)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Metallic"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup26)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["MetallicBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup28)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[2]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup2)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmap"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup3)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup4)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques["Shadeless"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup10)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Diffuse"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup5)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.ThorGearAll)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture", "BumpTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques[shaderDict["NextGen"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup11)) {
                    effectsStaticTRL.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture", "BumpTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques["Shadeless"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup13)) {
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques["Basic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup14)) {
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["Diffuse"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup16)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["DiffuseLightmap"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup17)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture", "LightmapTexture");
                }
            }

            if (!game.AlwaysForceCulling) {
                graphicsDevice.RenderState.CullMode = CullMode.None;
            }

            if (!alphaPrepass) {
                graphicsDevice.RenderState.AlphaBlendEnable = true;
                graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
                graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

                graphicsDevice.RenderState.AlphaTestEnable = true;
                graphicsDevice.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
                graphicsDevice.RenderState.ReferenceAlpha = 200;
            }

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                if (game.AlwaysForceCulling) {
                    graphicsDevice.RenderState.CullMode = DetermineCullMode(armature);
                }

                Matrix world = armature.WorldMatrix;

                effectsArmature.Parameters["World"].SetValue(world);

                effectsStaticTRL.Parameters["World"].SetValue(world);

                effectsStaticTRU.Parameters["World"].SetValue(world);
                effectsStaticTRU.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup20)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBumpSpecular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup25)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3Specular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup23)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Metallic"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup27)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["MetallicBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup29)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[2]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup6)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "BumpTexture");
                }
                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.HandGuns)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Diffuse"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup7)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup8)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmap"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup9)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques["Shadeless"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup21)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques[shaderDict["NextGen"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup12)) {
                    effectsStaticTRL.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture", "BumpTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques["Basic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup15)) {
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["Diffuse"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup18)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["DiffuseLightmap"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup19)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture", "LightmapTexture");
                }
            }

            if (!alphaPrepass) {
                graphicsDevice.RenderState.AlphaBlendEnable = true;
                graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
                graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

                graphicsDevice.RenderState.AlphaTestEnable = true;
                graphicsDevice.RenderState.AlphaFunction = CompareFunction.Less;
                graphicsDevice.RenderState.ReferenceAlpha = 200;
            }

            graphicsDevice.RenderState.DepthBufferWriteEnable = false;

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                Matrix world = armature.WorldMatrix;

                effectsArmature.Parameters["World"].SetValue(world);

                effectsStaticTRL.Parameters["World"].SetValue(world);

                effectsStaticTRU.Parameters["World"].SetValue(world);
                effectsStaticTRU.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup20)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBumpSpecular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup25)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump3Specular"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup23)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "LightmapTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "SpecularTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Metallic"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup27)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["MetallicBump3"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup29)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["ReflectionAmount"].SetValue((float)mesh.RenderParams[0]);
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[1]);
                    effectsArmature.Parameters["Bump1UVScale"].SetValue((float)mesh.RenderParams[2]);
                    effectsArmature.Parameters["Bump2UVScale"].SetValue((float)mesh.RenderParams[2]);
                    mesh.RenderSinglePass(effectsArmature,
                        "DiffuseTexture",
                        "BumpTexture",
                        "MaskTexture",
                        "Bump1Texture",
                        "Bump2Texture",
                        "EnvironmentTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup6)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "BumpTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.HandGuns)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["Diffuse"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup7)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmapBump"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup8)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    effectsArmature.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture", "BumpTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques[shaderDict["DiffuseLightmap"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup9)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture", "LightmapTexture");
                }

                effectsArmature.CurrentTechnique = effectsArmature.Techniques["Shadeless"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup21)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques[shaderDict["NextGen"]];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup12)) {
                    effectsStaticTRL.Parameters["BumpSpecularAmount"].SetValue((float)mesh.RenderParams[0]);
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture", "BumpTexture");
                }

                effectsStaticTRL.CurrentTechnique = effectsStaticTRL.Techniques["Basic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup15)) {
                    mesh.RenderSinglePass(effectsStaticTRL, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["Diffuse"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup18)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture");
                }

                effectsStaticTRU.CurrentTechnique = effectsStaticTRU.Techniques["DiffuseLightmap"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup19)) {
                    mesh.RenderSinglePass(effectsStaticTRU, "DiffuseTexture", "LightmapTexture");
                }
            }

            graphicsDevice.RenderState.AlphaTestEnable = false;

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }

                bool isThorGlowBeltVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowBelt);
                bool isThorGlowGauntletLeftVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft);
                bool isThorGlowGauntletRightVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight);

                if (!isThorGlowBeltVisible && !isThorGlowGauntletLeftVisible && !isThorGlowGauntletRightVisible) {
                    continue;
                }

                Armature armature = model.Armature;

                Matrix world = armature.WorldMatrix;

                effectsArmature.Parameters["World"].SetValue(world);

                graphicsDevice.RenderState.SourceBlend = Blend.BlendFactor;
                graphicsDevice.RenderState.BlendFactor = new Color(2.0f, 2.0f, 2.0f, 1.0f);
                graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

                effectsArmature.CurrentTechnique = effectsArmature.Techniques["ThorGlow1"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.ThorGlowAll)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
                graphicsDevice.RenderState.DestinationBlend = Blend.One;

                effectsArmature.CurrentTechnique = effectsArmature.Techniques["ThorGlow2"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.ThorGlowAll)) {
                    effectsArmature.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsArmature, "DiffuseTexture");
                }

                graphicsDevice.RenderState.SourceBlend = Blend.SourceColor;
                graphicsDevice.RenderState.DestinationBlend = Blend.One;

                RenderGauntletGlowBillboards(item, isThorGlowGauntletLeftVisible, isThorGlowGauntletRightVisible, false);
            }

            graphicsDevice.RenderState.DepthBufferWriteEnable = true;
            graphicsDevice.RenderState.AlphaBlendEnable = false;

            graphicsDevice.RenderState.FillMode = FillMode.Solid;
        }

        public void RenderSceneAlpha() {
            graphicsDevice.RenderState.FillMode =
                game.DisplayWireframe ? FillMode.WireFrame : FillMode.Solid;

            effectsAlpha.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsAlpha.Parameters["Projection"].SetValue(camera.ProjectionMatrix);

            graphicsDevice.RenderState.CullMode = game.BackFaceCulling ? CullMode.CullCounterClockwiseFace : CullMode.None;

            if (game.DisplayGround) {

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBasic"];
                effectsAlpha.Parameters["World"].SetValue(Matrix.Identity);

                if (modelGround != null) {
                    foreach (Mesh mesh in modelGround.Meshes) {
                        mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                    }
                }
            }

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                graphicsDevice.RenderState.CullMode = DetermineCullMode(armature);

                effectsAlpha.Parameters["World"].SetValue(armature.WorldMatrix);
                effectsAlpha.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBones"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup1)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup24)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup22)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup26)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup28)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup2)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup3)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup4)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup10)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup5)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.ThorGearAll)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBasic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup11)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup13)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup14)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaRootBone"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup16)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup17)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
            }

            if (!game.AlwaysForceCulling) {
                graphicsDevice.RenderState.CullMode = CullMode.None;
            }

            graphicsDevice.RenderState.AlphaBlendEnable = true;
            graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
            graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

            graphicsDevice.RenderState.AlphaTestEnable = true;
            graphicsDevice.RenderState.AlphaFunction = CompareFunction.GreaterEqual;
            graphicsDevice.RenderState.ReferenceAlpha = 200;

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                if (game.AlwaysForceCulling) {
                    graphicsDevice.RenderState.CullMode = DetermineCullMode(armature);
                }

                effectsAlpha.Parameters["World"].SetValue(armature.WorldMatrix);
                effectsAlpha.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBones"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup20)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup25)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup23)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup27)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup29)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup6)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.HandGuns)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup7)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup8)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup9)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup21)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBasic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup12)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup15)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaRootBone"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup18)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaRootBone"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup19)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
            }

            graphicsDevice.RenderState.AlphaBlendEnable = true;
            graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
            graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

            graphicsDevice.RenderState.AlphaTestEnable = true;
            graphicsDevice.RenderState.AlphaFunction = CompareFunction.Less;
            graphicsDevice.RenderState.ReferenceAlpha = 200;

            graphicsDevice.RenderState.DepthBufferWriteEnable = false;

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }
                Armature armature = model.Armature;

                effectsAlpha.Parameters["World"].SetValue(armature.WorldMatrix);
                effectsAlpha.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBones"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup20)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup25)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup23)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup27)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup29)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup6)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.HandGuns)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup7)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup8)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup9)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup21)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBasic"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup12)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup15)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaRootBone"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup18)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaRootBone"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.MeshGroup19)) {
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }
            }

            graphicsDevice.RenderState.AlphaTestEnable = false;

            foreach (Item item in items) {
                Model model = item.Model;
                if (!model.IsVisible) {
                    continue;
                }

                bool isThorGlowBeltVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowBelt);
                bool isThorGlowGauntletLeftVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft);
                bool isThorGlowGauntletRightVisible = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight);

                if (!isThorGlowBeltVisible && !isThorGlowGauntletLeftVisible && !isThorGlowGauntletRightVisible) {
                    continue;
                }

                Armature armature = model.Armature;

                graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
                graphicsDevice.RenderState.DestinationBlend = Blend.One;

                effectsAlpha.Parameters["World"].SetValue(armature.WorldMatrix);
                effectsAlpha.Parameters["RootMatrix"].SetValue(armature.BoneMatrices[0]);

                effectsAlpha.CurrentTechnique = effectsAlpha.Techniques["AlphaBones"];
                foreach (Mesh mesh in model.GetMeshGroup(MeshGroupNames.ThorGlowAll)) {
                    effectsAlpha.Parameters["BoneMatrices"].SetValue(armature.GetBoneMatrices(mesh));
                    mesh.RenderSinglePass(effectsAlpha, "DiffuseTexture");
                }

                graphicsDevice.RenderState.SourceBlend = Blend.SourceColor;
                graphicsDevice.RenderState.DestinationBlend = Blend.One;

                RenderGauntletGlowBillboards(item, isThorGlowGauntletLeftVisible, isThorGlowGauntletRightVisible, true);
            }

            graphicsDevice.RenderState.DepthBufferWriteEnable = true;
            graphicsDevice.RenderState.AlphaBlendEnable = false;

            graphicsDevice.RenderState.FillMode = FillMode.Solid;
        }

        public void ApplyPostProcessing() {
            ResolveTexture2D resolveTexture = resolveBackBuffer.GetTexture();
            ApplyPostProcessing(resolveTexture);
        }

        public void ApplyPostProcessing(Texture2D inputTexture) {
            effectsPostProcessing.CurrentTechnique = effectsPostProcessing.Techniques["PostProcessing"];
            effectsPostProcessing.Parameters["Texture"].SetValue(inputTexture);

            effectsPostProcessing.Parameters["Brightness"].SetValue(game.PostProcessBrightness);
            effectsPostProcessing.Parameters["Gamma"].SetValue(game.PostProcessGamma);
            effectsPostProcessing.Parameters["Contrast"].SetValue(game.PostProcessContrast);
            effectsPostProcessing.Parameters["Saturation"].SetValue(game.PostProcessSaturation);

            effectsPostProcessing.Begin();
            EffectPass pass = effectsPostProcessing.CurrentTechnique.Passes[0];
            pass.Begin();
            fullScreenSprite.Render(inputTexture.Width, inputTexture.Height);
            pass.End();
            effectsPostProcessing.End();
        }

        public void RenderSceneToImage(string filename, double imageScale, bool saveAlpha, bool renderLogo) {
            //Model dummy = null;
            //foreach (Item item in items) {
            //    if (item.Type == ItemType.Dummy) {
            //        dummy = item.Model;
            //        break;
            //    }
            //}

            int width = graphicsDevice.Viewport.Width;
            int height = graphicsDevice.Viewport.Height;
            width = (int)Math.Round(width * imageScale);
            height = (int)Math.Round(height * imageScale);

            //if (dummy != null) {
            //    dummy.SetMeshGroupVisible(MeshGroupNames.Dummy, false);
            //}

            System.Drawing.Bitmap image = mosaicRenderer.Render(width, height, saveAlpha);
            
            if (renderLogo) {
                RenderLogoOverlay(image);
            }

            string filenameLower = filename.ToLower();
            if (filenameLower.EndsWith(".png")) {
                image.Save(filename, ImageFormat.Png);
            }
            if (filenameLower.EndsWith(".jpg")) {
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 95L);
                image.Save(filename, imageCodecs["JPEG"], encoderParameters);
            }

            image.Dispose();

            //if (dummy != null) {
            //    dummy.SetMeshGroupVisible(MeshGroupNames.Dummy, true);
            //}
        }

        private void RenderLogoOverlay(System.Drawing.Bitmap image) {
            System.Drawing.Bitmap logo = Properties.Resources.XNALaraWatermark;
            int borderSize = 10;
            int x = image.Width - borderSize - logo.Width;
            int y = image.Height - borderSize - logo.Height;
            if (x < 0 || y < 0) {
                return;
            }
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(logo, x, y, logo.Width, logo.Height);
            g.Dispose();
        }

        private void RenderGauntletGlowBillboards(Item item, bool isGauntletLeftVisible, bool isGauntletRightVisible, bool alphaOnly) {
            if (!isGauntletLeftVisible && !isGauntletRightVisible) {
                return;
            }

            Armature armature = item.Model.Armature;

            Matrix worldMatrix = armature.WorldMatrix;
            float worldScale = worldMatrix.M11;

            effectsBillboard.Parameters["World"].SetValue(worldMatrix);
            effectsBillboard.Parameters["View"].SetValue(camera.ViewMatrix);
            effectsBillboard.Parameters["Projection"].SetValue(camera.ProjectionMatrix);

            effectsBillboard.Parameters["CameraPosition"].SetValue(camera.Position);

            effectsBillboard.Parameters["Texture"].SetValue(glowTexture);
            effectsBillboard.Parameters["AlphaOnly"].SetValue(alphaOnly);

            effectsBillboard.Parameters["BillboardWidth"].SetValue(0.5f * worldScale);
            effectsBillboard.Parameters["BillboardHeight"].SetValue(0.5f * worldScale);

            effectsBillboard.CurrentTechnique = effectsBillboard.Techniques["SphericalBillboard"];

            effectsBillboard.Begin();

            if (isGauntletLeftVisible) {
                Armature.Bone palmLeftBone = armature.GetBone("unused072");
                if (palmLeftBone != null) {
                    Vector3 palmLeftPos = palmLeftBone.absTransform.Translation;
                    Vector3 dirLeft = camera.Position - Vector3.Transform(palmLeftPos, worldMatrix);
                    dirLeft.Normalize();
                    Vector3 billboardLeftPos = palmLeftPos + dirLeft * 0.2f * worldScale;

                    effectsBillboard.Parameters["Color"].SetValue(item.ColorGlowLeft);
                    effectsBillboard.Parameters["BillboardPosition"].SetValue(billboardLeftPos);
                    EffectPass passLeft = effectsBillboard.CurrentTechnique.Passes[0];
                    passLeft.Begin();
                    billboard.Render();
                    passLeft.End();
                }
            }

            if (isGauntletRightVisible) {
                Armature.Bone palmRightBone = armature.GetBone("unused097");
                if (palmRightBone != null) {
                    Vector3 palmRightPos = palmRightBone.absTransform.Translation;
                    Vector3 dirRight = camera.Position - Vector3.Transform(palmRightPos, worldMatrix);
                    dirRight.Normalize();
                    Vector3 billboardRightPos = palmRightPos + dirRight * 0.2f * worldScale;

                    effectsBillboard.Parameters["Color"].SetValue(item.ColorGlowRight);
                    effectsBillboard.Parameters["BillboardPosition"].SetValue(billboardRightPos);
                    EffectPass passRight = effectsBillboard.CurrentTechnique.Passes[0];
                    passRight.Begin();
                    billboard.Render();
                    passRight.End();
                }
            }

            effectsBillboard.End();
        }

        private Vector4 ConvertLightColor(Color color, float intensity) {
            float r = (color.R / 255.0f) * intensity;
            float g = (color.G / 255.0f) * intensity;
            float b = (color.B / 255.0f) * intensity;
            float a = (color.A / 255.0f);
            return new Vector4(r, g, b, a);
        }

        private CullMode DetermineCullMode(Armature armature) {
            if (!game.BackFaceCulling) {
                return CullMode.None;
            }
            Vector3 s = armature.WorldScale;
            return s.X * s.Y * s.Z > 0 ? CullMode.CullCounterClockwiseFace : CullMode.CullClockwiseFace;
        }
    }
}
