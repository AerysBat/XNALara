namespace XNALara
{
    public class Winston : Item
    {
        public Winston(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "trousers", "vest", "suitleft", "suitright", "shoes", "hands", "shirt", "sleeves");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mouth", "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "face");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyeshading", "eyebrows", "eyelashes");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup9, "hair2");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("hands").RenderParams = new object[] { 0.1f, 8.0f, 8.0f };
            model.GetMesh("shirt").RenderParams = new object[] { 0.05f, 8.0f, 8.0f };
            model.GetMesh("shoes").RenderParams = new object[] { 0.1f, 4.0f, 4.0f };
            model.GetMesh("sleeves").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("suitleft").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
            model.GetMesh("suitright").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
            model.GetMesh("vest").RenderParams = new object[] { 0.05f, 8.0f, 8.0f };
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
