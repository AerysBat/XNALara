namespace XNALara
{
    public class Glasses : Item
    {
        public Glasses(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "frames");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "glass");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("glasses", "root");
        }
    }
}
