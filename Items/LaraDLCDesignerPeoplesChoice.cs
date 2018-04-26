namespace XNALara
{
    public class LaraDLCDesignerPeoplesChoice : Lara
    {
        public LaraDLCDesignerPeoplesChoice(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh018", "mesh020", "mesh023", "mesh025", "mesh026", "mesh027");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh003", "mesh010", "mesh012", "mesh014", "mesh015", "mesh016", "mesh019");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh024");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh007", "mesh008", "mesh009", "mesh022");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh002", "mesh006", "mesh017");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh011");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh001", "mesh004", "mesh013");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh022").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh018").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh020").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh023").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh025").RenderParams = new object[] { 0.3f, 24.0f, 24.0f };
            model.GetMesh("mesh026").RenderParams = new object[] { 0.3f, 24.0f, 24.0f };
            model.GetMesh("mesh027").RenderParams = new object[] { 0.3f, 12.0f, 16.0f };
        }
    }
}
