namespace XNALara
{
    public class LaraWetSuitNoGear : Lara
    {
        public LaraWetSuitNoGear(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "arms", "collar", "suit", "suitstripes1", "suitstripes2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "body", "eyeducts", "face", "feet", "hands", "legs", "mouth", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "hair1", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("arms").RenderParams = new object[] { 0.3f, 20.0f, 20.0f };
            model.GetMesh("collar").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suit").RenderParams = new object[] { 0.3f, 24.0f, 48.0f };
            model.GetMesh("suitstripes1").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suitstripes2").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
        }
    }
}
