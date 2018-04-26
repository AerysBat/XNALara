namespace XNALara
{
    public class Wings : Item
    {
        public Wings(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "wingbonesleft", "wingbonesright", "wingleft", "wingright");
        }

        protected override void SetRenderParams() {
            model.GetMesh("wingleft").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("wingright").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("wingbonesleft").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("wingbonesright").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("wing left", "wing left 7c");
            AddCameraTarget("wing right", "wing right 7c");
        }
    }
}
