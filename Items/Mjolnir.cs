namespace XNALara
{
    public class Mjolnir : Item
    {
        public Mjolnir(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mjolnir");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("mjolnir", "mjolnir");
        }
    }
}
