using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.ViewModels.Pages;
using BadMC_Launcher.Classes;
using Microsoft.Windows.ApplicationModel.Resources;
using BadMC_Launcher.Views.Pages.MainSideBarPages;

namespace BadMC_Launcher.Services.ViewServices;
public class MainSideBarManagerService {
    public void NavigateToPage<T>() where T : Page {
        App.GetService<MainPageViewModel>().NavigateTo(typeof(T));
    }

    public void Register(MainSideBarItem mainSideBarItem, bool isFooter = false) {
        if (isFooter) {
            MainSideBarData.MainSideBarFooterItems.Add(mainSideBarItem);
        }
        else {
            MainSideBarData.MainSideBarItems.Add(mainSideBarItem);
        }
    }
}
