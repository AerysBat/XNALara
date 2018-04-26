namespace XNALara
{
    public class Grapple : Item
    {
        public Grapple(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh1", "mesh2");
        }

        protected override void SetRenderParams() {
            model.GetMesh("mesh1").RenderParams = new object[] { 0.5f };
            model.GetMesh("mesh2").RenderParams = new object[] { 0.3f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
