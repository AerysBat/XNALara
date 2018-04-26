using System.Collections.Generic;

namespace XNALara
{
    public class Ship : Item
    {
        public Ship(Game game)
            : base(game) {
            vertexFormat = new VertexPositionNormalTexture2();
        }

        protected override void DefineMeshGroups() {
            List<string> meshNamesGroup16 = new List<string>();
            meshNamesGroup16.Add("part096");
            meshNamesGroup16.Add("part151");
            meshNamesGroup16.Add("part239");
            meshNamesGroup16.Add("part240");
            meshNamesGroup16.Add("part242");
            meshNamesGroup16.Add("part243");
            meshNamesGroup16.Add("part244");

            List<string> meshNamesGroup18 = new List<string>();
            meshNamesGroup18.Add("part069");
            meshNamesGroup18.Add("part081");
            meshNamesGroup18.Add("part241");

            List<string> meshNamesGroup19 = new List<string>();
            meshNamesGroup19.Add("part101");
            meshNamesGroup19.Add("part102");
            meshNamesGroup19.Add("part104");
            meshNamesGroup19.Add("part108");
            meshNamesGroup19.Add("part109");
            meshNamesGroup19.Add("part112");
            meshNamesGroup19.Add("part113");
            meshNamesGroup19.Add("part114");
            meshNamesGroup19.Add("part117");
            meshNamesGroup19.Add("part118");
            meshNamesGroup19.Add("part124");
            meshNamesGroup19.Add("part125");
            meshNamesGroup19.Add("part127");
            meshNamesGroup19.Add("part155");
            meshNamesGroup19.Add("part156");
            meshNamesGroup19.Add("part160");
            meshNamesGroup19.Add("part161");
            meshNamesGroup19.Add("part165");
            meshNamesGroup19.Add("part171");
            meshNamesGroup19.Add("part172");
            meshNamesGroup19.Add("part182");
            meshNamesGroup19.Add("part189");
            meshNamesGroup19.Add("part190");
            meshNamesGroup19.Add("part198");
            meshNamesGroup19.Add("part199");
            meshNamesGroup19.Add("part213");
            meshNamesGroup19.Add("part214");
            meshNamesGroup19.Add("part226");

            List<string> meshNamesGroup17 = new List<string>();
            foreach (Mesh mesh in model.Meshes) {
                if (!meshNamesGroup16.Contains(mesh.Name) &&
                    !meshNamesGroup18.Contains(mesh.Name) &&
                    !meshNamesGroup19.Contains(mesh.Name)) {
                    meshNamesGroup17.Add(mesh.Name);
                }
            }

            model.DefineMeshGroup(MeshGroupNames.MeshGroup16, meshNamesGroup16.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup17, meshNamesGroup17.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup18, meshNamesGroup18.ToArray());
            model.DefineMeshGroup(MeshGroupNames.MeshGroup19, meshNamesGroup19.ToArray());
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
            AddCameraTarget("root", "root");
        }
    }
}
