namespace XNALara
{
    public class KnightThrall : Item
    {
        public KnightThrall(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup20, "Mesh001", "Mesh002", "Mesh003", "Mesh004");
        }

        protected override void SetRenderParams() {
            model.GetMesh("Mesh001").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("Mesh002").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("Mesh003").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("Mesh004").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
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
