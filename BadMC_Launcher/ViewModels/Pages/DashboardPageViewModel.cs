using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Models.Classes.MinecraftClass;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.Services.Settings;
using BadMC_Launcher.Utilities.MinecraftUtils;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class DashboardPageViewModel : ObservableObject {
    MinecraftConfigService MinecraftService = App.GetService<MinecraftConfigService>();
    MinecraftPathEntry? minecraftPathEntry;

    public DashboardPageViewModel() {
        if (MinecraftService.ActiveMinecraftPath != null) {
            minecraftPathEntry = MinecraftService.MinecraftPaths.FirstOrDefault(item => item.MinecraftPath == MinecraftService.ActiveMinecraftPath);
            if (minecraftPathEntry != null) {
                MinecraftList = (ObservableCollection<MinecraftItem>)MinecraftItem.GetMinecraftItems(minecraftPathEntry);
                if (minecraftPathEntry.ActiveMinecraftEntryId != null) {
                    var minecraftItem = MinecraftItem.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId, minecraftPathEntry);
                    if (minecraftItem != null) {
                        MinecraftListSelectedItem = MinecraftList.FirstOrDefault(item => item.MinecraftName == minecraftItem.MinecraftName);
                    }
                }
                MinecraftPathListSelectedItem = minecraftPathEntry;
                
            }
        }
        MinecraftPathList = new ObservableCollection<MinecraftPathEntry>(MinecraftService.MinecraftPaths);
        SetLaunchButtonEntry();
    }

    //LaunchButton Property
    [ObservableProperty]
    public partial string? GameEntryName { get; set; }

    [ObservableProperty]
    public partial BitmapImage? GameEntryImage { get; set; }

    //MinecraftsList
    [ObservableProperty]
    public partial ObservableCollection<MinecraftItem>? MinecraftList { get; set; }

    //MinecraftFolderPathsList
    [ObservableProperty]
    public partial ObservableCollection<MinecraftPathEntry>? MinecraftPathList { get; set; }

    [ObservableProperty]
    public partial MinecraftPathEntry? MinecraftPathListSelectedItem { get; set; }

    [ObservableProperty]
    public partial MinecraftItem? MinecraftListSelectedItem { get; set; }

    [RelayCommand]
    public void RefreshMinecraftList() {
        MinecraftService.SyncSettingGet();
        minecraftPathEntry = MinecraftService.MinecraftPaths.FirstOrDefault(item => item.MinecraftPath == MinecraftService.ActiveMinecraftPath);
        if (MinecraftService.ActiveMinecraftPath != null && minecraftPathEntry != null) {
            MinecraftList = (ObservableCollection<MinecraftItem>)MinecraftItem.GetMinecraftItems(minecraftPathEntry);
            SetLaunchButtonEntry();
        }
    }

    [RelayCommand]
    public void ViewLoaclMinecraftFolder() {
        if (MinecraftService.ActiveMinecraftPath != null) {
            try {
                using (Process.Start(new ProcessStartInfo(MinecraftService.ActiveMinecraftPath) {
                UseShellExecute = true,
                Verb = "open"
                })) {

                }
            }
            catch (Exception ex) {
                switch (ex) {
                    case Win32Exception:
                        //TODO: Dialog
                        break;
                    case FileNotFoundException:
                        //TODO: Dialog
                        break;
                    default:
                        throw;
                }
            }
        }
    }

    [RelayCommand]
    public void MinecraftListSelected(object parameter) {
        if (parameter is ListView listView) {
            var item = (MinecraftItem)listView.SelectedItem;
            if (item != null && MinecraftService.ActiveMinecraftPath != null && minecraftPathEntry != null) {
                minecraftPathEntry.ActiveMinecraftEntryId = item.MinecraftName;
                SetLaunchButtonEntry();
            }
        }
    }

    [RelayCommand]
    public void MinecraftPathsListSelected(object parameter) {
        if (parameter is ComboBox comboBox) {
            var item = (MinecraftPathEntry)comboBox.SelectedItem;
            MinecraftService.ActiveMinecraftPath = item.MinecraftPath;
            minecraftPathEntry = MinecraftService.MinecraftPaths.FirstOrDefault(item => item.MinecraftPath == MinecraftService.ActiveMinecraftPath);
            if (MinecraftService.ActiveMinecraftPath != null && minecraftPathEntry != null) {
                MinecraftList = (ObservableCollection<MinecraftItem>)MinecraftItem.GetMinecraftItems(minecraftPathEntry);
                if (minecraftPathEntry.ActiveMinecraftEntryId != null) {
                    MinecraftListSelectedItem = MinecraftItem.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId, minecraftPathEntry);
                }
            }
            else {
                MinecraftList = null;
            }
            SetLaunchButtonEntry();
        }
    }


    [RelayCommand]
    public void MinecraftEmptyListHyperLink() {
        if (MinecraftList != null && !MinecraftList.Any()) {
            return;
        }

    }

    public void SetLaunchButtonEntry() {
        if (MinecraftService.ActiveMinecraftPath != null && minecraftPathEntry != null && minecraftPathEntry.ActiveMinecraftEntryId != null) {
            if (MinecraftService.ActiveMinecraftPath != null) {
                var minecraftItem = MinecraftItem.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId, minecraftPathEntry);
                if (minecraftItem != null) {
                    GameEntryName = minecraftItem.MinecraftName;
                    GameEntryImage = minecraftItem.MinecraftImage;
                    return;
                }
            }
        }
        GameEntryName = App.GetService<ResourceLoader>().GetString("DashboardLaunchButtonTagDefault");
        GameEntryImage = new BitmapImage() { UriSource = new Uri(@"ms-appx:///Assets/Icons/MinecraftIcons/Drowned.png") };
    }
}
