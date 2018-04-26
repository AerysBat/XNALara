namespace XNALara
{
    public class Jellyfish : Item
    {
        public Jellyfish(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "part1", "part2", "part3");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
