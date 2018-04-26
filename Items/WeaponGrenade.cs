namespace XNALara
{
    public class WeaponGrenade : Item
    {
        public WeaponGrenade(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part1");
        }

        protected override void SetRenderParams() {
            model.GetMesh("part1").RenderParams = new object[] { 0.3f, 4.0f, 4.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
