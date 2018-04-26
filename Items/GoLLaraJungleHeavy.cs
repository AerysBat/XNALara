namespace XNALara
{
    public class GoLLaraJungleHeavy : Item
    {
        public GoLLaraJungleHeavy(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh002");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh003", "mesh004", "mesh005", "mesh007", "mesh008", "mesh010", "mesh011", "mesh012", "mesh013");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh009");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh006");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("mesh001").RenderParams = new object[] { 0.3f };
            model.GetMesh("mesh011").RenderParams = new object[] { 0.3f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head neck upper");
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
