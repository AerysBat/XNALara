namespace XNALara
{
    public class Helicopter : Item
    {
        public Helicopter(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part1", "part2", "part3", "part4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "part5", "part6");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.25f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root ground");
        }
    }
}
