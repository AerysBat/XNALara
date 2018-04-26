namespace XNALara
{
    public class LaraBathingSuitNoGear : Lara
    {
        public LaraBathingSuitNoGear(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "collar", "suit");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "arms", "body", "eyeducts", "face", "feet", "hands", "legs", /*"light",*/ "mouth", "ribbon");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "hair1", "zipper1", "zipper2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("collar").RenderParams = new object[] { 0.1f, 12.0f, 12.0f };
            model.GetMesh("suit").RenderParams = new object[] { 0.3f, 24.0f, 48.0f };
        }
    }
}
