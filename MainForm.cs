using Microsoft.Win32;
using System.ComponentModel;

namespace ContextMenuPowerTool
{
    public partial class MainForm : Form
    {
        private readonly RegistryContextMenuScanner _scanner = new RegistryContextMenuScanner();
        private readonly BindingList<ContextMenuItem> _items = [];
        private readonly BindingSource _bs = [];

        private readonly string _backupFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ContextMenuPowerTool_Backups");

        public MainForm()
        {
            InitializeComponent();

            _bs.DataSource = _items;
            gridItems.AutoGenerateColumns = false;
            gridItems.DataSource = _bs;

            chkHKCU.Checked = true;
            chkHKLM.Checked = true;

            chkAllFiles.Checked = true;
            chkDirectory.Checked = true;
            chkBackground.Checked = true;
            chkDrive.Checked = true;

            chkShowStatic.Checked = true;
            chkShowHandlers.Checked = true;


            txtFilter.TextChanged += (_, __) => ApplyFilter();
            chkShowDisabledOnly.CheckedChanged += (_, __) => ApplyFilter();
            chkShowInSubmenuOnly.CheckedChanged += (_, __) => ApplyFilter();
            chkShowHandlers.CheckedChanged += (_, __) => ApplyFilter();
            chkShowStatic.CheckedChanged += (_, __) => ApplyFilter();

            Shown += (_, __) => RefreshScan();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshScan();
        }

        private void RefreshScan()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                HashSet<ContextScope> scopes = GetSelectedScopes();
                bool includeUser = chkHKCU.Checked;
                bool includeMachine = chkHKLM.Checked;

                IReadOnlyList<ContextMenuItem> list = RegistryContextMenuScanner.Scan(includeUser, includeMachine, scopes);

                _items.RaiseListChangedEvents = false;
                _items.Clear();
                foreach (ContextMenuItem it in list.OrderBy(x => x.Scope).ThenBy(x => x.DisplayName, StringComparer.OrdinalIgnoreCase))
                {
                    _items.Add(it);
                }
                _items.RaiseListChangedEvents = true;
                _items.ResetBindings();

                ApplyFilter();
                lblStatus.Text = $"Items: {_items.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Scan failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private HashSet<ContextScope> GetSelectedScopes()
        {
            HashSet<ContextScope> scopes = [];

            if (chkAllFiles.Checked)
            {
                scopes.Add(ContextScope.AllFiles);
            }

            if (chkDirectory.Checked)
            {
                scopes.Add(ContextScope.Directory);
            }

            if (chkBackground.Checked)
            {
                scopes.Add(ContextScope.DirectoryBackground);
            }

            if (chkDrive.Checked)
            {
                scopes.Add(ContextScope.Drive);
            }

            if (scopes.Count == 0)
            {
                scopes.Add(ContextScope.AllFiles);
            }

            return scopes;
        }

