namespace XNALara
{
    public class GoLLara : Item
    {
        public GoLLara(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh002");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh003", "mesh004left", "mesh004right", "mesh006");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh005");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("mesh001").RenderParams = new object[] { 0.2f };
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
