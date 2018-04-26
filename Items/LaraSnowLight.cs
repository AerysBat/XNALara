namespace XNALara
{
    public class LaraSnowLight : Lara
    {
        public LaraSnowLight(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "backpack", "belts", "boots1", "boots3", "gloves", "jacket", "sleeves", "trousers");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "eyeducts", "light2", "mouth", "face", "body", "boots2", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "backring");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "light1", "zipper1", "zipper2", "hair1", "metal");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites", "boots4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup9, "boots5");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("boots2").RenderParams = new object[] { 0.6f };
            model.GetMesh("metal").RenderParams = new object[] { 0.6f };
            model.GetMesh("backpack").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("belts").RenderParams = new object[] { 0.1f, 10.0f, 20.0f };
            model.GetMesh("boots1").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("boots3").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("gloves").RenderParams = new object[] { 0.1f, 20.0f, 20.0f };
            model.GetMesh("jacket").RenderParams = new object[] { 0.25f, 32.0f, 32.0f };
            model.GetMesh("sleeves").RenderParams = new object[] { 0.25f, 20.0f, 20.0f };
            model.GetMesh("trousers").RenderParams = new object[] { 0.05f, 16.0f, 16.0f };
        }
    }
}
