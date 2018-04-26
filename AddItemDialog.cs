using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XNALara
{
    public partial class AddItemDialog : Form
    {
        private Game game;
        private List<ItemDesc> selectedItems = new List<ItemDesc>();


        public AddItemDialog(Game game, List<Item> existingItems) {
            this.game = game;
            InitializeComponent(game.EnableAddModelMultiSelect);

            ScanSubDirectories("data");

            if (treeView.Nodes.Count > 0) {
                treeView.Nodes[0].Expand();
            }
        }

        public ItemDesc[] SelectedItems {
            get { return selectedItems.ToArray(); }
        }

        public bool InFrontOfCameraChecked {
            get { return checkBoxInFrontOfCamera.Checked; }
            set { checkBoxInFrontOfCamera.Checked = value; }
        }

        private void ScanSubDirectories(string directoryName) {
            ScanSubDirectories(directoryName, null, null);
        }

        private void ScanSubDirectories(string directoryName, string rootDirectory, TreeNode treeRoot) {
            string directoryRelativePath =
                (rootDirectory != null ? rootDirectory + "\\" + directoryName : directoryName);

            if (directoryRelativePath == "data\\common" ||
                directoryRelativePath.StartsWith("data\\skydome_")) {
                return;
            }
            
            DirectoryInfo[] directories = new DirectoryInfo(directoryRelativePath).GetDirectories();
            if (directories.Length > 0) {
                SortDirectories(directories);
                TreeNode treeNode = AddNodeToTree(directoryName, treeRoot);
                foreach (DirectoryInfo directory in directories) {
                    ScanSubDirectories(directory.Name, directoryRelativePath, treeNode);
                }
            }
            else {
                if (rootDirectory != null) {
                    ItemType itemType = CheckDirectory(directoryName, rootDirectory);
                    if (itemType != ItemType.None) {
                        AddNodeToTree(directoryName, treeRoot, itemType, directoryRelativePath);
                    }
                }
            }
        }

        private void SortDirectories(DirectoryInfo[] directories) {
            Array.Sort<DirectoryInfo>(directories, 
                delegate(DirectoryInfo d1, DirectoryInfo d2) { 
                    return d1.Name.CompareTo(d2.Name);
                }
            );
        }

        private TreeNode AddNodeToTree(string name, TreeNode parentNode) {
            TreeNode childNode = new TreeNode();
            childNode.Text = name;
            if (parentNode != null) {
                parentNode.Nodes.Add(childNode);
            }
            else {
                treeView.Nodes.Add(childNode);
            }
            return childNode;
        }

        private TreeNode AddNodeToTree(string name, TreeNode parentNode, ItemType itemType, string dirPath) {
            TreeNode childNode = new TreeNode();
            childNode.Text = name;
            childNode.Tag = new ItemDesc(name, itemType, dirPath);
            if (parentNode != null) {
                parentNode.Nodes.Add(childNode);
            }
            else {
                treeView.Nodes.Add(childNode);
            }
            return childNode;
        }

        private ItemType CheckDirectory(string directoryName, string rootDirectory) {
            string directoryRelativePath = rootDirectory + "\\" + directoryName;

            FileInfo[] filesMesh = new DirectoryInfo(directoryRelativePath).GetFiles("*.mesh");
            FileInfo[] filesObj = new DirectoryInfo(directoryRelativePath).GetFiles("*.obj");
            if (filesMesh.Length > 0 && filesObj.Length > 0 ||
                filesMesh.Length > 1 || filesObj.Length > 1) {
                MessageBox.Show("Data folder \"" + directoryRelativePath + "\" contains multiple mesh files (ambiguous).\nSkipping ...",
                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ItemType.None;
            }
            
            ItemType itemType = ItemType.None;
            try {
                itemType = (ItemType)Enum.Parse(typeof(ItemType), directoryName, true);
            }
            catch (Exception) {
                if (filesMesh.Length == 0 && filesObj.Length == 0) {
                    MessageBox.Show("Data folder \"" + directoryRelativePath + "\" contains no mesh file.\nSkipping ...",
                        "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ItemType.None;
                }
                if (filesMesh.Length == 0) {
                    itemType = ItemType.ExternObj;
                }
                else {
                    string name = null;
                    try {
                        name = filesMesh[0].Name;
                        name = name.Substring(0, name.Length - 5);
                        itemType = (ItemType)Enum.Parse(typeof(ItemType), name, true);
                    }
                    catch (Exception) {
                        MessageBox.Show("Data folder \"" + directoryRelativePath + "\" contains unknown mesh type \"" + name + "\".\nSkipping ...",
                            "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return ItemType.None;
                    }
                }
            }
            return itemType;
        }

        private void ButtonOKClick(object sender, EventArgs e) {
            TreeNode[] selectedNodes = null;
            if (treeView is TreeViewMultiSelect) {
                selectedNodes = ((TreeViewMultiSelect)treeView).SelectedNodes;
            }
            else {
                if (treeView.SelectedNode != null) {
                    selectedNodes = new TreeNode[] { treeView.SelectedNode };
                }
            }
            selectedItems.Clear();
            if (selectedNodes != null) {
                foreach (TreeNode node in selectedNodes) {
                    ItemDesc itemDesc = (ItemDesc)node.Tag;
                    if (itemDesc != null) {
                        selectedItems.Add(itemDesc);
                    }
                }
            }
            this.Close();
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }
    }
}
