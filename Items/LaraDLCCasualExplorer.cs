namespace XNALara
{
    public class LaraDLCCasualExplorer : Lara
    {
        public LaraDLCCasualExplorer(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh003", "mesh006", "mesh007", "mesh011", "mesh016", "mesh017", "mesh018", "mesh022", "mesh024");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh002", "mesh005", "mesh009", "mesh013", "mesh014", "mesh015");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh023");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh010", "mesh012", "mesh020", "mesh021");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh001", "mesh004", "mesh026", "mesh027");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh008");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh025", "mesh029", "mesh030");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh020").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh021").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh003").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh006").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh007").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh011").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh016").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh017").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh018").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh022").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh024").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
        }
    }
}
