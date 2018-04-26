namespace XNALara
{
    public class Doppelganger : Item
    {
        public Doppelganger(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.HandGuns,
                "handgunhandleft",
                "handgunhandright",
                "handgunholsterleft",
                "handgunholsterright");

            model.DefineMeshGroup(MeshGroupNames.HandGunHandLeft, "handgunhandleft");
            model.DefineMeshGroup(MeshGroupNames.HandGunHandRight, "handgunhandright");
            model.DefineMeshGroup(MeshGroupNames.HandGunHolsterLeft, "handgunholsterleft");
            model.DefineMeshGroup(MeshGroupNames.HandGunHolsterRight, "handgunholsterright");

            model.SetMeshGroupVisible(MeshGroupNames.HandGunHandLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHandRight, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterRight, false);

            model.DefineMeshGroup(MeshGroupNames.MeshGroup1, "belts1", "belts2", "boots", "gloves", "jacket1", "jacket2", "ribbons", "trousers1", "trousers2", "zipper3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup2, "arms", "body", "braid", "face", "fingers", "mouth");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup4, "eyeirises", "hair1", "metal", "zipper1", "zipper2", "zipper4");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup5, "eyewhites");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup6, "hair2", "hair3");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup7, "eyebrows", "eyelashes", "eyeshading");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup10, "eyepupils");
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }
            model.GetMesh("metal").RenderParams = new object[] { 0.6f };
            model.GetMesh("belts1").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("belts2").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("boots").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("gloves").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("jacket1").RenderParams = new object[] { 0.2f, 16.0f, 16.0f };
            model.GetMesh("jacket2").RenderParams = new object[] { 0.2f, 8.0f, 8.0f };
            model.GetMesh("ribbons").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
            model.GetMesh("trousers1").RenderParams = new object[] { 0.15f, 32.0f, 32.0f };
            model.GetMesh("trousers2").RenderParams = new object[] { 0.15f, 12.0f, 12.0f };
            model.GetMesh("zipper3").RenderParams = new object[] { 0.1f, 16.0f, 16.0f };
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("head", "head jaw");
            AddCameraTarget("body upper", "breast left", "breast right");
            AddCameraTarget("body lower", "pelvis");
            AddCameraTarget("hand left", "arm left wrist");
            AddCameraTarget("hand right", "arm right wrist");
            AddCameraTarget("knee left", "leg left knee");
            AddCameraTarget("knee right", "leg right knee");
            AddCameraTarget("foot left", "leg left ankle");
            AddCameraTarget("foot right", "leg right ankle");
        }
    }
}
