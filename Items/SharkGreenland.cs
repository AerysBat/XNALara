namespace XNALara
{
    public class SharkGreenland : Item
    {
        public SharkGreenland(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "body");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "teeth");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
            model.GetMesh("body").RenderParams = new object[] { 0.2f, 12.0f, 12.0f };
            model.GetMesh("eyes").RenderParams = new object[] { 0.4f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 4");
            AddCameraTarget("fin left", "fin left 2");
            AddCameraTarget("fin right", "fin right 2");
            AddCameraTarget("fin back", "fin back root");
        }
    }
}
