using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XNALara
{
    public class TreeViewMultiSelect : TreeView
    {
        private List<TreeNode> selectedNodes = new List<TreeNode>();
        private bool isSelectionEnabled = false;

        public TreeNode[] SelectedNodes {
            get {
                return selectedNodes.ToArray();
            }
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e) {
            if (!isSelectionEnabled) {
                e.Cancel = true;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            TreeNode selectedNode = this.GetNodeAt(e.X, e.Y);
            SelectNode(selectedNode);
            base.OnMouseDown(e);
        }

        private void SelectNode(TreeNode node) {
            if (node == null) {
                return;
            }
            switch (Control.ModifierKeys) {

                default: // single-select
                    ClearSelection();
                    SetNodeSelected(node, true);
                    break;

                case Keys.Control: // multi-select
                    SetNodeSelected(node, !selectedNodes.Contains(node));
                    break;
            }
        }

        private void ClearSelection() {
            for (int i = selectedNodes.Count - 1; i >= 0; i--) {
                TreeNode node = selectedNodes[i];
                selectedNodes.RemoveAt(i);
                SetNodeSelected(node, false);
            }
        }

        private void SetNodeSelected(TreeNode node, bool isSelected) {
            if (isSelected) {
                TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(node, false, TreeViewAction.ByMouse);
                base.OnBeforeSelect(e);
                if (e.Cancel) {
                    return;
                }
                selectedNodes.Add(node);
                isSelectionEnabled = true;
                SelectedNode = node;
            }
            else {
                selectedNodes.Remove(node);
                isSelectionEnabled = false;
                SelectedNode = null;
            }
            SetNodeColors(node, isSelected);
        }

        private void SetNodeColors(TreeNode node, bool isSelected) {
            if (isSelected) {
                node.ForeColor = SystemColors.HighlightText;
                node.BackColor = SystemColors.Highlight;
            }
            else {
                node.ForeColor = SystemColors.WindowText;
                node.BackColor = SystemColors.Window;
            }
        }
    }
}
