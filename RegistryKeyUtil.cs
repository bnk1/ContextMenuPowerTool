using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace ContextMenuPowerTool
{
	public static class RegistryKeyUtil
	{
		public static RegistryKey? OpenKey(RegistryKey root, string path, bool writable)
		{
			return root.OpenSubKey(path, writable);
		}

		public static IEnumerable<string> SafeGetSubKeyNames(RegistryKey key)
		{
			try
			{
				return key.GetSubKeyNames();
			}
			catch
			{
				return [];
			}
		}

		public static string? SafeGetString(RegistryKey? key, string? valueName)
		{
			if (key == null)
				return null;

			try
			{
				object? v = key.GetValue(valueName);
				return v?.ToString();
			}
			catch
			{
				return null;
			}
		}

		public static bool KeyExists(RegistryKey root, string path)
		{
			using RegistryKey? k = root.OpenSubKey(path, false);
			return k != null;
		}
	}
}
