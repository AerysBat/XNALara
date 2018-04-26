namespace XNALara
{
    public class Panther : Item
    {
        public Panther(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "part4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "part2", "part3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "part1");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.15f };
            }
            model.GetMesh("part4").RenderParams = new object[] { 0.15f, 32.0f, 32.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 2");
            AddCameraTarget("pelvis", "pelvis");
            AddCameraTarget("tail", "tail 3");
        }
    }
}
