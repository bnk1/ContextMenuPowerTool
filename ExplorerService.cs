using System;
using System.Diagnostics;
using System.Linq;

namespace ContextMenuPowerTool
{
	public static class ExplorerService
	{
		public static void RestartExplorer()
		{
			foreach (Process p in Process.GetProcessesByName("explorer").ToList())
			{
				try
				{
					p.Kill(true);
				}
				catch
				{
				}
			}

			Process.Start(new ProcessStartInfo
			{
				FileName = "explorer.exe",
				UseShellExecute = true
			});
		}

		public static void OpenRegeditAt(string hiveDisplay, string fullKeyPath)
		{
			string full = $"{hiveDisplay}\\{fullKeyPath}".Replace(@"Software\Classes\", @"Software\Classes\");
			try
			{
				using Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit")!;
				key.SetValue("LastKey", full);
			}
			catch
			{
			}

			Process.Start(new ProcessStartInfo
			{
				FileName = "regedit.exe",
				UseShellExecute = true
			});
		}
	}
}
