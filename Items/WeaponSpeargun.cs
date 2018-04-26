namespace XNALara
{
    public class WeaponSpeargun : Item
    {
        public WeaponSpeargun(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part1", "part2");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.4f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
