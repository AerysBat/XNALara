using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public partial class LightingParamsDialog : Form
    {
        public static readonly Vector3 DefaultLight1Direction = new Vector3(-1, -1, -1);
        public static readonly float DefaultLight1Intensity = 1.1f;
        public static readonly Color DefaultLight1Color = Color.White;
        public static readonly float DefaultLight1ShadowDepth = 0.4f;

        public static readonly Vector3 DefaultLight2Direction = new Vector3(+1, -1, -1);
        public static readonly float DefaultLight2Intensity = 0.0f;
        public static readonly Color DefaultLight2Color = Color.White;
        public static readonly float DefaultLight2ShadowDepth = 0.4f;

        public static readonly Vector3 DefaultLight3Direction = new Vector3(0, -1, 0);
        public static readonly float DefaultLight3Intensity = 0.0f;
        public static readonly Color DefaultLight3Color = Color.White;
        public static readonly float DefaultLight3ShadowDepth = 0.4f;

        public static readonly bool DefaultForceShadersV3 = false;

        private Game game;

        public LightingParamsDialog(Game game) {
            this.game = game;
            InitializeComponent();

            SetTrackBarLight1AngleHorizontal(game.Light1AngleHorizontal);
            SetTrackBarLight1AngleVertical(game.Light1AngleVertical);
            SetTrackBarLight1Intensity(game.Light1Intensity);
            SetButtonLight1Color(game.Light1Color);
            SetTrackBarLight1ShadowDepth(game.Light1ShadowDepth);

            SetTrackBarLight2AngleHorizontal(game.Light2AngleHorizontal);
            SetTrackBarLight2AngleVertical(game.Light2AngleVertical);
            SetTrackBarLight2Intensity(game.Light2Intensity);
            SetButtonLight2Color(game.Light2Color);
            SetTrackBarLight2ShadowDepth(game.Light2ShadowDepth);

            SetTrackBarLight3AngleHorizontal(game.Light3AngleHorizontal);
            SetTrackBarLight3AngleVertical(game.Light3AngleVertical);
            SetTrackBarLight3Intensity(game.Light3Intensity);
            SetButtonLight3Color(game.Light3Color);
            SetTrackBarLight3ShadowDepth(game.Light3ShadowDepth);

            SetCheckBoxForceShadersV3(game.ForceShadersV3);
        }

        private void SetTrackBarLight1AngleHorizontal(float angle) {
            int angleInt = (int)Math.Round(angle);
            while (angleInt < 0) {
                angleInt += 360;
            }
            while (angleInt > 360) {
                angleInt -= 360;
            }
            trackBarLight1AngleHorizontal.Value = angleInt;
            textBoxLight1AngleHorizontal.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight1AngleVertical(float angle) {
            int angleInt = (int)Math.Round(angle);
            if (angleInt < -90) {
                angleInt = -90;
            }
            if (angleInt > 90) {
                angleInt = 90;
            }
            trackBarLight1AngleVertical.Value = angleInt;
            textBoxLight1AngleVertical.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight1Intensity(float intensity) {
            int value = (int)Math.Round(intensity * 100);
            if (value > trackBarLight1Intensity.Maximum) {
                value = trackBarLight1Intensity.Maximum;
            }
            trackBarLight1Intensity.Value = value;
            textBoxLight1Intensity.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetButtonLight1Color(Color color) {
            buttonLight1Color.BackColor = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
        }

        private void SetTrackBarLight1ShadowDepth(float depth) {
            int value = (int)Math.Round(depth * 100);
            if (value > trackBarLight1ShadowDepth.Maximum) {
                value = trackBarLight1ShadowDepth.Maximum;
            }
            trackBarLight1ShadowDepth.Value = value;
            textBoxLight1ShadowDepth.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetTrackBarLight2AngleHorizontal(float angle) {
            int angleInt = (int)Math.Round(angle);
            while (angleInt < 0) {
                angleInt += 360;
            }
            while (angleInt > 360) {
                angleInt -= 360;
            }
            trackBarLight2AngleHorizontal.Value = angleInt;
            textBoxLight2AngleHorizontal.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight2AngleVertical(float angle) {
            int angleInt = (int)Math.Round(angle);
            if (angleInt < -90) {
                angleInt = -90;
            }
            if (angleInt > 90) {
                angleInt = 90;
            }
            trackBarLight2AngleVertical.Value = angleInt;
            textBoxLight2AngleVertical.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight2Intensity(float intensity) {
            int value = (int)Math.Round(intensity * 100);
            if (value > trackBarLight2Intensity.Maximum) {
                value = trackBarLight2Intensity.Maximum;
            }
            trackBarLight2Intensity.Value = value;
            textBoxLight2Intensity.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetButtonLight2Color(Color color) {
            buttonLight2Color.BackColor = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
        }

        private void SetTrackBarLight2ShadowDepth(float depth) {
            int value = (int)Math.Round(depth * 100);
            if (value > trackBarLight2ShadowDepth.Maximum) {
                value = trackBarLight2ShadowDepth.Maximum;
            }
            trackBarLight2ShadowDepth.Value = value;
            textBoxLight2ShadowDepth.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetTrackBarLight3AngleHorizontal(float angle) {
            int angleInt = (int)Math.Round(angle);
            while (angleInt < 0) {
                angleInt += 360;
            }
            while (angleInt > 360) {
                angleInt -= 360;
            }
            trackBarLight3AngleHorizontal.Value = angleInt;
            textBoxLight3AngleHorizontal.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight3AngleVertical(float angle) {
            int angleInt = (int)Math.Round(angle);
            if (angleInt < -90) {
                angleInt = -90;
            }
            if (angleInt > 90) {
                angleInt = 90;
            }
            trackBarLight3AngleVertical.Value = angleInt;
            textBoxLight3AngleVertical.Text = string.Format("{0}", angleInt);
        }

        private void SetTrackBarLight3Intensity(float intensity) {
            int value = (int)Math.Round(intensity * 100);
            if (value > trackBarLight3Intensity.Maximum) {
                value = trackBarLight3Intensity.Maximum;
            }
            trackBarLight3Intensity.Value = value;
            textBoxLight3Intensity.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetButtonLight3Color(Color color) {
            buttonLight3Color.BackColor = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
        }

        private void SetTrackBarLight3ShadowDepth(float depth) {
            int value = (int)Math.Round(depth * 100);
            if (value > trackBarLight3ShadowDepth.Maximum) {
                value = trackBarLight3ShadowDepth.Maximum;
            }
            trackBarLight3ShadowDepth.Value = value;
            textBoxLight3ShadowDepth.Text = string.Format("{0:0.0#}", value * 0.01f);
        }

        private void SetCheckBoxForceShadersV3(bool forceShadersV3) {
            checkBoxForceShadersV3.Checked = forceShadersV3;
        }

        private void TrackBarLight1AngleHorizontalScroll(object sender, EventArgs e) {
            int angle = trackBarLight1AngleHorizontal.Value;
            game.Light1AngleHorizontal = angle;
            SetTrackBarLight1AngleHorizontal(angle);
        }

        private void TrackBarLight1AngleVerticalScroll(object sender, EventArgs e) {
            int angle = trackBarLight1AngleVertical.Value;
            game.Light1AngleVertical = angle;
            SetTrackBarLight1AngleVertical(angle);
        }

        private void TrackBarLight1IntensityScroll(object sender, EventArgs e) {
            float value = trackBarLight1Intensity.Value * 0.01f;
            game.Light1Intensity = value;
            SetTrackBarLight1Intensity(value);
        }

        private void ButtonLight1ColorClick(object sender, EventArgs e) {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = System.Drawing.Color.
                FromArgb(game.Light1Color.R,
                         game.Light1Color.G,
                         game.Light1Color.B);
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                System.Drawing.Color color = dialog.Color;
                game.Light1Color = new Color(color.R, color.G, color.B, color.A);
                SetButtonLight1Color(game.Light1Color);
            }
        }

        private void TrackBarLight1ShadowDepthScroll(object sender, EventArgs e) {
            float value = trackBarLight1ShadowDepth.Value * 0.01f;
            game.Light1ShadowDepth = value;
            SetTrackBarLight1ShadowDepth(value);
        }

        private void TrackBarLight2AngleHorizontalScroll(object sender, EventArgs e) {
            int angle = trackBarLight2AngleHorizontal.Value;
            game.Light2AngleHorizontal = angle;
            SetTrackBarLight2AngleHorizontal(angle);
        }

        private void TrackBarLight2AngleVerticalScroll(object sender, EventArgs e) {
            int angle = trackBarLight2AngleVertical.Value;
            game.Light2AngleVertical = angle;
            SetTrackBarLight2AngleVertical(angle);
        }

        private void TrackBarLight2IntensityScroll(object sender, EventArgs e) {
            float value = trackBarLight2Intensity.Value * 0.01f;
            game.Light2Intensity = value;
            SetTrackBarLight2Intensity(value);
        }

        private void ButtonLight2ColorClick(object sender, EventArgs e) {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = System.Drawing.Color.
                FromArgb(game.Light2Color.R,
                         game.Light2Color.G,
                         game.Light2Color.B);
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                System.Drawing.Color color = dialog.Color;
                game.Light2Color = new Color(color.R, color.G, color.B, 255);
                SetButtonLight2Color(game.Light2Color);
            }
        }

        private void TrackBarLight2ShadowDepthScroll(object sender, EventArgs e) {
            float value = trackBarLight2ShadowDepth.Value * 0.01f;
            game.Light2ShadowDepth = value;
            SetTrackBarLight2ShadowDepth(value);
        }

        private void TrackBarLight3AngleHorizontalScroll(object sender, EventArgs e) {
            int angle = trackBarLight3AngleHorizontal.Value;
            game.Light3AngleHorizontal = angle;
            SetTrackBarLight3AngleHorizontal(angle);
        }

        private void TrackBarLight3AngleVerticalScroll(object sender, EventArgs e) {
            int angle = trackBarLight3AngleVertical.Value;
            game.Light3AngleVertical = angle;
            SetTrackBarLight3AngleVertical(angle);
        }

        private void TrackBarLight3IntensityScroll(object sender, EventArgs e) {
            float value = trackBarLight3Intensity.Value * 0.01f;
            game.Light3Intensity = value;
            SetTrackBarLight3Intensity(value);
        }

        private void ButtonLight3ColorClick(object sender, EventArgs e) {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = System.Drawing.Color.
                FromArgb(game.Light3Color.R,
                         game.Light3Color.G,
                         game.Light3Color.B);
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                System.Drawing.Color color = dialog.Color;
                game.Light3Color = new Color(color.R, color.G, color.B, 255);
                SetButtonLight3Color(game.Light3Color);
            }
        }

        private void TrackBarLight3ShadowDepthScroll(object sender, EventArgs e) {
            float value = trackBarLight3ShadowDepth.Value * 0.01f;
            game.Light3ShadowDepth = value;
            SetTrackBarLight3ShadowDepth(value);
        }

        private void CheckBoxForceShadersV3CheckedChanged(object sender, EventArgs e) {
            bool forceShadersV3 = checkBoxForceShadersV3.Checked;
            game.ForceShadersV3 = forceShadersV3;
            SetCheckBoxForceShadersV3(forceShadersV3);
        }

        private void ButtonResetAllClick(object sender, EventArgs e) {
            game.Light1Direction = DefaultLight1Direction;
            game.Light1Intensity = DefaultLight1Intensity;
            game.Light1Color = DefaultLight1Color;
            game.Light1ShadowDepth = DefaultLight1ShadowDepth;

            game.Light2Direction = DefaultLight2Direction;
            game.Light2Intensity = DefaultLight2Intensity;
            game.Light2Color = DefaultLight2Color;
            game.Light2ShadowDepth = DefaultLight2ShadowDepth;

            game.Light3Direction = DefaultLight3Direction;
            game.Light3Intensity = DefaultLight3Intensity;
            game.Light3Color = DefaultLight3Color;
            game.Light3ShadowDepth = DefaultLight3ShadowDepth;

            game.ForceShadersV3 = DefaultForceShadersV3;

            SetTrackBarLight1AngleHorizontal(game.Light1AngleHorizontal);
            SetTrackBarLight1AngleVertical(game.Light1AngleVertical);
            SetTrackBarLight1Intensity(game.Light1Intensity);
            SetButtonLight1Color(game.Light1Color);
            SetTrackBarLight1ShadowDepth(game.Light1ShadowDepth);

            SetTrackBarLight2AngleHorizontal(game.Light2AngleHorizontal);
            SetTrackBarLight2AngleVertical(game.Light2AngleVertical);
            SetTrackBarLight2Intensity(game.Light2Intensity);
            SetButtonLight2Color(game.Light2Color);
            SetTrackBarLight2ShadowDepth(game.Light2ShadowDepth);

            SetTrackBarLight3AngleHorizontal(game.Light3AngleHorizontal);
            SetTrackBarLight3AngleVertical(game.Light3AngleVertical);
            SetTrackBarLight3Intensity(game.Light3Intensity);
            SetButtonLight3Color(game.Light3Color);
            SetTrackBarLight3ShadowDepth(game.Light3ShadowDepth);

            SetCheckBoxForceShadersV3(game.ForceShadersV3);
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
            game.ControlGUI.HandleLightingParamsDialogClosed();
        }
    }
}
