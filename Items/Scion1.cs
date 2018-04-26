namespace XNALara
{
    public class Scion1 : Item
    {
        public Scion1(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "scion1a", "scion1b");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "scion1c");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("scion1", "root");
        }
    }
}
