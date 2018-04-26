using System.Windows.Forms;
namespace XNALara
{
    partial class AddItemDialog
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
        private void InitializeComponent(bool multiSelect) {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxInFrontOfCamera = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView = multiSelect ? new XNALara.TreeViewMultiSelect() : new TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = string.Format("Select model{0} to add:", multiSelect ? "(s)" : "");
            // 
            // buttonOK
            // 
            this.buttonOK.AutoSize = true;
            this.buttonOK.Location = new System.Drawing.Point(357, 430);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 27);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // checkBoxInFrontOfCamera
            // 
            this.checkBoxInFrontOfCamera.AutoSize = true;
            this.checkBoxInFrontOfCamera.Location = new System.Drawing.Point(12, 434);
            this.checkBoxInFrontOfCamera.Name = "checkBoxInFrontOfCamera";
            this.checkBoxInFrontOfCamera.Size = new System.Drawing.Size(176, 21);
            this.checkBoxInFrontOfCamera.TabIndex = 4;
            this.checkBoxInFrontOfCamera.Text = "place in front of camera";
            this.checkBoxInFrontOfCamera.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = multiSelect ? " (press Ctrl for multi-selection)" : "";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 29);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(420, 395);
            this.treeView.TabIndex = 3;
            // 
            // AddItemDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(444, 469);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxInFrontOfCamera);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItemDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = string.Format("Add model{0}", multiSelect ? "(s)" : "");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private TreeView treeView;
        private System.Windows.Forms.CheckBox checkBoxInFrontOfCamera;
        private System.Windows.Forms.Label label2;
    }
}