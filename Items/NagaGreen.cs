namespace XNALara
{
    public class NagaGreen : Item
    {
        public NagaGreen(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "teeth", "body", "legs", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyes");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body", "spine 2");
            AddCameraTarget("pelvis", "pelvis");
            AddCameraTarget("tail", "tail 4");
        }
    }
}
