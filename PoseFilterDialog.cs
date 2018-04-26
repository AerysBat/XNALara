using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XNALara
{
    public partial class PoseFilterDialog : Form
    {
        private Game game;
        private Dictionary<string, string> selectedBones = new Dictionary<string, string>();

        public PoseFilterDialog(Game game,
                                string dialogTitle, string labelText, 
                                ICollection<string> boneNames,
                                bool allSelectedByDefault) {
            InitializeComponent();
            this.game = game;
            this.Text = dialogTitle;
            this.label.Text = labelText;

            foreach (string boneName in boneNames) {
                this.listBox.Items.Add(boneName);
            }

            if (allSelectedByDefault) {
                int itemCount = this.listBox.Items.Count;
                for (int i = 0; i < itemCount; i++) {
                    this.listBox.SetSelected(i, true);
                }
            }
        }

        public bool IsBoneSelected(string boneName) {
            return selectedBones.ContainsKey(boneName);
        }

        private void ButtonOKClick(object sender, System.EventArgs e) {
            selectedBones.Clear();
            foreach (string boneName in listBox.SelectedItems) {
                selectedBones[boneName] = boneName;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
