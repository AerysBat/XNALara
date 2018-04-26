namespace XNALara
{
    public class Tiger2 : Tiger1
    {
        public Tiger2(Game game)
            : base(game) {
        }

        protected override void LoadModel() {
            LoadModelIntern(ItemType.Tiger1, "tiger1");
        }
    }
}
