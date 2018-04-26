namespace XNALara
{
    public partial class AboutBox
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelShaders = new System.Windows.Forms.Label();
            this.labelVersionAndDate = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(9, 133);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(150, 20);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Dusan Pavlicek";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 184);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(359, 27);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::XNALara.Properties.Resources.XNALaraAbout;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(9, 9);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(362, 122);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // labelShaders
            // 
            this.labelShaders.ForeColor = System.Drawing.Color.Gray;
            this.labelShaders.Location = new System.Drawing.Point(218, 153);
            this.labelShaders.Name = "labelShaders";
            this.labelShaders.Size = new System.Drawing.Size(150, 20);
            this.labelShaders.TabIndex = 8;
            this.labelShaders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVersionAndDate
            // 
            this.labelVersionAndDate.BackColor = System.Drawing.SystemColors.Control;
            this.labelVersionAndDate.Location = new System.Drawing.Point(168, 133);
            this.labelVersionAndDate.Name = "labelVersionAndDate";
            this.labelVersionAndDate.Size = new System.Drawing.Size(200, 20);
            this.labelVersionAndDate.TabIndex = 9;
            this.labelVersionAndDate.Text = "v1.0";
            this.labelVersionAndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelContact
            // 
            this.labelContact.Location = new System.Drawing.Point(9, 153);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(150, 20);
            this.labelContact.TabIndex = 3;
            this.labelContact.Text = "pavlicd@volny.cz";
            this.labelContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 229);
            this.Controls.Add(this.labelVersionAndDate);
            this.Controls.Add(this.labelShaders);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.labelAuthor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelShaders;
        private System.Windows.Forms.Label labelVersionAndDate;
        private System.Windows.Forms.Label labelContact;
    }
}