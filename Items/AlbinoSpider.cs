namespace XNALara
{
    public class AlbinoSpider : Item
    {
        public AlbinoSpider(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "legs1", "legs2", "eyes");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.3f };
            }
            model.GetMesh("eyes").RenderParams = new object[] { 0.4f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaws upper left 1", "head jaws upper right 2");
            AddCameraTarget("body", "root body");
        }
    }
}
