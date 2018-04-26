using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class SkyDomeThailandSea : Item
    {
        public const string MeshGroupDome = "Dome";
        public const string MeshGroupClouds = "Clouds";

        public static readonly Color BackgroundColor = new Color(32, 47, 32);


        public SkyDomeThailandSea(Game game)
            : base(game) {
        }

        protected override void DefineMeshGroups() {
            model.DefineMeshGroup(MeshGroupDome, "dome1", "dome2", "dome3", "dome4");
            model.DefineMeshGroup(MeshGroupClouds, "clouds");
        }

        protected override void SetRenderParams() {
        }

        protected override void DefineCameraTargets() {
        }
    }
}
