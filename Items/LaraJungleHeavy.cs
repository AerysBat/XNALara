namespace XNALara
{
    public class LaraJungleHeavy : Lara
    {
        public LaraJungleHeavy(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "backpack", "belts", "boots", "gloves", "jacket", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "eyeducts", "face", "fingers", "light1", "light2", "mouth", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "backring");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "hair1", "metal", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("metal").RenderParams = new object[] { 0.6f };
            model.GetMesh("backpack").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("belts").RenderParams = new object[] { 0.1f, 10.0f, 20.0f };
            model.GetMesh("boots").RenderParams = new object[] { 0.1f, 15.0f, 30.0f };
            model.GetMesh("gloves").RenderParams = new object[] { 0.1f, 5.0f, 7.0f };
            model.GetMesh("jacket").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
        }
    }
}
