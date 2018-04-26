namespace XNALara
{
    public class ShipNatlaRoom : Item
    {
        public ShipNatlaRoom(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalTexture2();
        }

        protected override void DefineMeshGroups() {
        }

        protected override void SetRenderParams() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup16,
                "Mesh031", 
                "Mesh051", 
                "Mesh052", 
                "Mesh053");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup17,
                "Mesh001", 
                "Mesh002", 
                "Mesh003", 
                "Mesh004", 
                "Mesh007", 
                "Mesh008", 
                "Mesh009", 
                "Mesh010", 
                "Mesh011", 
                "Mesh012", 
                "Mesh013", 
                "Mesh014", 
                "Mesh015", 
                "Mesh016", 
                "Mesh017", 
                "Mesh018", 
                "Mesh019", 
                "Mesh020", 
                "Mesh021", 
                "Mesh022", 
                "Mesh023", 
                "Mesh024", 
                "Mesh025", 
                "Mesh026", 
                "Mesh027", 
                "Mesh028", 
                "Mesh029", 
                "Mesh030", 
                "Mesh032", 
                "Mesh034", 
                "Mesh035", 
                "Mesh036", 
                "Mesh037", 
                "Mesh038", 
                "Mesh039", 
                "Mesh040", 
                "Mesh041", 
                "Mesh042", 
                "Mesh043", 
                "Mesh044", 
                "Mesh045", 
                "Mesh046", 
                "Mesh054", 
                "Mesh055");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup19,
                "Mesh005", 
                "Mesh006", 
                "Mesh033", 
                "Mesh050");
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
