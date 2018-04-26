namespace XNALara
{
    public class Braid : Item
    {
        public Braid(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "braid", "leather");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("braid", "braid 1");
        }
    }
}
