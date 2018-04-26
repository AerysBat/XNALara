namespace XNALara
{
    public class GoLLaraJungleShorts : Item
    {
        public GoLLaraJungleShorts(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh006");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001left", "mesh001right", "mesh002", "mesh003", "mesh004", "mesh005", "mesh007", "mesh008", "mesh009", "mesh010");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh011");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh012");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("mesh008").RenderParams = new object[] { 0.2f };
            model.GetMesh("mesh009").RenderParams = new object[] { 0.3f };
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
