namespace XNALara
{
    public class LaraCasual : Lara
    {
        public LaraCasual(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "backpack", "belts", "boots1", "sweater", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "eyeducts", "face", "hands", "light1", "light2", "mouth", "neck", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "backring");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "boots2", "hair1", "metal", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("boots2").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal").RenderParams = new object[] { 0.6f };
            model.GetMesh("backpack").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("belts").RenderParams = new object[] { 0.1f, 10.0f, 20.0f };
            model.GetMesh("boots1").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("sweater").RenderParams = new object[] { 0.03f, 12.0f, 30.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.05f, 8.0f, 8.0f };
        }
    }
}
