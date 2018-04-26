namespace XNALara
{
    public class AmandaHeavy : Item
    {
        public AmandaHeavy(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "bands1", "belt", "boots", "coat", "trousers", "sleeves");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "face", "hand2left", "hand2right", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes", "metal1", "metal3", "metal5", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1", "fur2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading", "hair2left", "hair2right", "jewelry", "scar");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "fur1");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("metal1").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal3").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal5").RenderParams = new object[] { 0.6f };
            model.GetMesh("bands1").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("belt").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("boots").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("coat").RenderParams = new object[] { 0.1f, 16.0f, 12.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.1f, 10.0f, 10.0f };
            model.GetMesh("sleeves").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
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
