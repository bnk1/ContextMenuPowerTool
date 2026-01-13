using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace ContextMenuPowerTool
{
	public static class RegistryOperations
	{
		public static void RenameSubKeyTree(RegistryKey parentKey, string oldName, string newName)
		{
			using RegistryKey? oldKey = parentKey.OpenSubKey(oldName, true) ?? throw new InvalidOperationException($"Subkey not found: {oldName}");

            if (parentKey.OpenSubKey(newName) != null)
				throw new InvalidOperationException($"Target subkey already exists: {newName}");

			using RegistryKey newKey = parentKey.CreateSubKey(newName, true)
				?? throw new InvalidOperationException($"Failed to create target subkey: {newName}");

			CopyKeyTree(oldKey, newKey);
			parentKey.DeleteSubKeyTree(oldName, false);
		}

		public static void CopyKeyTree(RegistryKey source, RegistryKey destination)
		{
			foreach (string valueName in source.GetValueNames())
			{
				object? value = source.GetValue(valueName);
				RegistryValueKind kind = source.GetValueKind(valueName);
				// Fix CS8604: Ensure value is not null, use empty value for the kind if needed
				if (value is null)
				{
					value = kind switch
					{
						RegistryValueKind.String => string.Empty,
						RegistryValueKind.ExpandString => string.Empty,
						RegistryValueKind.Binary => Array.Empty<byte>(),
						RegistryValueKind.DWord => 0,
						RegistryValueKind.QWord => 0L,
						RegistryValueKind.MultiString => Array.Empty<string>(),
						_ => string.Empty
					};
				}
				destination.SetValue(valueName, value, kind);
			}

			foreach (string subName in source.GetSubKeyNames())
			{
				using RegistryKey? srcSub = source.OpenSubKey(subName, false);
				if (srcSub == null)
					continue;

				using RegistryKey dstSub = destination.CreateSubKey(subName, true)
					?? throw new InvalidOperationException($"Failed to create subkey: {subName}");

				CopyKeyTree(srcSub, dstSub);
			}
		}

		public static void DeleteIfExists(RegistryKey parentKey, string subName)
		{
			try
			{
				parentKey.DeleteSubKeyTree(subName, false);
			}
			catch
			{
			}
		}

		public static void SetStringValue(RegistryKey key, string? name, string value)
		{
			key.SetValue(name, value, RegistryValueKind.String);
		}

		public static void SetDwordValue(RegistryKey key, string name, int value)
		{
			key.SetValue(name, value, RegistryValueKind.DWord);
		}

		public static string MakeSafeKeyName(string name)
		{
			string s = name.Trim();
			foreach (char c in Path.GetInvalidFileNameChars())
			{
				s = s.Replace(c, '_');
			}

			s = s.Replace('\\', '_').Replace('/', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_');
			if (string.IsNullOrWhiteSpace(s))
				s = "Item";

			return s;
		}

		public static string StripDisabledMarkers(string keyName)
		{
			string s = keyName;

			if (s.EndsWith(".disabled", StringComparison.OrdinalIgnoreCase))
				s = s[..^".disabled".Length];

			while (s.StartsWith('_'))
			{
				s = s[1..];
			}

			return s;
		}

		public static bool IsDisabledKeyName(string keyName)
		{
            return keyName.EndsWith(".disabled", StringComparison.OrdinalIgnoreCase) || keyName.StartsWith('_');
        }
    }
}
