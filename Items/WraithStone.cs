namespace XNALara
{
    public class WraithStone : Item
    {
        public WraithStone(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part1");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "part2");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("stone", "stone");
        }
    }
}
