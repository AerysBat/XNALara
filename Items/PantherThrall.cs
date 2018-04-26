namespace XNALara
{
    public class PantherThrall : Item
    {
        public PantherThrall(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part1", "part3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "part2");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
            model.GetMesh("part1").RenderParams = new object[] { 0.2f, 8.0f, 8.0f };
            model.GetMesh("part3").RenderParams = new object[] { 0.2f, 8.0f, 8.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 2");
            AddCameraTarget("pelvis", "pelvis");
            AddCameraTarget("tail", "tail 3");
        }
    }
}
