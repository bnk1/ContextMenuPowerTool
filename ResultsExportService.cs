using System.Text;

namespace ContextMenuPowerTool
{
    /// <summary>
    /// Writes the current scan results to a file the user can share.
    /// Format is chosen from the file extension: ".csv" produces a spreadsheet-friendly
    /// table, anything else produces a readable plain-text report.
    /// </summary>
    public static class ResultsExportService
    {
        public static void Export(
            string path,
            IReadOnlyList<ContextMenuItem> items,
            IReadOnlyCollection<ContextScope> scopes,
            bool includeUserHive,
            bool includeMachineHive)
        {
            bool asCsv = Path.GetExtension(path).Equals(".csv", StringComparison.OrdinalIgnoreCase);

            string content = asCsv
                ? BuildCsv(items)
                : BuildTextReport(items, scopes, includeUserHive, includeMachineHive);

            // UTF-8 with BOM so Excel opens non-ASCII names correctly.
            File.WriteAllText(path, content, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
        }

        private static string BuildCsv(IReadOnlyList<ContextMenuItem> items)
        {
            string[] headers =
            [
                "DisplayName", "Type", "Scope", "Hive", "Enabled", "InSubmenu", "Extended",
                "KeyName", "FullPath", "Command", "HandlerClsid", "HandlerName",
                "HandlerModule", "Icon", "DisabledReasonCode", "DisabledReason"
            ];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(",", headers));

            foreach (ContextMenuItem it in items)
            {
                string[] fields =
                [
                    it.DisplayName,
                    it.ItemType.ToString(),
                    it.Scope.ToString(),
                    it.HiveDisplay,
                    it.IsEnabled ? "Enabled" : "Disabled",
                    it.IsInSubmenu ? "Yes" : "No",
                    it.IsExtended ? "Yes" : "No",
                    it.KeyName,
                    $"{it.HiveDisplay}\\{it.FullKeyPath}\\{it.KeyName}",
                    it.Command ?? "",
                    it.HandlerClsid ?? "",
                    it.FriendlyName ?? "",
                    it.HandlerModule ?? "",
                    it.Icon ?? "",
                    it.DisabledReasonCode.ToString(),
                    it.DisabledReasonText ?? ""
                ];

                sb.AppendLine(string.Join(",", fields.Select(CsvEscape)));
            }

            return sb.ToString();
        }

        private static string CsvEscape(string value)
        {
            if (value.Contains('"') || value.Contains(',') || value.Contains('\n') || value.Contains('\r'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private static string BuildTextReport(
            IReadOnlyList<ContextMenuItem> items,
            IReadOnlyCollection<ContextScope> scopes,
            bool includeUserHive,
            bool includeMachineHive)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Context Menu Power Tool - Scan Report");
            sb.AppendLine("=====================================");
            sb.AppendLine($"Generated : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"Machine   : {Environment.MachineName}");
            sb.AppendLine($"OS        : {Environment.OSVersion}");
            sb.AppendLine($"User      : {Environment.UserName}");
            sb.AppendLine();

            string hives = string.Join(", ",
                new[] { includeUserHive ? "HKCU" : null, includeMachineHive ? "HKLM" : null }
                    .Where(x => x != null));
            sb.AppendLine($"Hives scanned  : {(string.IsNullOrEmpty(hives) ? "(none)" : hives)}");
            sb.AppendLine($"Scopes scanned : {string.Join(", ", scopes)}");
            sb.AppendLine($"Total items    : {items.Count} " +
                          $"({items.Count(i => i.IsEnabled)} enabled, {items.Count(i => !i.IsEnabled)} disabled)");
            sb.AppendLine();

            sb.AppendLine("NOTE ON COVERAGE");
            sb.AppendLine("----------------");
            sb.AppendLine("This tool reads context-menu entries from the registry:");
            sb.AppendLine("  - Static verbs under  <scope>\\shell");
            sb.AppendLine("  - Classic COM handlers under  <scope>\\shellex\\ContextMenuHandlers");
            sb.AppendLine("It CANNOT list items that are not in those registry locations, including:");
            sb.AppendLine("  - Packaged (MSIX/AppX) IExplorerCommand shell extensions, e.g. Dropbox's");
            sb.AppendLine("    \"Transfer a copy\" / \"Copy Dropbox link\". These live under");
            sb.AppendLine("    Software\\Classes\\PackagedCom\\Package and are not enumerable as verbs.");
            sb.AppendLine("  - Verbs generated at runtime by a COM handler's DLL (the handler shows,");
            sb.AppendLine("    but its individual menu entries do not exist in the registry).");
            sb.AppendLine();

            foreach (IGrouping<ContextScope, ContextMenuItem> scopeGroup in items
                         .GroupBy(i => i.Scope)
                         .OrderBy(g => g.Key))
            {
                sb.AppendLine();
                sb.AppendLine($"### SCOPE: {scopeGroup.Key} ###");

                foreach (ContextMenuItem it in scopeGroup
                             .OrderBy(i => i.DisplayName, StringComparer.OrdinalIgnoreCase))
                {
                    string state = it.IsEnabled ? "ENABLED " : "disabled";
                    sb.AppendLine();
                    sb.AppendLine($"[{state}] {it.DisplayName}  ({it.ItemType}, {it.HiveDisplay})");
                    sb.AppendLine($"    Path    : {it.HiveDisplay}\\{it.FullKeyPath}\\{it.KeyName}");

                    if (!string.IsNullOrWhiteSpace(it.Command))
                        sb.AppendLine($"    Command : {it.Command}");

                    if (!string.IsNullOrWhiteSpace(it.HandlerClsid))
                        sb.AppendLine($"    CLSID   : {it.HandlerClsid}");

                    if (!string.IsNullOrWhiteSpace(it.FriendlyName))
                        sb.AppendLine($"    Handler : {it.FriendlyName}");

                    if (!string.IsNullOrWhiteSpace(it.HandlerModule))
                        sb.AppendLine($"    Module  : {it.HandlerModule}");

                    if (it.IsInSubmenu)
                        sb.AppendLine("    (in Power Menu submenu)");

                    if (!it.IsEnabled && !string.IsNullOrWhiteSpace(it.DisabledReasonText))
                        sb.AppendLine($"    Reason  : {it.DisabledReasonText}");
                }
            }

            return sb.ToString();
        }
    }
}
