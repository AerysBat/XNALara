using System;
using System.Windows.Forms;

namespace XNALara
{
    public partial class PostProcessParamsDialog : Form
    {
        public static readonly float DefaultBrightness = 1.0f;
        public static readonly float DefaultGamma = 1.0f;
        public static readonly float DefaultContrast = 1.0f;
        public static readonly float DefaultSaturation = 1.0f;
        
        private Game game;

        public PostProcessParamsDialog(Game game) {
            this.game = game;
            InitializeComponent();

            SetTrackBarBrightness(game.PostProcessBrightness);
            SetTrackBarGamma(game.PostProcessGamma);
            SetTrackBarContrast(game.PostProcessContrast);
            SetTrackBarSaturation(game.PostProcessSaturation);
        }

        private void SetTrackBarBrightness(float brightness) {
            int brightnessInt = (int)Math.Round(brightness * 100);
            if (brightnessInt < trackBarBrightness.Minimum) {
                brightnessInt = trackBarBrightness.Minimum;
            }
            if (brightnessInt > trackBarBrightness.Maximum) {
                brightnessInt = trackBarBrightness.Maximum;
            }
            trackBarBrightness.Value = brightnessInt;
            textBoxBrightness.Text = string.Format("{0}", brightnessInt);
        }

        private void SetTrackBarGamma(float gamma) {
            int gammaInt = (int)Math.Round(gamma * 100);
            if (gammaInt < trackBarGamma.Minimum) {
                gammaInt = trackBarGamma.Minimum;
            }
            if (gammaInt > trackBarGamma.Maximum) {
                gammaInt = trackBarGamma.Maximum;
            }
            trackBarGamma.Value = gammaInt;
            textBoxGamma.Text = string.Format("{0}", gammaInt);
        }

        private void SetTrackBarContrast(float contrast) {
            int contrastInt = (int)Math.Round(contrast * 100);
            if (contrastInt < trackBarContrast.Minimum) {
                contrastInt = trackBarContrast.Minimum;
            }
            if (contrastInt > trackBarContrast.Maximum) {
                contrastInt = trackBarContrast.Maximum;
            }
            trackBarContrast.Value = contrastInt;
            textBoxContrast.Text = string.Format("{0}", contrastInt);
        }

        private void SetTrackBarSaturation(float saturation) {
            int saturationInt = (int)Math.Round(saturation * 100);
            if (saturationInt < trackBarSaturation.Minimum) {
                saturationInt = trackBarSaturation.Minimum;
            }
            if (saturationInt > trackBarSaturation.Maximum) {
                saturationInt = trackBarSaturation.Maximum;
            }
            trackBarSaturation.Value = saturationInt;
            textBoxSaturation.Text = string.Format("{0}", saturationInt);
        }

        private void TrackBarBrightnessScroll(object sender, EventArgs e) {
            float brightness = trackBarBrightness.Value / 100.0f;
            game.PostProcessBrightness = brightness;
            SetTrackBarBrightness(brightness);
        }

        private void TrackBarGammaScroll(object sender, EventArgs e) {
            float gamma = trackBarGamma.Value / 100.0f;
            game.PostProcessGamma = gamma;
            SetTrackBarGamma(gamma);
        }

        private void TrackBarContrastScroll(object sender, EventArgs e) {
            float contrast = trackBarContrast.Value / 100.0f;
            game.PostProcessContrast = contrast;
            SetTrackBarContrast(contrast);
        }

        private void TrackBarSaturationScroll(object sender, EventArgs e) {
            float saturation = trackBarSaturation.Value / 100.0f;
            game.PostProcessSaturation = saturation;
            SetTrackBarSaturation(saturation);
        }

        private void ButtonResetAllClick(object sender, EventArgs e) {
            game.PostProcessBrightness = DefaultBrightness;
            game.PostProcessGamma = DefaultGamma;
            game.PostProcessContrast = DefaultContrast;
            game.PostProcessSaturation = DefaultSaturation;

            SetTrackBarBrightness(game.PostProcessBrightness);
            SetTrackBarGamma(game.PostProcessGamma);
            SetTrackBarContrast(game.PostProcessContrast);
            SetTrackBarSaturation(game.PostProcessSaturation);
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
            game.ControlGUI.HandlePostProcessParamsDialogClosed();
        }
    }
}
