namespace XNALara
{
    public class FoliageTree2 : Item
    {
        public FoliageTree2(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalTexture2();
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup17, "trunk");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup19, "leaves");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
