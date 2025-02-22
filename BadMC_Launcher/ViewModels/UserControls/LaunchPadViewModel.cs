using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.Classes;
using BadMC_Launcher.Servicess.Settings;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;

namespace BadMC_Launcher.ViewModels.UserControls;
public partial class LaunchPadViewModel : ObservableObject {
    MinecraftConfigService MinecraftService = App.GetService<MinecraftConfigService>();
    MinecraftPathEntry? minecraftPathEntry;

    public LaunchPadViewModel() {
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
    public void LaunchButton() {

    }

    //Refresh MinecraftList
    [RelayCommand]
    public void RefreshMinecraftList() {
        //Get Configs From Json File
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
        GameEntryName = App.GetService<ResourceLoader>().GetString("LaunchPad_LaunchButtonTagDefaultResource");
        GameEntryImage = new BitmapImage() { UriSource = new Uri(@"ms-appx:///Assets/Icons/MinecraftIcons/Drowned.png") };
    }
}
