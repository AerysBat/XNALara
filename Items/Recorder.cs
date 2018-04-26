namespace XNALara
{
    public class Recorder : Item
    {
        public Recorder(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "recorder", "glass");
        }

        protected override void SetRenderParams() {
            model.GetMesh("recorder").RenderParams = new object[] { 0.2f };
            model.GetMesh("glass").RenderParams = new object[] { 0.4f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
