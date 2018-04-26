namespace XNALara
{
    partial class LoadSceneDialog
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
            this.checkBoxScene = new System.Windows.Forms.CheckBox();
            this.checkBoxCamera = new System.Windows.Forms.CheckBox();
            this.checkBoxLights = new System.Windows.Forms.CheckBox();
            this.checkBoxClearScene = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxWindowSize = new System.Windows.Forms.CheckBox();
            this.checkBoxPostProcess = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxScene
            // 
            this.checkBoxScene.AutoSize = true;
            this.checkBoxScene.Checked = true;
            this.checkBoxScene.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxScene.Location = new System.Drawing.Point(12, 39);
            this.checkBoxScene.Name = "checkBoxScene";
            this.checkBoxScene.Size = new System.Drawing.Size(289, 21);
            this.checkBoxScene.TabIndex = 1;
            this.checkBoxScene.Text = "load scene (models, background, skybox)";
            this.checkBoxScene.UseVisualStyleBackColor = true;
            // 
            // checkBoxCamera
            // 
            this.checkBoxCamera.AutoSize = true;
            this.checkBoxCamera.Checked = true;
            this.checkBoxCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCamera.Location = new System.Drawing.Point(12, 76);
            this.checkBoxCamera.Name = "checkBoxCamera";
            this.checkBoxCamera.Size = new System.Drawing.Size(105, 21);
            this.checkBoxCamera.TabIndex = 2;
            this.checkBoxCamera.Text = "load camera";
            this.checkBoxCamera.UseVisualStyleBackColor = true;
            // 
            // checkBoxLights
            // 
            this.checkBoxLights.AutoSize = true;
            this.checkBoxLights.Checked = true;
            this.checkBoxLights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLights.Location = new System.Drawing.Point(12, 103);
            this.checkBoxLights.Name = "checkBoxLights";
            this.checkBoxLights.Size = new System.Drawing.Size(91, 21);
            this.checkBoxLights.TabIndex = 3;
            this.checkBoxLights.Text = "load lights";
            this.checkBoxLights.UseVisualStyleBackColor = true;
            // 
            // checkBoxClearScene
            // 
            this.checkBoxClearScene.AutoSize = true;
            this.checkBoxClearScene.Checked = true;
            this.checkBoxClearScene.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClearScene.Location = new System.Drawing.Point(12, 12);
            this.checkBoxClearScene.Name = "checkBoxClearScene";
            this.checkBoxClearScene.Size = new System.Drawing.Size(174, 21);
            this.checkBoxClearScene.TabIndex = 0;
            this.checkBoxClearScene.Text = "remove existing models";
            this.checkBoxClearScene.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(202, 197);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBoxWindowSize
            // 
            this.checkBoxWindowSize.AutoSize = true;
            this.checkBoxWindowSize.Checked = true;
            this.checkBoxWindowSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWindowSize.Location = new System.Drawing.Point(12, 167);
            this.checkBoxWindowSize.Name = "checkBoxWindowSize";
            this.checkBoxWindowSize.Size = new System.Drawing.Size(149, 21);
            this.checkBoxWindowSize.TabIndex = 5;
            this.checkBoxWindowSize.Text = "update window size";
            this.checkBoxWindowSize.UseVisualStyleBackColor = true;
            // 
            // checkBoxPostProcess
            // 
            this.checkBoxPostProcess.AutoSize = true;
            this.checkBoxPostProcess.Checked = true;
            this.checkBoxPostProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPostProcess.Location = new System.Drawing.Point(12, 130);
            this.checkBoxPostProcess.Name = "checkBoxPostProcess";
            this.checkBoxPostProcess.Size = new System.Drawing.Size(210, 21);
            this.checkBoxPostProcess.TabIndex = 4;
            this.checkBoxPostProcess.Text = "load post-processing params";
            this.checkBoxPostProcess.UseVisualStyleBackColor = true;
            // 
            // LoadSceneDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 244);
            this.Controls.Add(this.checkBoxPostProcess);
            this.Controls.Add(this.checkBoxWindowSize);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxClearScene);
            this.Controls.Add(this.checkBoxLights);
            this.Controls.Add(this.checkBoxCamera);
            this.Controls.Add(this.checkBoxScene);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadSceneDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load scene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxScene;
        private System.Windows.Forms.CheckBox checkBoxCamera;
        private System.Windows.Forms.CheckBox checkBoxLights;
        private System.Windows.Forms.CheckBox checkBoxClearScene;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxWindowSize;
        private System.Windows.Forms.CheckBox checkBoxPostProcess;
    }
}