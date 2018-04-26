namespace XNALara
{
    public partial class ControlGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.buttonResetBoneXYZ = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneSelectedModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadTexturesOfSelectedModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetPoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadPoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.resetSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSaveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportObjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMeshAsciiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMeshAsciiPosedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorPoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipPoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mirrorModelXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorModelYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorModelZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.setBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.displayBonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayBoneNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.displayTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableBumpMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.displayWireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backFaceCullingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysForceCullingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useAlternativeReflectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skydomeParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lightingParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postprocessingParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.displayAccessoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handgunsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayHandGunHandLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayHandGunHandRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayHandGunHolsterLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayHandGunHolsterRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGearBeltMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGearGauntletLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGearGauntletRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGlowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGlowBeltMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGlowGauntletLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayThorGlowGauntletRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGlowLeftColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGlowRightColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dWindowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAddModelMultiSelectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCameraPivot = new System.Windows.Forms.Label();
            this.comboBoxCameraPivot = new System.Windows.Forms.ComboBox();
            this.treeViewBones = new System.Windows.Forms.TreeView();
            this.buttonResetX = new System.Windows.Forms.Button();
            this.buttonResetY = new System.Windows.Forms.Button();
            this.buttonResetZ = new System.Windows.Forms.Button();
            this.labelItem = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.checkBoxLockItem = new System.Windows.Forms.CheckBox();
            this.checkBoxLockCamera = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxItemVisible = new System.Windows.Forms.CheckBox();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.labelH = new System.Windows.Forms.Label();
            this.buttonResetH = new System.Windows.Forms.Button();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.labelScale = new System.Windows.Forms.Label();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.buttonBoneMode = new System.Windows.Forms.Button();
            this.labelPosition = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.buttonResetPos = new System.Windows.Forms.Button();
            this.buttonResetScale = new System.Windows.Forms.Button();
            this.buttonLookIntoCamera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(285, 52);
            this.trackBarX.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarX.Maximum = 180;
            this.trackBarX.Minimum = -180;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarX.Size = new System.Drawing.Size(61, 374);
            this.trackBarX.TabIndex = 1;
            this.trackBarX.TickFrequency = 5;
            this.trackBarX.Scroll += new System.EventHandler(this.TrackBarXScroll);
            this.trackBarX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarXMouseUp);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(327, 52);
            this.trackBarY.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarY.Maximum = 180;
            this.trackBarY.Minimum = -180;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(61, 374);
            this.trackBarY.TabIndex = 2;
            this.trackBarY.TickFrequency = 5;
            this.trackBarY.Scroll += new System.EventHandler(this.TrackBarYScroll);
            this.trackBarY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarYMouseUp);
            // 
            // trackBarZ
            // 
            this.trackBarZ.Location = new System.Drawing.Point(369, 52);
            this.trackBarZ.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarZ.Maximum = 180;
            this.trackBarZ.Minimum = -180;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZ.Size = new System.Drawing.Size(61, 374);
            this.trackBarZ.TabIndex = 3;
            this.trackBarZ.TickFrequency = 5;
            this.trackBarZ.Scroll += new System.EventHandler(this.TrackBarZScroll);
            this.trackBarZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarZMouseUp);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(283, 33);
            this.labelX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(45, 17);
            this.labelX.TabIndex = 20;
            this.labelX.Text = "X axis";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(325, 33);
            this.labelY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(45, 17);
            this.labelY.TabIndex = 19;
            this.labelY.Text = "Y axis";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(367, 33);
            this.labelZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(45, 17);
            this.labelZ.TabIndex = 18;
            this.labelZ.Text = "Z axis";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(285, 461);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(35, 22);
            this.textBoxX.TabIndex = 5;
            this.textBoxX.Validated += new System.EventHandler(this.TextBoxXValidated);
            this.textBoxX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxXKeyPress);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(327, 461);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(35, 22);
            this.textBoxY.TabIndex = 6;
            this.textBoxY.Validated += new System.EventHandler(this.TextBoxYValidated);
            this.textBoxY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxYKeyPress);
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(369, 461);
            this.textBoxZ.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(35, 22);
            this.textBoxZ.TabIndex = 7;
            this.textBoxZ.Validated += new System.EventHandler(this.TextBoxZValidated);
            this.textBoxZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxZKeyPress);
            // 
            // buttonResetBoneXYZ
            // 
            this.buttonResetBoneXYZ.Location = new System.Drawing.Point(285, 487);
            this.buttonResetBoneXYZ.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetBoneXYZ.Name = "buttonResetBoneXYZ";
            this.buttonResetBoneXYZ.Size = new System.Drawing.Size(161, 27);
            this.buttonResetBoneXYZ.TabIndex = 14;
            this.buttonResetBoneXYZ.TabStop = false;
            this.buttonResetBoneXYZ.Text = "Reset selected bone";
            this.buttonResetBoneXYZ.UseVisualStyleBackColor = true;
            this.buttonResetBoneXYZ.Click += new System.EventHandler(this.ButtonResetXYZClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(462, 29);
            this.menuStrip.TabIndex = 25;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.cloneSelectedModelToolStripMenuItem,
            this.removeSelectedItemToolStripMenuItem,
            this.reloadTexturesOfSelectedModelToolStripMenuItem,
            this.toolStripSeparator4,
            this.resetPoseToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadPoseToolStripMenuItem,
            this.savePoseToolStripMenuItem,
            this.toolStripSeparator12,
            this.resetSceneToolStripMenuItem,
            this.loadSceneToolStripMenuItem,
            this.saveSceneToolStripMenuItem,
            this.toolStripSeparator8,
            this.saveImageToolStripMenuItem,
            this.quickSaveImageToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportObjToolStripMenuItem,
            this.exportMeshAsciiToolStripMenuItem,
            this.exportMeshAsciiPosedToolStripMenuItem,
            this.toolStripSeparator10,
            this.exitToolStripMenuItem,
            this.undoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.addItemToolStripMenuItem.Text = "Add model(s) ...";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.AddItemMenuItemClick);
            // 
            // cloneSelectedModelToolStripMenuItem
            // 
            this.cloneSelectedModelToolStripMenuItem.Name = "cloneSelectedModelToolStripMenuItem";
            this.cloneSelectedModelToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.cloneSelectedModelToolStripMenuItem.Text = "Clone selected model";
            this.cloneSelectedModelToolStripMenuItem.Click += new System.EventHandler(this.CloneSelectedItemMenuItemClick);
            // 
            // removeSelectedItemToolStripMenuItem
            // 
            this.removeSelectedItemToolStripMenuItem.Name = "removeSelectedItemToolStripMenuItem";
            this.removeSelectedItemToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.removeSelectedItemToolStripMenuItem.Text = "Remove selected model";
            this.removeSelectedItemToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectedItemMenuItemClick);
            // 
            // reloadTexturesOfSelectedModelToolStripMenuItem
            // 
            this.reloadTexturesOfSelectedModelToolStripMenuItem.Name = "reloadTexturesOfSelectedModelToolStripMenuItem";
            this.reloadTexturesOfSelectedModelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.reloadTexturesOfSelectedModelToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.reloadTexturesOfSelectedModelToolStripMenuItem.Text = "Reload textures of selected model";
            this.reloadTexturesOfSelectedModelToolStripMenuItem.Click += new System.EventHandler(this.ReloadTexturesOfSelectedModelMenuItemClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(409, 6);
            // 
            // resetPoseToolStripMenuItem
            // 
            this.resetPoseToolStripMenuItem.Name = "resetPoseToolStripMenuItem";
            this.resetPoseToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.resetPoseToolStripMenuItem.Text = "Reset selected pose";
            this.resetPoseToolStripMenuItem.Click += new System.EventHandler(this.ResetPoseMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(409, 6);
            // 
            // loadPoseToolStripMenuItem
            // 
            this.loadPoseToolStripMenuItem.Name = "loadPoseToolStripMenuItem";
            this.loadPoseToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.loadPoseToolStripMenuItem.Text = "Load pose ...";
            this.loadPoseToolStripMenuItem.Click += new System.EventHandler(this.LoadPoseMenuItemClick);
            // 
            // savePoseToolStripMenuItem
            // 
            this.savePoseToolStripMenuItem.Name = "savePoseToolStripMenuItem";
            this.savePoseToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.savePoseToolStripMenuItem.Text = "Save selected pose ...";
            this.savePoseToolStripMenuItem.Click += new System.EventHandler(this.SavePoseMenuItemClick);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(409, 6);
            // 
            // resetSceneToolStripMenuItem
            // 
            this.resetSceneToolStripMenuItem.Name = "resetSceneToolStripMenuItem";
            this.resetSceneToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.resetSceneToolStripMenuItem.Text = "Reset scene";
            this.resetSceneToolStripMenuItem.Click += new System.EventHandler(this.ResetSceneMenuItemClick);
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.loadSceneToolStripMenuItem.Text = "Load scene ...";
            this.loadSceneToolStripMenuItem.Click += new System.EventHandler(this.LoadSceneMenuItemClick);
            // 
            // saveSceneToolStripMenuItem
            // 
            this.saveSceneToolStripMenuItem.Name = "saveSceneToolStripMenuItem";
            this.saveSceneToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.saveSceneToolStripMenuItem.Text = "Save scene ...";
            this.saveSceneToolStripMenuItem.Click += new System.EventHandler(this.SaveSceneMenuItemClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(409, 6);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.saveImageToolStripMenuItem.Text = "Save image ...";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.SaveImageMenuItemClick);
            // 
            // quickSaveImageToolStripMenuItem
            // 
            this.quickSaveImageToolStripMenuItem.Name = "quickSaveImageToolStripMenuItem";
            this.quickSaveImageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.quickSaveImageToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.quickSaveImageToolStripMenuItem.Text = "Quick-save image";
            this.quickSaveImageToolStripMenuItem.Click += new System.EventHandler(this.QuickSaveImageMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(409, 6);
            // 
            // exportObjToolStripMenuItem
            // 
            this.exportObjToolStripMenuItem.Name = "exportObjToolStripMenuItem";
            this.exportObjToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.exportObjToolStripMenuItem.Text = "Export scene as .obj ...";
            this.exportObjToolStripMenuItem.Click += new System.EventHandler(this.ExportObjMenuItemClick);
            // 
            // exportMeshAsciiToolStripMenuItem
            // 
            this.exportMeshAsciiToolStripMenuItem.Name = "exportMeshAsciiToolStripMenuItem";
            this.exportMeshAsciiToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.exportMeshAsciiToolStripMenuItem.Text = "Export selected as .mesh.ascii (T-pose) ...";
            this.exportMeshAsciiToolStripMenuItem.Click += new System.EventHandler(this.ExportMeshAsciiMenuItemClick);
            // 
            // exportMeshAsciiPosedToolStripMenuItem
            // 
            this.exportMeshAsciiPosedToolStripMenuItem.Name = "exportMeshAsciiPosedToolStripMenuItem";
            this.exportMeshAsciiPosedToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.exportMeshAsciiPosedToolStripMenuItem.Text = "Export selected as .mesh.ascii (posed) ...";
            this.exportMeshAsciiPosedToolStripMenuItem.Click += new System.EventHandler(this.ExportMeshAsciiPosedMenuItemClick);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(409, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(412, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Visible = false;
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Crimson;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(51, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.controlsToolStripMenuItem.Text = "3D window controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.ControlsMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutMenuItemClick);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mirrorPoseToolStripMenuItem,
            this.flipPoseToolStripMenuItem,
            this.toolStripSeparator1,
            this.mirrorModelXToolStripMenuItem,
            this.mirrorModelYToolStripMenuItem,
            this.mirrorModelZToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(104, 25);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // mirrorPoseToolStripMenuItem
            // 
            this.mirrorPoseToolStripMenuItem.Name = "mirrorPoseToolStripMenuItem";
            this.mirrorPoseToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.mirrorPoseToolStripMenuItem.Text = "Mirror (copy) pose left/right";
            this.mirrorPoseToolStripMenuItem.Click += new System.EventHandler(this.MirrorPoseMenuItemClick);
            // 
            // flipPoseToolStripMenuItem
            // 
            this.flipPoseToolStripMenuItem.Name = "flipPoseToolStripMenuItem";
            this.flipPoseToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.flipPoseToolStripMenuItem.Text = "Flip (swap) pose left/right";
            this.flipPoseToolStripMenuItem.Click += new System.EventHandler(this.FlipPoseMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // mirrorModelXToolStripMenuItem
            // 
            this.mirrorModelXToolStripMenuItem.Name = "mirrorModelXToolStripMenuItem";
            this.mirrorModelXToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.mirrorModelXToolStripMenuItem.Text = "Mirror model X";
            this.mirrorModelXToolStripMenuItem.Click += new System.EventHandler(this.MirrorModelXMenuItemClick);
            // 
            // mirrorModelYToolStripMenuItem
            // 
            this.mirrorModelYToolStripMenuItem.Name = "mirrorModelYToolStripMenuItem";
            this.mirrorModelYToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.mirrorModelYToolStripMenuItem.Text = "Mirror model Y";
            this.mirrorModelYToolStripMenuItem.Click += new System.EventHandler(this.MirrorModelYMenuItemClick);
            // 
            // mirrorModelZToolStripMenuItem
            // 
            this.mirrorModelZToolStripMenuItem.Name = "mirrorModelZToolStripMenuItem";
            this.mirrorModelZToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.mirrorModelZToolStripMenuItem.Text = "Mirror model Z";
            this.mirrorModelZToolStripMenuItem.Click += new System.EventHandler(this.MirrorModelZMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator9,
            this.setBackgroundColorToolStripMenuItem,
            this.assignBackgroundImageToolStripMenuItem,
            this.removeBackgroundImageToolStripMenuItem,
            this.toolStripSeparator5,
            this.displayBonesToolStripMenuItem,
            this.displayBoneNamesToolStripMenuItem,
            this.toolStripSeparator11,
            this.displayTexturesToolStripMenuItem,
            this.enableBumpMapsToolStripMenuItem,
            this.toolStripSeparator13,
            this.displayWireframeToolStripMenuItem,
            this.backFaceCullingToolStripMenuItem,
            this.alwaysForceCullingToolStripMenuItem,
            this.displayGroundToolStripMenuItem,
            this.useAlternativeReflectionMenuItem,
            this.skydomeParametersToolStripMenuItem,
            this.toolStripSeparator6,
            this.lightingParamsToolStripMenuItem,
            this.cameraParametersToolStripMenuItem,
            this.postprocessingParametersToolStripMenuItem,
            this.toolStripSeparator7,
            this.displayAccessoriesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(79, 25);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOnTopMenuItemClick);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(368, 6);
            // 
            // setBackgroundColorToolStripMenuItem
            // 
            this.setBackgroundColorToolStripMenuItem.Name = "setBackgroundColorToolStripMenuItem";
            this.setBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.setBackgroundColorToolStripMenuItem.Text = "Set background color ...";
            this.setBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.SetBackgroundColorMenuItemClick);
            // 
            // assignBackgroundImageToolStripMenuItem
            // 
            this.assignBackgroundImageToolStripMenuItem.Name = "assignBackgroundImageToolStripMenuItem";
            this.assignBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.assignBackgroundImageToolStripMenuItem.Text = "Assign background image ...";
            this.assignBackgroundImageToolStripMenuItem.Click += new System.EventHandler(this.AssignBackgroundImageMenuItemClick);
            // 
            // removeBackgroundImageToolStripMenuItem
            // 
            this.removeBackgroundImageToolStripMenuItem.Name = "removeBackgroundImageToolStripMenuItem";
            this.removeBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.removeBackgroundImageToolStripMenuItem.Text = "Remove background image";
            this.removeBackgroundImageToolStripMenuItem.Click += new System.EventHandler(this.RemoveBackgroundImageMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(368, 6);
            // 
            // displayBonesToolStripMenuItem
            // 
            this.displayBonesToolStripMenuItem.Name = "displayBonesToolStripMenuItem";
            this.displayBonesToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayBonesToolStripMenuItem.Text = "Display bones";
            this.displayBonesToolStripMenuItem.Click += new System.EventHandler(this.DisplayBonesMenuItemClick);
            // 
            // displayBoneNamesToolStripMenuItem
            // 
            this.displayBoneNamesToolStripMenuItem.Name = "displayBoneNamesToolStripMenuItem";
            this.displayBoneNamesToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayBoneNamesToolStripMenuItem.Text = "Display bone names";
            this.displayBoneNamesToolStripMenuItem.Click += new System.EventHandler(this.DisplayBoneNamesMenuItemClick);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(368, 6);
            // 
            // displayTexturesToolStripMenuItem
            // 
            this.displayTexturesToolStripMenuItem.Name = "displayTexturesToolStripMenuItem";
            this.displayTexturesToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayTexturesToolStripMenuItem.Text = "Display textures";
            this.displayTexturesToolStripMenuItem.Click += new System.EventHandler(this.DisplayTexturesMenuItemClick);
            // 
            // enableBumpMapsToolStripMenuItem
            // 
            this.enableBumpMapsToolStripMenuItem.Name = "enableBumpMapsToolStripMenuItem";
            this.enableBumpMapsToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.enableBumpMapsToolStripMenuItem.Text = "Enable bump maps";
            this.enableBumpMapsToolStripMenuItem.Click += new System.EventHandler(this.EnableBumpMapsMenuItemClick);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(368, 6);
            // 
            // displayWireframeToolStripMenuItem
            // 
            this.displayWireframeToolStripMenuItem.Name = "displayWireframeToolStripMenuItem";
            this.displayWireframeToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayWireframeToolStripMenuItem.Text = "Display wireframe";
            this.displayWireframeToolStripMenuItem.Click += new System.EventHandler(this.DisplayWireframeMenuItemClick);
            // 
            // backFaceCullingToolStripMenuItem
            // 
            this.backFaceCullingToolStripMenuItem.Name = "backFaceCullingToolStripMenuItem";
            this.backFaceCullingToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.backFaceCullingToolStripMenuItem.Text = "Back-face culling";
            this.backFaceCullingToolStripMenuItem.Click += new System.EventHandler(this.BackFaceCullingMenuItemClick);
            // 
            // alwaysForceCullingToolStripMenuItem
            // 
            this.alwaysForceCullingToolStripMenuItem.Name = "alwaysForceCullingToolStripMenuItem";
            this.alwaysForceCullingToolStripMenuItem.Size = new System.Drawing.Size(324, 26);
            this.alwaysForceCullingToolStripMenuItem.Text = "Always force culling";
            this.alwaysForceCullingToolStripMenuItem.Click += new System.EventHandler(this.AlwaysForceCullingMenuItemClick);
            // 
            // displayGroundToolStripMenuItem
            // 
            this.displayGroundToolStripMenuItem.Name = "displayGroundToolStripMenuItem";
            this.displayGroundToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayGroundToolStripMenuItem.Text = "Display ground";
            this.displayGroundToolStripMenuItem.Click += new System.EventHandler(this.DisplayGroundMenuItemClick);
            // 
            // useAlternativeReflectionMenuItem
            // 
            this.useAlternativeReflectionMenuItem.Name = "useAlternativeReflectionMenuItem";
            this.useAlternativeReflectionMenuItem.Size = new System.Drawing.Size(371, 26);
            this.useAlternativeReflectionMenuItem.Text = "Use alternative reflection";
            this.useAlternativeReflectionMenuItem.Click += new System.EventHandler(this.UseAlternativeReflectionMenuItemClick);
            // 
            // skydomeParametersToolStripMenuItem
            // 
            this.skydomeParametersToolStripMenuItem.Name = "skydomeParametersToolStripMenuItem";
            this.skydomeParametersToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.skydomeParametersToolStripMenuItem.Text = "Skydome parameters ...";
            this.skydomeParametersToolStripMenuItem.Click += new System.EventHandler(this.SkyDomeParametersMenuItemClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(368, 6);
            // 
            // lightingParamsToolStripMenuItem
            // 
            this.lightingParamsToolStripMenuItem.Name = "lightingParamsToolStripMenuItem";
            this.lightingParamsToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.lightingParamsToolStripMenuItem.Text = "Lighting parameters ...";
            this.lightingParamsToolStripMenuItem.Click += new System.EventHandler(this.LightingParamsMenuItemClick);
            // 
            // cameraParametersToolStripMenuItem
            // 
            this.cameraParametersToolStripMenuItem.Name = "cameraParametersToolStripMenuItem";
            this.cameraParametersToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.cameraParametersToolStripMenuItem.Text = "Camera parameters ...";
            this.cameraParametersToolStripMenuItem.Click += new System.EventHandler(this.CameraParametersMenuItemClick);
            // 
            // postprocessingParametersToolStripMenuItem
            // 
            this.postprocessingParametersToolStripMenuItem.Name = "postprocessingParametersToolStripMenuItem";
            this.postprocessingParametersToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.postprocessingParametersToolStripMenuItem.Text = "Post-processing parameters ...";
            this.postprocessingParametersToolStripMenuItem.Click += new System.EventHandler(this.PostProcessParamsMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(368, 6);
            // 
            // displayAccessoriesToolStripMenuItem
            // 
            this.displayAccessoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handgunsToolStripMenuItem,
            this.displayThorGearMenuItem,
            this.displayThorGlowMenuItem});
            this.displayAccessoriesToolStripMenuItem.Name = "displayAccessoriesToolStripMenuItem";
            this.displayAccessoriesToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.displayAccessoriesToolStripMenuItem.Text = "Display accessories";
            // 
            // handgunsToolStripMenuItem
            // 
            this.handgunsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayHandGunHandLeftToolStripMenuItem,
            this.displayHandGunHandRightToolStripMenuItem,
            this.displayHandGunHolsterLeftToolStripMenuItem,
            this.displayHandGunHolsterRightToolStripMenuItem});
            this.handgunsToolStripMenuItem.Name = "handgunsToolStripMenuItem";
            this.handgunsToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.handgunsToolStripMenuItem.Text = "Handguns";
            // 
            // displayHandGunHandLeftToolStripMenuItem
            // 
            this.displayHandGunHandLeftToolStripMenuItem.Name = "displayHandGunHandLeftToolStripMenuItem";
            this.displayHandGunHandLeftToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.displayHandGunHandLeftToolStripMenuItem.Text = "Hand left";
            this.displayHandGunHandLeftToolStripMenuItem.Click += new System.EventHandler(this.DisplayHandGunHandLeftMenuItemClick);
            // 
            // displayHandGunHandRightToolStripMenuItem
            // 
            this.displayHandGunHandRightToolStripMenuItem.Name = "displayHandGunHandRightToolStripMenuItem";
            this.displayHandGunHandRightToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.displayHandGunHandRightToolStripMenuItem.Text = "Hand right";
            this.displayHandGunHandRightToolStripMenuItem.Click += new System.EventHandler(this.DisplayHandGunHandRightMenuItemClick);
            // 
            // displayHandGunHolsterLeftToolStripMenuItem
            // 
            this.displayHandGunHolsterLeftToolStripMenuItem.Name = "displayHandGunHolsterLeftToolStripMenuItem";
            this.displayHandGunHolsterLeftToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.displayHandGunHolsterLeftToolStripMenuItem.Text = "Holster left";
            this.displayHandGunHolsterLeftToolStripMenuItem.Click += new System.EventHandler(this.DisplayHandGunHolsterLeftMenuItemClick);
            // 
            // displayHandGunHolsterRightToolStripMenuItem
            // 
            this.displayHandGunHolsterRightToolStripMenuItem.Name = "displayHandGunHolsterRightToolStripMenuItem";
            this.displayHandGunHolsterRightToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.displayHandGunHolsterRightToolStripMenuItem.Text = "Holster right";
            this.displayHandGunHolsterRightToolStripMenuItem.Click += new System.EventHandler(this.DisplayHandGunHolsterRightMenuItemClick);
            // 
            // displayThorGearMenuItem
            // 
            this.displayThorGearMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayThorGearBeltMenuItem,
            this.displayThorGearGauntletLeftMenuItem,
            this.displayThorGearGauntletRightMenuItem});
            this.displayThorGearMenuItem.Name = "displayThorGearMenuItem";
            this.displayThorGearMenuItem.Size = new System.Drawing.Size(221, 26);
            this.displayThorGearMenuItem.Text = "Thor\'s gear";
            // 
            // displayThorGearBeltMenuItem
            // 
            this.displayThorGearBeltMenuItem.Name = "displayThorGearBeltMenuItem";
            this.displayThorGearBeltMenuItem.Size = new System.Drawing.Size(199, 26);
            this.displayThorGearBeltMenuItem.Text = "Belt";
            this.displayThorGearBeltMenuItem.Click += new System.EventHandler(this.DisplayThorGearBeltMenuItemClick);
            // 
            // displayThorGearGauntletLeftMenuItem
            // 
            this.displayThorGearGauntletLeftMenuItem.Name = "displayThorGearGauntletLeftMenuItem";
            this.displayThorGearGauntletLeftMenuItem.Size = new System.Drawing.Size(199, 26);
            this.displayThorGearGauntletLeftMenuItem.Text = "Gauntlet left";
            this.displayThorGearGauntletLeftMenuItem.Click += new System.EventHandler(this.DisplayThorGearGauntletLeftMenuItemClick);
            // 
            // displayThorGearGauntletRightMenuItem
            // 
            this.displayThorGearGauntletRightMenuItem.Name = "displayThorGearGauntletRightMenuItem";
            this.displayThorGearGauntletRightMenuItem.Size = new System.Drawing.Size(199, 26);
            this.displayThorGearGauntletRightMenuItem.Text = "Gauntlet right";
            this.displayThorGearGauntletRightMenuItem.Click += new System.EventHandler(this.DisplayThorGearGauntletRightMenuItemClick);
            // 
            // displayThorGlowMenuItem
            // 
            this.displayThorGlowMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayThorGlowBeltMenuItem,
            this.displayThorGlowGauntletLeftMenuItem,
            this.displayThorGlowGauntletRightMenuItem,
            this.setGlowLeftColorMenuItem,
            this.setGlowRightColorMenuItem});
            this.displayThorGlowMenuItem.Name = "displayThorGlowMenuItem";
            this.displayThorGlowMenuItem.Size = new System.Drawing.Size(221, 26);
            this.displayThorGlowMenuItem.Text = "Thor\'s gear glow";
            // 
            // displayThorGlowBeltMenuItem
            // 
            this.displayThorGlowBeltMenuItem.Name = "displayThorGlowBeltMenuItem";
            this.displayThorGlowBeltMenuItem.Size = new System.Drawing.Size(234, 26);
            this.displayThorGlowBeltMenuItem.Text = "Belt";
            this.displayThorGlowBeltMenuItem.Click += new System.EventHandler(this.DisplayThorGlowBeltMenuItemClick);
            // 
            // displayThorGlowGauntletLeftMenuItem
            // 
            this.displayThorGlowGauntletLeftMenuItem.Name = "displayThorGlowGauntletLeftMenuItem";
            this.displayThorGlowGauntletLeftMenuItem.Size = new System.Drawing.Size(234, 26);
            this.displayThorGlowGauntletLeftMenuItem.Text = "Gauntlet left";
            this.displayThorGlowGauntletLeftMenuItem.Click += new System.EventHandler(this.DisplayThorGlowGauntletLeftGlowMenuItemClick);
            // 
            // displayThorGlowGauntletRightMenuItem
            // 
            this.displayThorGlowGauntletRightMenuItem.Name = "displayThorGlowGauntletRightMenuItem";
            this.displayThorGlowGauntletRightMenuItem.Size = new System.Drawing.Size(234, 26);
            this.displayThorGlowGauntletRightMenuItem.Text = "Gauntlet right";
            this.displayThorGlowGauntletRightMenuItem.Click += new System.EventHandler(this.DisplayThorGlowGauntletRightGlowMenuItemClick);
            // 
            // setGlowLeftColorMenuItem
            // 
            this.setGlowLeftColorMenuItem.Name = "setGlowLeftColorMenuItem";
            this.setGlowLeftColorMenuItem.Size = new System.Drawing.Size(234, 26);
            this.setGlowLeftColorMenuItem.Text = "Glow left color ...";
            this.setGlowLeftColorMenuItem.Click += new System.EventHandler(this.SetGlowLeftColorMenuItemClick);
            // 
            // setGlowRightColorMenuItem
            // 
            this.setGlowRightColorMenuItem.Name = "setGlowRightColorMenuItem";
            this.setGlowRightColorMenuItem.Size = new System.Drawing.Size(234, 26);
            this.setGlowRightColorMenuItem.Text = "Glow right color ...";
            this.setGlowRightColorMenuItem.Click += new System.EventHandler(this.SetGlowRightColorMenuItemClick);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dWindowSizeToolStripMenuItem,
            this.enableAddModelMultiSelectMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(81, 25);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // dWindowSizeToolStripMenuItem
            // 
            this.dWindowSizeToolStripMenuItem.Name = "dWindowSizeToolStripMenuItem";
            this.dWindowSizeToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.dWindowSizeToolStripMenuItem.Text = "3D canvas size ...";
            this.dWindowSizeToolStripMenuItem.Click += new System.EventHandler(this.CanvasSizeMenuItemClick);
            // 
            // enableAddModelMultiSelectMenuItem
            // 
            this.enableAddModelMultiSelectMenuItem.Name = "enableAddModelMultiSelectMenuItem";
            this.enableAddModelMultiSelectMenuItem.Size = new System.Drawing.Size(262, 26);
            this.enableAddModelMultiSelectMenuItem.Text = "AddModel multi-select";
            this.enableAddModelMultiSelectMenuItem.Click += new System.EventHandler(this.EnableAddModelMultiSelectMenuItemClick);
            // 
            // labelCameraPivot
            // 
            this.labelCameraPivot.AutoSize = true;
            this.labelCameraPivot.Location = new System.Drawing.Point(8, 524);
            this.labelCameraPivot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCameraPivot.Name = "labelCameraPivot";
            this.labelCameraPivot.Size = new System.Drawing.Size(95, 17);
            this.labelCameraPivot.TabIndex = 13;
            this.labelCameraPivot.Text = "Camera pivot:";
            // 
            // comboBoxCameraPivot
            // 
            this.comboBoxCameraPivot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraPivot.FormattingEnabled = true;
            this.comboBoxCameraPivot.Location = new System.Drawing.Point(107, 521);
            this.comboBoxCameraPivot.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCameraPivot.Name = "comboBoxCameraPivot";
            this.comboBoxCameraPivot.Size = new System.Drawing.Size(112, 24);
            this.comboBoxCameraPivot.TabIndex = 12;
            this.comboBoxCameraPivot.TabStop = false;
            this.comboBoxCameraPivot.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCameraPivotSelectedIndexChanged);
            // 
            // treeViewBones
            // 
            this.treeViewBones.HideSelection = false;
            this.treeViewBones.Location = new System.Drawing.Point(11, 145);
            this.treeViewBones.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewBones.Name = "treeViewBones";
            this.treeViewBones.Size = new System.Drawing.Size(260, 369);
            this.treeViewBones.TabIndex = 11;
            this.treeViewBones.TabStop = false;
            this.treeViewBones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterSelect);
            // 
            // buttonResetX
            // 
            this.buttonResetX.Location = new System.Drawing.Point(285, 430);
            this.buttonResetX.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetX.Name = "buttonResetX";
            this.buttonResetX.Size = new System.Drawing.Size(35, 27);
            this.buttonResetX.TabIndex = 10;
            this.buttonResetX.TabStop = false;
            this.buttonResetX.Text = "0";
            this.buttonResetX.UseVisualStyleBackColor = true;
            this.buttonResetX.Click += new System.EventHandler(this.ButtonResetXClick);
            // 
            // buttonResetY
            // 
            this.buttonResetY.Location = new System.Drawing.Point(327, 430);
            this.buttonResetY.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetY.Name = "buttonResetY";
            this.buttonResetY.Size = new System.Drawing.Size(35, 27);
            this.buttonResetY.TabIndex = 9;
            this.buttonResetY.TabStop = false;
            this.buttonResetY.Text = "0";
            this.buttonResetY.UseVisualStyleBackColor = true;
            this.buttonResetY.Click += new System.EventHandler(this.ButtonResetYClick);
            // 
            // buttonResetZ
            // 
            this.buttonResetZ.Location = new System.Drawing.Point(369, 430);
            this.buttonResetZ.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetZ.Name = "buttonResetZ";
            this.buttonResetZ.Size = new System.Drawing.Size(35, 27);
            this.buttonResetZ.TabIndex = 8;
            this.buttonResetZ.TabStop = false;
            this.buttonResetZ.Text = "0";
            this.buttonResetZ.UseVisualStyleBackColor = true;
            this.buttonResetZ.Click += new System.EventHandler(this.ButtonResetZClick);
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(7, 33);
            this.labelItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(50, 17);
            this.labelItem.TabIndex = 7;
            this.labelItem.Text = "Model:";
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(61, 30);
            this.comboBoxItem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(210, 24);
            this.comboBoxItem.TabIndex = 6;
            this.comboBoxItem.TabStop = false;
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.ComboBoxItemSelectedIndexChanged);
            // 
            // checkBoxLockItem
            // 
            this.checkBoxLockItem.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLockItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxLockItem.Location = new System.Drawing.Point(70, 114);
            this.checkBoxLockItem.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLockItem.Name = "checkBoxLockItem";
            this.checkBoxLockItem.Size = new System.Drawing.Size(55, 27);
            this.checkBoxLockItem.TabIndex = 5;
            this.checkBoxLockItem.TabStop = false;
            this.checkBoxLockItem.Text = "Lock";
            this.checkBoxLockItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxLockItem, "Lock model selection.");
            this.checkBoxLockItem.UseVisualStyleBackColor = true;
            this.checkBoxLockItem.CheckedChanged += new System.EventHandler(this.CheckBoxLockItemCheckedChanged);
            // 
            // checkBoxLockCamera
            // 
            this.checkBoxLockCamera.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLockCamera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxLockCamera.Location = new System.Drawing.Point(223, 519);
            this.checkBoxLockCamera.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLockCamera.Name = "checkBoxLockCamera";
            this.checkBoxLockCamera.Size = new System.Drawing.Size(48, 27);
            this.checkBoxLockCamera.TabIndex = 4;
            this.checkBoxLockCamera.TabStop = false;
            this.checkBoxLockCamera.Text = "Lock";
            this.checkBoxLockCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxLockCamera, "Lock camera.");
            this.checkBoxLockCamera.UseVisualStyleBackColor = true;
            this.checkBoxLockCamera.CheckedChanged += new System.EventHandler(this.CheckBoxLockCameraCheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.Tag = "";
            // 
            // checkBoxItemVisible
            // 
            this.checkBoxItemVisible.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxItemVisible.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxItemVisible.Location = new System.Drawing.Point(11, 114);
            this.checkBoxItemVisible.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxItemVisible.Name = "checkBoxItemVisible";
            this.checkBoxItemVisible.Size = new System.Drawing.Size(55, 27);
            this.checkBoxItemVisible.TabIndex = 26;
            this.checkBoxItemVisible.TabStop = false;
            this.checkBoxItemVisible.Text = "Show";
            this.checkBoxItemVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxItemVisible, "Model visibility.");
            this.checkBoxItemVisible.UseVisualStyleBackColor = true;
            this.checkBoxItemVisible.CheckedChanged += new System.EventHandler(this.CheckBoxItemVisibleCheckedChanged);
            // 
            // trackBarH
            // 
            this.trackBarH.LargeChange = 10;
            this.trackBarH.Location = new System.Drawing.Point(411, 52);
            this.trackBarH.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarH.Maximum = 1500;
            this.trackBarH.Minimum = -200;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarH.Size = new System.Drawing.Size(61, 374);
            this.trackBarH.TabIndex = 4;
            this.trackBarH.TickFrequency = 25;
            this.trackBarH.Scroll += new System.EventHandler(this.TrackBarHScroll);
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(409, 33);
            this.labelH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(49, 17);
            this.labelH.TabIndex = 2;
            this.labelH.Text = "Height";
            // 
            // buttonResetH
            // 
            this.buttonResetH.Location = new System.Drawing.Point(411, 430);
            this.buttonResetH.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetH.Name = "buttonResetH";
            this.buttonResetH.Size = new System.Drawing.Size(35, 27);
            this.buttonResetH.TabIndex = 1;
            this.buttonResetH.TabStop = false;
            this.buttonResetH.Text = "0";
            this.buttonResetH.UseVisualStyleBackColor = true;
            this.buttonResetH.Click += new System.EventHandler(this.ButtonResetHClick);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(411, 461);
            this.textBoxH.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(35, 22);
            this.textBoxH.TabIndex = 8;
            this.textBoxH.Validated += new System.EventHandler(this.TextBoxHValidated);
            this.textBoxH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxHKeyPress);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(8, 90);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(47, 17);
            this.labelScale.TabIndex = 27;
            this.labelScale.Text = "Scale:";
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(61, 87);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(169, 22);
            this.textBoxScale.TabIndex = 28;
            this.textBoxScale.Validated += new System.EventHandler(this.TextBoxScaleValidated);
            this.textBoxScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxScaleKeyPress);
            // 
            // buttonBoneMode
            // 
            this.buttonBoneMode.BackColor = System.Drawing.Color.Gray;
            this.buttonBoneMode.ForeColor = System.Drawing.Color.White;
            this.buttonBoneMode.Location = new System.Drawing.Point(285, 519);
            this.buttonBoneMode.Name = "buttonBoneMode";
            this.buttonBoneMode.Size = new System.Drawing.Size(161, 27);
            this.buttonBoneMode.TabIndex = 29;
            this.buttonBoneMode.Text = "Mode: Rotate";
            this.buttonBoneMode.UseVisualStyleBackColor = false;
            this.buttonBoneMode.Click += new System.EventHandler(this.ButtonBoneModeClick);
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(8, 62);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(36, 17);
            this.labelPosition.TabIndex = 30;
            this.labelPosition.Text = "Pos:";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(61, 59);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(169, 22);
            this.textBoxPosition.TabIndex = 31;
            this.textBoxPosition.Validated += new System.EventHandler(this.TextBoxPositionValidated);
            this.textBoxPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPositionKeyPress);
            // 
            // buttonResetPos
            // 
            this.buttonResetPos.Location = new System.Drawing.Point(236, 57);
            this.buttonResetPos.Name = "buttonResetPos";
            this.buttonResetPos.Size = new System.Drawing.Size(35, 27);
            this.buttonResetPos.TabIndex = 32;
            this.buttonResetPos.Text = "0";
            this.buttonResetPos.UseVisualStyleBackColor = true;
            this.buttonResetPos.Click += new System.EventHandler(this.ButtonResetPosClick);
            // 
            // buttonResetScale
            // 
            this.buttonResetScale.Location = new System.Drawing.Point(236, 85);
            this.buttonResetScale.Name = "buttonResetScale";
            this.buttonResetScale.Size = new System.Drawing.Size(35, 27);
            this.buttonResetScale.TabIndex = 33;
            this.buttonResetScale.Text = "1";
            this.buttonResetScale.UseVisualStyleBackColor = true;
            this.buttonResetScale.Click += new System.EventHandler(this.ButtonResetScaleClick);
            // 
            // buttonLookIntoCamera
            // 
            this.buttonLookIntoCamera.Location = new System.Drawing.Point(161, 114);
            this.buttonLookIntoCamera.Name = "buttonLookIntoCamera";
            this.buttonLookIntoCamera.Size = new System.Drawing.Size(110, 27);
            this.buttonLookIntoCamera.TabIndex = 34;
            this.buttonLookIntoCamera.Text = "Look into cam";
            this.buttonLookIntoCamera.UseVisualStyleBackColor = true;
            this.buttonLookIntoCamera.Click += new System.EventHandler(this.ButtonLookIntoCameraClick);
            // 
            // ControlGUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(462, 562);
            this.Controls.Add(this.buttonLookIntoCamera);
            this.Controls.Add(this.buttonResetScale);
            this.Controls.Add(this.buttonResetPos);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.buttonBoneMode);
            this.Controls.Add(this.textBoxScale);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.checkBoxItemVisible);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.buttonResetH);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.trackBarH);
            this.Controls.Add(this.checkBoxLockCamera);
            this.Controls.Add(this.checkBoxLockItem);
            this.Controls.Add(this.comboBoxItem);
            this.Controls.Add(this.labelItem);
            this.Controls.Add(this.buttonResetZ);
            this.Controls.Add(this.buttonResetY);
            this.Controls.Add(this.buttonResetX);
            this.Controls.Add(this.treeViewBones);
            this.Controls.Add(this.comboBoxCameraPivot);
            this.Controls.Add(this.labelCameraPivot);
            this.Controls.Add(this.buttonResetBoneXYZ);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(450, 360);
            this.Name = "ControlGUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control Window";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Button buttonResetBoneXYZ;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Label labelCameraPivot;
        private System.Windows.Forms.ComboBox comboBoxCameraPivot;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewBones;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportObjToolStripMenuItem;
        private System.Windows.Forms.Button buttonResetX;
        private System.Windows.Forms.Button buttonResetY;
        private System.Windows.Forms.Button buttonResetZ;
        private System.Windows.Forms.ToolStripMenuItem resetPoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayWireframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayTexturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayBonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAccessoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightingParamsToolStripMenuItem;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox checkBoxLockItem;
        private System.Windows.Forms.CheckBox checkBoxLockCamera;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Button buttonResetH;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.ToolStripMenuItem assignBackgroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem removeBackgroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.CheckBox checkBoxItemVisible;
        private System.Windows.Forms.ToolStripMenuItem handgunsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayHandGunHandLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayHandGunHandRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayHandGunHolsterLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayHandGunHolsterRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGlowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.ToolStripMenuItem cameraParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skydomeParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayBoneNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dWindowSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backFaceCullingToolStripMenuItem;
        private System.Windows.Forms.Button buttonBoneMode;
        private System.Windows.Forms.ToolStripMenuItem exportMeshAsciiToolStripMenuItem;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem quickSaveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneSelectedModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postprocessingParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Button buttonResetPos;
        private System.Windows.Forms.Button buttonResetScale;
        private System.Windows.Forms.Button buttonLookIntoCamera;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorPoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mirrorModelXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorModelYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorModelZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableBumpMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem reloadTexturesOfSelectedModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGearBeltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGearGauntletLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGearGauntletRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGlowBeltMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGlowGauntletLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayThorGlowGauntletRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipPoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMeshAsciiPosedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAddModelMultiSelectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGlowLeftColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGlowRightColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useAlternativeReflectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysForceCullingToolStripMenuItem;
    }
}