namespace XNALara
{
    public class Dummy : Item
    {
        public Dummy(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.Dummy, "dummy");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup10, "dummy");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("dummy", "dummy");
        }
    }
}
