using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public partial class SkyDomeParamsDialog : Form
    {
        private Game game;

        public SkyDomeParamsDialog(Game game) {
            this.game = game;
            InitializeComponent();

            SetTrackBarRotation(MathHelper.ToDegrees(game.SkyDomeRotation));
            SetTrackBarElevation(game.SkyDomeElevation);
            checkBoxDisplay.Checked = game.DisplaySkyDome;
        }

        private void SetTrackBarRotation(float rotation) {
            int rotationInt = (int)Math.Round(rotation);
            if (rotationInt < trackBarRotation.Minimum) {
                rotationInt = trackBarRotation.Minimum;
            }
            if (rotationInt > trackBarRotation.Maximum) {
                rotationInt = trackBarRotation.Maximum;
            }
            trackBarRotation.Value = rotationInt;
            textBoxRotation.Text = string.Format("{0}", rotationInt);
            game.SkyDomeRotation = MathHelper.ToRadians(rotationInt);
        }

        private void SetTrackBarElevation(float elevation) {
            int elevationInt = (int)Math.Round(elevation * 10.0f);
            if (elevationInt < trackBarElevation.Minimum) {
                elevationInt = trackBarElevation.Minimum;
            }
            if (elevationInt > trackBarElevation.Maximum) {
                elevationInt = trackBarElevation.Maximum;
            }
            elevation = elevationInt * 0.1f;
            trackBarElevation.Value = elevationInt;
            textBoxElevation.Text = string.Format("{0:0.0}", elevation);
            game.SkyDomeElevation = elevation;
        }

        private void TrackBarRotationScroll(object sender, EventArgs e) {
            int rotation = trackBarRotation.Value;
            SetTrackBarRotation(rotation);
        }

        private void TrackBarElevationScroll(object sender, EventArgs e) {
            float elevation = trackBarElevation.Value * 0.1f;
            SetTrackBarElevation(elevation);
        }

        private void CheckBoxDisplayCheckedChanged(object sender, EventArgs e) {
            game.DisplaySkyDome = checkBoxDisplay.Checked;
        }

        private void ButtonCloseClick(object sender, EventArgs e) {
            this.Close();
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }

        protected override void OnClosed(EventArgs e) {
            game.ControlGUI.HandleSkyDomeParamsDialogClosed();
        }
    }
}
