namespace XNALara
{
    public class LaraDLCLegend : Lara
    {
        public LaraDLCLegend(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh008", "mesh009", "mesh016", "mesh018", "mesh019", "mesh020", "mesh021", "mesh025", "mesh028");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh001", "mesh004", "mesh011", "mesh014", "mesh022", "mesh023", "mesh024");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh017");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh010", "mesh013");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh002", "mesh003", "mesh027");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh015");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh005", "mesh007", "mesh012");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh010").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh008").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh009").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh016").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh018").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh019").RenderParams = new object[] { 0.01f, 24.0f, 32.0f };
            model.GetMesh("mesh020").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh021").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh025").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh028").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
        }
    }
}
