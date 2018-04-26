namespace XNALara
{
    public class Zip : Item
    {
        public Zip(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "band", "hair", "jacket", "shoes", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "face", "handleft", "handright", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "body");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "necklaces");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites", "watch");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            model.GetMesh("band").RenderParams = new object[] { 0.1f, 4.0f, 4.0f };
            model.GetMesh("hair").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("jacket").RenderParams = new object[] { 0.03f, 16.0f, 16.0f };
            model.GetMesh("shoes").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.03f, 8.0f, 8.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "spine upper");
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
