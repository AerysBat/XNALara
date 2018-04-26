namespace XNALara
{
    partial class CameraParamsDialog
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
            this.labelFOV = new System.Windows.Forms.Label();
            this.trackBarFOV = new System.Windows.Forms.TrackBar();
            this.textBoxFOV = new System.Windows.Forms.TextBox();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.labelTarget = new System.Windows.Forms.Label();
            this.textBoxTargetX = new System.Windows.Forms.TextBox();
            this.textBoxTargetY = new System.Windows.Forms.TextBox();
            this.textBoxTargetZ = new System.Windows.Forms.TextBox();
            this.labelRotation = new System.Windows.Forms.Label();
            this.labelRotationHoriz = new System.Windows.Forms.Label();
            this.labelRotationVert = new System.Windows.Forms.Label();
            this.textBoxRotationHoriz = new System.Windows.Forms.TextBox();
            this.textBoxRotationVert = new System.Windows.Forms.TextBox();
            this.labelDistance = new System.Windows.Forms.Label();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.labelTargetX = new System.Windows.Forms.Label();
            this.labelTargetY = new System.Windows.Forms.Label();
            this.labelTargetZ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFOV)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFOV
            // 
            this.labelFOV.AutoSize = true;
            this.labelFOV.Location = new System.Drawing.Point(12, 123);
            this.labelFOV.Name = "labelFOV";
            this.labelFOV.Size = new System.Drawing.Size(85, 17);
            this.labelFOV.TabIndex = 0;
            this.labelFOV.Text = "field of view:";
            // 
            // trackBarFOV
            // 
            this.trackBarFOV.Location = new System.Drawing.Point(103, 116);
            this.trackBarFOV.Maximum = 130;
            this.trackBarFOV.Minimum = 5;
            this.trackBarFOV.Name = "trackBarFOV";
            this.trackBarFOV.Size = new System.Drawing.Size(241, 61);
            this.trackBarFOV.TabIndex = 7;
            this.trackBarFOV.TickFrequency = 5;
            this.trackBarFOV.Value = 20;
            this.trackBarFOV.Scroll += new System.EventHandler(this.TrackBarFOVScroll);
            // 
            // textBoxFOV
            // 
            this.textBoxFOV.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFOV.Location = new System.Drawing.Point(350, 120);
            this.textBoxFOV.Name = "textBoxFOV";
            this.textBoxFOV.ReadOnly = true;
            this.textBoxFOV.Size = new System.Drawing.Size(80, 22);
            this.textBoxFOV.TabIndex = 0;
            this.textBoxFOV.TabStop = false;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Location = new System.Drawing.Point(12, 180);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(80, 27);
            this.buttonResetAll.TabIndex = 8;
            this.buttonResetAll.Text = "Reset all";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.ButtonResetAllClick);
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(12, 15);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(49, 17);
            this.labelTarget.TabIndex = 0;
            this.labelTarget.Text = "target:";
            // 
            // textBoxTargetX
            // 
            this.textBoxTargetX.Location = new System.Drawing.Point(104, 12);
            this.textBoxTargetX.Name = "textBoxTargetX";
            this.textBoxTargetX.Size = new System.Drawing.Size(80, 22);
            this.textBoxTargetX.TabIndex = 1;
            this.textBoxTargetX.Validated += new System.EventHandler(this.TextBoxTargetXValidated);
            this.textBoxTargetX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTargetXKeyPress);
            // 
            // textBoxTargetY
            // 
            this.textBoxTargetY.Location = new System.Drawing.Point(227, 12);
            this.textBoxTargetY.Name = "textBoxTargetY";
            this.textBoxTargetY.Size = new System.Drawing.Size(80, 22);
            this.textBoxTargetY.TabIndex = 2;
            this.textBoxTargetY.Validated += new System.EventHandler(this.TextBoxTargetYValidated);
            this.textBoxTargetY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTargetYKeyPress);
            // 
            // textBoxTargetZ
            // 
            this.textBoxTargetZ.Location = new System.Drawing.Point(350, 12);
            this.textBoxTargetZ.Name = "textBoxTargetZ";
            this.textBoxTargetZ.Size = new System.Drawing.Size(80, 22);
            this.textBoxTargetZ.TabIndex = 3;
            this.textBoxTargetZ.Validated += new System.EventHandler(this.TextBoxTargetZValidated);
            this.textBoxTargetZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTargetZKeyPress);
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Location = new System.Drawing.Point(12, 55);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(60, 17);
            this.labelRotation.TabIndex = 0;
            this.labelRotation.Text = "rotation:";
            // 
            // labelRotationHoriz
            // 
            this.labelRotationHoriz.AutoSize = true;
            this.labelRotationHoriz.Location = new System.Drawing.Point(81, 55);
            this.labelRotationHoriz.Name = "labelRotationHoriz";
            this.labelRotationHoriz.Size = new System.Drawing.Size(70, 17);
            this.labelRotationHoriz.TabIndex = 0;
            this.labelRotationHoriz.Text = "horizontal";
            // 
            // labelRotationVert
            // 
            this.labelRotationVert.AutoSize = true;
            this.labelRotationVert.Location = new System.Drawing.Point(81, 83);
            this.labelRotationVert.Name = "labelRotationVert";
            this.labelRotationVert.Size = new System.Drawing.Size(53, 17);
            this.labelRotationVert.TabIndex = 0;
            this.labelRotationVert.Text = "vertical";
            // 
            // textBoxRotationHoriz
            // 
            this.textBoxRotationHoriz.Location = new System.Drawing.Point(157, 52);
            this.textBoxRotationHoriz.Name = "textBoxRotationHoriz";
            this.textBoxRotationHoriz.Size = new System.Drawing.Size(80, 22);
            this.textBoxRotationHoriz.TabIndex = 4;
            this.textBoxRotationHoriz.Validated += new System.EventHandler(this.TextBoxRotationHorizValidated);
            this.textBoxRotationHoriz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRotationHorizKeyPress);
            // 
            // textBoxRotationVert
            // 
            this.textBoxRotationVert.Location = new System.Drawing.Point(157, 80);
            this.textBoxRotationVert.Name = "textBoxRotationVert";
            this.textBoxRotationVert.Size = new System.Drawing.Size(80, 22);
            this.textBoxRotationVert.TabIndex = 5;
            this.textBoxRotationVert.Validated += new System.EventHandler(this.TextBoxRotationVertValidated);
            this.textBoxRotationVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRotationVertKeyPress);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(279, 67);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(65, 17);
            this.labelDistance.TabIndex = 9;
            this.labelDistance.Text = "distance:";
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(350, 64);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(80, 22);
            this.textBoxDistance.TabIndex = 6;
            this.textBoxDistance.Validated += new System.EventHandler(this.TextBoxDistanceValidated);
            this.textBoxDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDistanceKeyPress);
            // 
            // labelTargetX
            // 
            this.labelTargetX.AutoSize = true;
            this.labelTargetX.Location = new System.Drawing.Point(81, 15);
            this.labelTargetX.Name = "labelTargetX";
            this.labelTargetX.Size = new System.Drawing.Size(17, 17);
            this.labelTargetX.TabIndex = 10;
            this.labelTargetX.Text = "X";
            // 
            // labelTargetY
            // 
            this.labelTargetY.AutoSize = true;
            this.labelTargetY.Location = new System.Drawing.Point(204, 15);
            this.labelTargetY.Name = "labelTargetY";
            this.labelTargetY.Size = new System.Drawing.Size(17, 17);
            this.labelTargetY.TabIndex = 11;
            this.labelTargetY.Text = "Y";
            // 
            // labelTargetZ
            // 
            this.labelTargetZ.AutoSize = true;
            this.labelTargetZ.Location = new System.Drawing.Point(327, 15);
            this.labelTargetZ.Name = "labelTargetZ";
            this.labelTargetZ.Size = new System.Drawing.Size(17, 17);
            this.labelTargetZ.TabIndex = 12;
            this.labelTargetZ.Text = "Z";
            // 
            // CameraParamsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(444, 227);
            this.Controls.Add(this.labelTargetZ);
            this.Controls.Add(this.labelTargetY);
            this.Controls.Add(this.labelTargetX);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.textBoxRotationVert);
            this.Controls.Add(this.textBoxRotationHoriz);
            this.Controls.Add(this.labelRotationVert);
            this.Controls.Add(this.labelRotationHoriz);
            this.Controls.Add(this.labelRotation);
            this.Controls.Add(this.textBoxTargetZ);
            this.Controls.Add(this.textBoxTargetY);
            this.Controls.Add(this.textBoxTargetX);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.buttonResetAll);
            this.Controls.Add(this.textBoxFOV);
            this.Controls.Add(this.trackBarFOV);
            this.Controls.Add(this.labelFOV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CameraParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera parameters";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFOV;
        private System.Windows.Forms.TrackBar trackBarFOV;
        private System.Windows.Forms.TextBox textBoxFOV;
        private System.Windows.Forms.Button buttonResetAll;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.TextBox textBoxTargetX;
        private System.Windows.Forms.TextBox textBoxTargetY;
        private System.Windows.Forms.TextBox textBoxTargetZ;
        private System.Windows.Forms.Label labelRotation;
        private System.Windows.Forms.Label labelRotationHoriz;
        private System.Windows.Forms.Label labelRotationVert;
        private System.Windows.Forms.TextBox textBoxRotationHoriz;
        private System.Windows.Forms.TextBox textBoxRotationVert;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label labelTargetX;
        private System.Windows.Forms.Label labelTargetY;
        private System.Windows.Forms.Label labelTargetZ;
    }
}