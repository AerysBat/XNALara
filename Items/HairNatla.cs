namespace XNALara
{
    public class HairNatla : Item
    {
        public HairNatla(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "hair3", "hair4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup9, "hair5");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("hair", "head neck upper");
        }
    }
}
