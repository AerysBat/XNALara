namespace XNALara
{
    public class Scion2 : Item
    {
        public Scion2(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "scion2a", "scion2b", "scion2c", "scion2d");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "scion2e");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("scion2", "root");
        }
    }
}
