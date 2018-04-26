namespace XNALara
{
    public class YetiThrall : Item
    {
        public YetiThrall(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part3", "part4", "part5a", "part5b", "part6");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "part2", "part7");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "part1a", "part1b");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("part2").RenderParams = new object[] { 0.3f };
            model.GetMesh("part3").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
            model.GetMesh("part4").RenderParams = new object[] { 0.5f, 8.0f, 8.0f };
            model.GetMesh("part5a").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
            model.GetMesh("part5b").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
            model.GetMesh("part6").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw 2");
            AddCameraTarget("body upper", "arm left shoulder 1", "arm right shoulder 1");
            AddCameraTarget("body lower", "pelvis");
            AddCameraTarget("hand left", "arm left wrist");
            AddCameraTarget("hand right", "arm right wrist");
            AddCameraTarget("knee left", "leg left knee");
            AddCameraTarget("knee right", "leg right knee");
            AddCameraTarget("foot left", "leg left ankle");
            AddCameraTarget("foot right", "leg right ankle");
        }
    }
}
