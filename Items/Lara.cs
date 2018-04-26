
namespace XNALara
{
    public abstract class Lara : Item
    {
        public Lara(Game game)
            : base(game) {
        }

        protected override void PostProcessModel(Model model) {
            ThorWireframeSplitter.SplitThorWireframe(model);
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.HandGuns,
                "handgunhandleft", "handgunhandright",
                "handgunholsterleft", "handgunholsterright");

            model.DefineMeshGroup(MeshGroupNames.ThorGearAll, "thorbelt1", "thorbelt2", "thorgauntletleft", "thorgauntletright");
            model.DefineMeshGroup(MeshGroupNames.ThorGearBelt, "thorbelt1", "thorbelt2");
            model.DefineMeshGroup(MeshGroupNames.ThorGearGauntletLeft, "thorgauntletleft");
            model.DefineMeshGroup(MeshGroupNames.ThorGearGauntletRight, "thorgauntletright");

            model.DefineMeshGroup(MeshGroupNames.ThorGlowAll, "thorglowbelt", "thorglowgauntletleft", "thorglowgauntletright");
            model.DefineMeshGroup(MeshGroupNames.ThorGlowBelt, "thorglowbelt");
            model.DefineMeshGroup(MeshGroupNames.ThorGlowGauntletLeft, "thorglowgauntletleft");
            model.DefineMeshGroup(MeshGroupNames.ThorGlowGauntletRight, "thorglowgauntletright");

            model.DefineMeshGroup(MeshGroupNames.HandGunHandLeft, "handgunhandleft");
            model.DefineMeshGroup(MeshGroupNames.HandGunHandRight, "handgunhandright");
            model.DefineMeshGroup(MeshGroupNames.HandGunHolsterLeft, "handgunholsterleft");
            model.DefineMeshGroup(MeshGroupNames.HandGunHolsterRight, "handgunholsterright");

            model.SetMeshGroupVisible(MeshGroupNames.HandGunHandLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHandRight, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterRight, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGearBelt, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletRight, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowBelt, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft, false);
            model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight, false);
        }

        protected override void SetRenderParams() {
            foreach (Mesh mesh in model.Meshes) {
                mesh.RenderParams = new object[] { 0.1f };
            }

            Mesh meshHandgunHandLeft = model.GetMesh("handgunhandleft");
            Mesh meshHandgunHandRight = model.GetMesh("handgunhandright");
            Mesh meshHandgunHolsterLeft = model.GetMesh("handgunholsterleft");
            Mesh meshHandgunHolsterRight = model.GetMesh("handgunholsterright");
            Mesh meshThorBelt1 = model.GetMesh("thorbelt1");
            Mesh meshThorBelt2 = model.GetMesh("thorbelt2");
            Mesh meshThorGauntletLeft = model.GetMesh("thorgauntletleft");
            Mesh meshThorGauntletRight = model.GetMesh("thorgauntletright");

            if (meshHandgunHandLeft != null) {
                meshHandgunHandLeft.RenderParams = new object[] { 0.4f };
            }
            if (meshHandgunHandRight != null) {
                meshHandgunHandRight.RenderParams = new object[] { 0.4f };
            }
            if (meshHandgunHolsterLeft != null) {
                meshHandgunHolsterLeft.RenderParams = new object[] { 0.4f };
            }
            if (meshHandgunHolsterRight != null) {
                meshHandgunHolsterRight.RenderParams = new object[] { 0.4f };
            }
            if (meshThorBelt1 != null) {
                meshThorBelt1.RenderParams = new object[] { 0.5f };
            }
            if (meshThorBelt2 != null) {
                meshThorBelt2.RenderParams = new object[] { 0.5f };
            }
            if (meshThorGauntletLeft != null) {
                meshThorGauntletLeft.RenderParams = new object[] { 0.5f };
            }
            if (meshThorGauntletRight != null) {
                meshThorGauntletRight.RenderParams = new object[] { 0.5f };
            }
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
