using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Interfaces;

namespace BadMC_Launcher.Models.Datas.ViewDatas;

internal static class MainMenuData {
    internal static ObservableCollection<IMainMenuSharchItem> MainMenuSharchItems { get; set; } = new();
}
