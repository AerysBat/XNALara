using System;
using System.Drawing;
using System.Windows.Forms;

namespace XNALara
{
    public partial class CanvasSizeDialog : Form
    {
        private Game game;

        public CanvasSizeDialog(Game game) {
            this.game = game;
            InitializeComponent();
            comboBox.SelectedIndex = 0;
        }

        public Size CanvasSize {
            get {
                switch (comboBox.SelectedIndex) {
                    default:
                    case 0:
                        return new Size(700, 700);
                    case 1:
                        return new Size(320, 240);
                    case 2:
                        return new Size(512, 384);
                    case 3:
                        return new Size(640, 480);
                    case 4:
                        return new Size(720, 576);
                    case 5:
                        return new Size(800, 600);
                    case 6:
                        return new Size(960, 720);
                    case 7:
                        return new Size(1024, 768);
                    case 8:
                        return new Size(1280, 960);
                    case 9:
                        return new Size(1600, 1200);
                    case 10:
                        return new Size(320, 180);
                    case 11:
                        return new Size(512, 288);
                    case 12:
                        return new Size(640, 360);
                    case 13:
                        return new Size(720, 405);
                    case 14:
                        return new Size(800, 450);
                    case 15:
                        return new Size(960, 540);
                    case 16:
                        return new Size(1024, 576);
                    case 17:
                        return new Size(1280, 720);
                    case 18:
                        return new Size(1600, 900);
                }
            }
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
