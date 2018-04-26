using System.Collections.Generic;

namespace XNALara
{
    public class CroftManorHall : Item
    {
        public CroftManorHall(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalColorTextureTangent();
        }

        protected override void DefineMeshGroups() {
            List<string> meshNamesTransparent = new List<string>();
            meshNamesTransparent.Add("Group35");
            meshNamesTransparent.Add("Group36");
            meshNamesTransparent.Add("Group37");
            meshNamesTransparent.Add("Group112");

            List<string> meshNamesShadeless = new List<string>();
            meshNamesShadeless.Add("Group10");
            meshNamesShadeless.Add("Group91");
            meshNamesShadeless.Add("Group92");

            List<string> meshNamesSolid = new List<string>();
            foreach (Mesh mesh in model.Meshes) {
                if (!meshNamesTransparent.Contains(mesh.Name) &&
                    !meshNamesShadeless.Contains(mesh.Name)) {
                    meshNamesSolid.Add(mesh.Name);
                }
            }
            model.DefineMeshGroup(MeshGroupNames.MeshGroup11, meshNamesSolid.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup12, meshNamesTransparent.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup13, meshNamesShadeless.ToArray());
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
