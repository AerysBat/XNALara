namespace XNALara
{
    public class LaraDLCJungleShortsGrey : Lara
    {
        public LaraDLCJungleShortsGrey(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh008", "mesh009", "mesh010", "mesh017", "mesh021", "mesh022", "mesh024");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh001", "mesh004", "mesh013", "mesh015", "mesh019", "mesh020", "mesh023");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh018");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh011", "mesh014");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh002", "mesh003", "mesh026");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh016");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh005", "mesh007", "mesh012");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh011").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh008").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh009").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh010").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh017").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh021").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh022").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh024").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
        }
    }
}
