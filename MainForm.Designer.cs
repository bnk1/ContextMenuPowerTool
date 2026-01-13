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
        private System.Windows.Forms.Label lblStatus;

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
            lblStatus = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            colEnabled = new DataGridViewCheckBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colScope = new DataGridViewTextBoxColumn();
            colHive = new DataGridViewTextBoxColumn();
            colSub = new DataGridViewCheckBoxColumn();
            colCmd = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gridItems
            // 
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.AllowUserToResizeRows = false;
            gridItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colEnabled, colName, colType, colScope, colHive, colSub, colCmd });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8.142858F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gridItems.DefaultCellStyle = dataGridViewCellStyle1;
            gridItems.Location = new Point(21, 144);
            gridItems.Margin = new Padding(5, 6, 5, 6);
            gridItems.Name = "gridItems";
            gridItems.ReadOnly = true;
            gridItems.RowHeadersVisible = false;
            gridItems.RowHeadersWidth = 72;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.Size = new Size(1680, 1280);
            gridItems.TabIndex = 0;
            gridItems.SelectionChanged += gridItems_SelectionChanged;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(94, 18);
            txtFilter.Margin = new Padding(5, 6, 5, 6);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(717, 35);
            txtFilter.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 30);
            label1.TabIndex = 1;
            label1.Text = "Filter:";
            // 
            // chkHKCU
            // 
            chkHKCU.AutoSize = true;
            chkHKCU.Location = new Point(857, 22);
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
            chkHKLM.Location = new Point(969, 22);
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
            chkAllFiles.Location = new Point(21, 80);
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
            chkDirectory.Location = new Point(146, 80);
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
            chkBackground.Location = new Point(291, 80);
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
            chkDrive.Location = new Point(471, 80);
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
            chkShowDisabledOnly.Location = new Point(857, 80);
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
            chkShowInSubmenuOnly.Location = new Point(1054, 80);
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
            chkShowStatic.Location = new Point(600, 80);
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
            chkShowHandlers.Location = new Point(703, 80);
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
            btnRefresh.Location = new Point(5, 578);
            btnRefresh.Margin = new Padding(5, 6, 5, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(92, 40);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnEnable
            // 
            btnEnable.AutoSize = true;
            btnEnable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnable.Location = new Point(5, 318);
            btnEnable.Margin = new Padding(5, 6, 5, 6);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(85, 40);
            btnEnable.TabIndex = 12;
            btnEnable.Text = "Enable";
            btnEnable.Click += btnEnable_Click;
            // 
            // btnDisable
            // 
            btnDisable.AutoSize = true;
            btnDisable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDisable.Location = new Point(5, 526);
            btnDisable.Margin = new Padding(5, 6, 5, 6);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(91, 40);
            btnDisable.TabIndex = 11;
            btnDisable.Text = "Disable";
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEnsureSubmenu
            // 
            btnEnsureSubmenu.AutoSize = true;
            btnEnsureSubmenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnsureSubmenu.Location = new Point(5, 110);
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
            btnRemoveFromSubmenu.Location = new Point(5, 58);
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
            btnUp.Location = new Point(5, 162);
            btnUp.Margin = new Padding(5, 6, 5, 6);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(206, 40);
            btnUp.TabIndex = 7;
            btnUp.Text = "Submenu: Move Up";
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.AutoSize = true;
            btnDown.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDown.Location = new Point(5, 266);
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
            btnBackup.Location = new Point(5, 214);
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
            btnRestore.Location = new Point(5, 370);
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
            btnRestartExplorer.Location = new Point(5, 422);
            btnRestartExplorer.Margin = new Padding(5, 6, 5, 6);
            btnRestartExplorer.Name = "btnRestartExplorer";
            btnRestartExplorer.Size = new Size(168, 40);
            btnRestartExplorer.TabIndex = 3;
            btnRestartExplorer.Text = "Restart Explorer";
            btnRestartExplorer.Click += btnRestartExplorer_Click;
            // 
            // btnOpenRegedit
            // 
            btnOpenRegedit.AutoSize = true;
            btnOpenRegedit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenRegedit.Location = new Point(5, 474);
            btnOpenRegedit.Margin = new Padding(5, 6, 5, 6);
            btnOpenRegedit.Name = "btnOpenRegedit";
            btnOpenRegedit.Size = new Size(173, 40);
            btnOpenRegedit.TabIndex = 2;
            btnOpenRegedit.Text = "Open in Regedit";
            btnOpenRegedit.Click += btnOpenRegedit_Click;
            // 
            // txtDetails
            // 
            txtDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtDetails.Location = new Point(1731, 860);
            txtDetails.Margin = new Padding(5, 6, 5, 6);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.ScrollBars = ScrollBars.Vertical;
            txtDetails.Size = new Size(700, 560);
            txtDetails.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(1303, 24);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 30);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnMoveToSubmenu);
            flowLayoutPanel1.Controls.Add(btnRemoveFromSubmenu);
            flowLayoutPanel1.Controls.Add(btnEnsureSubmenu);
            flowLayoutPanel1.Controls.Add(btnUp);
            flowLayoutPanel1.Controls.Add(btnBackup);
            flowLayoutPanel1.Controls.Add(btnDown);
            flowLayoutPanel1.Controls.Add(btnEnable);
            flowLayoutPanel1.Controls.Add(btnRestore);
            flowLayoutPanel1.Controls.Add(btnRestartExplorer);
            flowLayoutPanel1.Controls.Add(btnOpenRegedit);
            flowLayoutPanel1.Controls.Add(btnDisable);
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(1731, 154);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(272, 624);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // colEnabled
            // 
            colEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colEnabled.DataPropertyName = "IsEnabled";
            colEnabled.HeaderText = "On";
            colEnabled.MinimumWidth = 9;
            colEnabled.Name = "colEnabled";
            colEnabled.ReadOnly = true;
            colEnabled.Width = 47;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colName.DataPropertyName = "DisplayName";
            colName.HeaderText = "Name";
            colName.MinimumWidth = 3;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 110;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            colType.DataPropertyName = "ItemType";
            colType.HeaderText = "Type";
            colType.MinimumWidth = 9;
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 9;
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
            colHive.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
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
            // colCmd
            // 
            colCmd.DataPropertyName = "Command";
            colCmd.HeaderText = "Command / CLSID";
            colCmd.MinimumWidth = 9;
            colCmd.Name = "colCmd";
            colCmd.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2460, 1448);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblStatus);
            Controls.Add(txtDetails);
            Controls.Add(chkShowInSubmenuOnly);
            Controls.Add(chkShowDisabledOnly);
            Controls.Add(chkShowHandlers);
            Controls.Add(chkShowStatic);
            Controls.Add(chkDrive);
            Controls.Add(chkBackground);
            Controls.Add(chkDirectory);
            Controls.Add(chkAllFiles);
            Controls.Add(chkHKLM);
            Controls.Add(chkHKCU);
            Controls.Add(txtFilter);
            Controls.Add(label1);
            Controls.Add(gridItems);
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "ContextMenuPowerTool (Win10) - Power User";
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewCheckBoxColumn colEnabled;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colScope;
        private DataGridViewTextBoxColumn colHive;
        private DataGridViewCheckBoxColumn colSub;
        private DataGridViewTextBoxColumn colCmd;
    }
}
