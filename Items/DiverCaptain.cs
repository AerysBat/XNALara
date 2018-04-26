namespace XNALara
{
    public class DiverCaptain : Item
    {
        public DiverCaptain(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "head", "suit1", "suit2left", "suit2right", "suit3", "suit4", "suit5");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "gear1", "gear2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes", "gun", "metal", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("metal").RenderParams = new object[] { 0.6f };
            model.GetMesh("head").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suit1").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
            model.GetMesh("suit2left").RenderParams = new object[] { 0.15f, 8.0f, 8.0f };
            model.GetMesh("suit2right").RenderParams = new object[] { 0.15f, 8.0f, 8.0f };
            model.GetMesh("suit3").RenderParams = new object[] { 0.15f, 16.0f, 16.0f };
            model.GetMesh("suit4").RenderParams = new object[] { 0.15f, 8.0f, 8.0f };
            model.GetMesh("suit5").RenderParams = new object[] { 0.15f, 16.0f, 16.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "spine 1");
            AddCameraTarget("body lower", "spine 4");
            AddCameraTarget("hand left", "arm left wrist");
            AddCameraTarget("hand right", "arm right wrist");
            AddCameraTarget("knee left", "leg left knee");
            AddCameraTarget("knee right", "leg right knee");
            AddCameraTarget("foot left", "leg left ankle");
            AddCameraTarget("foot right", "leg right ankle");
        }
    }
}
