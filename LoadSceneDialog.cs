using System;
using System.Windows.Forms;

namespace XNALara
{
    public partial class LoadSceneDialog : Form
    {
        private Game game;

        public LoadSceneDialog(Game game) {
            this.game = game;
            InitializeComponent();
        }

        public bool ClearScene {
            get { return checkBoxClearScene.Checked; }
        }

        public bool LoadScene {
            get { return checkBoxScene.Checked; }
        }

        public bool LoadCamera {
            get { return checkBoxCamera.Checked; }
        }

        public bool LoadLights {
            get { return checkBoxLights.Checked; }
        }

        public bool LoadPostProcess {
            get { return checkBoxPostProcess.Checked; }
        }

        public bool LoadWindowSize {
            get { return checkBoxWindowSize.Checked; }
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
