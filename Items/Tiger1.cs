namespace XNALara
{
    public class Tiger1 : Item
    {
        public Tiger1(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh1", "mesh2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "mesh3");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("mesh1").RenderParams = new object[] { 0.1f, 4.0f, 4.0f };
            model.GetMesh("mesh2").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 2");
            AddCameraTarget("pelvis", "pelvis");
            AddCameraTarget("tail", "tail 4");
        }
    }
}
