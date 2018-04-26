using System;
using System.Windows.Forms;

namespace XNALara
{
    public partial class HelpBox : Form
    {
        private Game game;

        public HelpBox(Game game) {
            this.game = game;
            InitializeComponent();

            textBox.Lines = new string[] {
                "LMB drag ... rotate camera",
                "Shift + LMB drag, or LMB + RMB drag ... pan camera",
                "RMB drag ... zoom camera",
                "Shift + RMB drag ... move camera forward/backward",
                "",
                "LMB click ... select bone",
                "",
                "(NumPad1 or Q) + LMB drag ... rotate selected bone around X axis",
                "(NumPad2 or W) + LMB drag ... rotate selected bone around Y axis",
                "(NumPad3 or E) + LMB drag ... rotate selected bone around Z axis",
                "",
                "NumPad0 ... reset selected bone",
                "",
                "Ctrl + LMB click/drag ... position model on ground plane",
                "(Shift +) arrow keys ... move model on ground plane (two speeds)",
                "(Shift +) Alt + arrow keys ... move model vertically",
                "",
                "F2 ... camera quick-save",
                "F3 ... camera quick-load",
                "",
                "F5 ... image quick-save",
                "F8 ... reload textures of the selected model",
                "",
                "1, 2, 3, 4, 5, 6, 7, 8, 9, 0 ... set predefined camera target (look-at)",
                "",
                "Ctrl + Z or NumPad5 ... undo (bone transforms)",
            };
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
