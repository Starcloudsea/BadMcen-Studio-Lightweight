using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes;

namespace BadMC_Launcher.Models.Datas.ViewDatas;
internal static class MainSideBarData {
    internal static ObservableCollection<MainSideBarItem> MainSideBarItems { get; set; } = new();

    internal static ObservableCollection<MainSideBarItem> MainSideBarFooterItems { get; set; } = new();
}
