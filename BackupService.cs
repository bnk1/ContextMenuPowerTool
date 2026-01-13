using System;
using System.Diagnostics;
using System.IO;

namespace ContextMenuPowerTool
{
    public sealed class BackupService
    {
        public string BackupFolder { get; }

        public BackupService(string backupFolder)
        {
            BackupFolder = backupFolder;
            Directory.CreateDirectory(BackupFolder);
        }

        public string ExportRegistrySnapshot()
        {
            string stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string file = Path.Combine(BackupFolder, $"ContextMenuBackup_{stamp}.reg");

            // Export the two major locations we touch. This is broad, but safe for restore.
            // Power-user tool: we do a full Software\Classes export for both hives.
            // You can narrow this later if you want.
            string temp1 = Path.Combine(BackupFolder, $"HKCU_Classes_{stamp}.reg");
            string temp2 = Path.Combine(BackupFolder, $"HKLM_Classes_{stamp}.reg");

            RunRegExport(@"HKCU\Software\Classes", temp1);
            RunRegExport(@"HKLM\Software\Classes", temp2);

            File.WriteAllText(file,
                $"Windows Registry Editor Version 5.00{Environment.NewLine}{Environment.NewLine}" +
                File.ReadAllText(temp1) + Environment.NewLine + Environment.NewLine +
                File.ReadAllText(temp2));

            return file;
        }

        public static void ImportRegistrySnapshot(string regFilePath)
        {
            RunRegImport(regFilePath);
        }

        private static void RunRegExport(string keyPath, string outputFile)
        {
            Run("reg.exe", $"export \"{keyPath}\" \"{outputFile}\" /y");
        }

        private static void RunRegImport(string inputFile)
        {
            Run("reg.exe", $"import \"{inputFile}\"");
        }

        private static void Run(string file, string args)
        {
            using Process p = new Process();
            p.StartInfo = new ProcessStartInfo
            {
                FileName = file,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            p.Start();
            p.WaitForExit();

            if (p.ExitCode != 0)
            {
                string err = p.StandardError.ReadToEnd();
                if (string.IsNullOrWhiteSpace(err))
                    err = p.StandardOutput.ReadToEnd();

                throw new InvalidOperationException($"Registry operation failed ({p.ExitCode}): {err}");
            }
        }
    }
}
