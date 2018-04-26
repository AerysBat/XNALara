namespace XNALara
{
    public class WeaponAssaultRifle : Item
    {
        public WeaponAssaultRifle(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part2");
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
