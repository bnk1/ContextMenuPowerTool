using Microsoft.Win32;

namespace ContextMenuPowerTool
{
	public sealed class RegistryContextMenuScanner
	{
		public const string SubmenuKeyName = "PowerMenuManager";
		public const string SubmenuDisplayName = "Power Menu";

		public static IReadOnlyList<ContextMenuItem> Scan(bool includeUserHive, bool includeMachineHive, HashSet<ContextScope> scopes)
		{
			List<ContextMenuItem> items = [];

			if (includeUserHive)
				ScanHive(items, Registry.CurrentUser, @"Software\Classes", "HKCU", includeUserHive: true, includeMachineHive: false, scopes: scopes);

			if (includeMachineHive)
				ScanHive(items, Registry.LocalMachine, @"Software\Classes", "HKLM", includeUserHive: false, includeMachineHive: true, scopes: scopes);

			return items;
		}

		private static void ScanHive(List<ContextMenuItem> items, RegistryKey hiveRoot, string classesBase, string hiveDisplay, bool includeUserHive, bool includeMachineHive, HashSet<ContextScope> scopes)
		{
			foreach (ContextScope scope in scopes)
			{
				string scopeRoot = GetScopeRootRelativeToClasses(scope);

				string shellPath = $"{classesBase}\\{scopeRoot}\\shell";
				string shellexPath = $"{classesBase}\\{scopeRoot}\\shellex\\ContextMenuHandlers";

				using RegistryKey? shellKey = hiveRoot.OpenSubKey(shellPath, false);
				if (shellKey != null)
					ScanStaticShell(items, hiveDisplay, includeUserHive, includeMachineHive, shellKey, shellPath, scope);

				using RegistryKey? shellexKey = hiveRoot.OpenSubKey(shellexPath, false);
				if (shellexKey != null)
					ScanShellExHandlers(items, hiveDisplay, includeUserHive, includeMachineHive, shellexKey, shellexPath, scope);

				string submenuShellPath = $"{classesBase}\\{scopeRoot}\\shell\\{SubmenuKeyName}\\shell";
				using RegistryKey? submenuShellKey = hiveRoot.OpenSubKey(submenuShellPath, false);
				if (submenuShellKey != null)
					MarkSubmenuMembership(items, submenuShellKey, hiveDisplay, scope);
			}
		}

		private static void ScanStaticShell(List<ContextMenuItem> items, string hiveDisplay, bool includeUserHive, bool includeMachineHive, RegistryKey shellKey, string shellPath, ContextScope scope)
		{
			foreach (string subName in RegistryKeyUtil.SafeGetSubKeyNames(shellKey))
			{
				if (string.Equals(subName, SubmenuKeyName, StringComparison.OrdinalIgnoreCase))
					continue;

				using RegistryKey? itemKey = shellKey.OpenSubKey(subName, false);
				if (itemKey == null)
					continue;

				string? muiVerb = RegistryKeyUtil.SafeGetString(itemKey, "MUIVerb");
				string? defaultName = RegistryKeyUtil.SafeGetString(itemKey, null);
				string display = !string.IsNullOrWhiteSpace(muiVerb) ? muiVerb! : !string.IsNullOrWhiteSpace(defaultName) ? defaultName! : subName;
				
				bool nameDisabled = RegistryOperations.IsDisabledKeyName(subName);	// Disabled via key name
                bool legacyDisable = false;                                         // Disabled via "LegacyDisable" value
                bool programmaticOnly = false;                                      // Disabled via "ProgrammaticAccessOnly" value

                try
				{
					legacyDisable = itemKey.GetValue("LegacyDisable") != null;
					programmaticOnly = itemKey.GetValue("ProgrammaticAccessOnly") != null;
				}
				catch 
				{ 
				}

                bool isExtended = false;
				try
				{
					isExtended = itemKey.GetValue("Extended") != null;
				}
				catch
				{
				}

				string? icon = RegistryKeyUtil.SafeGetString(itemKey, "Icon");

				string? command = null;												// Disabed if no command found

                using (RegistryKey? cmdKey = itemKey.OpenSubKey("command", false))
				{
					if (cmdKey != null)
						command = RegistryKeyUtil.SafeGetString(cmdKey, null);
				}

                bool hasCommand = !string.IsNullOrWhiteSpace(command);

                bool effectivelyDisabled = nameDisabled || legacyDisable || programmaticOnly || !hasCommand;

                string? disabledReason = null;
                DisableReason disableCode = DisableReason.None;

				if (nameDisabled)
				{
					disableCode = DisableReason.NameBased;
					disabledReason = "Disabled by key name";
				}
				else if (legacyDisable)
				{
					disableCode = DisableReason.LegacyDisable;
					disabledReason = "LegacyDisable value present";
				}
				else if (programmaticOnly)
				{
					disableCode = DisableReason.ProgrammaticAccessOnly;
					disabledReason = "ProgrammaticAccessOnly";
				}
				else if (!hasCommand)
				{
					disableCode = DisableReason.MissingCommand;
                    disabledReason = "Missing command";
                }

                items.Add(new ContextMenuItem
				{
					DisplayName        = display,
					KeyName            = subName,
					NormalizedName     = RegistryOperations.StripDisabledMarkers(subName),
					IsEnabled          = !effectivelyDisabled,
					IsInSubmenu        = false,
					Scope              = scope,
					ItemType           = ContextItemType.StaticCommand,
					FromUserHive       = includeUserHive,
					FromMachineHive    = includeMachineHive,
					HiveDisplay        = hiveDisplay,
					BasePath           = shellPath,
					FullKeyPath        = shellPath,
					Command            = command,
					Icon               = icon,
					HandlerClsid       = null,
					IsExtended         = isExtended,
					DisabledReasonCode  = disableCode,
                    DisabledReasonText = disabledReason
                });
			}
		}

