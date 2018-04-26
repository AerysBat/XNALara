namespace XNALara
{
    public class GoLChompy : Item
    {
        public GoLChompy(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh002", "mesh003", "mesh004");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.3f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw 1");
            AddCameraTarget("body", "spine 2", "spine 3");
            AddCameraTarget("tail", "spine 6");
        }
    }
}
