namespace XNALara
{
    public class LaraDLCDesignerFashionWinner : Lara
    {
        public LaraDLCDesignerFashionWinner(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh014", "mesh016", "mesh017", "mesh018", "mesh024", "mesh025", "mesh028", "mesh029", "mesh030", "mesh032");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh001", "mesh008", "mesh011", "mesh019", "mesh020", "mesh022", "mesh023");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh015");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh009", "mesh010", "mesh013", "mesh021", "mesh027", "mesh033");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh004", "mesh005", "mesh031");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh012");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh003", "mesh006", "mesh007");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh009").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh013").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh014").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh016").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh017").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh018").RenderParams = new object[] { 0.01f, 20.0f, 24.0f };
            model.GetMesh("mesh024").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh025").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh028").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh029").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh030").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh032").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
        }
    }
}
