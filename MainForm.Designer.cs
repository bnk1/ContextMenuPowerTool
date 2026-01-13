namespace ContextMenuPowerTool
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHKCU;
        private System.Windows.Forms.CheckBox chkHKLM;

        private System.Windows.Forms.CheckBox chkAllFiles;
        private System.Windows.Forms.CheckBox chkDirectory;
        private System.Windows.Forms.CheckBox chkBackground;
        private System.Windows.Forms.CheckBox chkDrive;

        private System.Windows.Forms.CheckBox chkShowDisabledOnly;
        private System.Windows.Forms.CheckBox chkShowInSubmenuOnly;
        private System.Windows.Forms.CheckBox chkShowStatic;
        private System.Windows.Forms.CheckBox chkShowHandlers;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnEnsureSubmenu;
        private System.Windows.Forms.Button btnMoveToSubmenu;
        private System.Windows.Forms.Button btnRemoveFromSubmenu;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRestartExplorer;
        private System.Windows.Forms.Button btnOpenRegedit;

        private System.Windows.Forms.TextBox txtDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gridItems = new DataGridView();
            txtFilter = new TextBox();
            label1 = new Label();
            chkHKCU = new CheckBox();
            chkHKLM = new CheckBox();
            chkAllFiles = new CheckBox();
            chkDirectory = new CheckBox();
            chkBackground = new CheckBox();
            chkDrive = new CheckBox();
            chkShowDisabledOnly = new CheckBox();
            chkShowInSubmenuOnly = new CheckBox();
            chkShowStatic = new CheckBox();
            chkShowHandlers = new CheckBox();
            btnRefresh = new Button();
            btnEnable = new Button();
            btnDisable = new Button();
            btnEnsureSubmenu = new Button();
            btnMoveToSubmenu = new Button();
            btnRemoveFromSubmenu = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnBackup = new Button();
            btnRestore = new Button();
            btnRestartExplorer = new Button();
            btnOpenRegedit = new Button();
            txtDetails = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            toolStrip1 = new ToolStrip();
            newToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            printToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            cutToolStripButton = new ToolStripButton();
            copyToolStripButton = new ToolStripButton();
            pasteToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            colEnabled = new DataGridViewCheckBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colScope = new DataGridViewTextBoxColumn();
            colHive = new DataGridViewTextBoxColumn();
            colSub = new DataGridViewCheckBoxColumn();
            DisabledReason = new DataGridViewTextBoxColumn();
            colCmd = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gridItems
            // 
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.AllowUserToResizeRows = false;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colEnabled, colName, colType, colScope, colHive, colSub, DisabledReason, colCmd });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8.142858F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gridItems.DefaultCellStyle = dataGridViewCellStyle1;
            gridItems.Dock = DockStyle.Fill;
            gridItems.Location = new Point(0, 0);
            gridItems.Margin = new Padding(5, 6, 5, 6);
            gridItems.Name = "gridItems";
            gridItems.ReadOnly = true;
            gridItems.RowHeadersVisible = false;
            gridItems.RowHeadersWidth = 72;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.Size = new Size(1706, 600);
            gridItems.TabIndex = 0;
            gridItems.SelectionChanged += gridItems_SelectionChanged;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(78, 6);
            txtFilter.Margin = new Padding(5, 6, 5, 6);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(717, 35);
            txtFilter.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 30);
            label1.TabIndex = 1;
            label1.Text = "Filter:";
            // 
            // chkHKCU
            // 
            chkHKCU.AutoSize = true;
            chkHKCU.Location = new Point(805, 6);
            chkHKCU.Margin = new Padding(5, 6, 5, 6);
            chkHKCU.Name = "chkHKCU";
            chkHKCU.Size = new Size(92, 34);
            chkHKCU.TabIndex = 3;
            chkHKCU.Text = "HKCU";
            chkHKCU.UseVisualStyleBackColor = true;
            // 
            // chkHKLM
            // 
            chkHKLM.AutoSize = true;
            chkHKLM.Location = new Point(907, 6);
            chkHKLM.Margin = new Padding(5, 6, 5, 6);
            chkHKLM.Name = "chkHKLM";
            chkHKLM.Size = new Size(95, 34);
            chkHKLM.TabIndex = 4;
            chkHKLM.Text = "HKLM";
            chkHKLM.UseVisualStyleBackColor = true;
            // 
            // chkAllFiles
            // 
            chkAllFiles.AutoSize = true;
            chkAllFiles.Location = new Point(1216, 6);
            chkAllFiles.Margin = new Padding(5, 6, 5, 6);
            chkAllFiles.Name = "chkAllFiles";
            chkAllFiles.Size = new Size(103, 34);
            chkAllFiles.TabIndex = 5;
            chkAllFiles.Text = "AllFiles";
            chkAllFiles.UseVisualStyleBackColor = true;
            // 
            // chkDirectory
            // 
            chkDirectory.AutoSize = true;
            chkDirectory.Location = new Point(1329, 6);
            chkDirectory.Margin = new Padding(5, 6, 5, 6);
            chkDirectory.Name = "chkDirectory";
            chkDirectory.Size = new Size(123, 34);
            chkDirectory.TabIndex = 6;
            chkDirectory.Text = "Directory";
            chkDirectory.UseVisualStyleBackColor = true;
            // 
            // chkBackground
            // 
            chkBackground.AutoSize = true;
            chkBackground.Location = new Point(1462, 6);
            chkBackground.Margin = new Padding(5, 6, 5, 6);
            chkBackground.Name = "chkBackground";
            chkBackground.Size = new Size(149, 34);
            chkBackground.TabIndex = 7;
            chkBackground.Text = "Background";
            chkBackground.UseVisualStyleBackColor = true;
            // 
            // chkDrive
            // 
            chkDrive.AutoSize = true;
            chkDrive.Location = new Point(1621, 6);
            chkDrive.Margin = new Padding(5, 6, 5, 6);
            chkDrive.Name = "chkDrive";
            chkDrive.Size = new Size(87, 34);
            chkDrive.TabIndex = 8;
            chkDrive.Text = "Drive";
            chkDrive.UseVisualStyleBackColor = true;
            // 
            // chkShowDisabledOnly
            // 
            chkShowDisabledOnly.AutoSize = true;
            chkShowDisabledOnly.Location = new Point(1948, 6);
            chkShowDisabledOnly.Margin = new Padding(5, 6, 5, 6);
            chkShowDisabledOnly.Name = "chkShowDisabledOnly";
            chkShowDisabledOnly.Size = new Size(164, 34);
            chkShowDisabledOnly.TabIndex = 11;
            chkShowDisabledOnly.Text = "Disabled only";
            chkShowDisabledOnly.UseVisualStyleBackColor = true;
            // 
            // chkShowInSubmenuOnly
            // 
            chkShowInSubmenuOnly.AutoSize = true;
            chkShowInSubmenuOnly.Location = new Point(1012, 6);
            chkShowInSubmenuOnly.Margin = new Padding(5, 6, 5, 6);
            chkShowInSubmenuOnly.Name = "chkShowInSubmenuOnly";
            chkShowInSubmenuOnly.Size = new Size(194, 34);
            chkShowInSubmenuOnly.TabIndex = 12;
            chkShowInSubmenuOnly.Text = "In submenu only";
            chkShowInSubmenuOnly.UseVisualStyleBackColor = true;
            // 
            // chkShowStatic
            // 
            chkShowStatic.AutoSize = true;
            chkShowStatic.Location = new Point(1718, 6);
            chkShowStatic.Margin = new Padding(5, 6, 5, 6);
            chkShowStatic.Name = "chkShowStatic";
            chkShowStatic.Size = new Size(89, 34);
            chkShowStatic.TabIndex = 9;
            chkShowStatic.Text = "Static";
            chkShowStatic.UseVisualStyleBackColor = true;
            // 
            // chkShowHandlers
            // 
            chkShowHandlers.AutoSize = true;
            chkShowHandlers.Location = new Point(1817, 6);
            chkShowHandlers.Margin = new Padding(5, 6, 5, 6);
            chkShowHandlers.Name = "chkShowHandlers";
            chkShowHandlers.Size = new Size(121, 34);
            chkShowHandlers.TabIndex = 10;
            chkShowHandlers.Text = "Handlers";
            chkShowHandlers.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.Location = new Point(1232, 58);
            btnRefresh.Margin = new Padding(5, 6, 5, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(234, 40);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnEnable
            // 
            btnEnable.AutoSize = true;
            btnEnable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnable.Dock = DockStyle.Fill;
            btnEnable.Location = new Point(277, 58);
            btnEnable.Margin = new Padding(5, 6, 5, 6);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(216, 40);
            btnEnable.TabIndex = 12;
            btnEnable.Text = "Enable";
            btnEnable.Click += btnEnable_Click;
            // 
            // btnDisable
            // 
            btnDisable.AutoSize = true;
            btnDisable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDisable.Dock = DockStyle.Fill;
            btnDisable.Location = new Point(503, 58);
            btnDisable.Margin = new Padding(5, 6, 5, 6);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(241, 40);
            btnDisable.TabIndex = 11;
            btnDisable.Text = "Disable";
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEnsureSubmenu
            // 
            btnEnsureSubmenu.AutoSize = true;
            btnEnsureSubmenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnsureSubmenu.Dock = DockStyle.Fill;
            btnEnsureSubmenu.Location = new Point(754, 6);
            btnEnsureSubmenu.Margin = new Padding(5, 6, 5, 6);
            btnEnsureSubmenu.Name = "btnEnsureSubmenu";
            btnEnsureSubmenu.Size = new Size(247, 40);
            btnEnsureSubmenu.TabIndex = 10;
            btnEnsureSubmenu.Text = "Create/Ensure Submenu";
            btnEnsureSubmenu.Click += btnEnsureSubmenu_Click;
            // 
            // btnMoveToSubmenu
            // 
            btnMoveToSubmenu.AutoSize = true;
            btnMoveToSubmenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMoveToSubmenu.Dock = DockStyle.Fill;
            btnMoveToSubmenu.Location = new Point(5, 6);
            btnMoveToSubmenu.Margin = new Padding(5, 6, 5, 6);
            btnMoveToSubmenu.Name = "btnMoveToSubmenu";
            btnMoveToSubmenu.Size = new Size(262, 40);
            btnMoveToSubmenu.TabIndex = 9;
            btnMoveToSubmenu.Text = "Move to Submenu (Static)";
            btnMoveToSubmenu.Click += btnMoveToSubmenu_Click;
            // 
            // btnRemoveFromSubmenu
            // 
            btnRemoveFromSubmenu.AutoSize = true;
            btnRemoveFromSubmenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveFromSubmenu.Dock = DockStyle.Fill;
            btnRemoveFromSubmenu.Location = new Point(503, 6);
            btnRemoveFromSubmenu.Margin = new Padding(5, 6, 5, 6);
            btnRemoveFromSubmenu.Name = "btnRemoveFromSubmenu";
            btnRemoveFromSubmenu.Size = new Size(241, 40);
            btnRemoveFromSubmenu.TabIndex = 8;
            btnRemoveFromSubmenu.Text = "Remove from Submenu";
            btnRemoveFromSubmenu.Click += btnRemoveFromSubmenu_Click;
            // 
            // btnUp
            // 
            btnUp.AutoSize = true;
            btnUp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUp.Dock = DockStyle.Fill;
            btnUp.Location = new Point(1011, 58);
            btnUp.Margin = new Padding(5, 6, 5, 6);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(211, 40);
            btnUp.TabIndex = 7;
            btnUp.Text = "Submenu: Move Up";
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.AutoSize = true;
            btnDown.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDown.Dock = DockStyle.Fill;
            btnDown.Location = new Point(1232, 6);
            btnDown.Margin = new Padding(5, 6, 5, 6);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(234, 40);
            btnDown.TabIndex = 6;
            btnDown.Text = "Submenu: Move Down";
            btnDown.Click += btnDown_Click;
            // 
            // btnBackup
            // 
            btnBackup.AutoSize = true;
            btnBackup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackup.Dock = DockStyle.Fill;
            btnBackup.Location = new Point(1011, 6);
            btnBackup.Margin = new Padding(5, 6, 5, 6);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(211, 40);
            btnBackup.TabIndex = 5;
            btnBackup.Text = "Backup (REG Export)";
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.AutoSize = true;
            btnRestore.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRestore.Dock = DockStyle.Fill;
            btnRestore.Location = new Point(277, 6);
            btnRestore.Margin = new Padding(5, 6, 5, 6);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(216, 40);
            btnRestore.TabIndex = 4;
            btnRestore.Text = "Restore (REG Import)";
            btnRestore.Click += btnRestore_Click;
            // 
            // btnRestartExplorer
            // 
            btnRestartExplorer.AutoSize = true;
            btnRestartExplorer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRestartExplorer.Dock = DockStyle.Fill;
            btnRestartExplorer.Location = new Point(754, 58);
            btnRestartExplorer.Margin = new Padding(5, 6, 5, 6);
            btnRestartExplorer.Name = "btnRestartExplorer";
            btnRestartExplorer.Size = new Size(247, 40);
            btnRestartExplorer.TabIndex = 3;
            btnRestartExplorer.Text = "Restart Explorer";
            btnRestartExplorer.Click += btnRestartExplorer_Click;
            // 
            // btnOpenRegedit
            // 
            btnOpenRegedit.AutoSize = true;
            btnOpenRegedit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenRegedit.Dock = DockStyle.Fill;
            btnOpenRegedit.Location = new Point(5, 58);
            btnOpenRegedit.Margin = new Padding(5, 6, 5, 6);
            btnOpenRegedit.Name = "btnOpenRegedit";
            btnOpenRegedit.Size = new Size(262, 40);
            btnOpenRegedit.TabIndex = 2;
            btnOpenRegedit.Text = "Open in Regedit";
            btnOpenRegedit.Click += btnOpenRegedit_Click;
            // 
            // txtDetails
            // 
            txtDetails.Dock = DockStyle.Fill;
            txtDetails.Location = new Point(0, 0);
            txtDetails.Margin = new Padding(5, 6, 5, 6);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.ScrollBars = ScrollBars.Vertical;
            txtDetails.Size = new Size(454, 600);
            txtDetails.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnMoveToSubmenu, 0, 0);
            tableLayoutPanel1.Controls.Add(btnRefresh, 5, 1);
            tableLayoutPanel1.Controls.Add(btnRemoveFromSubmenu, 2, 0);
            tableLayoutPanel1.Controls.Add(btnDown, 5, 0);
            tableLayoutPanel1.Controls.Add(btnEnsureSubmenu, 3, 0);
            tableLayoutPanel1.Controls.Add(btnBackup, 4, 0);
            tableLayoutPanel1.Controls.Add(btnRestore, 1, 0);
            tableLayoutPanel1.Controls.Add(btnOpenRegedit, 0, 1);
            tableLayoutPanel1.Controls.Add(btnEnable, 1, 1);
            tableLayoutPanel1.Controls.Add(btnDisable, 2, 1);
            tableLayoutPanel1.Controls.Add(btnRestartExplorer, 3, 1);
            tableLayoutPanel1.Controls.Add(btnUp, 4, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 123);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(2289, 104);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Location = new Point(67, 251);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtDetails);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gridItems);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(2168, 602);
            splitContainer1.SplitterDistance = 456;
            splitContainer1.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtFilter);
            flowLayoutPanel1.Controls.Add(chkHKCU);
            flowLayoutPanel1.Controls.Add(chkHKLM);
            flowLayoutPanel1.Controls.Add(chkShowInSubmenuOnly);
            flowLayoutPanel1.Controls.Add(chkAllFiles);
            flowLayoutPanel1.Controls.Add(chkDirectory);
            flowLayoutPanel1.Controls.Add(chkBackground);
            flowLayoutPanel1.Controls.Add(chkDrive);
            flowLayoutPanel1.Controls.Add(chkShowStatic);
            flowLayoutPanel1.Controls.Add(chkShowHandlers);
            flowLayoutPanel1.Controls.Add(chkShowDisabledOnly);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 76);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(2289, 47);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 76);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(2289, 0);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(28, 28);
            toolStrip1.Items.AddRange(new ToolStripItem[] { newToolStripButton, openToolStripButton, saveToolStripButton, printToolStripButton, toolStripSeparator, cutToolStripButton, copyToolStripButton, pasteToolStripButton, toolStripSeparator1, helpToolStripButton });
            toolStrip1.Location = new Point(0, 38);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(2289, 38);
            toolStrip1.TabIndex = 19;
            toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = Color.Magenta;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(40, 32);
            newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(40, 32);
            openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(40, 32);
            saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Magenta;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(40, 32);
            printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 38);
            // 
            // cutToolStripButton
            // 
            cutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutToolStripButton.Image = (Image)resources.GetObject("cutToolStripButton.Image");
            cutToolStripButton.ImageTransparentColor = Color.Magenta;
            cutToolStripButton.Name = "cutToolStripButton";
            cutToolStripButton.Size = new Size(40, 32);
            cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            copyToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyToolStripButton.Image = (Image)resources.GetObject("copyToolStripButton.Image");
            copyToolStripButton.ImageTransparentColor = Color.Magenta;
            copyToolStripButton.Name = "copyToolStripButton";
            copyToolStripButton.Size = new Size(40, 32);
            copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            pasteToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pasteToolStripButton.Image = (Image)resources.GetObject("pasteToolStripButton.Image");
            pasteToolStripButton.ImageTransparentColor = Color.Magenta;
            pasteToolStripButton.Name = "pasteToolStripButton";
            pasteToolStripButton.Size = new Size(40, 32);
            pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 38);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Magenta;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(40, 32);
            helpToolStripButton.Text = "He&lp";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(2289, 38);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator2, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator3, printToolStripMenuItem, printPreviewToolStripMenuItem, toolStripSeparator4, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(62, 34);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(257, 40);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(257, 40);
            openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(254, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(257, 40);
            saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(257, 40);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(254, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(257, 40);
            printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(257, 40);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(254, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(257, 40);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator5, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator6, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(66, 34);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(252, 40);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(252, 40);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(249, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(252, 40);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(252, 40);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(252, 40);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(249, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(252, 40);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(78, 34);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(228, 40);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(228, 40);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator7, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(74, 34);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(214, 40);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(214, 40);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(214, 40);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(211, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(214, 40);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 888);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(2289, 39);
            statusStrip1.TabIndex = 21;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(206, 30);
            lblStatus.Text = "toolStripStatusLabel1";
            // 
            // colEnabled
            // 
            colEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colEnabled.DataPropertyName = "IsEnabled";
            colEnabled.HeaderText = "On";
            colEnabled.MinimumWidth = 9;
            colEnabled.Name = "colEnabled";
            colEnabled.ReadOnly = true;
            colEnabled.Width = 47;
            // 
            // colName
            // 
            colName.DataPropertyName = "DisplayName";
            colName.FillWeight = 12.5499144F;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 3;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 96;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colType.DataPropertyName = "ItemType";
            colType.HeaderText = "Type";
            colType.MinimumWidth = 9;
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 97;
            // 
            // colScope
            // 
            colScope.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colScope.DataPropertyName = "Scope";
            colScope.HeaderText = "Scope";
            colScope.MinimumWidth = 9;
            colScope.Name = "colScope";
            colScope.ReadOnly = true;
            colScope.Width = 110;
            // 
            // colHive
            // 
            colHive.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colHive.DataPropertyName = "HiveDisplay";
            colHive.HeaderText = "Hive";
            colHive.MinimumWidth = 9;
            colHive.Name = "colHive";
            colHive.ReadOnly = true;
            colHive.Width = 95;
            // 
            // colSub
            // 
            colSub.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSub.DataPropertyName = "IsInSubmenu";
            colSub.HeaderText = "In Menu";
            colSub.MinimumWidth = 9;
            colSub.Name = "colSub";
            colSub.ReadOnly = true;
            colSub.Width = 97;
            // 
            // DisabledReason
            // 
            DisabledReason.HeaderText = "Disabled Reason";
            DisabledReason.MinimumWidth = 9;
            DisabledReason.Name = "DisabledReason";
            DisabledReason.ReadOnly = true;
            DisabledReason.Width = 175;
            // 
            // colCmd
            // 
            colCmd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCmd.DataPropertyName = "Command";
            colCmd.FillWeight = 187.450043F;
            colCmd.HeaderText = "Command / CLSID";
            colCmd.MinimumWidth = 9;
            colCmd.Name = "colCmd";
            colCmd.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2289, 927);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "ContextMenuPowerTool (Win10) - Power User";
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private ToolStrip toolStrip1;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton cutToolStripButton;
        private ToolStripButton copyToolStripButton;
        private ToolStripButton pasteToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton helpToolStripButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private DataGridViewCheckBoxColumn colEnabled;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colScope;
        private DataGridViewTextBoxColumn colHive;
        private DataGridViewCheckBoxColumn colSub;
        private DataGridViewTextBoxColumn DisabledReason;
        private DataGridViewTextBoxColumn colCmd;
    }
}