		private static void ScanShellExHandlers(List<ContextMenuItem> items, string hiveDisplay, bool includeUserHive, bool includeMachineHive, RegistryKey handlersKey, string handlersPath, ContextScope scope)
		{
			foreach (string subName in RegistryKeyUtil.SafeGetSubKeyNames(handlersKey))
			{
				using RegistryKey? itemKey = handlersKey.OpenSubKey(subName, false);

				if (itemKey == null)
					continue;

                string rawClsid = RegistryKeyUtil.SafeGetString(itemKey, null) ?? "";

                bool minusDisabled = rawClsid.StartsWith('-');
                string clsid = rawClsid.TrimStart('-').Trim();

                bool brokenClsid = false;

                if (!string.IsNullOrWhiteSpace(clsid))
                {
                    using var inproc = Registry.ClassesRoot.OpenSubKey($@"CLSID\{clsid}\InprocServer32");
                    brokenClsid = inproc == null || inproc.GetValue(null) == null;
                }

                // FINAL effective rule
                bool effectivelyDisabled = minusDisabled || brokenClsid;

                string? disabledReason = null;
                DisableReason disableCode = DisableReason.None;

                if (minusDisabled)
				{
					disableCode = DisableReason.ShellExMinusClsid;
                    disabledReason = "CLSID prefixed with '-' (ShellExView/EcMenu)";
				}
				else if (brokenClsid)
				{
					disableCode = DisableReason.BrokenComRegistration;
                    disabledReason = "COM handler not registered";
				}

                items.Add(new ContextMenuItem
				{
					DisplayName = subName,
					KeyName = subName,
					NormalizedName = RegistryOperations.StripDisabledMarkers(subName),
					IsEnabled = !effectivelyDisabled,
					IsInSubmenu = false,
					Scope = scope,
					ItemType = ContextItemType.ShellExtensionHandler,
					FromUserHive = includeUserHive,
					FromMachineHive = includeMachineHive,
					HiveDisplay = hiveDisplay,
					BasePath = handlersPath,
					FullKeyPath = handlersPath,
					Command = null,
					Icon = null,
					HandlerClsid = clsid,
					IsExtended = false,
					DisabledReasonCode = disableCode,
                    DisabledReasonText = disabledReason	
                });
			}
		}

