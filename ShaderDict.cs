using System.Collections.Generic;

namespace XNALara
{
    class ShaderDict
    {
        private bool isLight1On;
        private bool isLight2On;
        private bool isLight3On;
        private bool supportsShadersV3;
        private bool forceShadersV3;

        private bool hasChanged;
        private Dictionary<string, string> dict = new Dictionary<string, string>();


        public ShaderDict() {
            hasChanged = true;
        }

        public bool IsLight1On {
            set {
                if (isLight1On != value) {
                    isLight1On = value;
                    hasChanged = true;
                }
            }
        }

        public bool IsLight2On {
            set {
                if (isLight2On != value) {
                    isLight2On = value;
                    hasChanged = true;
                }
            }
        }

        public bool IsLight3On {
            set {
                if (isLight3On != value) {
                    isLight3On = value;
                    hasChanged = true;
                }
            }
        }

        public bool SupportsShadersV3 {
            set {
                if (supportsShadersV3 != value) {
                    supportsShadersV3 = value;
                    hasChanged = true;
                }
            }
        }

        public bool ForceShadersV3 {
            set {
                if (forceShadersV3 != value) {
                    forceShadersV3 = value;
                    hasChanged = true;
                }
            }
        }


        public string this[string key] {
            get {
                if (hasChanged) {
                    RebuildDict();
                    hasChanged = false;
                }
                return dict[key];
            }
        }


        private void RebuildDict() {
            dict.Clear();

            if (isLight3On || forceShadersV3) {
                if (supportsShadersV3) {
                    dict["Diffuse"] = "Diffuse_3";
                    dict["DiffuseLightmap"] = "DiffuseLightmap_3";
                    dict["DiffuseBump"] = "DiffuseBump_3";
                    dict["DiffuseLightmapBump"] = "DiffuseLightmapBump_3";
                    dict["DiffuseLightmapBump3"] = "DiffuseLightmapBump3_3";
                    dict["DiffuseLightmapBumpSpecular"] = "DiffuseLightmapBumpSpecular_3";
                    dict["DiffuseLightmapBump3Specular"] = "DiffuseLightmapBump3Specular_3";
                    dict["Metallic"] = forceShadersV3 ? "Metallic_3_V3" : "Metallic_3";
                    dict["MetallicBump3"] = "MetallicBump3_3";
                    dict["NextGen"] = "NextGen_3";
                }
                else {
                    dict["Diffuse"] = "Diffuse_2";
                    dict["DiffuseLightmap"] = "DiffuseLightmap_2";
                    dict["DiffuseBump"] = "DiffuseBump_2";
                    dict["DiffuseLightmapBump"] = "DiffuseLightmapBump_2";
                    dict["DiffuseLightmapBump3"] = "DiffuseLightmapBump3_2_LQ";
                    dict["DiffuseLightmapBumpSpecular"] = "DiffuseLightmapBumpSpecular_2";
                    dict["DiffuseLightmapBump3Specular"] = "DiffuseLightmapBump3_2_LQ";
                    dict["Metallic"] = "Metallic_3";
                    dict["MetallicBump3"] = "MetallicBump3_1_LQ";
                    dict["NextGen"] = "NextGen_2";
                }
            }
            else {
                if (isLight2On) {
                    dict["Diffuse"] = "Diffuse_2";
                    dict["DiffuseLightmap"] = "DiffuseLightmap_2";
                    dict["DiffuseBump"] = "DiffuseBump_2";
                    dict["DiffuseLightmapBump"] = "DiffuseLightmapBump_2";
                    dict["DiffuseLightmapBump3"] = (supportsShadersV3 ? "DiffuseLightmapBump3_2_HQ" : "DiffuseLightmapBump3_2_LQ");
                    dict["DiffuseLightmapBumpSpecular"] = "DiffuseLightmapBumpSpecular_2";
                    dict["DiffuseLightmapBump3Specular"] = (supportsShadersV3 ? "DiffuseLightmapBump3Specular_3" : "DiffuseLightmapBump3_2_LQ");
                    dict["Metallic"] = "Metallic_2";
                    dict["MetallicBump3"] = supportsShadersV3 ? "MetallicBump3_2" : "MetallicBump3_1_LQ";
                    dict["NextGen"] = "NextGen_2";
                }
                else {
                    dict["Diffuse"] = "Diffuse_1";
                    dict["DiffuseLightmap"] = "DiffuseLightmap_1";
                    dict["DiffuseBump"] = "DiffuseBump_1";
                    dict["DiffuseLightmapBump"] = "DiffuseLightmapBump_1";
                    dict["DiffuseLightmapBump3"] = "DiffuseLightmapBump3_1";
                    dict["DiffuseLightmapBumpSpecular"] = "DiffuseLightmapBumpSpecular_1";
                    dict["DiffuseLightmapBump3Specular"] = "DiffuseLightmapBump3Specular_1";
                    dict["Metallic"] = "Metallic_1";
                    dict["MetallicBump3"] = supportsShadersV3 ? "MetallicBump3_1_HQ" : "MetallicBump3_1_LQ";
                    dict["NextGen"] = "NextGen_1";
                }
            }
        }
    }
}
