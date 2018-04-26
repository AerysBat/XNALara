namespace XNALara
{
    public class Kraken : Item
    {
        public Kraken(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part1", "part2", "part4", "part5", "part6", "part7", "part8", "part9", "part10", "part12");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "part11");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part3");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
            model.GetMesh("part1").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part2").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part4").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part5").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part6").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part7").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part8").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part9").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part10").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("part12").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "body 1");
        }
    }
}
