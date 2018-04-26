namespace XNALara
{
    public class Alister : Item
    {
        public Alister(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "buttons", "coat1left", "coat1right", "coat2", "leather", "shirt", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "bodyleft", "bodyright", "eyeducts", "face", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyes");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1", "metal");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2", "hair3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading", "glass");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "necklace");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("buttons").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("coat1left").RenderParams = new object[] { 0.05f, 8.0f, 12.0f };
            model.GetMesh("coat1right").RenderParams = new object[] { 0.05f, 8.0f, 12.0f };
            model.GetMesh("coat2").RenderParams = new object[] { 0.05f, 8.0f, 12.0f };
            model.GetMesh("leather").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("shirt").RenderParams = new object[] { 0.1f, 4.0f, 4.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
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
