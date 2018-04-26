namespace XNALara
{
    public class LaraDLCBikiniYellow : Lara
    {
        public LaraDLCBikiniYellow(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            base.DefineMeshGroups();
            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "mesh013", "mesh015", "mesh022", "mesh023", "mesh024");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "mesh001", "mesh008", "mesh010", "mesh017", "mesh018", "mesh019", "mesh020", "mesh021");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup3, "mesh014");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "mesh009", "mesh012");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "mesh004", "mesh005", "mesh016");

            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "mesh011");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "mesh003", "mesh006", "mesh007");
        }

        protected override void SetRenderParams() {
            base.SetRenderParams();
            model.GetMesh("mesh012").RenderParams = new object[] { 0.6f };
            model.GetMesh("mesh013").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh015").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh022").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh023").RenderParams = new object[] { 0.1f, 12.0f, 16.0f };
            model.GetMesh("mesh024").RenderParams = new object[] { 0.6f, 12.0f, 16.0f };
        }
    }
}
