namespace XNALara
{
    public class LaraWetSuit : Lara
    {
        public LaraWetSuit(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "arms", "backpack", "belts", "collar", "gear2", "gear3", "gear6", "suit", "suitstripes1", "suitstripes2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "eyeducts", "face", "feet", "hands", "legs", "light", "mouth", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "backring");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "gear5", "hair1", "metal", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites", "gear1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading", "gear4");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("metal").RenderParams = new object[] { 0.2f };
            model.GetMesh("arms").RenderParams = new object[] { 0.3f, 20.0f, 20.0f };
            model.GetMesh("backpack").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("belts").RenderParams = new object[] { 0.1f, 10.0f, 20.0f };
            model.GetMesh("collar").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("gear2").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("gear3").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("gear6").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suit").RenderParams = new object[] { 0.3f, 24.0f, 48.0f };
            model.GetMesh("suitstripes1").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suitstripes2").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
        }
    }
}
