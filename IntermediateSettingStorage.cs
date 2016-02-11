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
        }
        internal static Key RefreshKey { get; set; }
    }
}
