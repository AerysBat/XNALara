namespace XNALara
{
    public class Amelia : Item
    {
        public Amelia(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "coat1", "skirtleft", "skirtright");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body1", "body2", "coat2", "hands", "face", "legs");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "hair1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("coat1").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
            model.GetMesh("skirtleft").RenderParams = new object[] { 0.0f, 16.0f, 16.0f };
            model.GetMesh("skirtright").RenderParams = new object[] { 0.0f, 16.0f, 16.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "organs 1", "organs 3");
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
