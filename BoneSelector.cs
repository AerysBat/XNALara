using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class BoneSelector
    {
        private const double BoneProximityThreshold = 30.0;

        private Game game;
        private GraphicsDevice graphicsDevice;
        private List<Model> models = new List<Model>();
        private CameraTurnTable camera;

        private BasicEffect basicEffect;
        private VertexDeclaration vertexDeclaration;
        private Matrix viewMatrix;
        private Matrix projectionMatrix;

        private int screenWidth;
        private int screenHeight;

        private List<Armature.Bone> activeBones = new List<Armature.Bone>();
        private List<Armature.Bone> visibleBones = new List<Armature.Bone>();
        private List<Vector3> visibleBonesProjections = new List<Vector3>();
        private int renderedBonesCount;

        private int selectedBoneIndex = -1;

        private SpriteBatch spriteBatch;
        private SpriteFont font;


        public BoneSelector(Game game) {
            this.game = game;
            this.graphicsDevice = game.GraphicsDevice;
            this.camera = game.Camera;

            basicEffect = new BasicEffect(graphicsDevice, null);
            vertexDeclaration = new VertexDeclaration(graphicsDevice, VertexPositionColor.VertexElements);
            viewMatrix = Matrix.CreateLookAt(Vector3.UnitZ, Vector3.Zero, Vector3.Up);

            camera.CameraEvent += HandleCameraEvent;
            HandleWindowSizeChanged(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            try {
                font = game.Content.Load<SpriteFont>("BoneSelectorFont");
            }
            catch (Exception ex) {
                string currDir = Directory.GetCurrentDirectory();
                string contentDir = currDir + @"\Content";
                string fontFile = contentDir + @"\BoneSelectorFont.spritefont";
                MessageBox.Show(ex.Message + "\n\n" +
                    "Current directory: " + currDir + "\n" +
                    "folder \"Content\": " + (Directory.Exists(contentDir) ? "FOUND" : "NOT FOUND")+ "\n"+
                    "file \"Content\\BoneSelectorFont.spritefont\": " + (File.Exists(fontFile) ? "FOUND" : "NOT FOUND"),
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public void AddModel(Model model) {
            models.Add(model);
            Armature armature = model.Armature;
            foreach (Armature.Bone bone in armature.Bones) {
                if (bone.name.StartsWith("unused")) {
                    continue;
                }
                activeBones.Add(bone);
                if (model.IsVisible) {
                    visibleBones.Add(bone);
                    visibleBonesProjections.Add(Vector3.Zero);
                }
            }
            armature.ArmatureEvent += HandleArmatureEvent;
            RecalculateBonePositions();
        }

        public void RemoveModel(Model model) {
            models.Remove(model);
            Armature armature = model.Armature;
            int i = 0;
            while (i < activeBones.Count) {
                Armature.Bone bone = activeBones[i];
                if (bone.armature == armature) {
                    activeBones.RemoveAt(i);
                    if (model.IsVisible) {
                        int j = visibleBones.IndexOf(bone);
                        visibleBones.RemoveAt(j);
                        visibleBonesProjections.RemoveAt(j);
                    }
                }
                else {
                    i++;
                }
            }
            armature.ArmatureEvent -= HandleArmatureEvent;
            selectedBoneIndex = -1;
        }

        public Armature.Bone SelectedBone {
            get { return selectedBoneIndex < 0 ? null : visibleBones[selectedBoneIndex]; }
        }

        public void HandleModelVisibilityChanged(Model model) {
            visibleBones.Clear();
            visibleBonesProjections.Clear();
            foreach (Armature.Bone bone in activeBones) {
                if (!bone.armature.Model.IsVisible) {
                    continue;
                }
                visibleBones.Add(bone);
                visibleBonesProjections.Add(Vector3.Zero);
            }
            selectedBoneIndex = -1;
            RecalculateBonePositions();
        }

        public void HandleWindowSizeChanged(int width, int height) {
            screenWidth = width;
            screenHeight = height;
            projectionMatrix = Matrix.CreateOrthographicOffCenter(0, screenWidth, 0, screenHeight, 1.0f, 100.0f);
            RecalculateBonePositions();
        }

        public void HandleCameraEvent() {
            RecalculateBonePositions();
        }

        public void HandleArmatureEvent() {
            RecalculateBonePositions();
        }

        public void HandleMouseMoved(int mouseX, int mouseY) {
            mouseY = screenHeight - 1 - mouseY;
            double minDistance = double.PositiveInfinity;
            selectedBoneIndex = -1;
            for (int i = 0; i < visibleBonesProjections.Count; i++) {
                Vector3 boneProj = visibleBonesProjections[i];
                if (boneProj.Z < 0) {
                    continue;
                }
                double dx = boneProj.X - mouseX;
                double dy = boneProj.Y - mouseY;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                if (distance < BoneProximityThreshold && distance < minDistance) {
                    minDistance = distance;
                    selectedBoneIndex = i;
                }
            }
        }

        public void Render() {
            if (selectedBoneIndex < 0 || renderedBonesCount == 0) {
                return;
            }
            Color DefaultBoneColor = new Color(Color.White, 0.35f);
            Armature.Bone selectedBone = null;
            Vector3 selectedBoneProj = Vector3.Zero;
            VertexPositionColor[] points = new VertexPositionColor[renderedBonesCount];
            int j = 0;
            for (int i = 0; i < visibleBones.Count; i++) {
                Vector3 boneProj = visibleBonesProjections[i];
                if (boneProj.Z < 0) {
                    continue;
                }
                Color color;
                if (i == selectedBoneIndex) {
                    color = Color.Red;
                    selectedBone = visibleBones[i];
                    selectedBoneProj = boneProj;
                }
                else {
                    color = DefaultBoneColor;
                }
                points[j] = new VertexPositionColor(boneProj, color);
                j++;
            }
            
            graphicsDevice.RenderState.PointSize = 5;
            graphicsDevice.VertexDeclaration = vertexDeclaration;
            
            graphicsDevice.RenderState.AlphaBlendEnable = true;
            graphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
            graphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

            basicEffect.VertexColorEnabled = true;
            basicEffect.World = Matrix.Identity;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;

            basicEffect.Begin();
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes) {
                pass.Begin();
                graphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.PointList, points, 0, points.Length);
                pass.End();
            }
            basicEffect.End();

            graphicsDevice.RenderState.AlphaBlendEnable = false;

            if (game.DisplayBoneNames && selectedBone != null) {
                spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.SaveState);
                int x = (int)Math.Round(selectedBoneProj.X);
                int y = (int)Math.Round(screenHeight - 1 - selectedBoneProj.Y - font.LineSpacing - 3);
                string label = selectedBone.name;
                spriteBatch.DrawString(font, label, new Vector2(x + 1, y + 1), Color.Black);
                spriteBatch.DrawString(font, label, new Vector2(x, y), Color.Yellow);
                spriteBatch.End();
            }
        }

        private void RecalculateBonePositions() {
            Viewport viewport = graphicsDevice.Viewport;
            Matrix projectionMatrix = camera.ProjectionMatrix;
            Matrix viewMatrix = camera.ViewMatrix;
            float cameraNear = camera.NearPlane;
            renderedBonesCount = 0;
            for (int i = 0; i < visibleBones.Count; i++) {
                Armature.Bone bone = visibleBones[i];
                Matrix worldMatrix = bone.armature.WorldMatrix;
                Vector3 absPos = bone.absTransform.Translation;
                Vector3 projected = viewport.Project(absPos, projectionMatrix, viewMatrix, worldMatrix);
                projected.Y = viewport.Height - 1 - projected.Y;
                if (projected.Z > 0 && projected.Z < 1) {
                    projected.Z = 0;
                    renderedBonesCount++;
                }
                else {
                    projected.Z = -1;
                }
                visibleBonesProjections[i] = projected;
            }
        }
    }
}
