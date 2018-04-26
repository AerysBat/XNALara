using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public partial class CameraParamsDialog : Form
    {
        public static readonly Vector3 DefaultCameraTarget = new Vector3(0, 1, 0);
        public static readonly float DefaultCameraRotationHoriz = 0.0f;
        public static readonly float DefaultCameraRotationVert = 10.0f;
        public static readonly float DefaultCameraDistance = 4.0f;
        public static readonly float DefaultCameraFOV = 30.0f;

        private Game game;

        public CameraParamsDialog(Game game) {
            this.game = game;
            InitializeComponent();

            game.Camera.CameraEvent += HandleCameraEvent;
            HandleCameraEvent();
        }

        private void ButtonResetAllClick(object sender, EventArgs e) {
            game.Camera.FieldOfViewHorizontal = MathHelper.ToRadians(DefaultCameraFOV);
            game.Camera.Target = DefaultCameraTarget;
            game.Camera.Distance = DefaultCameraDistance;
            game.Camera.SetRotation(MathHelper.ToRadians(DefaultCameraRotationHoriz), MathHelper.ToRadians(DefaultCameraRotationVert));
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }

        protected override void OnClosed(EventArgs e) {
            game.Camera.CameraEvent -= HandleCameraEvent;
            game.ControlGUI.HandleCameraParamsDialogClosed();
        }

        private void HandleCameraEvent() {
            textBoxTargetX.Text = string.Format("{0:0.0###}", game.Camera.Target.X);
            textBoxTargetY.Text = string.Format("{0:0.0###}", game.Camera.Target.Y);
            textBoxTargetZ.Text = string.Format("{0:0.0###}", game.Camera.Target.Z);

            textBoxRotationHoriz.Text = string.Format("{0:0.0###}", MathHelper.ToDegrees(game.Camera.RotationHorizontal));
            textBoxRotationVert.Text = string.Format("{0:0.0###}", MathHelper.ToDegrees(game.Camera.RotationVertical));

            textBoxDistance.Text = string.Format("{0:0.0###}", game.Camera.Distance);

            int fovDeg = (int)Math.Round(MathHelper.ToDegrees(game.Camera.FieldOfViewHorizontal));
            trackBarFOV.Value = fovDeg;
            textBoxFOV.Text = string.Format("{0}", fovDeg);
        }

        private bool HandleTextInputTarget() {
            float targetX, targetY, targetZ;
            if (!float.TryParse(textBoxTargetX.Text, out targetX)) {
                return false;
            }
            if (!float.TryParse(textBoxTargetY.Text, out targetY)) {
                return false;
            }
            if (!float.TryParse(textBoxTargetZ.Text, out targetZ)) {
                return false;
            }
            
            game.Camera.Target = new Vector3(targetX, targetY, targetZ);
            return true;
        }

        private bool HandleTextInputRotation() {
            float angleHoriz, angleVert;
            if (!float.TryParse(textBoxRotationHoriz.Text, out angleHoriz)) {
                return false;
            }
            if (!float.TryParse(textBoxRotationVert.Text, out angleVert)) {
                return false;
            }

            game.Camera.SetRotation(MathHelper.ToRadians(angleHoriz), MathHelper.ToRadians(angleVert));
            return true;
        }

        private bool HandleTextInputDistance() {
            float distance;
            if (!float.TryParse(textBoxDistance.Text, out distance)) {
                return false;
            }

            game.Camera.Distance = distance;
            return true;
        }

        private void TextBoxTargetXKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputTarget();
            }
        }

        private void TextBoxTargetYKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputTarget();
            }
        }

        private void TextBoxTargetZKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputTarget();
            }
        }

        private void TextBoxTargetXValidated(object sender, EventArgs e) {
            HandleTextInputTarget();
        }

        private void TextBoxTargetYValidated(object sender, EventArgs e) {
            HandleTextInputTarget();
        }

        private void TextBoxTargetZValidated(object sender, EventArgs e) {
            HandleTextInputTarget();
        }

        private void TextBoxRotationHorizKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputRotation();
            }
        }

        private void TextBoxRotationVertKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputRotation();
            }
        }

        private void TextBoxRotationHorizValidated(object sender, EventArgs e) {
            HandleTextInputRotation();
        }

        private void TextBoxRotationVertValidated(object sender, EventArgs e) {
            HandleTextInputRotation();
        }

        private void TextBoxDistanceKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputDistance();
            }
        }

        private void TextBoxDistanceValidated(object sender, EventArgs e) {
            HandleTextInputDistance();
        }

        private void TrackBarFOVScroll(object sender, EventArgs e) {
            game.Camera.FieldOfViewHorizontal = MathHelper.ToRadians(trackBarFOV.Value);
        }
    }
}
