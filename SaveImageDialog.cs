using System;
using System.Windows.Forms;

namespace XNALara
{
    public partial class SaveImageDialog : Form
    {
        private Game game;

        public SaveImageDialog(Game game) {
            this.game = game;
            InitializeComponent();

            comboBox.SelectedIndex = 1;
        }

        public double ImageSize {
            get {
                switch (comboBox.SelectedIndex) {
                    case 0:
                        return 0.5;
                    default:
                    case 1:
                        return 1.0;
                    case 2:
                        return 1.25;
                    case 3:
                        return 1.5;
                    case 4:
                        return 2.0;
                    case 5:
                        return 2.5;
                    case 6:
                        return 3.0;
                    case 7:
                        return 4.0;
                    case 8:
                        return 5.0;
                    case 9:
                        return 6.0;
                    case 10:
                        return 8.0;
                    case 11:
                        return 10.0;
                }
            }
        }

        public bool SaveAlphaChannel {
            get { return checkBoxAlpha.Checked; }
        }

        public bool RenderLogo {
            set { checkBoxLogo.Checked = value; }
            get { return checkBoxLogo.Checked; }
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
