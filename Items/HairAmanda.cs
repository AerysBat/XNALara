namespace XNALara
{
    public class HairAmanda : Item
    {
        public HairAmanda(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "hair2left", "hair2right");
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
