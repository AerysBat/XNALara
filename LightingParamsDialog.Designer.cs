namespace XNALara
{
    partial class LightingParamsDialog
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
            this.labelLight1ShadowDepth = new System.Windows.Forms.Label();
            this.trackBarLight1ShadowDepth = new System.Windows.Forms.TrackBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.trackBarLight1AngleHorizontal = new System.Windows.Forms.TrackBar();
            this.trackBarLight1AngleVertical = new System.Windows.Forms.TrackBar();
            this.textBoxLight1AngleHorizontal = new System.Windows.Forms.TextBox();
            this.textBoxLight1AngleVertical = new System.Windows.Forms.TextBox();
            this.textBoxLight1ShadowDepth = new System.Windows.Forms.TextBox();
            this.labelLight1AngleHorizontal = new System.Windows.Forms.Label();
            this.labelLight1AngleVertical = new System.Windows.Forms.Label();
            this.labelLight1Intensity = new System.Windows.Forms.Label();
            this.trackBarLight1Intensity = new System.Windows.Forms.TrackBar();
            this.textBoxLight1Intensity = new System.Windows.Forms.TextBox();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.groupBoxLight1 = new System.Windows.Forms.GroupBox();
            this.buttonLight1Color = new System.Windows.Forms.Button();
            this.groupBoxLight2 = new System.Windows.Forms.GroupBox();
            this.buttonLight2Color = new System.Windows.Forms.Button();
            this.textBoxLight2ShadowDepth = new System.Windows.Forms.TextBox();
            this.trackBarLight2ShadowDepth = new System.Windows.Forms.TrackBar();
            this.labelLight2ShadowDepth = new System.Windows.Forms.Label();
            this.textBoxLight2Intensity = new System.Windows.Forms.TextBox();
            this.textBoxLight2AngleVertical = new System.Windows.Forms.TextBox();
            this.textBoxLight2AngleHorizontal = new System.Windows.Forms.TextBox();
            this.trackBarLight2Intensity = new System.Windows.Forms.TrackBar();
            this.trackBarLight2AngleVertical = new System.Windows.Forms.TrackBar();
            this.trackBarLight2AngleHorizontal = new System.Windows.Forms.TrackBar();
            this.labelLight2Intensity = new System.Windows.Forms.Label();
            this.labelLight2AngleVertical = new System.Windows.Forms.Label();
            this.labelLight2AngleHorizontal = new System.Windows.Forms.Label();
            this.buttonLight3Color = new System.Windows.Forms.Button();
            this.textBoxLight3ShadowDepth = new System.Windows.Forms.TextBox();
            this.trackBarLight3ShadowDepth = new System.Windows.Forms.TrackBar();
            this.labelLight3ShadowDepth = new System.Windows.Forms.Label();
            this.textBoxLight3Intensity = new System.Windows.Forms.TextBox();
            this.textBoxLight3AngleVertical = new System.Windows.Forms.TextBox();
            this.textBoxLight3AngleHorizontal = new System.Windows.Forms.TextBox();
            this.trackBarLight3Intensity = new System.Windows.Forms.TrackBar();
            this.groupBoxLight3 = new System.Windows.Forms.GroupBox();
            this.trackBarLight3AngleVertical = new System.Windows.Forms.TrackBar();
            this.trackBarLight3AngleHorizontal = new System.Windows.Forms.TrackBar();
            this.labelLight3Intensity = new System.Windows.Forms.Label();
            this.labelLight3AngleVertical = new System.Windows.Forms.Label();
            this.labelLight3AngleHorizontal = new System.Windows.Forms.Label();
            this.checkBoxForceShadersV3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1ShadowDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1AngleHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1AngleVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1Intensity)).BeginInit();
            this.groupBoxLight1.SuspendLayout();
            this.groupBoxLight2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2ShadowDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2Intensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2AngleVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2AngleHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3ShadowDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3Intensity)).BeginInit();
            this.groupBoxLight3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3AngleVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3AngleHorizontal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLight1ShadowDepth
            // 
            this.labelLight1ShadowDepth.AutoSize = true;
            this.labelLight1ShadowDepth.Location = new System.Drawing.Point(8, 145);
            this.labelLight1ShadowDepth.Name = "labelLight1ShadowDepth";
            this.labelLight1ShadowDepth.Size = new System.Drawing.Size(100, 17);
            this.labelLight1ShadowDepth.TabIndex = 0;
            this.labelLight1ShadowDepth.Text = "shadow depth:";
            // 
            // trackBarLight1ShadowDepth
            // 
            this.trackBarLight1ShadowDepth.Location = new System.Drawing.Point(104, 141);
            this.trackBarLight1ShadowDepth.Maximum = 100;
            this.trackBarLight1ShadowDepth.Minimum = 25;
            this.trackBarLight1ShadowDepth.Name = "trackBarLight1ShadowDepth";
            this.trackBarLight1ShadowDepth.Size = new System.Drawing.Size(213, 56);
            this.trackBarLight1ShadowDepth.TabIndex = 4;
            this.trackBarLight1ShadowDepth.TickFrequency = 5;
            this.trackBarLight1ShadowDepth.Value = 40;
            this.trackBarLight1ShadowDepth.Scroll += new System.EventHandler(this.TrackBarLight1ShadowDepthScroll);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(320, 678);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 27);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // trackBarLight1AngleHorizontal
            // 
            this.trackBarLight1AngleHorizontal.LargeChange = 10;
            this.trackBarLight1AngleHorizontal.Location = new System.Drawing.Point(116, 21);
            this.trackBarLight1AngleHorizontal.Maximum = 360;
            this.trackBarLight1AngleHorizontal.Name = "trackBarLight1AngleHorizontal";
            this.trackBarLight1AngleHorizontal.Size = new System.Drawing.Size(202, 56);
            this.trackBarLight1AngleHorizontal.TabIndex = 0;
            this.trackBarLight1AngleHorizontal.TickFrequency = 10;
            this.trackBarLight1AngleHorizontal.Scroll += new System.EventHandler(this.TrackBarLight1AngleHorizontalScroll);
            // 
            // trackBarLight1AngleVertical
            // 
            this.trackBarLight1AngleVertical.Location = new System.Drawing.Point(116, 61);
            this.trackBarLight1AngleVertical.Maximum = 90;
            this.trackBarLight1AngleVertical.Minimum = -90;
            this.trackBarLight1AngleVertical.Name = "trackBarLight1AngleVertical";
            this.trackBarLight1AngleVertical.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight1AngleVertical.TabIndex = 1;
            this.trackBarLight1AngleVertical.TickFrequency = 5;
            this.trackBarLight1AngleVertical.Scroll += new System.EventHandler(this.TrackBarLight1AngleVerticalScroll);
            // 
            // textBoxLight1AngleHorizontal
            // 
            this.textBoxLight1AngleHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight1AngleHorizontal.Location = new System.Drawing.Point(323, 25);
            this.textBoxLight1AngleHorizontal.Name = "textBoxLight1AngleHorizontal";
            this.textBoxLight1AngleHorizontal.ReadOnly = true;
            this.textBoxLight1AngleHorizontal.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight1AngleHorizontal.TabIndex = 0;
            this.textBoxLight1AngleHorizontal.TabStop = false;
            // 
            // textBoxLight1AngleVertical
            // 
            this.textBoxLight1AngleVertical.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight1AngleVertical.Location = new System.Drawing.Point(323, 65);
            this.textBoxLight1AngleVertical.Name = "textBoxLight1AngleVertical";
            this.textBoxLight1AngleVertical.ReadOnly = true;
            this.textBoxLight1AngleVertical.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight1AngleVertical.TabIndex = 0;
            this.textBoxLight1AngleVertical.TabStop = false;
            // 
            // textBoxLight1ShadowDepth
            // 
            this.textBoxLight1ShadowDepth.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight1ShadowDepth.Location = new System.Drawing.Point(323, 145);
            this.textBoxLight1ShadowDepth.Name = "textBoxLight1ShadowDepth";
            this.textBoxLight1ShadowDepth.ReadOnly = true;
            this.textBoxLight1ShadowDepth.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight1ShadowDepth.TabIndex = 0;
            this.textBoxLight1ShadowDepth.TabStop = false;
            // 
            // labelLight1AngleHorizontal
            // 
            this.labelLight1AngleHorizontal.AutoSize = true;
            this.labelLight1AngleHorizontal.Location = new System.Drawing.Point(8, 25);
            this.labelLight1AngleHorizontal.Name = "labelLight1AngleHorizontal";
            this.labelLight1AngleHorizontal.Size = new System.Drawing.Size(113, 17);
            this.labelLight1AngleHorizontal.TabIndex = 9;
            this.labelLight1AngleHorizontal.Text = "angle horizontal:";
            // 
            // labelLight1AngleVertical
            // 
            this.labelLight1AngleVertical.AutoSize = true;
            this.labelLight1AngleVertical.Location = new System.Drawing.Point(8, 65);
            this.labelLight1AngleVertical.Name = "labelLight1AngleVertical";
            this.labelLight1AngleVertical.Size = new System.Drawing.Size(96, 17);
            this.labelLight1AngleVertical.TabIndex = 10;
            this.labelLight1AngleVertical.Text = "angle vertical:";
            // 
            // labelLight1Intensity
            // 
            this.labelLight1Intensity.AutoSize = true;
            this.labelLight1Intensity.Location = new System.Drawing.Point(56, 105);
            this.labelLight1Intensity.Name = "labelLight1Intensity";
            this.labelLight1Intensity.Size = new System.Drawing.Size(64, 17);
            this.labelLight1Intensity.TabIndex = 11;
            this.labelLight1Intensity.Text = "intensity:";
            // 
            // trackBarLight1Intensity
            // 
            this.trackBarLight1Intensity.LargeChange = 10;
            this.trackBarLight1Intensity.Location = new System.Drawing.Point(116, 101);
            this.trackBarLight1Intensity.Maximum = 300;
            this.trackBarLight1Intensity.Name = "trackBarLight1Intensity";
            this.trackBarLight1Intensity.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight1Intensity.TabIndex = 3;
            this.trackBarLight1Intensity.TickFrequency = 10;
            this.trackBarLight1Intensity.Scroll += new System.EventHandler(this.TrackBarLight1IntensityScroll);
            // 
            // textBoxLight1Intensity
            // 
            this.textBoxLight1Intensity.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight1Intensity.Location = new System.Drawing.Point(323, 105);
            this.textBoxLight1Intensity.Name = "textBoxLight1Intensity";
            this.textBoxLight1Intensity.ReadOnly = true;
            this.textBoxLight1Intensity.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight1Intensity.TabIndex = 0;
            this.textBoxLight1Intensity.TabStop = false;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Location = new System.Drawing.Point(12, 678);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(80, 27);
            this.buttonResetAll.TabIndex = 15;
            this.buttonResetAll.Text = "Reset all";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.ButtonResetAllClick);
            // 
            // groupBoxLight1
            // 
            this.groupBoxLight1.Controls.Add(this.buttonLight1Color);
            this.groupBoxLight1.Controls.Add(this.trackBarLight1ShadowDepth);
            this.groupBoxLight1.Controls.Add(this.trackBarLight1Intensity);
            this.groupBoxLight1.Controls.Add(this.textBoxLight1Intensity);
            this.groupBoxLight1.Controls.Add(this.textBoxLight1ShadowDepth);
            this.groupBoxLight1.Controls.Add(this.trackBarLight1AngleVertical);
            this.groupBoxLight1.Controls.Add(this.labelLight1Intensity);
            this.groupBoxLight1.Controls.Add(this.labelLight1AngleHorizontal);
            this.groupBoxLight1.Controls.Add(this.labelLight1ShadowDepth);
            this.groupBoxLight1.Controls.Add(this.trackBarLight1AngleHorizontal);
            this.groupBoxLight1.Controls.Add(this.textBoxLight1AngleHorizontal);
            this.groupBoxLight1.Controls.Add(this.labelLight1AngleVertical);
            this.groupBoxLight1.Controls.Add(this.textBoxLight1AngleVertical);
            this.groupBoxLight1.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLight1.Name = "groupBoxLight1";
            this.groupBoxLight1.Size = new System.Drawing.Size(383, 200);
            this.groupBoxLight1.TabIndex = 15;
            this.groupBoxLight1.TabStop = false;
            this.groupBoxLight1.Text = "Light 1";
            // 
            // buttonLight1Color
            // 
            this.buttonLight1Color.Location = new System.Drawing.Point(11, 101);
            this.buttonLight1Color.Name = "buttonLight1Color";
            this.buttonLight1Color.Size = new System.Drawing.Size(36, 30);
            this.buttonLight1Color.TabIndex = 2;
            this.buttonLight1Color.UseVisualStyleBackColor = true;
            this.buttonLight1Color.Click += new System.EventHandler(this.ButtonLight1ColorClick);
            // 
            // groupBoxLight2
            // 
            this.groupBoxLight2.Controls.Add(this.buttonLight2Color);
            this.groupBoxLight2.Controls.Add(this.textBoxLight2ShadowDepth);
            this.groupBoxLight2.Controls.Add(this.trackBarLight2ShadowDepth);
            this.groupBoxLight2.Controls.Add(this.labelLight2ShadowDepth);
            this.groupBoxLight2.Controls.Add(this.textBoxLight2Intensity);
            this.groupBoxLight2.Controls.Add(this.textBoxLight2AngleVertical);
            this.groupBoxLight2.Controls.Add(this.textBoxLight2AngleHorizontal);
            this.groupBoxLight2.Controls.Add(this.trackBarLight2Intensity);
            this.groupBoxLight2.Controls.Add(this.trackBarLight2AngleVertical);
            this.groupBoxLight2.Controls.Add(this.trackBarLight2AngleHorizontal);
            this.groupBoxLight2.Controls.Add(this.labelLight2Intensity);
            this.groupBoxLight2.Controls.Add(this.labelLight2AngleVertical);
            this.groupBoxLight2.Controls.Add(this.labelLight2AngleHorizontal);
            this.groupBoxLight2.Location = new System.Drawing.Point(12, 218);
            this.groupBoxLight2.Name = "groupBoxLight2";
            this.groupBoxLight2.Size = new System.Drawing.Size(383, 200);
            this.groupBoxLight2.TabIndex = 16;
            this.groupBoxLight2.TabStop = false;
            this.groupBoxLight2.Text = "Light 2";
            // 
            // buttonLight2Color
            // 
            this.buttonLight2Color.Location = new System.Drawing.Point(11, 101);
            this.buttonLight2Color.Name = "buttonLight2Color";
            this.buttonLight2Color.Size = new System.Drawing.Size(36, 30);
            this.buttonLight2Color.TabIndex = 7;
            this.buttonLight2Color.UseVisualStyleBackColor = true;
            this.buttonLight2Color.Click += new System.EventHandler(this.ButtonLight2ColorClick);
            // 
            // textBoxLight2ShadowDepth
            // 
            this.textBoxLight2ShadowDepth.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight2ShadowDepth.Location = new System.Drawing.Point(323, 145);
            this.textBoxLight2ShadowDepth.Name = "textBoxLight2ShadowDepth";
            this.textBoxLight2ShadowDepth.ReadOnly = true;
            this.textBoxLight2ShadowDepth.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight2ShadowDepth.TabIndex = 0;
            this.textBoxLight2ShadowDepth.TabStop = false;
            // 
            // trackBarLight2ShadowDepth
            // 
            this.trackBarLight2ShadowDepth.Location = new System.Drawing.Point(104, 141);
            this.trackBarLight2ShadowDepth.Maximum = 100;
            this.trackBarLight2ShadowDepth.Minimum = 25;
            this.trackBarLight2ShadowDepth.Name = "trackBarLight2ShadowDepth";
            this.trackBarLight2ShadowDepth.Size = new System.Drawing.Size(213, 56);
            this.trackBarLight2ShadowDepth.TabIndex = 9;
            this.trackBarLight2ShadowDepth.TickFrequency = 5;
            this.trackBarLight2ShadowDepth.Value = 40;
            this.trackBarLight2ShadowDepth.Scroll += new System.EventHandler(this.TrackBarLight2ShadowDepthScroll);
            // 
            // labelLight2ShadowDepth
            // 
            this.labelLight2ShadowDepth.AutoSize = true;
            this.labelLight2ShadowDepth.Location = new System.Drawing.Point(8, 145);
            this.labelLight2ShadowDepth.Name = "labelLight2ShadowDepth";
            this.labelLight2ShadowDepth.Size = new System.Drawing.Size(100, 17);
            this.labelLight2ShadowDepth.TabIndex = 9;
            this.labelLight2ShadowDepth.Text = "shadow depth:";
            // 
            // textBoxLight2Intensity
            // 
            this.textBoxLight2Intensity.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight2Intensity.Location = new System.Drawing.Point(323, 105);
            this.textBoxLight2Intensity.Name = "textBoxLight2Intensity";
            this.textBoxLight2Intensity.ReadOnly = true;
            this.textBoxLight2Intensity.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight2Intensity.TabIndex = 0;
            this.textBoxLight2Intensity.TabStop = false;
            // 
            // textBoxLight2AngleVertical
            // 
            this.textBoxLight2AngleVertical.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight2AngleVertical.Location = new System.Drawing.Point(323, 65);
            this.textBoxLight2AngleVertical.Name = "textBoxLight2AngleVertical";
            this.textBoxLight2AngleVertical.ReadOnly = true;
            this.textBoxLight2AngleVertical.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight2AngleVertical.TabIndex = 0;
            this.textBoxLight2AngleVertical.TabStop = false;
            // 
            // textBoxLight2AngleHorizontal
            // 
            this.textBoxLight2AngleHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight2AngleHorizontal.Location = new System.Drawing.Point(323, 21);
            this.textBoxLight2AngleHorizontal.Name = "textBoxLight2AngleHorizontal";
            this.textBoxLight2AngleHorizontal.ReadOnly = true;
            this.textBoxLight2AngleHorizontal.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight2AngleHorizontal.TabIndex = 0;
            this.textBoxLight2AngleHorizontal.TabStop = false;
            // 
            // trackBarLight2Intensity
            // 
            this.trackBarLight2Intensity.LargeChange = 10;
            this.trackBarLight2Intensity.Location = new System.Drawing.Point(116, 101);
            this.trackBarLight2Intensity.Maximum = 300;
            this.trackBarLight2Intensity.Name = "trackBarLight2Intensity";
            this.trackBarLight2Intensity.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight2Intensity.TabIndex = 8;
            this.trackBarLight2Intensity.TickFrequency = 10;
            this.trackBarLight2Intensity.Scroll += new System.EventHandler(this.TrackBarLight2IntensityScroll);
            // 
            // trackBarLight2AngleVertical
            // 
            this.trackBarLight2AngleVertical.Location = new System.Drawing.Point(116, 61);
            this.trackBarLight2AngleVertical.Maximum = 90;
            this.trackBarLight2AngleVertical.Minimum = -90;
            this.trackBarLight2AngleVertical.Name = "trackBarLight2AngleVertical";
            this.trackBarLight2AngleVertical.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight2AngleVertical.TabIndex = 6;
            this.trackBarLight2AngleVertical.TickFrequency = 5;
            this.trackBarLight2AngleVertical.Scroll += new System.EventHandler(this.TrackBarLight2AngleVerticalScroll);
            // 
            // trackBarLight2AngleHorizontal
            // 
            this.trackBarLight2AngleHorizontal.LargeChange = 10;
            this.trackBarLight2AngleHorizontal.Location = new System.Drawing.Point(116, 21);
            this.trackBarLight2AngleHorizontal.Maximum = 360;
            this.trackBarLight2AngleHorizontal.Name = "trackBarLight2AngleHorizontal";
            this.trackBarLight2AngleHorizontal.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight2AngleHorizontal.TabIndex = 5;
            this.trackBarLight2AngleHorizontal.TickFrequency = 10;
            this.trackBarLight2AngleHorizontal.Scroll += new System.EventHandler(this.TrackBarLight2AngleHorizontalScroll);
            // 
            // labelLight2Intensity
            // 
            this.labelLight2Intensity.AutoSize = true;
            this.labelLight2Intensity.Location = new System.Drawing.Point(56, 105);
            this.labelLight2Intensity.Name = "labelLight2Intensity";
            this.labelLight2Intensity.Size = new System.Drawing.Size(64, 17);
            this.labelLight2Intensity.TabIndex = 2;
            this.labelLight2Intensity.Text = "intensity:";
            // 
            // labelLight2AngleVertical
            // 
            this.labelLight2AngleVertical.AutoSize = true;
            this.labelLight2AngleVertical.Location = new System.Drawing.Point(8, 65);
            this.labelLight2AngleVertical.Name = "labelLight2AngleVertical";
            this.labelLight2AngleVertical.Size = new System.Drawing.Size(96, 17);
            this.labelLight2AngleVertical.TabIndex = 1;
            this.labelLight2AngleVertical.Text = "angle vertical:";
            // 
            // labelLight2AngleHorizontal
            // 
            this.labelLight2AngleHorizontal.AutoSize = true;
            this.labelLight2AngleHorizontal.Location = new System.Drawing.Point(8, 25);
            this.labelLight2AngleHorizontal.Name = "labelLight2AngleHorizontal";
            this.labelLight2AngleHorizontal.Size = new System.Drawing.Size(113, 17);
            this.labelLight2AngleHorizontal.TabIndex = 0;
            this.labelLight2AngleHorizontal.Text = "angle horizontal:";
            // 
            // buttonLight3Color
            // 
            this.buttonLight3Color.Location = new System.Drawing.Point(11, 101);
            this.buttonLight3Color.Name = "buttonLight3Color";
            this.buttonLight3Color.Size = new System.Drawing.Size(36, 30);
            this.buttonLight3Color.TabIndex = 12;
            this.buttonLight3Color.UseVisualStyleBackColor = true;
            this.buttonLight3Color.Click += new System.EventHandler(this.ButtonLight3ColorClick);
            // 
            // textBoxLight3ShadowDepth
            // 
            this.textBoxLight3ShadowDepth.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight3ShadowDepth.Location = new System.Drawing.Point(323, 145);
            this.textBoxLight3ShadowDepth.Name = "textBoxLight3ShadowDepth";
            this.textBoxLight3ShadowDepth.ReadOnly = true;
            this.textBoxLight3ShadowDepth.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight3ShadowDepth.TabIndex = 0;
            this.textBoxLight3ShadowDepth.TabStop = false;
            // 
            // trackBarLight3ShadowDepth
            // 
            this.trackBarLight3ShadowDepth.Location = new System.Drawing.Point(104, 141);
            this.trackBarLight3ShadowDepth.Maximum = 100;
            this.trackBarLight3ShadowDepth.Minimum = 25;
            this.trackBarLight3ShadowDepth.Name = "trackBarLight3ShadowDepth";
            this.trackBarLight3ShadowDepth.Size = new System.Drawing.Size(213, 56);
            this.trackBarLight3ShadowDepth.TabIndex = 14;
            this.trackBarLight3ShadowDepth.TickFrequency = 5;
            this.trackBarLight3ShadowDepth.Value = 40;
            this.trackBarLight3ShadowDepth.Scroll += new System.EventHandler(this.TrackBarLight3ShadowDepthScroll);
            // 
            // labelLight3ShadowDepth
            // 
            this.labelLight3ShadowDepth.AutoSize = true;
            this.labelLight3ShadowDepth.Location = new System.Drawing.Point(8, 145);
            this.labelLight3ShadowDepth.Name = "labelLight3ShadowDepth";
            this.labelLight3ShadowDepth.Size = new System.Drawing.Size(100, 17);
            this.labelLight3ShadowDepth.TabIndex = 9;
            this.labelLight3ShadowDepth.Text = "shadow depth:";
            // 
            // textBoxLight3Intensity
            // 
            this.textBoxLight3Intensity.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight3Intensity.Location = new System.Drawing.Point(323, 105);
            this.textBoxLight3Intensity.Name = "textBoxLight3Intensity";
            this.textBoxLight3Intensity.ReadOnly = true;
            this.textBoxLight3Intensity.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight3Intensity.TabIndex = 0;
            this.textBoxLight3Intensity.TabStop = false;
            // 
            // textBoxLight3AngleVertical
            // 
            this.textBoxLight3AngleVertical.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight3AngleVertical.Location = new System.Drawing.Point(323, 65);
            this.textBoxLight3AngleVertical.Name = "textBoxLight3AngleVertical";
            this.textBoxLight3AngleVertical.ReadOnly = true;
            this.textBoxLight3AngleVertical.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight3AngleVertical.TabIndex = 0;
            this.textBoxLight3AngleVertical.TabStop = false;
            // 
            // textBoxLight3AngleHorizontal
            // 
            this.textBoxLight3AngleHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLight3AngleHorizontal.Location = new System.Drawing.Point(323, 21);
            this.textBoxLight3AngleHorizontal.Name = "textBoxLight3AngleHorizontal";
            this.textBoxLight3AngleHorizontal.ReadOnly = true;
            this.textBoxLight3AngleHorizontal.Size = new System.Drawing.Size(50, 22);
            this.textBoxLight3AngleHorizontal.TabIndex = 0;
            this.textBoxLight3AngleHorizontal.TabStop = false;
            // 
            // trackBarLight3Intensity
            // 
            this.trackBarLight3Intensity.LargeChange = 10;
            this.trackBarLight3Intensity.Location = new System.Drawing.Point(116, 101);
            this.trackBarLight3Intensity.Maximum = 300;
            this.trackBarLight3Intensity.Name = "trackBarLight3Intensity";
            this.trackBarLight3Intensity.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight3Intensity.TabIndex = 13;
            this.trackBarLight3Intensity.TickFrequency = 10;
            this.trackBarLight3Intensity.Scroll += new System.EventHandler(this.TrackBarLight3IntensityScroll);
            // 
            // groupBoxLight3
            // 
            this.groupBoxLight3.Controls.Add(this.buttonLight3Color);
            this.groupBoxLight3.Controls.Add(this.textBoxLight3ShadowDepth);
            this.groupBoxLight3.Controls.Add(this.trackBarLight3ShadowDepth);
            this.groupBoxLight3.Controls.Add(this.labelLight3ShadowDepth);
            this.groupBoxLight3.Controls.Add(this.textBoxLight3Intensity);
            this.groupBoxLight3.Controls.Add(this.textBoxLight3AngleVertical);
            this.groupBoxLight3.Controls.Add(this.textBoxLight3AngleHorizontal);
            this.groupBoxLight3.Controls.Add(this.trackBarLight3Intensity);
            this.groupBoxLight3.Controls.Add(this.trackBarLight3AngleVertical);
            this.groupBoxLight3.Controls.Add(this.trackBarLight3AngleHorizontal);
            this.groupBoxLight3.Controls.Add(this.labelLight3Intensity);
            this.groupBoxLight3.Controls.Add(this.labelLight3AngleVertical);
            this.groupBoxLight3.Controls.Add(this.labelLight3AngleHorizontal);
            this.groupBoxLight3.Location = new System.Drawing.Point(12, 424);
            this.groupBoxLight3.Name = "groupBoxLight3";
            this.groupBoxLight3.Size = new System.Drawing.Size(383, 200);
            this.groupBoxLight3.TabIndex = 17;
            this.groupBoxLight3.TabStop = false;
            this.groupBoxLight3.Text = "Light 3";
            // 
            // trackBarLight3AngleVertical
            // 
            this.trackBarLight3AngleVertical.Location = new System.Drawing.Point(116, 61);
            this.trackBarLight3AngleVertical.Maximum = 90;
            this.trackBarLight3AngleVertical.Minimum = -90;
            this.trackBarLight3AngleVertical.Name = "trackBarLight3AngleVertical";
            this.trackBarLight3AngleVertical.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight3AngleVertical.TabIndex = 11;
            this.trackBarLight3AngleVertical.TickFrequency = 5;
            this.trackBarLight3AngleVertical.Scroll += new System.EventHandler(this.TrackBarLight3AngleVerticalScroll);
            // 
            // trackBarLight3AngleHorizontal
            // 
            this.trackBarLight3AngleHorizontal.LargeChange = 10;
            this.trackBarLight3AngleHorizontal.Location = new System.Drawing.Point(116, 21);
            this.trackBarLight3AngleHorizontal.Maximum = 360;
            this.trackBarLight3AngleHorizontal.Name = "trackBarLight3AngleHorizontal";
            this.trackBarLight3AngleHorizontal.Size = new System.Drawing.Size(201, 56);
            this.trackBarLight3AngleHorizontal.TabIndex = 10;
            this.trackBarLight3AngleHorizontal.TickFrequency = 10;
            this.trackBarLight3AngleHorizontal.Scroll += new System.EventHandler(this.TrackBarLight3AngleHorizontalScroll);
            // 
            // labelLight3Intensity
            // 
            this.labelLight3Intensity.AutoSize = true;
            this.labelLight3Intensity.Location = new System.Drawing.Point(56, 105);
            this.labelLight3Intensity.Name = "labelLight3Intensity";
            this.labelLight3Intensity.Size = new System.Drawing.Size(64, 17);
            this.labelLight3Intensity.TabIndex = 2;
            this.labelLight3Intensity.Text = "intensity:";
            // 
            // labelLight3AngleVertical
            // 
            this.labelLight3AngleVertical.AutoSize = true;
            this.labelLight3AngleVertical.Location = new System.Drawing.Point(8, 65);
            this.labelLight3AngleVertical.Name = "labelLight3AngleVertical";
            this.labelLight3AngleVertical.Size = new System.Drawing.Size(96, 17);
            this.labelLight3AngleVertical.TabIndex = 1;
            this.labelLight3AngleVertical.Text = "angle vertical:";
            // 
            // labelLight3AngleHorizontal
            // 
            this.labelLight3AngleHorizontal.AutoSize = true;
            this.labelLight3AngleHorizontal.Location = new System.Drawing.Point(8, 25);
            this.labelLight3AngleHorizontal.Name = "labelLight3AngleHorizontal";
            this.labelLight3AngleHorizontal.Size = new System.Drawing.Size(113, 17);
            this.labelLight3AngleHorizontal.TabIndex = 0;
            this.labelLight3AngleHorizontal.Text = "angle horizontal:";
            // 
            // checkBoxForceShadersV3
            // 
            this.checkBoxForceShadersV3.AutoSize = true;
            this.checkBoxForceShadersV3.Location = new System.Drawing.Point(12, 635);
            this.checkBoxForceShadersV3.Name = "checkBoxForceShadersV3";
            this.checkBoxForceShadersV3.Size = new System.Drawing.Size(234, 21);
            this.checkBoxForceShadersV3.TabIndex = 18;
            this.checkBoxForceShadersV3.Text = "force shaders v3.0 (if supported)";
            this.checkBoxForceShadersV3.UseVisualStyleBackColor = true;
            this.checkBoxForceShadersV3.CheckedChanged += new System.EventHandler(this.CheckBoxForceShadersV3CheckedChanged);
            // 
            // LightingParamsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(409, 722);
            this.Controls.Add(this.checkBoxForceShadersV3);
            this.Controls.Add(this.groupBoxLight3);
            this.Controls.Add(this.groupBoxLight2);
            this.Controls.Add(this.buttonResetAll);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxLight1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LightingParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lighting parameters";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1ShadowDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1AngleHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1AngleVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight1Intensity)).EndInit();
            this.groupBoxLight1.ResumeLayout(false);
            this.groupBoxLight1.PerformLayout();
            this.groupBoxLight2.ResumeLayout(false);
            this.groupBoxLight2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2ShadowDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2Intensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2AngleVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight2AngleHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3ShadowDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3Intensity)).EndInit();
            this.groupBoxLight3.ResumeLayout(false);
            this.groupBoxLight3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3AngleVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLight3AngleHorizontal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLight1ShadowDepth;
        private System.Windows.Forms.TrackBar trackBarLight1ShadowDepth;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TrackBar trackBarLight1AngleHorizontal;
        private System.Windows.Forms.TrackBar trackBarLight1AngleVertical;
        private System.Windows.Forms.TextBox textBoxLight1AngleHorizontal;
        private System.Windows.Forms.TextBox textBoxLight1AngleVertical;
        private System.Windows.Forms.TextBox textBoxLight1ShadowDepth;
        private System.Windows.Forms.Label labelLight1AngleHorizontal;
        private System.Windows.Forms.Label labelLight1AngleVertical;
        private System.Windows.Forms.Label labelLight1Intensity;
        private System.Windows.Forms.TrackBar trackBarLight1Intensity;
        private System.Windows.Forms.TextBox textBoxLight1Intensity;
        private System.Windows.Forms.Button buttonResetAll;
        private System.Windows.Forms.GroupBox groupBoxLight1;
        private System.Windows.Forms.GroupBox groupBoxLight2;
        private System.Windows.Forms.TextBox textBoxLight2Intensity;
        private System.Windows.Forms.TextBox textBoxLight2AngleVertical;
        private System.Windows.Forms.TextBox textBoxLight2AngleHorizontal;
        private System.Windows.Forms.TrackBar trackBarLight2Intensity;
        private System.Windows.Forms.TrackBar trackBarLight2AngleVertical;
        private System.Windows.Forms.TrackBar trackBarLight2AngleHorizontal;
        private System.Windows.Forms.Label labelLight2Intensity;
        private System.Windows.Forms.Label labelLight2AngleVertical;
        private System.Windows.Forms.Label labelLight2AngleHorizontal;
        private System.Windows.Forms.TextBox textBoxLight2ShadowDepth;
        private System.Windows.Forms.TrackBar trackBarLight2ShadowDepth;
        private System.Windows.Forms.Label labelLight2ShadowDepth;
        private System.Windows.Forms.Button buttonLight1Color;
        private System.Windows.Forms.Button buttonLight2Color;
        private System.Windows.Forms.Button buttonLight3Color;
        private System.Windows.Forms.TextBox textBoxLight3ShadowDepth;
        private System.Windows.Forms.TrackBar trackBarLight3ShadowDepth;
        private System.Windows.Forms.Label labelLight3ShadowDepth;
        private System.Windows.Forms.TextBox textBoxLight3Intensity;
        private System.Windows.Forms.TextBox textBoxLight3AngleVertical;
        private System.Windows.Forms.TextBox textBoxLight3AngleHorizontal;
        private System.Windows.Forms.TrackBar trackBarLight3Intensity;
        private System.Windows.Forms.GroupBox groupBoxLight3;
        private System.Windows.Forms.TrackBar trackBarLight3AngleVertical;
        private System.Windows.Forms.TrackBar trackBarLight3AngleHorizontal;
        private System.Windows.Forms.Label labelLight3Intensity;
        private System.Windows.Forms.Label labelLight3AngleVertical;
        private System.Windows.Forms.Label labelLight3AngleHorizontal;
        private System.Windows.Forms.CheckBox checkBoxForceShadersV3;
    }
}