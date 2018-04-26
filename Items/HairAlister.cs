namespace XNALara
{
    public class HairAlister : Item
    {
        public HairAlister(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2", "hair3");
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
