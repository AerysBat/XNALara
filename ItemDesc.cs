namespace XNALara
{
    public class ItemDesc
    {
        public string name;
        public ItemType itemType;
        public string dirPath;

        public ItemDesc(string name, ItemType itemType, string dirPath) {
            this.name = name;
            this.itemType = itemType;
            this.dirPath = dirPath;
        }

        public override string ToString() {
            return string.Format("ItemDesc('{0}','{1}','{2}')", name, itemType, dirPath);
        }
    }
}
