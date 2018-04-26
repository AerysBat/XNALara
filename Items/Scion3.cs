namespace XNALara
{
    public class Scion3 : Item
    {
        public Scion3(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "scion3a", "scion3b", "scion3c");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "scion3d");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("scion3", "root");
        }
    }
}
