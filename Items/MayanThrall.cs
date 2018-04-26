namespace XNALara
{
    public class MayanThrall : Item
    {
        public MayanThrall(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh1a", "mesh1b", "mesh2", "mesh5", "mesh6", "mesh8");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh7");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh4");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw 2");
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
