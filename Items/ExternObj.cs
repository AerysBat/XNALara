using System.Collections.Generic;

namespace XNALara
{
    public class ExternObj : Item
    {
        public ExternObj(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            List<string> meshNamesSolid = new List<string>();
            List<string> meshNamesTransparent = new List<string>();
            List<string> meshNamesShadeless = new List<string>();
            foreach (Mesh mesh in model.Meshes) {
                if (mesh.IsTransparent) {
                    meshNamesTransparent.Add(mesh.Name);
                    continue;
                }
                if (mesh.IsShadeless) {
                    meshNamesShadeless.Add(mesh.Name);
                    continue;
                }
                meshNamesSolid.Add(mesh.Name);
            }
            model.DefineMeshGroup(MeshGroupNames.MeshGroup24, meshNamesSolid.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup25, meshNamesTransparent.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup10, meshNamesShadeless.ToArray());
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
