namespace XNALara
{
    public partial class SaveImageDialog
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxAlpha = new System.Windows.Forms.CheckBox();
            this.checkBoxLogo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "50%",
            "100%",
            "125%",
            "150%",
            "200%",
            "250%",
            "300%",
            "400%",
            "500%",
            "600%",
            "800%",
            "1000%"});
            this.comboBox.Location = new System.Drawing.Point(97, 12);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(100, 24);
            this.comboBox.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 17);
            this.label.TabIndex = 1;
            this.label.Text = "image size:";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(15, 115);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(182, 27);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlpha
            // 
            this.checkBoxAlpha.AutoSize = true;
            this.checkBoxAlpha.Location = new System.Drawing.Point(15, 50);
            this.checkBoxAlpha.Name = "checkBoxAlpha";
            this.checkBoxAlpha.Size = new System.Drawing.Size(150, 21);
            this.checkBoxAlpha.TabIndex = 3;
            this.checkBoxAlpha.Text = "save alpha channel";
            this.checkBoxAlpha.UseVisualStyleBackColor = true;
            // 
            // checkBoxLogo
            // 
            this.checkBoxLogo.AutoSize = true;
            this.checkBoxLogo.Location = new System.Drawing.Point(15, 77);
            this.checkBoxLogo.Name = "checkBoxLogo";
            this.checkBoxLogo.Size = new System.Drawing.Size(100, 21);
            this.checkBoxLogo.TabIndex = 4;
            this.checkBoxLogo.Text = "render logo";
            this.checkBoxLogo.UseVisualStyleBackColor = true;
            // 
            // SaveImageDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(214, 154);
            this.Controls.Add(this.checkBoxLogo);
            this.Controls.Add(this.checkBoxAlpha);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label);
            this.Controls.Add(this.comboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveImageDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select image size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxAlpha;
        private System.Windows.Forms.CheckBox checkBoxLogo;
    }
}