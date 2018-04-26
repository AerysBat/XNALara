namespace XNALara
{
    public class Yacht : Item
    {
        public Yacht(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalTexture2();
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupNames.MeshGroup16, "part1", "part2", "part3", "part4", "part12", "part23", "part24", "part25", /*"part34",*/ "part44");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup17, "part5", "part6", "part7", "part8", "part9", "part10", "part11", "part14", "part15", "part16", "part17", "part18", "part19", "part20", "part21", "part26", "part27", "part28", "part29", "part30", "part31", "part32", "part33", "part35", "part36", "part37", "part38", "part39", "part40");
            model.DefineMeshGroup(MeshGroupNames.MeshGroup18, "part13", "part22", "part41", "part42");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
