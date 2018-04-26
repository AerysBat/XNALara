namespace XNALara
{
    public class GoLDoppelganger : Item
    {
        public GoLDoppelganger(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh003", "mesh005");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh002left", "mesh002right", "mesh004", "mesh007", "mesh008", "mesh009", "mesh010");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh006");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("mesh001").RenderParams = new object[] { 0.3f };
            model.GetMesh("mesh004").RenderParams = new object[] { 0.3f };
            model.GetMesh("mesh007").RenderParams = new object[] { 0.3f };
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
