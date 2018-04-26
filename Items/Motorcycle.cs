namespace XNALara
{
    public class Motorcycle : Item
    {
        public Motorcycle(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh1", "mesh2", "mesh3", "mesh6");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh5");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.02f };
            }
            model.GetMesh("mesh1").RenderParams = new object[] { 0.5f };
            model.GetMesh("mesh2").RenderParams = new object[] { 0.5f };
            model.GetMesh("mesh5").RenderParams = new object[] { 1.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("body", "body");
            AddCameraTarget("headlight", "fork front");
            AddCameraTarget("wheel front", "wheel front");
            AddCameraTarget("wheel back", "wheel back");
        }
    }
}
