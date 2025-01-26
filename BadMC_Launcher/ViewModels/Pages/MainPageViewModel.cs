using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes.Settings;

namespace BadMC_Launcher.ViewModels.Pages;

partial class MainPageViewModel : ObservableObject {
    [ObservableProperty]
    private string windowName = WindowConfigs.WindowName;

    public MainPageViewModel() {

    }
}
