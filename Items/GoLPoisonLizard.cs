namespace XNALara
{
    public class GoLPoisonLizard : Item
    {
        public GoLPoisonLizard(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh001", "mesh002", "mesh003", "mesh004", "mesh005");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.3f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 2");
            AddCameraTarget("tail", "tail 5");
        }
    }
}
