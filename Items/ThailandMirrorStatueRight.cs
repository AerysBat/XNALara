namespace XNALara
{
    public class ThailandMirrorStatueRight : Item
    {
        public ThailandMirrorStatueRight(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalTexture2();
        }

        protected override void DefineMeshGroups() {
        }

        protected override void SetRenderParams() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup17, "body", "fan1", "fan2", "cloth", "deco", "block");
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
