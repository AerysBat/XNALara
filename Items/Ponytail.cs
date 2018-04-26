namespace XNALara
{
    public class Ponytail : Item
    {
        public Ponytail(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "ponytail");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.2f };
            }
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("ponytail", "ponytail 1");
        }
    }
}
