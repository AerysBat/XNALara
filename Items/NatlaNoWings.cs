namespace XNALara
{
    public class NatlaNoWings : Item
    {
        public NatlaNoWings(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "arms", "detail3", "jacket", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "detail1", "detail2", "detail4", "detail5", "face", "feet", "hair1", "handleft", "handright");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mouth", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyes", "label");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading", "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup8, "hair3", "hair4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup9, "hair5");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("arms").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("detail3").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("jacket").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "unused007");
            AddCameraTarget("body lower", "pelvis");
            AddCameraTarget("hand left", "arm left wrist");
            AddCameraTarget("hand right", "arm right wrist");
            AddCameraTarget("knee left", "leg left knee");
            AddCameraTarget("knee right", "leg right knee");
            AddCameraTarget("foot left", "leg left ankle");
            AddCameraTarget("foot right", "leg right ankle");
            //AddCameraTarget("wing left", "wing left 7c");
            //AddCameraTarget("wing right", "wing right 7c");
        }
    }
}
