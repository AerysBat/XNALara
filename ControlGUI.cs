using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace XNALara
{
    public partial class ControlGUI : Form
    {
        private Game game;

        private string initDir;

        private List<Item> items;
        private Dictionary<Model, Item> itemDict = new Dictionary<Model, Item>();
        private Dictionary<string, int> maxItemID = new Dictionary<string, int>();
        private Dictionary<Item, DataSet> dataSetDict = new Dictionary<Item, DataSet>();
        private Item selectedItem;
        private Armature.Bone selectedBone;
        private List<Armature.Bone> selectedBonesTree;

        private bool ignoreCameraPivotEvent = false;

        private LightingParamsDialog lightingParamsDialog = null;
        private CameraParamsDialog cameraParamsDialog = null;
        private PostProcessParamsDialog postProcessParamsDialog = null;
        private SkyDomeParamsDialog skyDomeParamsDialog = null;

        private bool placeNewItemsInFrontOfCamera = false;
        private bool isBoneModeRotate = true;

        private int quickSaveImageID = 0;
        private double quickSaveImageSize = 1.0;
        private bool quickSaveImageAlpha = false;

        private UndoHistory undoHistory;

        private bool preferredAlwaysOnTop = true;


        public ControlGUI(Game game) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            undoHistory = new UndoHistory(this);

            this.game = game;
            InitializeComponent();
            RecalculateGUILayout();

            initDir = Directory.GetCurrentDirectory();
            items = new List<Item>();

            ImportConfig();
            SynchronizeMenuItems();

            EnablePositionScaleControls(false);
            EnableXYZHControls(false);
        }

        public bool PreferredAlwaysOnTop {
            set { preferredAlwaysOnTop = value; }
            get { return preferredAlwaysOnTop; }
        }

        private void EnableXYZHControls(bool enabled) {
            EnableXYZControls(enabled);
            trackBarH.Enabled = enabled;
            textBoxH.Enabled = enabled;
            if (!enabled) {
                SetTrackBarHValue(0);
            }
            buttonResetH.Enabled = enabled;
        }

        private void EnableXYZControls(bool enabled) {
            trackBarX.Enabled = enabled;
            trackBarY.Enabled = enabled;
            trackBarZ.Enabled = enabled;
            textBoxX.Enabled = enabled;
            textBoxY.Enabled = enabled;
            textBoxZ.Enabled = enabled;
            if (!enabled) {
                SetTrackBarXValue(0);
                SetTrackBarYValue(0);
                SetTrackBarZValue(0);
            }
            buttonResetX.Enabled = enabled;
            buttonResetY.Enabled = enabled;
            buttonResetZ.Enabled = enabled;
            buttonResetBoneXYZ.Enabled = enabled;
        }

        private void EnablePositionScaleControls(bool enabled) {
            textBoxPosition.Enabled = enabled;
            textBoxScale.Enabled = enabled;
            if (!enabled) {
                textBoxPosition.Text = "";
                textBoxScale.Text = "";
            }
            buttonResetPos.Enabled = enabled;
            buttonResetScale.Enabled = enabled;
        }

        private void SynchronizeMenuItems() {
            alwaysOnTopToolStripMenuItem.Checked = this.PreferredAlwaysOnTop;
            displayBonesToolStripMenuItem.Checked = game.DisplayBones;
            displayBoneNamesToolStripMenuItem.Checked = game.DisplayBoneNames;
            displayTexturesToolStripMenuItem.Checked = game.DisplayTextures;
            enableBumpMapsToolStripMenuItem.Checked = game.EnableBumpMaps;
            displayWireframeToolStripMenuItem.Checked = game.DisplayWireframe;
            backFaceCullingToolStripMenuItem.Checked = game.BackFaceCulling;
            alwaysForceCullingToolStripMenuItem.Checked = game.AlwaysForceCulling;
            displayGroundToolStripMenuItem.Checked = game.DisplayGround;
            useAlternativeReflectionMenuItem.Checked = game.UseAlternativeReflection;
            enableAddModelMultiSelectMenuItem.Checked = game.EnableAddModelMultiSelect;
        }

        private void AddItem(Item item) {
            checkBoxLockItem.Checked = false;
            comboBoxItem.Enabled = true;
            //checkBoxLockCamera.Checked = false;
            //comboBoxCameraPivot.Enabled = true;

            items.Add(item);
            DataSet dataSet = new DataSet();
            dataSet.item = item;
            Armature.Bone[] bones = item.Model.Armature.Bones;
            List<Armature.Bone> sortedBones = new List<Armature.Bone>();
            foreach (Armature.Bone bone in bones) {
                if (!bone.name.StartsWith("unused")) {
                    sortedBones.Add(bone);
                }
            }
            sortedBones.Sort(CompareBonesByName);
            BuildNodeTree(sortedBones, out dataSet.treeRootNodes, out dataSet.treeNodeDict);
            dataSet.boneTransforms = new BoneTransform[bones.Length];
            for (int i = 0; i < bones.Length; i++) {
                dataSet.boneTransforms[i] = new BoneTransform();
            }
            dataSet.height = 0;
            dataSetDict[item] = dataSet;
            itemDict[item.Model] = item;

            int itemID = GetNextItemID(item);
            string itemTag = item.DirName;
            if (itemID > 1) {
                itemTag += string.Format(" #{0}", itemID);
            }
            comboBoxItem.Items.Add(new ComboBoxItem(itemTag));
            item.Tag = itemTag;

            HandleItemSelectedIn3D(item);
            game.HandleItemAdded(item);
        }

        private int GetNextItemID(Item nextItem) {
            int id;
            if (!maxItemID.TryGetValue(nextItem.DirName, out id)) {
                id = 0;
            }
            id++;
            maxItemID[nextItem.DirName] = id;
            return id;
        }

        private void RemoveItem(Item item) {
            if (item == null) {
                return;
            }

            checkBoxLockItem.Checked = false;
            comboBoxItem.Enabled = true;
            //checkBoxLockCamera.Checked = false;
            //comboBoxCameraPivot.Enabled = true;

            HandleItemSelectedIn3D(null);

            items.Remove(item);
            dataSetDict.Remove(item);
            itemDict.Remove(item.Model);

            for (int i = 0; i < comboBoxItem.Items.Count; i++) {
                if (((ComboBoxItem)comboBoxItem.Items[i]).tag == item.Tag) {
                    comboBoxItem.Items.RemoveAt(i);
                    break;
                }
            }

            game.HandleItemRemoved(item);
        }

        private void RemoveAllItems() {
            while (items.Count > 0) {
                RemoveItem(items[0]);
            }
            maxItemID.Clear();
        }

        public Item SelectedItem {
            get { return selectedItem; }
        }

        public Armature.Bone SelectedBone {
            get { return selectedBone; }
        }

        public BoneTransform[] GetBoneTransforms(Item item) {
            return item != null ? dataSetDict[item].boneTransforms : null;
        }

        public float GetBoneRotationX(Armature.Bone bone) {
            Item item = itemDict[bone.armature.Model];
            DataSet dataSet = dataSetDict[item];
            return dataSet.boneTransforms[bone.id].rotX;
        }

        public float GetBoneRotationY(Armature.Bone bone) {
            Item item = itemDict[bone.armature.Model];
            DataSet dataSet = dataSetDict[item];
            return dataSet.boneTransforms[bone.id].rotY;
        }

        public float GetBoneRotationZ(Armature.Bone bone) {
            Item item = itemDict[bone.armature.Model];
            DataSet dataSet = dataSetDict[item];
            return dataSet.boneTransforms[bone.id].rotZ;
        }

        public bool IsItemSelectionLocked {
            get { return checkBoxLockItem.Checked; }
        }

        public bool IsCameraLocked {
            get { return checkBoxLockCamera.Checked; }
        }

        public void SetCameraPivot(int pivotIndex) {
            if (pivotIndex < 0 || pivotIndex >= comboBoxCameraPivot.Items.Count) {
                return;
            }
            comboBoxCameraPivot.SelectedIndex = -1;
            comboBoxCameraPivot.SelectedIndex = pivotIndex;
        }

        public void HandleItemSelectedIn3D(Item item) {
            if (item == selectedItem) {
                return;
            }
            if (item != null) {
                for (int i = 0; i < comboBoxItem.Items.Count; i++) {
                    if (((ComboBoxItem)comboBoxItem.Items[i]).tag == item.Tag) {
                        comboBoxItem.SelectedIndex = i;
                        break;
                    }
                }
            }
            else {
                comboBoxItem.SelectedItem = null;
            }
            //HandleItemSelectedInGUI(item);
        }

        public void Undo() {
            undoHistory.RestoreState();
        }

        public void UndoSaveInterrupt() {
            undoHistory.SaveInterrupt();
        }

        private void HandleItemSelectedInGUI(Item item) {
            if (item == selectedItem) {
                return;
            }

            if (selectedItem != null) {
                undoHistory.SaveState(new UndoHistoryStateSelectItem(selectedItem));
            }

            selectedItem = item;
            selectedBone = null;
            if (selectedItem != null) {
                EnablePositionScaleControls(true);
                EnableXYZHControls(true);
                EnableXYZControls(false);
            }
            else {
                EnablePositionScaleControls(false);
                EnableXYZHControls(false);
            }

            DataSet dataSet = null;
            if (selectedItem != null) {
                dataSet = dataSetDict[selectedItem];
            }

            this.treeViewBones.Nodes.Clear();
            if (dataSet != null) {
                foreach (TreeNode treeNode in dataSet.treeRootNodes) {
                    this.treeViewBones.Nodes.Add(treeNode);
                }
                this.treeViewBones.ExpandAll();
            }

            if (selectedItem != null) {
                SetTextBoxScaleValue(selectedItem.Model.Armature.WorldScale);
            }

            float height = 0;
            if (selectedItem != null) {
                Vector3 position = selectedItem.Model.Armature.WorldTranslation;
                height = position.Y;
                HandlePositionChanged(position);
            }
            SetTrackBarHValue(height);

            this.comboBoxCameraPivot.Items.Clear();
            if (selectedItem != null) {
                if (selectedItem.CameraTargetKeys.Count > 0) {
                    foreach (string cameraTargetKey in selectedItem.CameraTargetKeys) {
                        comboBoxCameraPivot.Items.Add(cameraTargetKey);
                    }
                    ignoreCameraPivotEvent = true;
                    comboBoxCameraPivot.SelectedIndex = 0;
                }
            }

            if (selectedItem != null) {
                Model model = selectedItem.Model;
                this.checkBoxItemVisible.Checked = model.IsVisible;
                UpdateAccessoriesCheckboxes(model);
            }
        }

        private void UpdateAccessoriesCheckboxes(Model model) {
            this.displayHandGunHandLeftToolStripMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.HandGunHandLeft);
            this.displayHandGunHandRightToolStripMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.HandGunHandRight);
            this.displayHandGunHolsterLeftToolStripMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.HandGunHolsterLeft);
            this.displayHandGunHolsterRightToolStripMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.HandGunHolsterRight);
            
            this.displayThorGearBeltMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGearBelt);
            this.displayThorGearGauntletLeftMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGearGauntletLeft);
            this.displayThorGearGauntletRightMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGearGauntletRight);
            this.displayThorGlowBeltMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowBelt);
            this.displayThorGlowGauntletLeftMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft);
            this.displayThorGlowGauntletRightMenuItem.Checked = model.IsMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight);
        }

        public void HandleBoneSelectedIn3D(Armature.Bone bone) {
            if (bone == selectedBone) {
                return;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            if (item != selectedItem) {
                if (IsItemSelectionLocked) {
                    return;
                }
                ignoreCameraPivotEvent = true;
                HandleItemSelectedIn3D(item);
            }

            DataSet dataSet = dataSetDict[item];
            treeViewBones.SelectedNode = dataSet.treeNodeDict[bone];
            //HandleBoneSelectedInGUI(bone);
        }

        private void HandleBoneSelectedInGUI(Armature.Bone bone, TreeNode treeNode) {
            if (bone == null) {
                if (selectedBone != null) {
                    undoHistory.SaveState(new UndoHistoryStateSelectBone(selectedBone));
                }

                selectedBone = null;
                EnableXYZControls(false);

                if (treeNode != null) {
                    selectedBonesTree = new List<Armature.Bone>();
                    BuildBoneSubTree(treeNode, selectedBonesTree);
                    buttonResetBoneXYZ.Enabled = true;
                }
                return;
            }

            selectedBonesTree = null;

            if (bone == selectedBone) {
                return;
            }

            if (selectedBone != null) {
                undoHistory.SaveState(new UndoHistoryStateSelectBone(selectedBone));
            }
            
            selectedBone = bone;
            EnableXYZControls(true);
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (isBoneModeRotate) {
                SetTrackBarXValue((int)Math.Round(boneTransform.rotX));
                SetTrackBarYValue((int)Math.Round(boneTransform.rotY));
                SetTrackBarZValue((int)Math.Round(boneTransform.rotZ));
            }
            else {
                SetTrackBarXValue((int)Math.Round(boneTransform.moveX * 1e3f));
                SetTrackBarYValue((int)Math.Round(boneTransform.moveY * 1e3f));
                SetTrackBarZValue((int)Math.Round(boneTransform.moveZ * 1e3f));
            }
        }

        private void BuildBoneSubTree(TreeNode rootNode, List<Armature.Bone> list) {
            foreach (TreeNode node in rootNode.Nodes) {
                if (node.Tag != null) {
                    list.Add((Armature.Bone)node.Tag);
                }
                BuildBoneSubTree(node, list);
            }
        }

        private void SetTextBoxScaleValue(Vector3 scale) {
            if (scale.X == scale.Y && scale.X == scale.Z) {
                textBoxScale.Text = string.Format("{0:0.0##}", scale.X);
            }
            else {
                textBoxScale.Text = string.Format("{0:0.0##}; {1:0.0##}; {2:0.0##}", scale.X, scale.Y, scale.Z);
            }
        }

        private void SetTrackBarXValue(int x) {
            this.trackBarX.Value = x;
            this.textBoxX.Text = string.Format("{0}", x);
        }

        private void SetTrackBarYValue(int y) {
            this.trackBarY.Value = y;
            this.textBoxY.Text = string.Format("{0}", y);
        }

        private void SetTrackBarZValue(int z) {
            this.trackBarZ.Value = z;
            this.textBoxZ.Text = string.Format("{0}", z);
        }

        private void SetTrackBarHValue(float height) {
            int value = (int)Math.Round(height * 100);
            if (value < this.trackBarH.Minimum) {
                value = this.trackBarH.Minimum;
            }
            if (value > this.trackBarH.Maximum) {
                value = this.trackBarH.Maximum;
            }
            this.trackBarH.Value = value;
            this.textBoxH.Text = string.Format("{0:0.00}", height);
        }

        private int CompareBonesByName(Armature.Bone bone1, Armature.Bone bone2) {
            return bone1.name.CompareTo(bone2.name);
        }

        private void BuildNodeTree(List<Armature.Bone> sortedBones, 
                                   out List<TreeNode> treeRootNodes,
                                   out Dictionary<Armature.Bone, TreeNode> treeNodeDict) {
            List<TreeItem> items = new List<TreeItem>();
            foreach (Armature.Bone bone in sortedBones) {
                TreeItem item = new TreeItem();
                item.nameTokens = bone.name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                item.bone = bone;
                items.Add(item);
            }
            treeNodeDict = new Dictionary<Armature.Bone, TreeNode>();
            TreeNode root = new TreeNode("Dummy");
            treeNodeDict = new Dictionary<Armature.Bone,TreeNode>();
            GroupTreeItems(items, 0, root, treeNodeDict);
            treeRootNodes = new List<TreeNode>();
            foreach (TreeNode node in root.Nodes) {
                treeRootNodes.Add(node);
            }
        }

        private void GroupTreeItems(List<TreeItem> items, int level, TreeNode root, 
                                Dictionary<Armature.Bone, TreeNode> treeNodeDict) {
            TreeNode groupNode = null;
            List<TreeItem> group = new List<TreeItem>();
            string token = null;
            foreach (TreeItem item in items) {
                if (level == item.nameTokens.Length - 1) {
                    TreeNode node = new TreeNode(item.bone.name);
                    node.Tag = item.bone;
                    node.ForeColor = Color.Blue;
                    root.Nodes.Add(node);
                    treeNodeDict[item.bone] = node;
                    continue;
                }
                if (item.nameTokens[level] != token) {
                    if (groupNode != null) {
                        GroupTreeItems(group, level + 1, groupNode, treeNodeDict);
                        root.Nodes.Add(groupNode);
                    }
                    token = item.nameTokens[level];
                    groupNode = new TreeNode(token);
                    groupNode.ForeColor = Color.Black;
                    group.Clear();
                    group.Add(item);
                }
                else {
                    group.Add(item);
                }
            }
            if (groupNode != null) {
                GroupTreeItems(group, level + 1, groupNode, treeNodeDict);
                root.Nodes.Add(groupNode);
            }
        }

        public void HandlePositionChanged(Vector3 position) {
            if (selectedItem != null) {
                textBoxPosition.Text = string.Format("{0:0.0##}; {1:0.0##}; {2:0.0##}", position.X, position.Y, position.Z);
            }
        }

        public void HandleScaleChangedInGUI(Vector3 scale) {
            SetTextBoxScaleValue(scale);
            if (selectedItem != null) {
                selectedItem.Model.Armature.WorldScale = scale;
            }
        }

        public bool HandleBoneRotationXChanged(Armature.Bone bone, float angle) {
            if (bone == null) {
                return false;
            }
            if (angle > 180) {
                angle = 180;
            }
            if (angle < -180) {
                angle = -180;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.rotX != angle) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.rotX = angle;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public bool HandleBoneRotationYChanged(Armature.Bone bone, float angle) {
            if (bone == null) {
                return false;
            }
            if (angle > 180) {
                angle = 180;
            }
            if (angle < -180) {
                angle = -180;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.rotY != angle) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.rotY = angle;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public bool HandleBoneRotationZChanged(Armature.Bone bone, float angle) {
            if (bone == null) {
                return false;
            }
            if (angle > 180) {
                angle = 180;
            }
            if (angle < -180) {
                angle = -180;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.rotZ != angle) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.rotZ = angle;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public bool HandleBoneTranslationXChanged(Armature.Bone bone, float position) {
            if (bone == null) {
                return false;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.moveX != position) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.moveX = position;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public bool HandleBoneTranslationYChanged(Armature.Bone bone, float position) {
            if (bone == null) {
                return false;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.moveY != position) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.moveY = position;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public bool HandleBoneTranslationZChanged(Armature.Bone bone, float position) {
            if (bone == null) {
                return false;
            }
            Model model = bone.armature.Model;
            Item item = itemDict[model];
            DataSet dataSet = dataSetDict[item];
            BoneTransform boneTransform = dataSet.boneTransforms[bone.id];
            if (boneTransform.moveZ != position) {
                undoHistory.SaveState(new UndoHistoryStateBoneTransform(bone, boneTransform));

                boneTransform.moveZ = position;
                ApplyTransformToBone(bone, boneTransform);
                return true;
            }
            return false;
        }

        public void HandleHeightChanged(float height) {
            if (height < trackBarH.Minimum * 0.01f) {
                height = trackBarH.Minimum * 0.01f;
            }
            if (height > trackBarH.Maximum * 0.01f) {
                height = trackBarH.Maximum * 0.01f;
            }
            SetTrackBarHValue(height);
            if (selectedItem == null) {
                return;
            }
            DataSet dataSet = dataSetDict[selectedItem];
            dataSet.height = height;
            ApplyHeightChangeToItem(selectedItem, height);
            HandlePositionChanged(selectedItem.Model.Armature.WorldTranslation);
        }

        public void ApplyTransformToBone(Armature.Bone bone, BoneTransform transform) {
            if (bone == selectedBone) {
                if (isBoneModeRotate) {
                    SetTrackBarXValue((int)Math.Round(transform.rotX));
                    SetTrackBarYValue((int)Math.Round(transform.rotY));
                    SetTrackBarZValue((int)Math.Round(transform.rotZ));
                }
                else {
                    SetTrackBarXValue((int)Math.Round(transform.moveX * 1e3f));
                    SetTrackBarYValue((int)Math.Round(transform.moveY * 1e3f));
                    SetTrackBarZValue((int)Math.Round(transform.moveZ * 1e3f));
                }
            }
            Matrix matrixX = Matrix.CreateRotationX(MathHelper.ToRadians(transform.rotX));
            Matrix matrixY = Matrix.CreateRotationY(MathHelper.ToRadians(transform.rotY));
            Matrix matrixZ = Matrix.CreateRotationZ(MathHelper.ToRadians(transform.rotZ));
            Matrix matrix = (matrixZ * matrixX) * matrixY;
            matrix *= Matrix.CreateTranslation(transform.moveX, transform.moveY, transform.moveZ);
            bone.armature.SetBoneTransform(bone.name, matrix);
        }

        private void ApplyHeightChangeToItem(Item item, float height) {
            Armature armature = item.Model.Armature;
            Vector3 translation = armature.WorldTranslation;
            translation.Y = height;
            armature.WorldTranslation = translation;
        }

        private void ComboBoxItemSelectedIndexChanged(object sender, EventArgs e) {
            int index = comboBoxItem.SelectedIndex;
            Item item = (index >= 0) ? items[index] : null;
            HandleItemSelectedInGUI(item);
        }

        private void CheckBoxLockItemCheckedChanged(object sender, EventArgs e) {
            comboBoxItem.Enabled = !IsItemSelectionLocked;
        }

        private void TreeViewAfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode node = this.treeViewBones.SelectedNode;
            Armature.Bone bone = (Armature.Bone)node.Tag;
            HandleBoneSelectedInGUI(bone, node);
        }

        private void TrackBarXScroll(object sender, EventArgs e) {
            float value = this.trackBarX.Value;
            if (isBoneModeRotate) {
                HandleBoneRotationXChanged(selectedBone, value);
            }
            else {
                HandleBoneTranslationXChanged(selectedBone, value * 1e-3f);
            }
        }

        private void TrackBarYScroll(object sender, EventArgs e) {
            float value = this.trackBarY.Value;
            if (isBoneModeRotate) {
                HandleBoneRotationYChanged(selectedBone, value);
            }
            else {
                HandleBoneTranslationYChanged(selectedBone, value * 1e-3f);
            }
        }

        private void TrackBarZScroll(object sender, EventArgs e) {
            float value = this.trackBarZ.Value;
            if (isBoneModeRotate) {
                HandleBoneRotationZChanged(selectedBone, value);
            }
            else {
                HandleBoneTranslationZChanged(selectedBone, value * 1e-3f);
            }
        }

        private void TrackBarHScroll(object sender, EventArgs e) {
            float height = this.trackBarH.Value * 0.01f;
            HandleHeightChanged(height);
        }

        private void TrackBarXMouseUp(object sender, MouseEventArgs e) {
            undoHistory.SaveInterrupt();
        }

        private void TrackBarYMouseUp(object sender, MouseEventArgs e) {
            undoHistory.SaveInterrupt();
        }

        private void TrackBarZMouseUp(object sender, MouseEventArgs e) {
            undoHistory.SaveInterrupt();
        }

        private void TextBoxPositionValidated(object sender, EventArgs e) {
            HandleTextInputPosition();
        }

        private void TextBoxScaleValidated(object sender, EventArgs e) {
            HandleTextInputScale();
        }

        private void TextBoxXValidated(object sender, EventArgs e) {
            if (HandleTextInputX()) {
                undoHistory.SaveInterrupt();
            }
        }

        private void TextBoxYValidated(object sender, EventArgs e) {
            if (HandleTextInputY()) {
                undoHistory.SaveInterrupt();
            }
        }

        private void TextBoxZValidated(object sender, EventArgs e) {
            if (HandleTextInputZ()) {
                undoHistory.SaveInterrupt();
            }
        }

        private void TextBoxHValidated(object sender, EventArgs e) {
            HandleTextInputH();
        }

        private void TextBoxPositionKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputPosition();
            }
        }

        private void TextBoxScaleKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputScale();
            }
        }

        private void TextBoxXKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (HandleTextInputX()) {
                    undoHistory.SaveInterrupt();
                }
            }
        }

        private void TextBoxYKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (HandleTextInputY()) {
                    undoHistory.SaveInterrupt();
                }
            }
        }

        private void TextBoxZKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                if (HandleTextInputZ()) {
                    undoHistory.SaveInterrupt();
                }
            }
        }

        private void TextBoxHKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                HandleTextInputH();
            }
        }

        private void HandleTextInputPosition() {
            string[] tokens = textBoxPosition.Text.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 3) {
                return;
            }
            float posX, posY, posZ;
            if (!float.TryParse(tokens[0], out posX)) {
                return;
            }
            if (!float.TryParse(tokens[1], out posY)) {
                return;
            }
            if (!float.TryParse(tokens[2], out posZ)) {
                return;
            }
            Vector3 position = new Vector3(posX, posY, posZ);
            HandlePositionChanged(position);
            SetTrackBarHValue(posY);
            if (selectedItem != null) {
                selectedItem.Model.Armature.WorldTranslation = position;
            }
        }

        private void HandleTextInputScale() {
            Vector3 scale;
            string[] tokens = textBoxScale.Text.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens.Length) {

                case 1:
                    float scaleXYZ;
                    if (!float.TryParse(tokens[0], out scaleXYZ)) {
                        return;
                    }
                    scale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
                    break;

                case 3:
                    float scaleX;
                    float scaleY;
                    float scaleZ;
                    if (!float.TryParse(tokens[0], out scaleX)) {
                        return;
                    }
                    if (!float.TryParse(tokens[1], out scaleY)) {
                        return;
                    }
                    if (!float.TryParse(tokens[2], out scaleZ)) {
                        return;
                    }
                    scale = new Vector3(scaleX, scaleY, scaleZ);
                    break;

                default:
                    return;
            }
            HandleScaleChangedInGUI(scale);
        }

        private bool HandleTextInputX() {
            float value;
            if (float.TryParse(textBoxX.Text, out value)) {
                if (isBoneModeRotate) {
                    return HandleBoneRotationXChanged(selectedBone, value);
                }
                else {
                    return HandleBoneTranslationXChanged(selectedBone, value * 1e-3f);
                }
            }
            return false;
        }

        private bool HandleTextInputY() {
            float value;
            if (float.TryParse(textBoxY.Text, out value)) {
                if (isBoneModeRotate) {
                    return HandleBoneRotationYChanged(selectedBone, value);
                }
                else {
                    return HandleBoneTranslationYChanged(selectedBone, value * 1e-3f);
                }
            }
            return false;
        }

        private bool HandleTextInputZ() {
            float value;
            if (float.TryParse(textBoxZ.Text, out value)) {
                if (isBoneModeRotate) {
                    return HandleBoneRotationZChanged(selectedBone, value);
                }
                else {
                    return HandleBoneTranslationZChanged(selectedBone, value * 1e-3f);
                }
            }
            return false;
        }

        private void HandleTextInputH() {
            float height;
            if (float.TryParse(textBoxH.Text, out height)) {
                HandleHeightChanged(height);
            }
        }

        private void ButtonResetPosClick(object sender, EventArgs e) {
            Vector3 position = Vector3.Zero;
            HandlePositionChanged(position);
            SetTrackBarHValue(0);
            selectedItem.Model.Armature.WorldTranslation = position;
        }

        private void ButtonResetScaleClick(object sender, EventArgs e) {
            HandleScaleChangedInGUI(new Vector3(1, 1, 1));
        }

        private void ButtonResetXYZClick(object sender, System.EventArgs e) {
            if (selectedBone != null) {
                ResetBoneXYZ(selectedBone);
            }
            if (selectedBonesTree != null) {
                foreach (Armature.Bone bone in selectedBonesTree) {
                    ResetBoneXYZ(bone);
                }
            }
        }

        private void ResetBoneXYZ(Armature.Bone bone) {
            bool result = false;
            if (isBoneModeRotate) {
                result |= HandleBoneRotationXChanged(bone, 0);
                result |= HandleBoneRotationYChanged(bone, 0);
                result |= HandleBoneRotationZChanged(bone, 0);
            }
            else {
                result |= HandleBoneTranslationXChanged(bone, 0);
                result |= HandleBoneTranslationYChanged(bone, 0);
                result |= HandleBoneTranslationZChanged(bone, 0);
            }
            if (result) {
                undoHistory.SaveInterrupt();
            }
        }

        private void ButtonResetXClick(object sender, EventArgs e) {
            bool result;
            if (isBoneModeRotate) {
                result = HandleBoneRotationXChanged(selectedBone, 0);
            }
            else {
                result = HandleBoneTranslationXChanged(selectedBone, 0);
            }
            if (result) {
                undoHistory.SaveInterrupt();
            }
        }

        private void ButtonResetYClick(object sender, EventArgs e) {
            bool result;
            if (isBoneModeRotate) {
                result = HandleBoneRotationYChanged(selectedBone, 0);
            }
            else {
                result = HandleBoneTranslationYChanged(selectedBone, 0);
            }
            if (result) {
                undoHistory.SaveInterrupt();
            }
        }

        private void ButtonResetZClick(object sender, EventArgs e) {
            bool result;
            if (isBoneModeRotate) {
                result = HandleBoneRotationZChanged(selectedBone, 0);
            }
            else {
                result = HandleBoneTranslationZChanged(selectedBone, 0);
            }
            if (result) {
                undoHistory.SaveInterrupt();
            }
        }

        private void ButtonResetHClick(object sender, EventArgs e) {
            HandleHeightChanged(0);
        }

        private void ComboBoxCameraPivotSelectedIndexChanged(object sender, System.EventArgs e) {
            if (ignoreCameraPivotEvent) {
                ignoreCameraPivotEvent = false;
                return;
            }
            string cameraTargetKey = (string)comboBoxCameraPivot.SelectedItem;
            if (cameraTargetKey == null) {
                return;
            }
            string[] cameraTargetBones = selectedItem.GetCameraTargetBones(cameraTargetKey);
            Armature armature = selectedItem.Model.Armature;
            Vector3 pivot = Vector3.Zero;
            foreach (string boneName in cameraTargetBones) {
                pivot += armature.GetBone(boneName).absTransform.Translation;
            }
            pivot /= cameraTargetBones.Length;
            pivot = Vector3.Transform(pivot, armature.WorldMatrix);
            game.CameraPivotChangedInGUI(pivot);
        }

        private void CheckBoxItemVisibleCheckedChanged(object sender, EventArgs e) {
            if (selectedItem != null) {
                selectedItem.Model.IsVisible = checkBoxItemVisible.Checked;
                game.BoneSelector.HandleModelVisibilityChanged(selectedItem.Model);
            }
        }

        private void CheckBoxLockCameraCheckedChanged(object sender, EventArgs e) {
            comboBoxCameraPivot.Enabled = !IsCameraLocked;
        }

        private void ButtonLookIntoCameraClick(object sender, EventArgs e) {
            if (selectedItem == null) {
                return;
            }

            Armature armature = selectedItem.Model.Armature;
            Armature.Bone eyeBoneLeft = armature.GetBone("head eyeball left");
            Armature.Bone eyeBoneRight = armature.GetBone("head eyeball right");
            if (eyeBoneLeft == null || eyeBoneRight == null) {
                return;
            }

            Matrix matrixLeft = eyeBoneLeft.relMove * eyeBoneLeft.parent.absTransform * armature.WorldMatrix;
            Matrix matrixRight = eyeBoneRight.relMove * eyeBoneRight.parent.absTransform * armature.WorldMatrix;

            Vector3 eyeLeftO = Vector3.Transform(Vector3.Zero, matrixLeft);
            Vector3 eyeLeftX = Vector3.Transform(Vector3.UnitX, matrixLeft) - eyeLeftO;
            Vector3 eyeLeftY = Vector3.Transform(Vector3.UnitY, matrixLeft) - eyeLeftO;
            Vector3 eyeLeftZ = Vector3.Transform(Vector3.UnitZ, matrixLeft) - eyeLeftO;

            Vector3 eyeRightO = Vector3.Transform(Vector3.Zero, matrixRight);
            Vector3 eyeRightX = Vector3.Transform(Vector3.UnitX, matrixRight) - eyeRightO;
            Vector3 eyeRightY = Vector3.Transform(Vector3.UnitY, matrixRight) - eyeRightO;
            Vector3 eyeRightZ = Vector3.Transform(Vector3.UnitZ, matrixRight) - eyeRightO;

            eyeLeftX.Normalize();
            eyeLeftY.Normalize();
            eyeLeftZ.Normalize();

            eyeRightX.Normalize();
            eyeRightY.Normalize();
            eyeRightZ.Normalize();

            matrixLeft = BasisTransformMatrix.GenerateMatrix(eyeLeftX, eyeLeftY, eyeLeftZ, Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ);
            matrixRight = BasisTransformMatrix.GenerateMatrix(eyeRightX, eyeRightY, eyeRightZ, Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ);

            Vector3 dirToCameraLeft = game.Camera.Position - eyeLeftO;
            Vector3 dirToCameraRight = game.Camera.Position - eyeRightO;

            dirToCameraLeft = Vector3.Transform(dirToCameraLeft, matrixLeft);
            dirToCameraRight = Vector3.Transform(dirToCameraRight, matrixRight);

            dirToCameraLeft.Normalize();
            dirToCameraRight.Normalize();

            float angleXLeft = MathHelper.ToDegrees((float)Math.Acos(dirToCameraLeft.Y) - MathHelper.PiOver2);
            float angleYLeft = MathHelper.ToDegrees((float)Math.Atan2(-dirToCameraLeft.Z, dirToCameraLeft.X) + MathHelper.PiOver2);

            float angleXRight = MathHelper.ToDegrees((float)Math.Acos(dirToCameraRight.Y) - MathHelper.PiOver2);
            float angleYRight = MathHelper.ToDegrees((float)Math.Atan2(-dirToCameraRight.Z, dirToCameraRight.X) + MathHelper.PiOver2);

            if ((Control.ModifierKeys & Keys.Shift) == 0) {
                angleXLeft = Math.Min(Math.Max(angleXLeft, -2.0f), 12.0f);
                angleYLeft = Math.Min(Math.Max(angleYLeft, -12.0f), 28.0f);

                angleXRight = Math.Min(Math.Max(angleXRight, -2.0f), 12.0f);
                angleYRight = Math.Min(Math.Max(angleYRight, -28.0f), 12.0f);
            }

            HandleBoneRotationXChanged(eyeBoneLeft, angleXLeft);
            HandleBoneRotationYChanged(eyeBoneLeft, angleYLeft);
            HandleBoneRotationZChanged(eyeBoneLeft, 0);

            HandleBoneRotationXChanged(eyeBoneRight, angleXRight);
            HandleBoneRotationYChanged(eyeBoneRight, angleYRight);
            HandleBoneRotationZChanged(eyeBoneRight, 0);
        }

        private void ButtonBoneModeClick(object sender, EventArgs e) {
            isBoneModeRotate = !isBoneModeRotate;
            buttonBoneMode.Text = isBoneModeRotate ? "Mode: Rotate" : "Mode: Move";
            if (selectedItem == null || selectedBone == null) {
                return;
            }
            DataSet dataSet = dataSetDict[selectedItem];
            BoneTransform transform = dataSet.boneTransforms[selectedBone.id];
            if (isBoneModeRotate) {
                SetTrackBarXValue((int)Math.Round(transform.rotX));
                SetTrackBarYValue((int)Math.Round(transform.rotY));
                SetTrackBarZValue((int)Math.Round(transform.rotZ));
            }
            else {
                SetTrackBarXValue((int)Math.Round(transform.moveX * 1e3f));
                SetTrackBarYValue((int)Math.Round(transform.moveY * 1e3f));
                SetTrackBarZValue((int)Math.Round(transform.moveZ * 1e3f));
            }
        }

        private void AddItemMenuItemClick(object sender, EventArgs e) {
            AddItemDialog itemDialog = new AddItemDialog(game, items);
            itemDialog.InFrontOfCameraChecked = placeNewItemsInFrontOfCamera;
            itemDialog.ShowDialog(this);

            ItemDesc[] itemDescs = itemDialog.SelectedItems;
            placeNewItemsInFrontOfCamera = itemDialog.InFrontOfCameraChecked;

            foreach (ItemDesc itemDesc in itemDescs) {
                Item item = ItemFactory.GetItem(game, itemDesc.itemType);
                if (item == null) {
                    continue;
                }
                if (!item.LoadAndInitModel(itemDesc.itemType, itemDesc.dirPath)) {
                    continue;
                }
                if (placeNewItemsInFrontOfCamera) {
                    item.Model.Armature.WorldTranslation = CalculatePositionInFrontOfCamera(item);
                }
                AddItem(item);
            }

            undoHistory.Clear();
        }

        private Vector3 CalculatePositionInFrontOfCamera(Item item) {
            List<Mesh> meshes = new List<Mesh>(item.Model.Meshes);
            if (meshes.Count == 0) {
                return Vector3.Zero;
            }
            BoundingBox bbox = meshes[0].BoundingBox;
            for (int i = 1; i < meshes.Count; i++) {
                bbox = BoundingBox.CreateMerged(bbox, meshes[i].BoundingBox);
            }
            CameraTurnTable camera = game.Camera;
            Microsoft.Xna.Framework.Graphics.Viewport viewport = game.GraphicsDevice.Viewport;
            Vector2 viewportCenter = new Vector2(viewport.Width / 2, viewport.Height / 2);
            Vector3 position = Vector3.Zero;
            float minDist = float.PositiveInfinity;
            for (int i = 0; i < 5; i++) {
                float yPos = 0.5f + 0.1f * i;
                Vector3 pos;
                if (CalculatePositionInFrontOfCamera(yPos, out pos)) {
                    Vector3 p1 = pos + Vector3.UnitY * bbox.Min.Y;
                    Vector3 p2 = pos + Vector3.UnitY * bbox.Max.Y;
                    p1 = viewport.Project(p1, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
                    p2 = viewport.Project(p2, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
                    Vector2 bboxCenter = new Vector2((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                    float dist = (bboxCenter - viewportCenter).Length();
                    if (dist < minDist) {
                        minDist = dist;
                        position = pos;
                    }
                }
            }
            return position;
        }

        private bool CalculatePositionInFrontOfCamera(float yPos, out Vector3 position) {
            CameraTurnTable camera = game.Camera;
            Microsoft.Xna.Framework.Graphics.Viewport viewport = game.GraphicsDevice.Viewport;
            float x = viewport.Width / 2;
            float y = viewport.Height * yPos;
            Vector3 pointNear = new Vector3(x, y, 0);
            Vector3 pointFar = new Vector3(x, y, 1);
            pointNear = viewport.Unproject(pointNear, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
            pointFar = viewport.Unproject(pointFar, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
            Vector3 direction = pointFar - pointNear;
            direction.Normalize();
            Ray ray = new Ray(pointNear, direction);
            Plane groundPlane = new Plane(Vector3.Up, 0);
            Nullable<float> result = ray.Intersects(groundPlane);
            if (!result.HasValue) {
                position = Vector3.Zero;
                return false;
            }
            float t = result.Value;
            if (t < 0 || t > 50) {
                position = Vector3.Zero;
                return false;
            }
            position = pointNear + direction * t;
            position.Y = 0;
            return true;
        }

        private void CloneSelectedItemMenuItemClick(object sender, EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            CloneItem(selectedItem);

            undoHistory.Clear();
        }

        private void CloneItem(Item item) {
            Item clone = ItemFactory.GetItem(game, item.Type);
            if (clone == null) {
                return;
            }
            if (!clone.LoadAndInitModel(item.Type, item.DirName)) {
                return;
            }

            foreach (string groupName in item.Model.GetMeshGroupNames()) {
                bool isGroupVisible = item.Model.IsMeshGroupVisible(groupName);
                clone.Model.SetMeshGroupVisible(groupName, isGroupVisible);
            }

            AddItem(clone);

            Armature armatureOrig = item.Model.Armature;
            Armature armatureClone = clone.Model.Armature;

            DataSet dataSetOrig = dataSetDict[item];
            DataSet dataSetClone = dataSetDict[clone];

            foreach (Armature.Bone boneOrig in armatureOrig.Bones) {
                Armature.Bone boneClone = armatureClone.GetBone(boneOrig.name);

                BoneTransform boneTransformOrig = dataSetOrig.boneTransforms[boneOrig.id];
                BoneTransform boneTransformClone = dataSetClone.boneTransforms[boneClone.id];

                boneTransformClone.moveX = boneTransformOrig.moveX;
                boneTransformClone.moveY = boneTransformOrig.moveY;
                boneTransformClone.moveZ = boneTransformOrig.moveZ;
                boneTransformClone.rotX = boneTransformOrig.rotX;
                boneTransformClone.rotY = boneTransformOrig.rotY;
                boneTransformClone.rotZ = boneTransformOrig.rotZ;

                ApplyTransformToBone(boneClone, boneTransformClone);
            }

            armatureClone.WorldScale = armatureOrig.WorldScale;
            HandleScaleChangedInGUI(armatureClone.WorldScale);

            armatureClone.WorldTranslation = armatureOrig.WorldTranslation;
            HandleHeightChanged(armatureClone.WorldTranslation.Y);
        }

        private void RemoveSelectedItemMenuItemClick(object sender, EventArgs e) {
            RemoveItem(selectedItem);

            undoHistory.Clear();
        }

        private void ReloadTexturesOfSelectedModelMenuItemClick(object sender, EventArgs e) {
            ReloadTextures();
        }

        public void ReloadTextures() {
            if (selectedItem != null) {
                Dictionary<Microsoft.Xna.Framework.Graphics.Texture2D, Microsoft.Xna.Framework.Graphics.Texture2D> textureMapping = selectedItem.Model.ReloadTextures();
                foreach (Item item in items) {
                    if (item == selectedItem) {
                        continue;
                    }
                    foreach (KeyValuePair<Microsoft.Xna.Framework.Graphics.Texture2D, Microsoft.Xna.Framework.Graphics.Texture2D> entry in textureMapping) {
                        Microsoft.Xna.Framework.Graphics.Texture2D oldTexture = entry.Key;
                        Microsoft.Xna.Framework.Graphics.Texture2D newTexture = entry.Value;
                        item.Model.ReplaceTexture(oldTexture, newTexture);
                    }
                }                
            }
        }

        private void ResetPoseMenuItemClick(object sender, EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            DataSet dataSet = dataSetDict[selectedItem];
            Armature.Bone[] bones = selectedItem.Model.Armature.Bones;
            foreach (Armature.Bone bone in bones) {
                HandleBoneRotationXChanged(bone, 0);
                HandleBoneRotationYChanged(bone, 0);
                HandleBoneRotationZChanged(bone, 0);
                HandleBoneTranslationXChanged(bone, 0);
                HandleBoneTranslationYChanged(bone, 0);
                HandleBoneTranslationZChanged(bone, 0);
            }

            undoHistory.Clear();
        }

        private void LoadPoseMenuItemClick(object sender, System.EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Load pose file";
            dialog.Filter = "Pose file (*.pose)|*.pose";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            LoadPose(dialog.FileName);

            undoHistory.Clear();
        }

        private void SavePoseMenuItemClick(object sender, System.EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save pose file";
            dialog.Filter = "Pose file (*.pose)|*.pose";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            SavePose(dialog.FileName);
        }

        private void ResetSceneMenuItemClick(object sender, EventArgs e) {
            if (lightingParamsDialog != null) {
                lightingParamsDialog.Close();
                lightingParamsDialog = null;
            }
            if (cameraParamsDialog != null) {
                cameraParamsDialog.Close();
                cameraParamsDialog = null;
            }
            if (postProcessParamsDialog != null) {
                postProcessParamsDialog.Close();
                postProcessParamsDialog = null;
            }
            if (skyDomeParamsDialog != null) {
                skyDomeParamsDialog.Close();
                skyDomeParamsDialog = null;
            }

            RemoveAllItems();

            game.ResetCamera(game.Camera);
            game.ResetLights();
            game.ResetPostProcessParams();

            game.BackgroundColor = Game.DefaultBackgroundColor;
            game.BackgroundImage = null;

            game.DisplaySkyDome = false;
            game.SkyDomeRotation = 0;
            game.SkyDomeElevation = 0;

            game.CanvasSize = new Size(Game.DefaultCanvasWidth, Game.DefaultCanvasHeight);

            ImportConfig();
            SynchronizeMenuItems();

            undoHistory.Clear();
        }

        private void LoadSceneMenuItemClick(object sender, EventArgs e) {
            if (lightingParamsDialog != null) {
                lightingParamsDialog.Close();
                lightingParamsDialog = null;
            }
            if (cameraParamsDialog != null) {
                cameraParamsDialog.Close();
                cameraParamsDialog = null;
            }
            if (postProcessParamsDialog != null) {
                postProcessParamsDialog.Close();
                postProcessParamsDialog = null;
            }
            if (skyDomeParamsDialog != null) {
                skyDomeParamsDialog.Close();
                skyDomeParamsDialog = null;
            }

            OpenFileDialog dialogFile = new OpenFileDialog();
            dialogFile.Title = "Load scene";
            dialogFile.Filter = "Scene file (*.scene)|*.scene";
            dialogFile.RestoreDirectory = true;
            if (dialogFile.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            LoadSceneDialog dialogOptions = new LoadSceneDialog(game);
            if (dialogOptions.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            LoadScene(dialogFile.FileName,
                dialogOptions.ClearScene,
                dialogOptions.LoadScene,
                dialogOptions.LoadCamera,
                dialogOptions.LoadLights,
                dialogOptions.LoadPostProcess,
                dialogOptions.LoadWindowSize);
            SynchronizeMenuItems();

            undoHistory.Clear();
        }

        private void SaveSceneMenuItemClick(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save scene";
            dialog.Filter = "Scene file (*.scene)|*.scene";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                SaveScene(dialog.FileName);
            }
        }

        private void SaveImageMenuItemClick(object sender, EventArgs e) {
            SaveImageDialog paramsDialog = new SaveImageDialog(game);
            paramsDialog.RenderLogo = game.RenderLogo;
            if (paramsDialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            game.RenderLogo = paramsDialog.RenderLogo;

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Save image";
            if (paramsDialog.SaveAlphaChannel) {
                fileDialog.Filter = "Image (*.png)|*.png";
            }
            else {
                fileDialog.Filter = "Image (*.jpg)|*.jpg|Image (*.png)|*.png";
            }
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            try {
                game.Renderer.RenderSceneToImage(fileDialog.FileName, paramsDialog.ImageSize, paramsDialog.SaveAlphaChannel, paramsDialog.RenderLogo);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not save image.\n" + ex.StackTrace,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void QuickSaveImageMenuItemClick(object sender, EventArgs e) {
            QuickSaveImage();
        }

        public void QuickSaveImage() {
            string dirName = "images";
            if (!Directory.Exists(dirName)) {
                try {
                    Directory.CreateDirectory(dirName);
                }
                catch (Exception) {
                    MessageBox.Show(this, string.Format("Could not create directory \"{0}\".", dirName),
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (quickSaveImageID == 0) {
                SaveImageDialog paramsDialog = new SaveImageDialog(game);
                paramsDialog.RenderLogo = game.RenderLogo;
                if (paramsDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
                quickSaveImageSize = paramsDialog.ImageSize;
                quickSaveImageAlpha = paramsDialog.SaveAlphaChannel;
                game.RenderLogo = paramsDialog.RenderLogo;
            }

            quickSaveImageID = DetermineNextQuickSaveImageID(dirName);
            string filename = string.Format("{0}\\image{1:D5}.png", dirName, quickSaveImageID);

            try {
                game.Renderer.RenderSceneToImage(filename, quickSaveImageSize, quickSaveImageAlpha, game.RenderLogo);
                game.HUD.Message = string.Format("quick-saved image \"{0}\"", filename);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not save image.\n" + ex.StackTrace,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private int DetermineNextQuickSaveImageID(string dirName) {
            FileInfo[] fileInfos = new DirectoryInfo(dirName).GetFiles("image*.png");
            int maxID = 0;
            foreach (FileInfo fileInfo in fileInfos) {
                string s = fileInfo.Name;
                if (s.Length < 10) {
                    continue;
                }
                s = s.Substring(0, s.Length - 4).Substring(5);
                int id;
                if (int.TryParse(s, out id)) {
                    maxID = Math.Max(id, maxID);
                }
            }
            return maxID + 1;
        }

        private void ExportObjMenuItemClick(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export model";
            dialog.Filter = "Wavefront (*.obj)|*.obj";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            try {
                List<Model> models = new List<Model>();
                foreach (Item item in items) {
                    //if (item.Type == ItemType.Dummy) {
                    //    continue;
                    //}
                    models.Add(item.Model);
                }
                MeshObjExporter.ExportToObj(models, dialog.FileName);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not save model.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ExportMeshAsciiMenuItemClick(object sender, EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export mesh file (default T-pose)";
            dialog.Filter = "Mesh file (*.mesh.ascii)|*.mesh.ascii";
            dialog.DefaultExt = "mesh.ascii";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            try {
                MeshAsciiExporter.ExportToMeshAscii(selectedItem.Model, dialog.FileName, false);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not export mesh.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ExportMeshAsciiPosedMenuItemClick(object sender, EventArgs e) {
            if (selectedItem == null) {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export mesh file (posed)";
            dialog.Filter = "Mesh file (*.mesh.ascii)|*.mesh.ascii";
            dialog.DefaultExt = "mesh.ascii";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            try {
                MeshAsciiExporter.ExportToMeshAscii(selectedItem.Model, dialog.FileName, true);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not export mesh.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ExitMenuItemClick(object sender, EventArgs e) {
            if (DialogConfirmExit()) {
                ExportConfig();
                game.ForceExit();
            }
        }

        private void UndoMenuItemClick(object sender, EventArgs e) {
            Undo();
        }

        private void MirrorPoseMenuItemClick(object sender, EventArgs e) {
            MirrorPose();
        }

        private void FlipPoseMenuItemClick(object sender, EventArgs e) {
            FlipPose();
        }

        private void MirrorModelXMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                Armature armature = selectedItem.Model.Armature;
                Vector3 scale = armature.WorldScale;
                scale.X = -scale.X;
                SetTextBoxScaleValue(scale);
                armature.WorldScale = scale;
            }
        }

        private void MirrorModelYMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                Armature armature = selectedItem.Model.Armature;
                Vector3 scale = armature.WorldScale;
                scale.Y = -scale.Y;
                SetTextBoxScaleValue(scale);
                armature.WorldScale = scale;
            }
        }

        private void MirrorModelZMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                Armature armature = selectedItem.Model.Armature;
                Vector3 scale = armature.WorldScale;
                scale.Z = -scale.Z;
                SetTextBoxScaleValue(scale);
                armature.WorldScale = scale;
            }
        }

        private void AlwaysOnTopMenuItemClick(object sender, EventArgs e) {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = this.PreferredAlwaysOnTop = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void SetBackgroundColorMenuItemClick(object sender, EventArgs e) {
            ColorDialog dialog = new ColorDialog();
            byte colorR = game.BackgroundColor.R;
            byte colorG = game.BackgroundColor.G;
            byte colorB = game.BackgroundColor.B;
            dialog.Color = Color.FromArgb(colorR, colorG, colorB);
            if (dialog.ShowDialog() == DialogResult.OK) {
                colorR = dialog.Color.R;
                colorG = dialog.Color.G;
                colorB = dialog.Color.B;
                game.BackgroundColor = new Microsoft.Xna.Framework.Graphics.Color(colorR, colorG, colorB);
            }
        }

        private void AssignBackgroundImageMenuItemClick(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Load background image";
            dialog.Filter = "Image (*.bmp,*.png,*.jpg)|*.bmp;*.png;*.jpg";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }
            try {
                Microsoft.Xna.Framework.Graphics.Texture2D texture =
                    Microsoft.Xna.Framework.Graphics.Texture2D.FromFile(game.GraphicsDevice, dialog.FileName);
                BackgroundImage image = new BackgroundImage(texture);
                Microsoft.Xna.Framework.Rectangle rect = game.Window.ClientBounds;
                image.HandleWindowResized(rect.Width, rect.Height);
                game.BackgroundImage = image;
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Could not load background image.\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RemoveBackgroundImageMenuItemClick(object sender, EventArgs e) {
            game.BackgroundImage = null;
        }

        private void DisplayBonesMenuItemClick(object sender, EventArgs e) {
            displayBonesToolStripMenuItem.Checked = !displayBonesToolStripMenuItem.Checked;
            game.DisplayBones = displayBonesToolStripMenuItem.Checked;
        }

        private void DisplayBoneNamesMenuItemClick(object sender, EventArgs e) {
            displayBoneNamesToolStripMenuItem.Checked = !displayBoneNamesToolStripMenuItem.Checked;
            game.DisplayBoneNames = displayBoneNamesToolStripMenuItem.Checked;
        }

        private void DisplayTexturesMenuItemClick(object sender, EventArgs e) {
            displayTexturesToolStripMenuItem.Checked = !displayTexturesToolStripMenuItem.Checked;
            game.DisplayTextures = displayTexturesToolStripMenuItem.Checked;
        }

        private void EnableBumpMapsMenuItemClick(object sender, EventArgs e) {
            enableBumpMapsToolStripMenuItem.Checked = !enableBumpMapsToolStripMenuItem.Checked;
            game.EnableBumpMaps = enableBumpMapsToolStripMenuItem.Checked;
        }

        private void DisplayWireframeMenuItemClick(object sender, EventArgs e) {
            displayWireframeToolStripMenuItem.Checked = !displayWireframeToolStripMenuItem.Checked;
            game.DisplayWireframe = displayWireframeToolStripMenuItem.Checked;
        }

        private void BackFaceCullingMenuItemClick(object sender, EventArgs e) {
            backFaceCullingToolStripMenuItem.Checked = !backFaceCullingToolStripMenuItem.Checked;
            game.BackFaceCulling = backFaceCullingToolStripMenuItem.Checked;
        }

        private void AlwaysForceCullingMenuItemClick(object sender, EventArgs e) {
            alwaysForceCullingToolStripMenuItem.Checked = !alwaysForceCullingToolStripMenuItem.Checked;
            game.AlwaysForceCulling = alwaysForceCullingToolStripMenuItem.Checked;
        }

        private void DisplayGroundMenuItemClick(object sender, EventArgs e) {
            displayGroundToolStripMenuItem.Checked = !displayGroundToolStripMenuItem.Checked;
            game.DisplayGround = displayGroundToolStripMenuItem.Checked;
        }

        private void UseAlternativeReflectionMenuItemClick(object sender, EventArgs e) {
            useAlternativeReflectionMenuItem.Checked = !useAlternativeReflectionMenuItem.Checked;
            game.UseAlternativeReflection = useAlternativeReflectionMenuItem.Checked;

            MessageBox.Show("You need to reload your scene/models now for the new settings to take effect.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SkyDomeParametersMenuItemClick(object sender, EventArgs e) {
            if (skyDomeParamsDialog != null) {
                return;
            }
            skyDomeParamsDialog = new SkyDomeParamsDialog(game);
            skyDomeParamsDialog.Show(this);
        }

        private void LightingParamsMenuItemClick(object sender, EventArgs e) {
            if (lightingParamsDialog != null) {
                return;
            }
            lightingParamsDialog = new LightingParamsDialog(game);
            lightingParamsDialog.Show(this);
        }

        private void CameraParametersMenuItemClick(object sender, EventArgs e) {
            if (cameraParamsDialog != null) {
                return;
            }
            cameraParamsDialog = new CameraParamsDialog(game);
            cameraParamsDialog.Show(this);
        }

        private void PostProcessParamsMenuItemClick(object sender, EventArgs e) {
            if (postProcessParamsDialog != null) {
                return;
            }
            postProcessParamsDialog = new PostProcessParamsDialog(game);
            postProcessParamsDialog.Show(this);
        }

        public void HandleLightingParamsDialogClosed() {
            lightingParamsDialog = null;
        }

        public void HandleCameraParamsDialogClosed() {
            cameraParamsDialog = null;
        }

        public void HandlePostProcessParamsDialogClosed() {
            postProcessParamsDialog = null;
        }

        public void HandleSkyDomeParamsDialogClosed() {
            skyDomeParamsDialog = null;
        }

        private void DisplayHandGunHandLeftMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayHandGunHandLeftToolStripMenuItem.Checked = !displayHandGunHandLeftToolStripMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.HandGunHandLeft, displayHandGunHandLeftToolStripMenuItem.Checked);
            }
        }

        private void DisplayHandGunHandRightMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayHandGunHandRightToolStripMenuItem.Checked = !displayHandGunHandRightToolStripMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.HandGunHandRight, displayHandGunHandRightToolStripMenuItem.Checked);
            }
        }

        private void DisplayHandGunHolsterLeftMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayHandGunHolsterLeftToolStripMenuItem.Checked = !displayHandGunHolsterLeftToolStripMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterLeft, displayHandGunHolsterLeftToolStripMenuItem.Checked);
            }
        }

        private void DisplayHandGunHolsterRightMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayHandGunHolsterRightToolStripMenuItem.Checked = !displayHandGunHolsterRightToolStripMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.HandGunHolsterRight, displayHandGunHolsterRightToolStripMenuItem.Checked);
            }
        }

        private void DisplayThorGearBeltMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGearBeltMenuItem.Checked = !displayThorGearBeltMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGearBelt, displayThorGearBeltMenuItem.Checked);
            }
        }

        private void DisplayThorGearGauntletLeftMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGearGauntletLeftMenuItem.Checked = !displayThorGearGauntletLeftMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletLeft, displayThorGearGauntletLeftMenuItem.Checked);
            }
        }

        private void DisplayThorGearGauntletRightMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGearGauntletRightMenuItem.Checked = !displayThorGearGauntletRightMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGearGauntletRight, displayThorGearGauntletRightMenuItem.Checked);
            }
        }

        private void DisplayThorGlowBeltMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGlowBeltMenuItem.Checked = !displayThorGlowBeltMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGlowBelt, displayThorGlowBeltMenuItem.Checked);
            }
        }

        private void DisplayThorGlowGauntletLeftGlowMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGlowGauntletLeftMenuItem.Checked = !displayThorGlowGauntletLeftMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletLeft, displayThorGlowGauntletLeftMenuItem.Checked);
            }
        }

        private void DisplayThorGlowGauntletRightGlowMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                displayThorGlowGauntletRightMenuItem.Checked = !displayThorGlowGauntletRightMenuItem.Checked;
                selectedItem.Model.SetMeshGroupVisible(MeshGroupNames.ThorGlowGauntletRight, displayThorGlowGauntletRightMenuItem.Checked);
            }
        }

        private void SetGlowLeftColorMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Vector4ToColor(selectedItem.ColorGlowLeft);
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    selectedItem.ColorGlowLeft = ColorToVector4(dialog.Color);
                }                
            }
        }

        private void SetGlowRightColorMenuItemClick(object sender, EventArgs e) {
            if (selectedItem != null) {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Vector4ToColor(selectedItem.ColorGlowRight);
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    selectedItem.ColorGlowRight = ColorToVector4(dialog.Color);
                }
            }
        }

        private Color Vector4ToColor(Vector4 color) {
            int r = (int)Math.Round(color.X * 255);
            int g = (int)Math.Round(color.Y * 255);
            int b = (int)Math.Round(color.Z * 255);
            return Color.FromArgb(r, g, b);
        }

        private Vector4 ColorToVector4(Color color) {
            return new Vector4(color.R / 255f, color.G / 255f, color.B / 255f, 1);
        }

        private void CanvasSizeMenuItemClick(object sender, EventArgs e) {
            CanvasSizeDialog dialog = new CanvasSizeDialog(game);
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                game.CanvasSize = dialog.CanvasSize;
            }
        }

        private void EnableAddModelMultiSelectMenuItemClick(object sender, EventArgs e) {
            enableAddModelMultiSelectMenuItem.Checked = !enableAddModelMultiSelectMenuItem.Checked;
            game.EnableAddModelMultiSelect = enableAddModelMultiSelectMenuItem.Checked;
        }

        private void ControlsMenuItemClick(object sender, EventArgs e) {
            new HelpBox(game).ShowDialog(this);
        }

        private void AboutMenuItemClick(object sender, EventArgs e) {
            AboutBox dialog = new AboutBox(game);
            dialog.ShowDialog(this);
        }

        protected override void OnActivated(EventArgs e) {
            game.HasFocus = false;
        }

        protected override void OnDeactivate(EventArgs e) {
            game.HasFocus = true;
        }

        protected override void OnResize(EventArgs e) {
            RecalculateGUILayout();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (DialogConfirmExit()) {
                ExportConfig();
                game.ForceExit();
            }
            else {
                e.Cancel = true;
            }
        }

        private bool DialogConfirmExit() {
            bool savedFocus = game.HasFocus;
            game.HasFocus = false;
            DialogResult result =
                MessageBox.Show("Do you want to quit XNALara?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            game.HasFocus = savedFocus;
            return result == DialogResult.Yes;
        }

        private void RecalculateGUILayout() {
            int dx = this.Width - 470;
            int dy = this.Height - 595;
            this.comboBoxItem.Width = 210 + dx;
            this.textBoxPosition.Width = 169 + dx;
            this.textBoxScale.Width = 169 + dx;
            this.buttonResetPos.Location = new System.Drawing.Point(236 + dx, 57);
            this.buttonResetScale.Location = new System.Drawing.Point(236 + dx, 85);
            this.buttonLookIntoCamera.Location = new System.Drawing.Point(161 + dx, 114);
            this.treeViewBones.Size = new Size(260 + dx, 369 + dy);
            this.labelCameraPivot.Location = new System.Drawing.Point(8, 524 + dy);
            this.comboBoxCameraPivot.Location = new System.Drawing.Point(107, 519 + dy);
            this.comboBoxCameraPivot.Width = 112 + dx;
            this.checkBoxLockCamera.Location = new System.Drawing.Point(223 + dx, 519 + dy);
            this.labelX.Location = new System.Drawing.Point(283 + dx, 33);
            this.labelY.Location = new System.Drawing.Point(325 + dx, 33);
            this.labelZ.Location = new System.Drawing.Point(367 + dx, 33);
            this.labelH.Location = new System.Drawing.Point(409 + dx, 33);
            this.trackBarX.Location = new System.Drawing.Point(285 + dx, 52);
            this.trackBarY.Location = new System.Drawing.Point(327 + dx, 52);
            this.trackBarZ.Location = new System.Drawing.Point(369 + dx, 52);
            this.trackBarH.Location = new System.Drawing.Point(411 + dx, 52);
            this.trackBarX.Height = 374 + dy;
            this.trackBarY.Height = 374 + dy;
            this.trackBarZ.Height = 374 + dy;
            this.trackBarH.Height = 374 + dy;
            this.buttonResetX.Location = new System.Drawing.Point(285 + dx, 430 + dy);
            this.buttonResetY.Location = new System.Drawing.Point(327 + dx, 430 + dy);
            this.buttonResetZ.Location = new System.Drawing.Point(369 + dx, 430 + dy);
            this.buttonResetH.Location = new System.Drawing.Point(411 + dx, 430 + dy);
            this.textBoxX.Location = new System.Drawing.Point(285 + dx, 461 + dy);
            this.textBoxY.Location = new System.Drawing.Point(327 + dx, 461 + dy);
            this.textBoxZ.Location = new System.Drawing.Point(369 + dx, 461 + dy);
            this.textBoxH.Location = new System.Drawing.Point(411 + dx, 461 + dy);
            this.buttonResetBoneXYZ.Location = new System.Drawing.Point(285 + dx, 487 + dy);
            this.buttonBoneMode.Location = new System.Drawing.Point(285 + dx, 519 + dy);
        }

        private class TreeItem
        {
            public string[] nameTokens;
            public Armature.Bone bone;
        }

        public class BoneTransform
        {
            public float rotX;
            public float rotY;
            public float rotZ;

            public float moveX;
            public float moveY;
            public float moveZ;

            public BoneTransform Clone() {
                BoneTransform clone = new BoneTransform();
                clone.rotX = rotX;
                clone.rotY = rotY;
                clone.rotZ = rotZ;
                clone.moveX = moveX;
                clone.moveY = moveY;
                clone.moveZ = moveZ;
                return clone;
            }
        }

        public class DataSet
        {
            public Item item;
            public Dictionary<Armature.Bone, TreeNode> treeNodeDict;
            public List<TreeNode> treeRootNodes;
            public BoneTransform[] boneTransforms;
            public float height;
        }

        public class ComboBoxItem
        {
            public string tag;
            public string label;

            public ComboBoxItem(string tag) {
                this.tag = label = tag;
                int pos = label.LastIndexOfAny(new char[] { '\\', '/' });
                if (pos >= 0) {
                    label = label.Substring(pos + 1);
                }
            }

            public override string ToString() {
                return label;
            }
        }
    }
}
