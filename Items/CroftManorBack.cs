using System.Collections.Generic;

namespace XNALara
{
    public class CroftManorBack : Item
    {
        public CroftManorBack(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalColorTextureTangent();
        }

        protected override void DefineMeshGroups() {
            List<string> meshNamesTransparent = new List<string>();
            meshNamesTransparent.Add("part13");
            meshNamesTransparent.Add("part14");
            meshNamesTransparent.Add("part17");
            meshNamesTransparent.Add("part27");
            meshNamesTransparent.Add("part65");

            List<string> meshNamesSolid = new List<string>();
            foreach (Mesh mesh in model.Meshes) {
                if (!meshNamesTransparent.Contains(mesh.Name)) {
                    meshNamesSolid.Add(mesh.Name);
                }
            }
            model.DefineMeshGroup(MeshGroupNames.MeshGroup11, meshNamesSolid.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup12, meshNamesTransparent.ToArray());
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.05f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