		private static void MarkSubmenuMembership(List<ContextMenuItem> items, RegistryKey submenuShellKey, string hiveDisplay, ContextScope scope)
		{
			HashSet<string> submenuItems = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

			foreach (string sub in RegistryKeyUtil.SafeGetSubKeyNames(submenuShellKey))
			{
				submenuItems.Add(sub);
			}

			foreach (ContextMenuItem item in items)
			{
				if (item.HiveDisplay != hiveDisplay)
					continue;

				if (item.Scope != scope)
					continue;

				if (item.ItemType != ContextItemType.StaticCommand)
					continue;

				foreach (string sub in submenuItems)
				{
					string normalized = StripOrderPrefix(sub);
					if (string.Equals(normalized, RegistryOperations.MakeSafeKeyName(item.NormalizedName), StringComparison.OrdinalIgnoreCase))
					{
						item.IsInSubmenu = true;
						break;
					}
				}
			}
		}

		public static string GetScopeRootRelativeToClasses(ContextScope scope)
		{
			return scope switch
			{
				ContextScope.AllFiles => @"*",
				ContextScope.Directory => @"Directory",
				ContextScope.DirectoryBackground => @"Directory\Background",
				ContextScope.Drive => @"Drive",
				_ => @"*"
			};
		}

		public static string StripOrderPrefix(string keyName)
		{
			int idx = keyName.IndexOf('_');
			if (idx > 0 && idx <= 4)
			{
				string prefix = keyName[..idx];
				if (int.TryParse(prefix, out _))
					return keyName[(idx + 1)..];
			}

			return keyName;
		}

		public static void ScanSingle(ContextMenuItem item)
		{
			switch (item.ItemType)
			{
				case ContextItemType.StaticCommand:
					ScanSingle_Static(item);
					break;

				case ContextItemType.ShellExtensionHandler:
					ScanSingle_ShellEx(item);
					break;
			}
		}

		private static void ScanSingle_Static(ContextMenuItem item)
        {
            RegistryKey root = item.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            using var key = root.OpenSubKey( $"{item.BasePath}\\{item.KeyName}", writable: false);

            if (key == null)
            {
                // Key gone → item effectively removed
                item.IsEnabled = false;
                item.DisabledReasonCode = DisableReason.NameBased;
                item.DisabledReasonText = "Registry key not found";
                return;
            }

            bool nameDisabled = RegistryOperations.IsDisabledKeyName(item.KeyName);

            bool legacyDisable = key.GetValue("LegacyDisable") != null;
            bool programmaticOnly = key.GetValue("ProgrammaticAccessOnly") != null;

            string? command = null;
            using (var cmd = key.OpenSubKey("command"))
                command = cmd?.GetValue(null)?.ToString();

            bool hasCommand = !string.IsNullOrWhiteSpace(command);

            DisableReason reason = DisableReason.None;

            if (nameDisabled)
                reason = DisableReason.NameBased;
            else if (legacyDisable)
                reason = DisableReason.LegacyDisable;
            else if (programmaticOnly)
                reason = DisableReason.ProgrammaticAccessOnly;
            else if (!hasCommand)
                reason = DisableReason.MissingCommand;

            item.IsEnabled = reason == DisableReason.None;
            item.DisabledReasonCode = reason;
            item.DisabledReasonText = reason == DisableReason.None ? null : reason.ToString();
        }

        private static void ScanSingle_ShellEx(ContextMenuItem item)
        {
            RegistryKey root = item.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            using var key = root.OpenSubKey( $"{item.BasePath}\\{item.KeyName}", writable: false);

            if (key == null)
            {
                item.IsEnabled = false;
                item.DisabledReasonCode = DisableReason.ShellExMinusClsid;
                item.DisabledReasonText = "Handler key not found";
                return;
            }

            string raw = key.GetValue(null)?.ToString() ?? "";
            bool minus = raw.StartsWith('-');
            string clsid = raw.TrimStart('-').Trim();

            bool broken = false;
            if (!string.IsNullOrWhiteSpace(clsid))
            {
                using var inproc = Registry.ClassesRoot.OpenSubKey($@"CLSID\{clsid}\InprocServer32");
                broken = inproc == null || inproc.GetValue(null) == null;
            }

            DisableReason reason = DisableReason.None;

            if (minus)
                reason = DisableReason.ShellExMinusClsid;
            else if (broken)
                reason = DisableReason.BrokenComRegistration;

            item.IsEnabled = reason == DisableReason.None;
            item.DisabledReasonCode = reason;
            item.DisabledReasonText = reason == DisableReason.None ? null : reason.ToString();
        }

    }
}

