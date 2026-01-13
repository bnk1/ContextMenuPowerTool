using Microsoft.Win32;

namespace ContextMenuPowerTool.Services
{
    public static class ContextMenuEnableService
    {
        public static void Enable(ContextMenuItem item)
        {
            if (item.IsEnabled)
                return;

            switch (item.DisabledReasonCode)
            {
                case DisableReason.NameBased:
                    Enable_NameBased(item);
                    break;

                case DisableReason.LegacyDisable:
                    Enable_LegacyDisable(item);
                    break;

                case DisableReason.ProgrammaticAccessOnly:
                    Enable_ProgrammaticOnly(item);
                    break;

                case DisableReason.ShellExMinusClsid:
                    Enable_ShellExMinus(item);
                    break;

                case DisableReason.MissingCommand:
                    throw new InvalidOperationException(
                        "Cannot auto-enable: command is missing.");

                case DisableReason.BrokenComRegistration:
                    throw new InvalidOperationException(
                        "Cannot auto-enable: COM handler not registered.");

                default:
                    throw new InvalidOperationException(
                        "Unknown disable reason.");
            }
        }


        private static void Enable_NameBased(ContextMenuItem item)
        {
            using var root = item.HiveDisplay == "HKCU"        ? Registry.CurrentUser : Registry.LocalMachine;

            using var parent = root.OpenSubKey(item.BasePath, writable: true) ?? throw new InvalidOperationException("Key not found");

            string newName = item.NormalizedName;

            RegistryOperations.RenameSubKeyTree(parent, item.KeyName, newName);
        }

        private static void Enable_LegacyDisable(ContextMenuItem item)
        {
            using var root = item.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            using var key = root.OpenSubKey( item.FullKeyPath + "\\" + item.KeyName, writable: true) ?? throw new InvalidOperationException("Key not found");

            key.DeleteValue("LegacyDisable", throwOnMissingValue: false);
        }

        private static void Enable_ProgrammaticOnly(ContextMenuItem item)
        {
            using var root = item.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            using var key = root.OpenSubKey( item.FullKeyPath + "\\" + item.KeyName, writable: true) ?? throw new InvalidOperationException("Key not found");

            key.DeleteValue("ProgrammaticAccessOnly", false);
        }

        private static void Enable_ShellExMinus(ContextMenuItem item)
        {
            using var root = item.HiveDisplay == "HKCU" ? Registry.CurrentUser : Registry.LocalMachine;

            using var key = root.OpenSubKey( item.FullKeyPath + "\\" + item.KeyName, writable: true) ?? throw new InvalidOperationException("Key not found");

            key.SetValue(null, item.HandlerClsid, RegistryValueKind.String);
        }
    }
}

