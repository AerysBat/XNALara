using System;
using System.Windows.Forms;

namespace XNALara
{
    public partial class AboutBox : Form
    {
        private Game game;

        public AboutBox(Game game) {
            this.game = game;
            InitializeComponent();

            labelVersionAndDate.Text = string.Format("v{0}, {1}", game.ReleaseVersion, game.ReleaseDate);
            labelShaders.Text = string.Format("{0}, {1}", game.MaxVertexShaderProfile, game.MaxPixelShaderProfile);
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
