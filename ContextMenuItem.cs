
using System.ComponentModel;

namespace ContextMenuPowerTool
{
    public sealed class ContextMenuItem : INotifyPropertyChanged
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public required string DisplayName { get; set; }
        public required string KeyName { get; set; }              // actual registry subkey name (may include disabled marker/prefix)
        public required string NormalizedName { get; set; }       // stripped name (no prefix markers)
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
        public string? HandlerModule { get; set; }                // backing COM DLL for shellex handlers (InprocServer32)
        public string? FriendlyName { get; set; }                 // resolved COM friendly name (HKCR\CLSID\{clsid})
        public bool IsExtended { get; set; }                      // Shift+RightClick only

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public DisableReason _disableReasonCode { get; set; }

        public DisableReason DisabledReasonCode
        {
            get => _disableReasonCode;
            set
            {
                if (_disableReasonCode != value)
                {
                    _disableReasonCode = value;
                    OnPropertyChanged(nameof(DisabledReasonCode));
                }
            }
        }

        private string? _disableReasonText;
        public string? DisabledReasonText
        {
            get => _disableReasonText;
            set
            {
                if (_disableReasonText != value)
                {
                    _disableReasonText = value;
                    OnPropertyChanged(nameof(DisabledReasonText));
                }
            }
        }

        private bool _isInSubmenu;
        public bool IsInSubmenu
        {
            get => _isInSubmenu;
            set
            {
                if (_isInSubmenu != value)
                {
                    _isInSubmenu = value;
                    OnPropertyChanged(nameof(IsInSubmenu));
                }
            }
        }


        public override string ToString()
        {
            return $"{DisplayName} ({HiveDisplay}\\{FullKeyPath})";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
