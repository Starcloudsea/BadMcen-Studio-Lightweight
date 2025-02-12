using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Models.Classes.MinecraftClass;
using BadMC_Launcher.Models.ViewDatas;
using BadMC_Launcher.Services.Settings.MinecraftConfig;
using BadMC_Launcher.Utilities.MinecraftUtils;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Windows.ApplicationModel.Resources;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class DashboardPageViewModel : ObservableObject {

    public DashboardPageViewModel() {
        var minecraftService = App.GetService<MinecraftConfigService>();

        GameEntryName = minecraftService.ActiveMinecraftEntry != null ? minecraftService.ActiveMinecraftEntry.Id : App.GetService<ResourceLoader>().GetString("DashboardLaunchButtonTagDefault");
        GameEntryImage = @"\Assets\Icons\MinecraftIcons\Drowned.png";
        MinecraftPathList = (JsonList<MinecraftPathEntry>)minecraftService.MinecraftPaths;
        minecraftService.ActiveMinecraftPath = new MinecraftPathEntry() { MinecraftName = "Test", MinecraftPath = @"C:\Users\stars\AppData\Roaming\.minecraft" };
        MinecraftList = (ObservableCollection<MinecraftItem>)MinecraftItem.GetMinecraftItems(GetMinecraftDataUtil.GetMinecrafts());

    }

    [ObservableProperty]
    public partial string? GameEntryName { get; set; }

    [ObservableProperty]
    public partial string GameEntryImage { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<MinecraftItem>? MinecraftList { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<MinecraftPathEntry>? MinecraftPathList { get; set; }

    [RelayCommand]
    public void VersionButton() {

    }
}
