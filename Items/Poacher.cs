namespace XNALara
{
    public class Poacher : Item
    {
        public Poacher(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "clothes1", "gear", "belt2", "clothes3", "hat", "neckerchief", "gloves", "trousers", "clothleft", "clothright");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "metal", "zipper", "belt1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "hair1", "eyes", "clothes2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "hair2", "eyebrows", "eyelashes", "beard");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("metal").RenderParams = new object[] { 0.4f };
            model.GetMesh("clothleft").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("clothright").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("clothes1").RenderParams = new object[] { 0.05f, 8.0f, 8.0f };
            model.GetMesh("clothes3").RenderParams = new object[] { 0.05f, 8.0f, 8.0f };
            model.GetMesh("gear").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("belt2").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("hat").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("neckerchief").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("gloves").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.05f, 12.0f, 12.0f };
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
