using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Interfaces;
using BadMC_Launcher.Models.Datas.ViewDatas;

namespace BadMC_Launcher.Services.ViewServices;

public class MainSearchService {
    public void Register(IMainMenuSharchItem mainMenuSharchItem) {
        MainMenuData.MainMenuSharchItems.Add(mainMenuSharchItem);
    }
}
