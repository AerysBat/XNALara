namespace XNALara
{
    partial class PostProcessParamsDialog
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
            this.labelBrightness = new System.Windows.Forms.Label();
            this.labelContrast = new System.Windows.Forms.Label();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.textBoxBrightness = new System.Windows.Forms.TextBox();
            this.textBoxContrast = new System.Windows.Forms.TextBox();
            this.textBoxSaturation = new System.Windows.Forms.TextBox();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelGamma = new System.Windows.Forms.Label();
            this.trackBarGamma = new System.Windows.Forms.TrackBar();
            this.textBoxGamma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBrightness.Location = new System.Drawing.Point(12, 16);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(79, 17);
            this.labelBrightness.TabIndex = 0;
            this.labelBrightness.Text = "Brightness:";
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(12, 106);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(65, 17);
            this.labelContrast.TabIndex = 1;
            this.labelContrast.Text = "Contrast:";
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(12, 151);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(77, 17);
            this.labelSaturation.TabIndex = 2;
            this.labelSaturation.Text = "Saturation:";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.LargeChange = 10;
            this.trackBarBrightness.Location = new System.Drawing.Point(97, 12);
            this.trackBarBrightness.Maximum = 300;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(237, 53);
            this.trackBarBrightness.TabIndex = 0;
            this.trackBarBrightness.TickFrequency = 10;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.TrackBarBrightnessScroll);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.LargeChange = 10;
            this.trackBarContrast.Location = new System.Drawing.Point(97, 102);
            this.trackBarContrast.Maximum = 300;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(237, 53);
            this.trackBarContrast.TabIndex = 2;
            this.trackBarContrast.TickFrequency = 10;
            this.trackBarContrast.Scroll += new System.EventHandler(this.TrackBarContrastScroll);
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.LargeChange = 10;
            this.trackBarSaturation.Location = new System.Drawing.Point(97, 147);
            this.trackBarSaturation.Maximum = 300;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(237, 53);
            this.trackBarSaturation.TabIndex = 3;
            this.trackBarSaturation.TickFrequency = 10;
            this.trackBarSaturation.Scroll += new System.EventHandler(this.TrackBarSaturationScroll);
            // 
            // textBoxBrightness
            // 
            this.textBoxBrightness.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBrightness.Location = new System.Drawing.Point(340, 13);
            this.textBoxBrightness.Name = "textBoxBrightness";
            this.textBoxBrightness.ReadOnly = true;
            this.textBoxBrightness.Size = new System.Drawing.Size(40, 22);
            this.textBoxBrightness.TabIndex = 0;
            this.textBoxBrightness.TabStop = false;
            // 
            // textBoxContrast
            // 
            this.textBoxContrast.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxContrast.Location = new System.Drawing.Point(340, 103);
            this.textBoxContrast.Name = "textBoxContrast";
            this.textBoxContrast.ReadOnly = true;
            this.textBoxContrast.Size = new System.Drawing.Size(40, 22);
            this.textBoxContrast.TabIndex = 0;
            this.textBoxContrast.TabStop = false;
            // 
            // textBoxSaturation
            // 
            this.textBoxSaturation.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSaturation.Location = new System.Drawing.Point(340, 148);
            this.textBoxSaturation.Name = "textBoxSaturation";
            this.textBoxSaturation.ReadOnly = true;
            this.textBoxSaturation.Size = new System.Drawing.Size(40, 22);
            this.textBoxSaturation.TabIndex = 0;
            this.textBoxSaturation.TabStop = false;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Location = new System.Drawing.Point(12, 213);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(75, 27);
            this.buttonResetAll.TabIndex = 9;
            this.buttonResetAll.Text = "Reset all";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.ButtonResetAllClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(305, 213);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 27);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(12, 61);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(61, 17);
            this.labelGamma.TabIndex = 11;
            this.labelGamma.Text = "Gamma:";
            // 
            // trackBarGamma
            // 
            this.trackBarGamma.LargeChange = 10;
            this.trackBarGamma.Location = new System.Drawing.Point(97, 57);
            this.trackBarGamma.Maximum = 300;
            this.trackBarGamma.Name = "trackBarGamma";
            this.trackBarGamma.Size = new System.Drawing.Size(237, 53);
            this.trackBarGamma.TabIndex = 1;
            this.trackBarGamma.TickFrequency = 10;
            this.trackBarGamma.Scroll += new System.EventHandler(this.TrackBarGammaScroll);
            // 
            // textBoxGamma
            // 
            this.textBoxGamma.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGamma.Location = new System.Drawing.Point(340, 58);
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.ReadOnly = true;
            this.textBoxGamma.Size = new System.Drawing.Size(40, 22);
            this.textBoxGamma.TabIndex = 0;
            this.textBoxGamma.TabStop = false;
            // 
            // PostProcessParamsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(392, 254);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.textBoxGamma);
            this.Controls.Add(this.trackBarGamma);
            this.Controls.Add(this.labelGamma);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonResetAll);
            this.Controls.Add(this.textBoxSaturation);
            this.Controls.Add(this.textBoxContrast);
            this.Controls.Add(this.textBoxBrightness);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.labelContrast);
            this.Controls.Add(this.labelBrightness);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PostProcessParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Post-processing parameters";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.TextBox textBoxBrightness;
        private System.Windows.Forms.TextBox textBoxContrast;
        private System.Windows.Forms.TextBox textBoxSaturation;
        private System.Windows.Forms.Button buttonResetAll;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.TrackBar trackBarGamma;
        private System.Windows.Forms.TextBox textBoxGamma;
    }
}