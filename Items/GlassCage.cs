namespace XNALara
{
    public class GlassCage : Item
    {
        public GlassCage(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "metal");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "glass");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup10, "lights1", "lights2");
        }

        protected override void SetRenderParams() {
            model.GetMesh("metal").RenderParams = new object[] { 0.25f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
