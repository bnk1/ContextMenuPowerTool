
namespace ContextMenuPowerTool
{
    public sealed class ContextMenuItem
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public required string DisplayName { get; set; }
        public required string KeyName { get; set; }              // actual registry subkey name (may include disabled marker/prefix)
        public required string NormalizedName { get; set; }       // stripped name (no prefix markers)
        public required bool IsEnabled { get; set; }
        public required bool IsInSubmenu { get; set; }
        public required ContextScope Scope { get; init; }
        public required ContextItemType ItemType { get; init; }

        public required bool FromUserHive { get; init; }          // HKCU\Software\Classes
        public required bool FromMachineHive { get; init; }        // HKLM\Software\Classes

        public required string HiveDisplay { get; init; }         // "HKCU" / "HKLM"
        public required string BasePath { get; init; }            // e.g. @"Software\Classes\*\shell"
        public required string FullKeyPath { get; init; }         // full path under hive
        public string? Command { get; set; }
        public string? Icon { get; set; }
        public string? HandlerClsid { get; set; }                 // for shellex handlers
        public bool IsExtended { get; set; }                      // Shift+RightClick only

        public override string ToString()
        {
            return $"{DisplayName} ({HiveDisplay}\\{FullKeyPath})";
        }
    }
}
