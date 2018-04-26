namespace XNALara
{
    public class LaraDLCClassic : Lara
    {
        public LaraDLCClassic(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh001", "mesh004", "mesh007", "mesh009", "mesh010", "mesh011", "mesh018");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh002", "mesh005", "mesh013", "mesh015", "mesh016", "mesh017", "mesh020");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3);
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh008", "mesh012");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh019", "mesh023");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh014");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh006", "mesh021", "mesh024");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh008").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh001").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh004").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh007").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh009").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh010").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh011").RenderParams = new object[] { 0.3f, 12.0f, 16.0f };
            model.GetMesh("mesh018").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
        }
    }
}
