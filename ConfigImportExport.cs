using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private const string ConfigFilename = "XNALara.cfg";

        private void ImportConfig() {
            string cfgFilename = string.Format("{0}\\{1}", initDir, ConfigFilename);
            StreamReader file;
            try {
                file = new StreamReader(cfgFilename);
            }
            catch (Exception) {
                return;
            }
            while (true) {
                string line = file.ReadLine();
                if (line == null) {
                    break;
                }
                string[] tokens = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 2) {
                    continue;
                }
                string name = tokens[0].Trim();
                string value = tokens[1].Trim();
                ImportConfigParameter(name, value);
            }
            file.Close();
        }

        private void ExportConfig() {
            string cfgFilename = string.Format("{0}\\{1}", initDir, ConfigFilename);
            StreamWriter file;
            try {
                file = new StreamWriter(cfgFilename);
            }
            catch (Exception) {
                return;
            }

            ExportConfigParameter(file, "AlwaysOnTop", BoolToString(this.PreferredAlwaysOnTop));
            ExportConfigParameter(file, "DisplayBones", BoolToString(game.DisplayBones));
            ExportConfigParameter(file, "DisplayBoneNames", BoolToString(game.DisplayBoneNames));
            ExportConfigParameter(file, "DisplayTextures", BoolToString(game.DisplayTextures));
            ExportConfigParameter(file, "EnableBumpMaps", BoolToString(game.EnableBumpMaps));
            ExportConfigParameter(file, "DisplayWireframe", BoolToString(game.DisplayWireframe));
            ExportConfigParameter(file, "BackFaceCulling", BoolToString(game.BackFaceCulling));
            ExportConfigParameter(file, "AlwaysForceCulling", BoolToString(game.AlwaysForceCulling));
            ExportConfigParameter(file, "DisplayGround", BoolToString(game.DisplayGround));
            ExportConfigParameter(file, "UseAlternativeReflection", BoolToString(game.UseAlternativeReflection));
            ExportConfigParameter(file, "PlaceNewModelsInFrontOfCamera", BoolToString(placeNewItemsInFrontOfCamera));
            ExportConfigParameter(file, "ForceShadersV3", BoolToString(game.ForceShadersV3));
            ExportConfigParameter(file, "EnableAddModelMultiSelect", BoolToString(game.EnableAddModelMultiSelect));
            ExportConfigParameter(file, "RenderLogo", BoolToString(game.RenderLogo));

            switch (game.GameForm.WindowState) {
                case FormWindowState.Normal:
                    ExportConfigParameter(file, "3DWindowDimensions",
                        RectangleToString(new Rectangle(
                            game.GameForm.Location.X, game.GameForm.Location.Y,
                            game.CanvasSize.Width, game.CanvasSize.Height)));
                    break;
                case FormWindowState.Maximized:
                    ExportConfigParameter(file, "3DWindowDimensions", "maximized");
                    break;
                case FormWindowState.Minimized:
                    ExportConfigParameter(file, "3DWindowDimensions", "minimized");
                    break;
            }

            switch (this.WindowState) {
                case FormWindowState.Normal:
                    ExportConfigParameter(file, "ControlWindowDimensions",
                        RectangleToString(new Rectangle(
                            this.Location.X, this.Location.Y,
                            this.Size.Width, this.Size.Height)));
                    break;
                case FormWindowState.Maximized:
                    ExportConfigParameter(file, "ControlWindowDimensions", "maximized");
                    break;
                case FormWindowState.Minimized:
                    ExportConfigParameter(file, "ControlWindowDimensions", "minimized");
                    break;
            }

            file.Close();
        }

        private void ImportConfigParameter(string name, string value) {
            bool valueBool;
            Rectangle valueRect;
            switch (name) {
                case "AlwaysOnTop":
                    if (ParseBool(value, out valueBool)) {
                        this.PreferredAlwaysOnTop = valueBool;
                    }
                    break;

                case "DisplayBones":
                    if (ParseBool(value, out valueBool)) {
                        game.DisplayBones = valueBool;
                    }
                    break;

                case "DisplayBoneNames":
                    if (ParseBool(value, out valueBool)) {
                        game.DisplayBoneNames = valueBool;
                    }
                    break;

                case "DisplayTextures":
                    if (ParseBool(value, out valueBool)) {
                        game.DisplayTextures = valueBool;
                    }
                    break;

                case "EnableBumpMaps":
                    if (ParseBool(value, out valueBool)) {
                        game.EnableBumpMaps = valueBool;
                    }
                    break;

                case "DisplayWireframe":
                    if (ParseBool(value, out valueBool)) {
                        game.DisplayWireframe = valueBool;
                    }
                    break;

                case "BackFaceCulling":
                    if (ParseBool(value, out valueBool)) {
                        game.BackFaceCulling = valueBool;
                    }
                    break;

                case "AlwaysForceCulling":
                    if (ParseBool(value, out valueBool)) {
                        game.AlwaysForceCulling = valueBool;
                    }
                    break;

                case "DisplayGround":
                    if (ParseBool(value, out valueBool)) {
                        game.DisplayGround = valueBool;
                    }
                    break;

                case "UseAlternativeReflection":
                    if (ParseBool(value, out valueBool)) {
                        game.UseAlternativeReflection = valueBool;
                    }
                    break;

                case "PlaceNewModelsInFrontOfCamera":
                    if (ParseBool(value, out valueBool)) {
                        placeNewItemsInFrontOfCamera = valueBool;
                    }
                    break;

                case "ForceShadersV3":
                    if (ParseBool(value, out valueBool)) {
                        game.ForceShadersV3 = valueBool;
                    }
                    break;

                case "EnableAddModelMultiSelect":
                    if (ParseBool(value, out valueBool)) {
                        game.EnableAddModelMultiSelect = valueBool;
                    }
                    break;

                case "RenderLogo":
                    if (ParseBool(value, out valueBool)) {
                        game.RenderLogo = valueBool;
                    }
                    break;

                case "3DWindowDimensions":
                    switch (value.ToLower()) {
                        case "maximized":
                            game.GameForm.WindowState = FormWindowState.Maximized;
                            break;
                        case "minimized":
                            game.GameForm.WindowState = FormWindowState.Minimized;
                            break;
                        default:
                            game.GameForm.WindowState = FormWindowState.Normal;
                            if (ParseRectangle(value, out valueRect)) {
                                game.CanvasSize = valueRect.Size;
                                game.GameForm.Location = valueRect.Location;
                            }
                            break;
                    }
                    break;

                case "ControlWindowDimensions":
                    switch (value.ToLower()) {
                        case "maximized":
                            this.WindowState = FormWindowState.Maximized;
                            break;
                        case "minimized":
                            this.WindowState = FormWindowState.Minimized;
                            break;
                        default:
                            this.WindowState = FormWindowState.Normal;
                            if (ParseRectangle(value, out valueRect)) {
                                this.StartPosition = FormStartPosition.Manual;
                                this.Size = valueRect.Size;
                                this.Location = valueRect.Location;
                            }
                            break;
                    }
                    break;
            }
        }

        private string BoolToString(bool valueBool) {
            return valueBool.ToString();
        }

        private string RectangleToString(Rectangle valueRect) {
            return string.Format("{0} {1} {2} {3}", valueRect.X, valueRect.Y, valueRect.Width, valueRect.Height);
        }

        private bool ParseBool(string s, out bool valueBool) {
            return bool.TryParse(s, out valueBool);
        }

        private bool ParseRectangle(string s, out Rectangle valueRect) {
            valueRect = Rectangle.Empty;
            string[] tokens = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 4) {
                return false;
            }
            int[] values = new int[4];
            for (int i = 0; i < 4; i++) {
                if (!int.TryParse(tokens[i], out values[i])) {
                    return false;
                }
            }
            valueRect = new Rectangle(values[0], values[1], values[2], values[3]);
            return true;
        }

        private void ExportConfigParameter(StreamWriter file, string name, string value) {
            file.WriteLine(string.Format("{0} = {1}", name, value));
        }
    }
}