        private void ApplyFilter()
        {
            string f = txtFilter.Text.Trim();

            IEnumerable<ContextMenuItem> view = _items;

            if (chkShowDisabledOnly.Checked)
            {
                view = view.Where(x => !x.IsEnabled);
            }

            if (chkShowInSubmenuOnly.Checked)
            {
                view = view.Where(x => x.IsInSubmenu);
            }

            bool showStatic = chkShowStatic.Checked;
            bool showHandlers = chkShowHandlers.Checked;

            view = view.Where(x =>
            {
                return x.ItemType == ContextItemType.StaticCommand && showStatic || x.ItemType == ContextItemType.ShellExtensionHandler && showHandlers;
            });

            if (!string.IsNullOrWhiteSpace(f))
            {
                view = view.Where(x =>
                    x.DisplayName.Contains(f, StringComparison.OrdinalIgnoreCase) ||
                    x.KeyName.Contains(f, StringComparison.OrdinalIgnoreCase) ||
                    (x.Command?.Contains(f, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (x.HandlerClsid?.Contains(f, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            _bs.DataSource = view.ToList();
            lblStatus.Text = $"Shown: {((List<ContextMenuItem>)_bs.DataSource).Count} / Total: {_items.Count}";
        }

        private List<ContextMenuItem> SelectedItems()
        {
            List<ContextMenuItem> sel = [];
            foreach (DataGridViewRow row in gridItems.SelectedRows)
            {
                if (row.DataBoundItem is ContextMenuItem it)
                {
                    sel.Add(it);
                }
            }

            return sel;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            ToggleEnable(true);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            ToggleEnable(false);
        }

        private void ToggleEnable(bool enable)
        {
            List<ContextMenuItem> sel = SelectedItems();
            if (sel.Count == 0)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                foreach (ContextMenuItem it in sel)
                {
                    if (enable && it.IsEnabled)
                    {
                        continue;
                    }

                    if (!enable && !it.IsEnabled)
                    {
                        continue;
                    }

                    ToggleItemEnable(it, enable);
                    it.IsEnabled = enable;
                }

                RefreshScan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Enable/Disable failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void ToggleItemEnable(ContextMenuItem it, bool enable)
        {
            RegistryKey root = it.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            // parent path for rename is the container (shell or handlers)
            string parentPath = it.FullKeyPath;
            int lastSep = parentPath.LastIndexOf('\\');
            if (lastSep <= 0)
            {
                throw new InvalidOperationException("Unexpected registry path format.");
            }

            string containerPath = parentPath;
            using RegistryKey? container = root.OpenSubKey(containerPath, true) ?? throw new InvalidOperationException($"Cannot open: {it.HiveDisplay}\\{containerPath}");

            string currentName = it.KeyName;
            string normalized = RegistryOperations.StripDisabledMarkers(currentName);

            if (enable)
            {
                string targetName = normalized;
                if (string.Equals(currentName, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                RegistryOperations.RenameSubKeyTree(container, currentName, targetName);
                it.KeyName = targetName;
                it.NormalizedName = targetName;
            }
            else
            {
                string targetName = "_" + normalized + ".disabled";
                if (string.Equals(currentName, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                RegistryOperations.RenameSubKeyTree(container, currentName, targetName);
                it.KeyName = targetName;
                it.NormalizedName = normalized;
            }
        }

        private void btnEnsureSubmenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                EnsureSubmenuExistsForSelectedScopes();
                RefreshScan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Create submenu failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void EnsureSubmenuExistsForSelectedScopes()
        {
            HashSet<ContextScope> scopes = GetSelectedScopes();
            bool doHKCU = chkHKCU.Checked;
            bool doHKLM = chkHKLM.Checked;

            if (doHKCU)
                EnsureSubmenuExistsForHive(Registry.CurrentUser, @"Software\Classes", scopes);

            if (doHKLM)
                EnsureSubmenuExistsForHive(Registry.LocalMachine, @"Software\Classes", scopes);
        }

        private static void EnsureSubmenuExistsForHive(RegistryKey hive, string classesBase, HashSet<ContextScope> scopes)
        {
            foreach (ContextScope scope in scopes)
            {
                string scopeRoot = RegistryContextMenuScanner.GetScopeRootRelativeToClasses(scope);
                string submenuPath = $"{classesBase}\\{scopeRoot}\\shell\\{RegistryContextMenuScanner.SubmenuKeyName}";
                using RegistryKey submenu = hive.CreateSubKey(submenuPath, true)
                    ?? throw new InvalidOperationException($"Failed to create: {submenuPath}");

                RegistryOperations.SetStringValue(submenu, "MUIVerb", RegistryContextMenuScanner.SubmenuDisplayName);
                RegistryOperations.SetStringValue(submenu, "SubCommands", "");

                using RegistryKey shell = submenu.CreateSubKey("shell", true)
                    ?? throw new InvalidOperationException("Failed to create submenu shell.");
            }
        }

        private void btnMoveToSubmenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                EnsureSubmenuExistsForSelectedScopes();
                List<ContextMenuItem> sel = SelectedItems();
                if (sel.Count == 0)
                {
                    return;
                }

                foreach (ContextMenuItem it in sel)
                {
                    if (it.ItemType != ContextItemType.StaticCommand)
                    {
                        continue;
                    }

                    if (!it.IsEnabled)
                    {
                        continue;
                    }

                    MoveStaticItemToSubmenu(it);
                }

                RefreshScan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Move to submenu failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void MoveStaticItemToSubmenu(ContextMenuItem it)
        {
            if (string.IsNullOrWhiteSpace(it.Command))
            {
                throw new InvalidOperationException($"Item has no command: {it.DisplayName}");
            }

            RegistryKey root = it.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;
            string classesBase = @"Software\Classes";
            string scopeRoot = RegistryContextMenuScanner.GetScopeRootRelativeToClasses(it.Scope);

            string submenuShellPath = $"{classesBase}\\{scopeRoot}\\shell\\{RegistryContextMenuScanner.SubmenuKeyName}\\shell";
            using RegistryKey submenuShell = root.OpenSubKey(submenuShellPath, true)
                ?? throw new InvalidOperationException($"Cannot open submenu shell: {submenuShellPath}");

            int nextOrder = FindNextOrderPrefix(submenuShell);
            string safeName = RegistryOperations.MakeSafeKeyName(it.NormalizedName);
            string newKeyName = $"{nextOrder:000}_{safeName}";

            using RegistryKey newItem = submenuShell.CreateSubKey(newKeyName, true)
                ?? throw new InvalidOperationException($"Cannot create submenu item: {newKeyName}");

            RegistryOperations.SetStringValue(newItem, "MUIVerb", it.DisplayName);
            if (!string.IsNullOrWhiteSpace(it.Icon))
            {
                RegistryOperations.SetStringValue(newItem, "Icon", it.Icon!);
            }

            using RegistryKey cmd = newItem.CreateSubKey("command", true)
                ?? throw new InvalidOperationException("Cannot create command key.");
            RegistryOperations.SetStringValue(cmd, null, it.Command!);

            // Disable original (so it disappears from root menu)
            ToggleItemEnable(it, enable: false);
        }

        private static int FindNextOrderPrefix(RegistryKey submenuShell)
        {
            int max = 0;
            foreach (string name in submenuShell.GetSubKeyNames())
            {
                int idx = name.IndexOf('_');
                if (idx > 0)
                {
                    string prefix = name[..idx];
                    if (int.TryParse(prefix, out int p))
                    {
                        max = Math.Max(max, p);
                    }
                }
            }

            return max + 10;
        }

        private void btnRemoveFromSubmenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                List<ContextMenuItem> sel = SelectedItems();
                if (sel.Count == 0)
                {
                    return;
                }

                foreach (ContextMenuItem it in sel)
                {
                    if (it.ItemType != ContextItemType.StaticCommand)
                    {
                        continue;
                    }

                    RemoveStaticItemFromSubmenu(it);
                }

                RefreshScan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Remove from submenu failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void RemoveStaticItemFromSubmenu(ContextMenuItem it)
        {
            RegistryKey root = it.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;
            string classesBase = @"Software\Classes";
            string scopeRoot = RegistryContextMenuScanner.GetScopeRootRelativeToClasses(it.Scope);

            string submenuShellPath = $"{classesBase}\\{scopeRoot}\\shell\\{RegistryContextMenuScanner.SubmenuKeyName}\\shell";
            using RegistryKey submenuShell = root.OpenSubKey(submenuShellPath, true)
                ?? throw new InvalidOperationException($"Cannot open submenu shell: {submenuShellPath}");

            string safeName = RegistryOperations.MakeSafeKeyName(it.NormalizedName);
            string? foundKey = submenuShell.GetSubKeyNames()
                .FirstOrDefault(k => string.Equals(RegistryContextMenuScanner.StripOrderPrefix(k), safeName, StringComparison.OrdinalIgnoreCase));

            if (foundKey != null)
            {
                submenuShell.DeleteSubKeyTree(foundKey, false);
            }

            // Re-enable original if it exists disabled in the root container.
            // We look for "_" + normalized + ".disabled" in the real shell container.
            string shellPath = $"{classesBase}\\{scopeRoot}\\shell";
            using RegistryKey? shell = root.OpenSubKey(shellPath, true);
            if (shell != null)
            {
                string disabled = "_" + it.NormalizedName + ".disabled";
                if (shell.OpenSubKey(disabled) != null)
                {
                    RegistryOperations.RenameSubKeyTree(shell, disabled, it.NormalizedName);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSubmenuOrder(-1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSubmenuOrder(+1);
        }

        private void MoveSubmenuOrder(int direction)
        {
            List<ContextMenuItem> sel = SelectedItems();
            if (sel.Count != 1)
            {
                MessageBox.Show(this, "Select exactly one item (in submenu) to reorder.", "Reorder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ContextMenuItem it = sel[0];
            if (!it.IsInSubmenu)
            {
                MessageBox.Show(this, "This item is not in the submenu.", "Reorder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RegistryKey root = it.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;
            string classesBase = @"Software\Classes";
            string scopeRoot = RegistryContextMenuScanner.GetScopeRootRelativeToClasses(it.Scope);

            string submenuShellPath = $"{classesBase}\\{scopeRoot}\\shell\\{RegistryContextMenuScanner.SubmenuKeyName}\\shell";
            using RegistryKey submenuShell = root.OpenSubKey(submenuShellPath, true)
                ?? throw new InvalidOperationException($"Cannot open submenu shell: {submenuShellPath}");

            string safeName = RegistryOperations.MakeSafeKeyName(it.NormalizedName);

            List<string> keys = [.. submenuShell.GetSubKeyNames().OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];

            int idx = keys.FindIndex(k => string.Equals(RegistryContextMenuScanner.StripOrderPrefix(k), safeName, StringComparison.OrdinalIgnoreCase));
            if (idx < 0)
            {
                return;
            }

            int swapIdx = idx + direction;
            if (swapIdx < 0 || swapIdx >= keys.Count)
            {
                return;
            }

            string a = keys[idx];
            string b = keys[swapIdx];

            // Swap order prefixes by renaming both through temp key to avoid collisions
            string temp = "999_TEMP_SWAP_" + Guid.NewGuid().ToString("N");

            RegistryOperations.RenameSubKeyTree(submenuShell, a, temp);
            RegistryOperations.RenameSubKeyTree(submenuShell, b, a);
            RegistryOperations.RenameSubKeyTree(submenuShell, temp, b);

            RefreshScan();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                BackupService backup = new BackupService(_backupFolder);
                string file = backup.ExportRegistrySnapshot();
                MessageBox.Show(this, $"Backup created:\r\n{file}", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Backup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Registry backup (*.reg)|*.reg|All files (*.*)|*.*";
            ofd.InitialDirectory = _backupFolder;

            if (ofd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                BackupService backup = new BackupService(_backupFolder);
                BackupService.ImportRegistrySnapshot(ofd.FileName);
                ExplorerService.RestartExplorer();
                RefreshScan();
                MessageBox.Show(this, "Restore complete (Explorer restarted).", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Restore failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRestartExplorer_Click(object sender, EventArgs e)
        {
            ExplorerService.RestartExplorer();
        }

        private void btnOpenRegedit_Click(object sender, EventArgs e)
        {
            List<ContextMenuItem> sel = SelectedItems();
            if (sel.Count != 1)
            {
                return;
            }

            ExplorerService.OpenRegeditAt(sel[0].HiveDisplay, sel[0].FullKeyPath);
        }

        private void gridItems_SelectionChanged(object sender, EventArgs e)
        {
            List<ContextMenuItem> sel = SelectedItems();
            if (sel.Count == 1)
            {
                ContextMenuItem it = sel[0];
                txtDetails.Text = BuildDetails(it);
            }
            else
            {
                txtDetails.Text = "";
            }
        }

        private static string BuildDetails(ContextMenuItem it)
        {
            return
                $"Name: {it.DisplayName}\r\n" +
                $"Type: {it.ItemType}\r\n" +
                $"Scope: {it.Scope}\r\n" +
                $"Hive: {it.HiveDisplay}\r\n" +
                $"Enabled: {it.IsEnabled}\r\n" +
                $"In Submenu: {it.IsInSubmenu}\r\n" +
                $"Extended: {it.IsExtended}\r\n" +
                $"KeyName: {it.KeyName}\r\n" +
                $"Path: {it.HiveDisplay}\\{it.FullKeyPath}\\{it.KeyName}\r\n" +
                $"Command: {it.Command}\r\n" +
                $"Handler CLSID: {it.HandlerClsid}\r\n" +
                $"Icon: {it.Icon}\r\n" + 
                $"Disabled Reason: {it.DisabledReason}\r\n";
        }
    }
}
