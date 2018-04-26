namespace XNALara
{
    partial class SkyDomeParamsDialog
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
            this.labelRotation = new System.Windows.Forms.Label();
            this.labelElevation = new System.Windows.Forms.Label();
            this.trackBarRotation = new System.Windows.Forms.TrackBar();
            this.trackBarElevation = new System.Windows.Forms.TrackBar();
            this.textBoxRotation = new System.Windows.Forms.TextBox();
            this.textBoxElevation = new System.Windows.Forms.TextBox();
            this.checkBoxDisplay = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarElevation)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Location = new System.Drawing.Point(12, 16);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(60, 17);
            this.labelRotation.TabIndex = 0;
            this.labelRotation.Text = "rotation:";
            // 
            // labelElevation
            // 
            this.labelElevation.AutoSize = true;
            this.labelElevation.Location = new System.Drawing.Point(12, 63);
            this.labelElevation.Name = "labelElevation";
            this.labelElevation.Size = new System.Drawing.Size(69, 17);
            this.labelElevation.TabIndex = 0;
            this.labelElevation.Text = "elevation:";
            // 
            // trackBarRotation
            // 
            this.trackBarRotation.Location = new System.Drawing.Point(88, 12);
            this.trackBarRotation.Maximum = 360;
            this.trackBarRotation.Name = "trackBarRotation";
            this.trackBarRotation.Size = new System.Drawing.Size(278, 53);
            this.trackBarRotation.TabIndex = 1;
            this.trackBarRotation.TickFrequency = 10;
            this.trackBarRotation.Scroll += new System.EventHandler(this.TrackBarRotationScroll);
            // 
            // trackBarElevation
            // 
            this.trackBarElevation.Location = new System.Drawing.Point(88, 59);
            this.trackBarElevation.Maximum = 150;
            this.trackBarElevation.Minimum = -50;
            this.trackBarElevation.Name = "trackBarElevation";
            this.trackBarElevation.Size = new System.Drawing.Size(278, 53);
            this.trackBarElevation.TabIndex = 2;
            this.trackBarElevation.TickFrequency = 5;
            this.trackBarElevation.Scroll += new System.EventHandler(this.TrackBarElevationScroll);
            // 
            // textBoxRotation
            // 
            this.textBoxRotation.Location = new System.Drawing.Point(372, 16);
            this.textBoxRotation.Name = "textBoxRotation";
            this.textBoxRotation.Size = new System.Drawing.Size(60, 22);
            this.textBoxRotation.TabIndex = 0;
            this.textBoxRotation.TabStop = false;
            // 
            // textBoxElevation
            // 
            this.textBoxElevation.Location = new System.Drawing.Point(372, 63);
            this.textBoxElevation.Name = "textBoxElevation";
            this.textBoxElevation.Size = new System.Drawing.Size(60, 22);
            this.textBoxElevation.TabIndex = 0;
            this.textBoxElevation.TabStop = false;
            // 
            // checkBoxDisplay
            // 
            this.checkBoxDisplay.AutoSize = true;
            this.checkBoxDisplay.Location = new System.Drawing.Point(15, 120);
            this.checkBoxDisplay.Name = "checkBoxDisplay";
            this.checkBoxDisplay.Size = new System.Drawing.Size(131, 21);
            this.checkBoxDisplay.TabIndex = 3;
            this.checkBoxDisplay.Text = "display skydome";
            this.checkBoxDisplay.UseVisualStyleBackColor = true;
            this.checkBoxDisplay.CheckedChanged += new System.EventHandler(this.CheckBoxDisplayCheckedChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(352, 116);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 27);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // SkyDomeParamsDialog
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(444, 164);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.checkBoxDisplay);
            this.Controls.Add(this.textBoxElevation);
            this.Controls.Add(this.textBoxRotation);
            this.Controls.Add(this.trackBarElevation);
            this.Controls.Add(this.trackBarRotation);
            this.Controls.Add(this.labelElevation);
            this.Controls.Add(this.labelRotation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SkyDomeParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skydome parameters";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarElevation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRotation;
        private System.Windows.Forms.Label labelElevation;
        private System.Windows.Forms.TrackBar trackBarRotation;
        private System.Windows.Forms.TrackBar trackBarElevation;
        private System.Windows.Forms.TextBox textBoxRotation;
        private System.Windows.Forms.TextBox textBoxElevation;
        private System.Windows.Forms.CheckBox checkBoxDisplay;
        private System.Windows.Forms.Button buttonClose;
    }
}