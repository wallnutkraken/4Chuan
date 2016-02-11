using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jackie4Chuan
{
    static class IntermediateSettingStorage
    {
        internal static void SetKeyBindings()
        {
            RefreshKey = (Key)Properties.Settings.Default.RefreshKey;
            UpKey = (Key)Properties.Settings.Default.UpKey;
            RightKey = (Key)Properties.Settings.Default.RightKey;
            LeftKey = (Key)Properties.Settings.Default.LeftKey;
            DownKey = (Key)Properties.Settings.Default.DownKey;
        }
        internal static Key RefreshKey { get; set; }
        internal static Key UpKey { get; set; }
        internal static Key DownKey { get; set; }
        internal static Key RightKey { get; set; }
        internal static Key LeftKey { get; set; }
    }
}
