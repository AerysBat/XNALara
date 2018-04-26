using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNALara
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        public string ReleaseProductName {
            get { return "XNALara"; }
        }

        public string ReleaseVersion {
            get { return "9.7.7"; }
        }

        public string ReleaseDate {
            get { return "July 2011"; }
        }

        public static readonly Color DefaultBackgroundColor = new Color(72, 72, 72);

        public const int DefaultCanvasWidth = 700;
        public const int DefaultCanvasHeight = 700;

        private System.Windows.Forms.Form gameForm;
        private GraphicsDeviceManager graphicsDeviceManager;

        private ShaderProfile maxVertexShaderProfile;
        private ShaderProfile maxPixelShaderProfile;
        private bool supportsShadersV3;
        private bool forceShadersV3;

        private bool enableAddModelMultiSelect = true;
        private bool renderLogo = false;

        private CameraTurnTable camera;
        private CameraTurnTableState cameraSavedState;

        private TextureManager textureManager;
        private Renderer renderer;
        private HUD hud;

        private List<Armature> armatures = new List<Armature>();

        private BoneSelector boneSelector;

        private Point mouseAnchor;
        private int mouseWheel = 0;
        private bool mouseLeftDragging;
        private bool mouseRightDragging;
        private bool disableBoneSelection;

        private bool boneTransformActive = false;

        private Color backgroundColor = DefaultBackgroundColor;
        private BackgroundImage backgroundImage = null;

        private bool displayTextures = true;
        private bool enableBumpMaps = true;
        private bool displayWireframe = false;
        private bool backFaceCulling = false;
        private bool alwaysForceCulling = false;
        private bool displayBones = true;
        private bool displayBoneNames = true;
        private bool displayGround = true;
        private bool useAlternativeReflection = false;

        private bool displaySkyDome = false;
        private float skyDomeRotation = 0;
        private float skyDomeElevation = 0;

        private float light1AngleHorizontal;
        private float light1AngleVertical;
        private Vector3 light1Direction;
        private float light1Intensity;
        private Color light1Color;
        private float light1ShadowDepth;

        private float light2AngleHorizontal;
        private float light2AngleVertical;
        private Vector3 light2Direction;
        private float light2Intensity;
        private Color light2Color;
        private float light2ShadowDepth;

        private float light3AngleHorizontal;
        private float light3AngleVertical;
        private Vector3 light3Direction;
        private float light3Intensity;
        private Color light3Color;
        private float light3ShadowDepth;

        private float postProcessBrightness;
        private float postProcessGamma;
        private float postProcessContrast;
        private float postProcessSaturation;

        private ControlGUI controlGUI;
        private bool hasFocus = false;

        private bool forceExit = false;

        private SplashForm splash;
        private Timer timerSplash;


        public Game() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            this.Window.Title = string.Format("{0} {1} by Dusan Pavlicek (c) {2}", 
                ReleaseProductName, ReleaseVersion, ReleaseDate);
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler(WindowSizeChanged);

            Content.RootDirectory = "Content";

            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferMultiSampling = true;
            graphicsDeviceManager.PreparingDeviceSettings +=
                new EventHandler<PreparingDeviceSettingsEventArgs>(OnPreparingDeviceSettings);

            gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle);
            gameForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);

            gameForm.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.XNALaraIcon22.GetHicon());
            gameForm.ShowIcon = true;

            splash = new SplashForm();
            splash.Owner = gameForm;
            splash.TopMost = true;
            splash.Show();
            splash.Update();

            timerSplash = new Timer(SplashTimerTimeout, null, 2000, System.Threading.Timeout.Infinite);
        }

        private void SplashTimerTimeout(object state) {
            timerSplash.Dispose();
            timerSplash = null;


            if (this.splash.InvokeRequired) {
                this.splash.Invoke(new CloseSplashDelegate(CloseSplash));
            }
            else {
                CloseSplash();
            }
        }

        private delegate void CloseSplashDelegate();

        private void CloseSplash() {
            if (splash != null) {
                splash.Hide();
                splash.Dispose();
                splash = null;
            }
            if (controlGUI != null) {
                controlGUI.TopMost = controlGUI.PreferredAlwaysOnTop;
            }
        }

        public System.Drawing.Size CanvasSize {
            set {
                gameForm.WindowState = System.Windows.Forms.FormWindowState.Normal;

                System.Drawing.Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

                if (value.Width < screenSize.Width && value.Height < screenSize.Height) {
                    graphicsDeviceManager.PreferredBackBufferWidth = value.Width;
                    graphicsDeviceManager.PreferredBackBufferHeight = value.Height;
                    graphicsDeviceManager.ApplyChanges();

                    WindowSizeChanged();
                    camera.FieldOfViewHorizontal = camera.FieldOfViewHorizontal;
                }
                else {
                    gameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                    bool savedTopMost = controlGUI.TopMost;
                    controlGUI.TopMost = false;
                    System.Windows.Forms.MessageBox.Show("Requested canvas size is larger than the screen.", "Warning!",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    controlGUI.TopMost = savedTopMost;
                }
            }

            get { 
                return new System.Drawing.Size(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            }
        }

        public System.Windows.Forms.Form GameForm {
            get { return gameForm; }
        }

        public HUD HUD {
            get { return hud; }
        }

        public bool HasFocus {
            set { hasFocus = value; }
            get { return hasFocus; }
        }

        public TextureManager TextureManager {
            get { return textureManager; }
        }

        public Renderer Renderer {
            get { return renderer; }
        }

        public ShaderProfile MaxVertexShaderProfile {
            get { return maxVertexShaderProfile; }
        }

        public ShaderProfile MaxPixelShaderProfile {
            get { return maxPixelShaderProfile; }
        }

        public bool SupportsShadersV3 {
            get { return supportsShadersV3; }
        }

        public bool ForceShadersV3 {
            set { forceShadersV3 = value; }
            get { return forceShadersV3; }
        }

        public bool EnableAddModelMultiSelect {
            set { enableAddModelMultiSelect = value; }
            get { return enableAddModelMultiSelect; }
        }

        public bool RenderLogo {
            set { renderLogo = value; }
            get { return renderLogo; }
        }

        public CameraTurnTable Camera {
            get { return camera; }
        }

        public ControlGUI ControlGUI {
            get { return controlGUI; }
        }

        public BoneSelector BoneSelector {
            get { return boneSelector; }
        }

        public Color BackgroundColor {
            set { backgroundColor = value; }
            get { return backgroundColor; }
        }

        public BackgroundImage BackgroundImage {
            set { backgroundImage = value; }
            get { return backgroundImage; }
        }

        public bool DisplayBones {
            set { displayBones = value; }
            get { return displayBones; }
        }

        public bool DisplayBoneNames {
            set { displayBoneNames = value; }
            get { return displayBoneNames; }
        }

        public bool DisplayTextures {
            set { displayTextures = value; }
            get { return displayTextures; }
        }

        public bool EnableBumpMaps {
            set { enableBumpMaps = value; }
            get { return enableBumpMaps; }
        }

        public bool DisplayWireframe {
            set { displayWireframe = value; }
            get { return displayWireframe; }
        }

        public bool BackFaceCulling {
            set { backFaceCulling = value; }
            get { return backFaceCulling; }
        }

        public bool AlwaysForceCulling {
            set { alwaysForceCulling = value; }
            get { return alwaysForceCulling; }
        }

        public bool DisplayGround {
            set { displayGround = value; }
            get { return displayGround; }
        }

        public bool UseAlternativeReflection {
            set { useAlternativeReflection = value; }
            get { return useAlternativeReflection; }
        }

        public bool DisplaySkyDome {
            set { displaySkyDome = value; }
            get { return displaySkyDome; }
        }

        public float SkyDomeRotation {
            set { skyDomeRotation = value; }
            get { return skyDomeRotation; }
        }

        public float SkyDomeElevation {
            set { skyDomeElevation = value; }
            get { return skyDomeElevation; }
        }

        public float Light1AngleHorizontal {
            set {
                light1AngleHorizontal = value;
                light1Direction =
                    CalculateLightDirection(
                        light1AngleHorizontal, 
                        light1AngleVertical);
            }
            get {
                return light1AngleHorizontal;
            }
        }

        public float Light1AngleVertical {
            set {
                light1AngleVertical = value;
                light1Direction = 
                    CalculateLightDirection(
                        light1AngleHorizontal, 
                        light1AngleVertical);
            }
            get {
                return light1AngleVertical;
            }
        }

        public Vector3 Light1Direction {
            set {
                light1Direction = value;
                light1Direction.Normalize();
                ExtractLightAngles(
                    light1Direction, 
                    out light1AngleHorizontal, 
                    out light1AngleVertical);
            }
            get {
                return light1Direction;
            }
        }

        public float Light1Intensity {
            set { light1Intensity = value; }
            get { return light1Intensity; }
        }

        public Color Light1Color {
            set { light1Color = value; }
            get { return light1Color; }
        }

        public float Light1ShadowDepth {
            set { 
                light1ShadowDepth = value;
                if (light1ShadowDepth < 0) {
                    light1ShadowDepth = 0;
                }
                if (light1ShadowDepth > 1) {
                    light1ShadowDepth = 1;
                }
            }
            get { return light1ShadowDepth; }
        }

        public float Light2AngleHorizontal {
            set {
                light2AngleHorizontal = value;
                light2Direction =
                    CalculateLightDirection(
                        light2AngleHorizontal,
                        light2AngleVertical);
            }
            get {
                return light2AngleHorizontal;
            }
        }

        public float Light2AngleVertical {
            set {
                light2AngleVertical = value;
                light2Direction =
                    CalculateLightDirection(
                        light2AngleHorizontal,
                        light2AngleVertical);
            }
            get {
                return light2AngleVertical;
            }
        }

        public Vector3 Light2Direction {
            set {
                light2Direction = value;
                light2Direction.Normalize();
                ExtractLightAngles(
                    light2Direction,
                    out light2AngleHorizontal,
                    out light2AngleVertical);
            }
            get {
                return light2Direction;
            }
        }

        public float Light2Intensity {
            set { light2Intensity = value; }
            get { return light2Intensity; }
        }

        public Color Light2Color {
            set { light2Color = value; }
            get { return light2Color; }
        }

        public float Light2ShadowDepth {
            set { 
                light2ShadowDepth = value;
                if (light2ShadowDepth < 0) {
                    light2ShadowDepth = 0;
                }
                if (light2ShadowDepth > 1) {
                    light2ShadowDepth = 1;
                }
            }
            get { return light2ShadowDepth; }
        }

        public float Light3AngleHorizontal {
            set {
                light3AngleHorizontal = value;
                light3Direction =
                    CalculateLightDirection(
                        light3AngleHorizontal,
                        light3AngleVertical);
            }
            get {
                return light3AngleHorizontal;
            }
        }

        public float Light3AngleVertical {
            set {
                light3AngleVertical = value;
                light3Direction =
                    CalculateLightDirection(
                        light3AngleHorizontal,
                        light3AngleVertical);
            }
            get {
                return light3AngleVertical;
            }
        }

        public Vector3 Light3Direction {
            set {
                light3Direction = value;
                light3Direction.Normalize();
                ExtractLightAngles(
                    light3Direction,
                    out light3AngleHorizontal,
                    out light3AngleVertical);
            }
            get {
                return light3Direction;
            }
        }

        public float Light3Intensity {
            set { light3Intensity = value; }
            get { return light3Intensity; }
        }

        public Color Light3Color {
            set { light3Color = value; }
            get { return light3Color; }
        }

        public float Light3ShadowDepth {
            set {
                light3ShadowDepth = value;
                if (light3ShadowDepth < 0) {
                    light3ShadowDepth = 0;
                }
                if (light3ShadowDepth > 1) {
                    light3ShadowDepth = 1;
                }
            }
            get { return light3ShadowDepth; }
        }

        public float PostProcessBrightness {
            get { return postProcessBrightness; }
            set { postProcessBrightness = value; }
        }

        public float PostProcessGamma {
            get { return postProcessGamma; }
            set { postProcessGamma = value; }
        }

        public float PostProcessContrast {
            get { return postProcessContrast; }
            set { postProcessContrast = value; }
        }

        public float PostProcessSaturation {
            get { return postProcessSaturation; }
            set { postProcessSaturation = value; }
        }

        public bool IsPostProcessingActive {
            get {
                return
                    postProcessBrightness != 1.0f ||
                    postProcessGamma != 1.0f ||
                    postProcessContrast != 1.0f ||
                    postProcessSaturation != 1.0f;
            }
        }

        private Vector3 CalculateLightDirection(float lightAngleHorizontal, float lightAngleVertical) {
            double t = MathHelper.ToRadians(lightAngleHorizontal);
            double f = Math.PI / 2 - MathHelper.ToRadians(lightAngleVertical);
            double x = Math.Cos(t) * Math.Sin(f);
            double y = Math.Sin(t) * Math.Sin(f);
            double z = Math.Cos(f);
            return -new Vector3((float)x, (float)z, (float)-y);
        }

        private void ExtractLightAngles(Vector3 lightDirection, out float lightAngleHorizontal, out float lightAngleVertical) {
            double x = -lightDirection.X;
            double y = lightDirection.Z;
            double z = -lightDirection.Y;
            double t = Math.Atan2(y, x);
            double f = Math.PI / 2 - Math.Acos(z / lightDirection.Length());
            lightAngleHorizontal = MathHelper.ToDegrees((float)t);
            lightAngleVertical = MathHelper.ToDegrees((float)f);
        }

        public void HandleItemAdded(Item item) {
            Model model = item.Model;
            armatures.Add(model.Armature);
            renderer.AddItem(item);
            boneSelector.AddModel(model);
        }

        public void HandleItemRemoved(Item item) {
            Model model = item.Model;
            armatures.Remove(model.Armature);
            renderer.RemoveItem(item);
            boneSelector.RemoveModel(model);
            foreach (Mesh mesh in model.Meshes) {
                textureManager.HandleMeshRemoved(mesh);
            }
        }

        private void WindowSizeChanged(object sender, EventArgs e) {
            WindowSizeChanged();
        }

        private void WindowSizeChanged() {
            Rectangle rect = this.Window.ClientBounds;
            if (boneSelector != null) {
                boneSelector.HandleWindowSizeChanged(rect.Width, rect.Height);
            }
            if (backgroundImage != null) {
                backgroundImage.HandleWindowResized(rect.Width, rect.Height);
            }
        }

        private void OnPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e) {
            GraphicsAdapter adapter = e.GraphicsDeviceInformation.Adapter;

            GraphicsDeviceCapabilities caps = adapter.GetCapabilities(DeviceType.Hardware);
            maxVertexShaderProfile = caps.MaxVertexShaderProfile;
            maxPixelShaderProfile = caps.MaxPixelShaderProfile;
            supportsShadersV3 = (maxVertexShaderProfile >= ShaderProfile.VS_3_0 && maxPixelShaderProfile >= ShaderProfile.PS_3_0);

            SurfaceFormat format = adapter.CurrentDisplayMode.Format;
            PresentationParameters presentParams = e.GraphicsDeviceInformation.PresentationParameters;
            if (adapter.CheckDeviceMultiSampleType(DeviceType.Hardware, format, false, MultiSampleType.EightSamples)) {
                presentParams.MultiSampleQuality = 0;
                presentParams.MultiSampleType = MultiSampleType.EightSamples;
                return;
            }
            if (adapter.CheckDeviceMultiSampleType(DeviceType.Hardware, format, false, MultiSampleType.FourSamples)) {
                presentParams.MultiSampleQuality = 0;
                presentParams.MultiSampleType = MultiSampleType.FourSamples;
                return;
            }
            if (adapter.CheckDeviceMultiSampleType(DeviceType.Hardware, format, false, MultiSampleType.TwoSamples)) {
                presentParams.MultiSampleQuality = 0;
                presentParams.MultiSampleType = MultiSampleType.TwoSamples;
                return;
            }
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            graphicsDeviceManager.PreferredBackBufferWidth = DefaultCanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = DefaultCanvasHeight;
            graphicsDeviceManager.IsFullScreen = false;
            graphicsDeviceManager.ApplyChanges();

            this.IsFixedTimeStep = false;
            this.IsMouseVisible = true;

            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            CheckContentDirectory();

            textureManager = new TextureManager(this);

            camera = new CameraTurnTable(this.GraphicsDevice, this.Window);
            ResetCamera(camera);

            ModelLoader modelLoader = new ModelLoader(this);

            boneSelector = new BoneSelector(this);

            ResetLights();

            ForceShadersV3 = LightingParamsDialog.DefaultForceShadersV3;

            ResetPostProcessParams();

            renderer = new Renderer(this);
            renderer.Init();

            hud = new HUD(this);

            controlGUI = new ControlGUI(this);
            if (splash == null) {
                controlGUI.TopMost = controlGUI.PreferredAlwaysOnTop;
            }
            controlGUI.Show();
        }


        public void ResetCamera(CameraTurnTable camera) {
            camera.SetClippingPlanes(0.05f, 150.0f);
            camera.FieldOfViewHorizontal = MathHelper.ToRadians(CameraParamsDialog.DefaultCameraFOV);
            camera.Target = CameraParamsDialog.DefaultCameraTarget;
            camera.Distance = CameraParamsDialog.DefaultCameraDistance;
            camera.SetRotation(MathHelper.ToRadians(CameraParamsDialog.DefaultCameraRotationHoriz), MathHelper.ToRadians(CameraParamsDialog.DefaultCameraRotationVert));
        }


        public void ResetLights() {
            Light1Direction = LightingParamsDialog.DefaultLight1Direction;
            Light1Intensity = LightingParamsDialog.DefaultLight1Intensity;
            Light1Color = LightingParamsDialog.DefaultLight1Color;
            Light1ShadowDepth = LightingParamsDialog.DefaultLight1ShadowDepth;

            Light2Direction = LightingParamsDialog.DefaultLight2Direction;
            Light2Intensity = LightingParamsDialog.DefaultLight2Intensity;
            Light2Color = LightingParamsDialog.DefaultLight2Color;
            Light2ShadowDepth = LightingParamsDialog.DefaultLight2ShadowDepth;

            Light3Direction = LightingParamsDialog.DefaultLight3Direction;
            Light3Intensity = LightingParamsDialog.DefaultLight3Intensity;
            Light3Color = LightingParamsDialog.DefaultLight3Color;
            Light3ShadowDepth = LightingParamsDialog.DefaultLight3ShadowDepth;
        }


        public void ResetPostProcessParams() {
            PostProcessBrightness = PostProcessParamsDialog.DefaultBrightness;
            PostProcessGamma = PostProcessParamsDialog.DefaultGamma;
            PostProcessContrast = PostProcessParamsDialog.DefaultContrast;
            PostProcessSaturation = PostProcessParamsDialog.DefaultSaturation;
        }


        private void CheckContentDirectory() {
            string currDir = Directory.GetCurrentDirectory();
            string contentDir = currDir + @"\Content";
            if (!Directory.Exists(contentDir)) {
                System.Windows.Forms.MessageBox.Show(
                    "Directory \"Content\" not found.\n" +
                    "Current directory: " + currDir + "\n",
                    "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            float deltaMilliseconds = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (hasFocus) {
                ProcessMouse(deltaMilliseconds);
                ProcessKeyboard(deltaMilliseconds);
            }

            foreach (Armature armature in armatures) {
                armature.UpdateBoneMatrices();
            }

            hud.Update(gameTime);

            base.Update(gameTime);
        }


        private void ProcessMouse(float deltaMilliseconds) {
            MouseState mouseState = Mouse.GetState();

            KeyboardState keyboardState = Keyboard.GetState();
            bool axisKeyPressed = keyboardState.IsKeyDown(Keys.NumPad1) ||
                                  keyboardState.IsKeyDown(Keys.NumPad2) ||
                                  keyboardState.IsKeyDown(Keys.NumPad3) ||
                                  keyboardState.IsKeyDown(Keys.Q) ||
                                  keyboardState.IsKeyDown(Keys.W) ||
                                  keyboardState.IsKeyDown(Keys.E);
            bool ctrlKeyPressed = keyboardState.IsKeyDown(Keys.LeftControl) ||
                                  keyboardState.IsKeyDown(Keys.RightControl);
            bool shiftKeyPressed = keyboardState.IsKeyDown(Keys.LeftShift) ||
                                   keyboardState.IsKeyDown(Keys.RightShift);
            bool altKeyPressed = keyboardState.IsKeyDown(Keys.LeftAlt) ||
                                 keyboardState.IsKeyDown(Keys.RightAlt);

            if (axisKeyPressed ||
                ctrlKeyPressed ||
                shiftKeyPressed ||
                altKeyPressed) {
                disableBoneSelection = true;
            }
            else {
                if (!mouseLeftDragging) {
                    disableBoneSelection = false;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed) {
                if (displayBones && !disableBoneSelection) {
                    Armature.Bone selectedBone = boneSelector.SelectedBone;
                    if (selectedBone != null) {
                        controlGUI.HandleBoneSelectedIn3D(selectedBone);
                    }
                }
                if (!mouseLeftDragging) {
                    mouseLeftDragging = true;
                    mouseAnchor = new Point(mouseState.X, mouseState.Y);
                }
            }
            else {
                mouseLeftDragging = false;
                disableBoneSelection = false;

                if (boneTransformActive) {
                    boneTransformActive = false;
                    controlGUI.UndoSaveInterrupt();
                }
            }

            if (mouseState.RightButton == ButtonState.Pressed) {
                if (!mouseRightDragging) {
                    mouseRightDragging = true;
                    mouseAnchor = new Point(mouseState.X, mouseState.Y);
                }
            }
            else {
                mouseRightDragging = false;
            }

            if (mouseLeftDragging && mouseRightDragging) {
                int dx = mouseState.X - mouseAnchor.X;
                int dy = mouseState.Y - mouseAnchor.Y;
                mouseAnchor = new Point(mouseState.X, mouseState.Y);

                if (!controlGUI.IsCameraLocked) {
                    camera.Target -= (camera.Left * dx - camera.Up * dy) * 0.005f;
                }
                return;
            }

            if (mouseLeftDragging) {
                int dx = mouseState.X - mouseAnchor.X;
                int dy = mouseState.Y - mouseAnchor.Y;
                mouseAnchor = new Point(mouseState.X, mouseState.Y);

                if (axisKeyPressed) {
                    Armature.Bone selectedBone = controlGUI.SelectedBone;
                    if (selectedBone != null) {
                        boneTransformActive = true;

                        if (keyboardState.IsKeyDown(Keys.NumPad1) ||
                            keyboardState.IsKeyDown(Keys.Q)) {
                            float angle = controlGUI.GetBoneRotationX(selectedBone);
                            controlGUI.HandleBoneRotationXChanged(selectedBone, angle + (dx + dy) * 0.5f);
                        }
                        if (keyboardState.IsKeyDown(Keys.NumPad2) ||
                            keyboardState.IsKeyDown(Keys.W)) {
                            float angle = controlGUI.GetBoneRotationY(selectedBone);
                            controlGUI.HandleBoneRotationYChanged(selectedBone, angle + (dx + dy) * 0.5f);
                        }
                        if (keyboardState.IsKeyDown(Keys.NumPad3) ||
                            keyboardState.IsKeyDown(Keys.E)) {
                            float angle = controlGUI.GetBoneRotationZ(selectedBone);
                            controlGUI.HandleBoneRotationZChanged(selectedBone, angle + (dx + dy) * 0.5f);
                        }
                    }
                    return;
                }

                if (ctrlKeyPressed) {
                    Item selectedItem = controlGUI.SelectedItem;
                    if (selectedItem != null) {
                        Vector3 point;
                        if (ProjectMouseToGround(mouseState.X, mouseState.Y, out point)) {
                            Armature armature = selectedItem.Model.Armature;
                            float height = armature.WorldTranslation.Y;
                            armature.WorldTranslation = new Vector3(point.X, height, point.Z);
                            controlGUI.HandlePositionChanged(armature.WorldTranslation);
                        }
                    }
                    return;
                }

                if (!controlGUI.IsCameraLocked) {
                    if (shiftKeyPressed) {
                        camera.Target -= (camera.Left * dx - camera.Up * dy) * 0.005f;
                        return;
                    }
                    float rotationHorizontal = camera.RotationHorizontal - dx * 0.01f;
                    float rotationVertical = camera.RotationVertical + dy * 0.01f;
                    camera.SetRotation(rotationHorizontal, rotationVertical);
                }
            }

            if (mouseRightDragging) {
                if (!controlGUI.IsCameraLocked) {
                    int dy = mouseState.Y - mouseAnchor.Y;
                    mouseAnchor = new Point(mouseState.X, mouseState.Y);
                    if (!shiftKeyPressed) {
                        camera.Distance += dy * 0.01f;
                    }
                    else {
                        camera.Target -= camera.Forward * dy * 0.005f;
                    }
                }
            }

            if (!mouseLeftDragging && !mouseRightDragging) {
                boneSelector.HandleMouseMoved(mouseState.X, mouseState.Y);
            }

            if (mouseWheel != mouseState.ScrollWheelValue) {
                if (!controlGUI.IsCameraLocked) {
                    int delta = mouseWheel - mouseState.ScrollWheelValue;
                    camera.Distance += delta * 0.002f;
                }
                mouseWheel = mouseState.ScrollWheelValue;
            }
        }


        private void ProcessKeyboard(float deltaMilliseconds) {
            KeyboardState keyboardState = Keyboard.GetState();

            KeyboardEventHandler.ProcessKeyboardState(keyboardState);

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.NumPad0)) {
                Armature.Bone selectedBone = controlGUI.SelectedBone;
                if (selectedBone != null) {
                    controlGUI.HandleBoneRotationXChanged(selectedBone, 0);
                    controlGUI.HandleBoneRotationYChanged(selectedBone, 0);
                    controlGUI.HandleBoneRotationZChanged(selectedBone, 0);
                }
            }

            bool ctrlKeyPressed = keyboardState.IsKeyDown(Keys.LeftControl) ||
                                  keyboardState.IsKeyDown(Keys.RightControl);
            bool shiftKeyPressed = keyboardState.IsKeyDown(Keys.LeftShift) ||
                                   keyboardState.IsKeyDown(Keys.RightShift);
            bool altKeyPressed = keyboardState.IsKeyDown(Keys.LeftAlt) ||
                                 keyboardState.IsKeyDown(Keys.RightAlt);

            if (keyboardState.IsKeyDown(Keys.Up) ||
                keyboardState.IsKeyDown(Keys.Down) ||
                keyboardState.IsKeyDown(Keys.Left) ||
                keyboardState.IsKeyDown(Keys.Right)) {
                Item selectedItem = controlGUI.SelectedItem;
                if (selectedItem != null) {
                    Armature armature = selectedItem.Model.Armature;
                    float speed = shiftKeyPressed ? 3e-3f : 1e-3f;
                    if (!altKeyPressed) {
                        Vector3 dir = Vector3.Zero;
                        if (keyboardState.IsKeyDown(Keys.Up)) {
                            dir += DetermineMovementVector(Keys.Up);
                        }
                        if (keyboardState.IsKeyDown(Keys.Down)) {
                            dir += DetermineMovementVector(Keys.Down);
                        }
                        if (keyboardState.IsKeyDown(Keys.Left)) {
                            dir += DetermineMovementVector(Keys.Left);
                        }
                        if (keyboardState.IsKeyDown(Keys.Right)) {
                            dir += DetermineMovementVector(Keys.Right);
                        }
                        armature.WorldTranslation += dir * speed;
                        controlGUI.HandlePositionChanged(armature.WorldTranslation);
                    }
                    else {
                        float dir = 0;
                        if (keyboardState.IsKeyDown(Keys.Up)) {
                            dir += 1;
                        }
                        if (keyboardState.IsKeyDown(Keys.Down)) {
                            dir -= 1;
                        }
                        float height = armature.WorldTranslation.Y;
                        height += dir * speed;
                        controlGUI.HandleHeightChanged(height);
                    }
                }
            }

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.F2)) {
                cameraSavedState = camera.CameraState;
                hud.Message = "camera state saved";
            }

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.F3)) {
                if (cameraSavedState != null) {
                    camera.CameraState = cameraSavedState;
                    hud.Message = "camera state loaded";
                }
            }

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.F5)) {
                controlGUI.QuickSaveImage();
            }

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.F8)) {
                controlGUI.ReloadTextures();
            }

            if (KeyboardEventHandler.HasKeyBeenPressed(Keys.F12)) {
                if (controlGUI.IsDisposed) {
                    controlGUI = new ControlGUI(this);
                }
                controlGUI.Show();
            }

            if (!controlGUI.IsCameraLocked) {
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D1)) {
                    controlGUI.SetCameraPivot(0);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D2)) {
                    controlGUI.SetCameraPivot(1);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D3)) {
                    controlGUI.SetCameraPivot(2);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D4)) {
                    controlGUI.SetCameraPivot(3);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D5)) {
                    controlGUI.SetCameraPivot(4);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D6)) {
                    controlGUI.SetCameraPivot(5);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D7)) {
                    controlGUI.SetCameraPivot(6);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D8)) {
                    controlGUI.SetCameraPivot(7);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D9)) {
                    controlGUI.SetCameraPivot(8);
                }
                if (KeyboardEventHandler.HasKeyBeenPressed(Keys.D0)) {
                    controlGUI.SetCameraPivot(9);
                }
            }

            if (ctrlKeyPressed && KeyboardEventHandler.HasKeyBeenPressed(Keys.Z) ||
                KeyboardEventHandler.HasKeyBeenPressed(Keys.NumPad5)) {
                controlGUI.Undo();
            }
        }


        private bool ProjectMouseToGround(int mouseX, int mouseY, out Vector3 point) {
            Vector3 pointNear = new Vector3(mouseX, mouseY, 0);
            Vector3 pointFar = new Vector3(mouseX, mouseY, 1);
            Viewport viewport = this.GraphicsDevice.Viewport;
            pointNear = viewport.Unproject(pointNear, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
            pointFar = viewport.Unproject(pointFar, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
            Vector3 direction = pointFar - pointNear;
            direction.Normalize();
            Ray ray = new Ray(pointNear, direction);
            Plane groundPlane = new Plane(Vector3.Up, 0);
            Nullable<float> result = ray.Intersects(groundPlane);
            if (!result.HasValue) {
                point = Vector3.Zero;
                return false;
            }
            float t = result.Value;
            if (t < 0 || t > 200) {
                point = Vector3.Zero;
                return false;
            }
            point = pointNear + direction * t;
            return true;
        }


        public void CameraPivotChangedInGUI(Vector3 lookAt) {
            camera.Target = lookAt;
        }


        private Vector3 DetermineMovementVector(Keys keyPressed) {
            Direction cameraDir = DetermineCameraPrincipalDirection();
            switch (cameraDir) {
                case Direction.XPositive:
                    switch (keyPressed) {
                        case Keys.Up:
                            return Vector3.Right;
                        case Keys.Down:
                            return Vector3.Left;
                        case Keys.Left:
                            return Vector3.Forward;
                        case Keys.Right:
                            return Vector3.Backward;
                    }
                    break;
                case Direction.XNegative:
                    switch (keyPressed) {
                        case Keys.Up:
                            return Vector3.Left;
                        case Keys.Down:
                            return Vector3.Right;
                        case Keys.Left:
                            return Vector3.Backward;
                        case Keys.Right:
                            return Vector3.Forward;
                    }
                    break;
                case Direction.ZPositive:
                    switch (keyPressed) {
                        case Keys.Up:
                            return Vector3.Backward;
                        case Keys.Down:
                            return Vector3.Forward;
                        case Keys.Left:
                            return Vector3.Right;
                        case Keys.Right:
                            return Vector3.Left;
                    }
                    break;
                case Direction.ZNegative:
                    switch (keyPressed) {
                        case Keys.Up:
                            return Vector3.Forward;
                        case Keys.Down:
                            return Vector3.Backward;
                        case Keys.Left:
                            return Vector3.Left;
                        case Keys.Right:
                            return Vector3.Right;
                    }
                    break;
            }
            return Vector3.Zero;
        }


        private Direction DetermineCameraPrincipalDirection() {
            Vector3 dir = camera.Target - camera.Position;
            if (Math.Abs(dir.X) > Math.Abs(dir.Z)) {
                return dir.X > 0 ? 
                    Direction.XPositive : 
                    Direction.XNegative;
            }
            else {
                return dir.Z > 0 ?
                    Direction.ZPositive :
                    Direction.ZNegative;
            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            this.GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, 
                                      backgroundColor, 1.0f, 0);
            if (backgroundImage != null) {
                renderer.RenderBackgroundImage(0, 0, 0, 0, backgroundImage.ScaleX, backgroundImage.ScaleY);
            }

            renderer.RenderSceneFull(false);

            if (IsPostProcessingActive) {
                renderer.ApplyPostProcessing();
            }

            if (displayBones) {
                boneSelector.Render();
            }

            hud.Render();

            base.Draw(gameTime);
        }


        private void OnFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            e.Cancel = !forceExit;
        }


        public void ForceExit() {
            forceExit = true;
            this.Exit();
        }


        private enum Direction
        {
            Undefined,
            XPositive, XNegative,
            YPositive, YNegative,
            ZPositive, ZNegative
        }
    }
}
