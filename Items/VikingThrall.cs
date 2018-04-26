namespace XNALara
{
    public class VikingThrall : Item
    {
        public VikingThrall(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part1", "part2", "part3", "part5", "part8", "part9", "part10");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "part12");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "part4", "part6", "part7", "part11");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
            model.GetMesh("part4").RenderParams = new object[] { 0.05f };
            model.GetMesh("part6").RenderParams = new object[] { 0.05f };
            model.GetMesh("part7").RenderParams = new object[] { 0.05f };
            model.GetMesh("part11").RenderParams = new object[] { 0.05f };
            model.GetMesh("part12").RenderParams = new object[] { 0.05f };
            model.GetMesh("part1").RenderParams = new object[] { 0.5f, 8.0f, 8.0f };
            model.GetMesh("part2").RenderParams = new object[] { 0.5f, 8.0f, 8.0f };
            model.GetMesh("part3").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part5").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part8").RenderParams = new object[] { 0.2f, 32.0f, 32.0f };
            model.GetMesh("part9").RenderParams = new object[] { 0.2f, 32.0f, 32.0f };
            model.GetMesh("part10").RenderParams = new object[] { 0.2f, 32.0f, 32.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
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
