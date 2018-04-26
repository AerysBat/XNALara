namespace XNALara
{
    public class AmandaLight : Item
    {
        public AmandaLight(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "bands1", "bands2", "bands3", "boots", "trousers", "tshirt");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "arms", "body", "face", "hand1left", "hand1right", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes", "metal1", "metal2", "metal4", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading", "hair2left", "hair2right", "jewelry", "scar");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("metal1").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal2").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal4").RenderParams = new object[] { 0.6f };
            model.GetMesh("bands1").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("bands2").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("bands3").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("boots").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.15f, 10.0f, 10.0f };
            model.GetMesh("tshirt").RenderParams = new object[] { 0.15f, 16.0f, 32.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "breast left", "breast right");
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
