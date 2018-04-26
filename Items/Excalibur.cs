namespace XNALara
{
    public class Excalibur : Item
    {
        public Excalibur(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "excalibur");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.3f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("excalibur", "excalibur");
        }
    }
}
