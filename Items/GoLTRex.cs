namespace XNALara
{
    public class GoLTRex : Item
    {
        public GoLTRex(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh002", "mesh004");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 5");
            AddCameraTarget("tail", "tail 4");
            AddCameraTarget("leg hind left", "leg hind left 4");
            AddCameraTarget("leg hind right", "leg hind right 4");
        }
    }
}
