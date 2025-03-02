using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Servicess.Settings;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using BadMC_Launcher.Classes.Minecraft;
using BadMC_Launcher.Extensions;

namespace BadMC_Launcher.ViewModels.UserControls;
public partial class LaunchPadViewModel : ObservableObject {
    MinecraftConfigService MinecraftService = App.GetService<MinecraftConfigService>();
    MinecraftPathEntry? minecraftPathEntry;
    ObservableCollection<MinecraftItem> minecraftList = new ObservableCollection<MinecraftItem>();

    public LaunchPadViewModel() {
        //Check Active Minecraft Path
        if (MinecraftService.ActiveMinecraftPath != null) {

            //Get Minecraft Entry
            minecraftPathEntry = MinecraftService.MinecraftPaths.First(item => item.MinecraftPath == MinecraftService.ActiveMinecraftPath);
            if (minecraftPathEntry != null) {

                //Get Minecraft Items
                foreach (var minecraftEntry in minecraftPathEntry.GetMinecrafts()) {
                    var item = minecraftPathEntry.GetMinecraftItem(minecraftEntry);
                    if (item != null)
                    minecraftList.Add(item);
                }
                MinecraftList = minecraftList;


                if (minecraftPathEntry.ActiveMinecraftEntryId != null) {
                    var minecraftItem = minecraftPathEntry.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId);
                    if (minecraftItem != null) {
                        MinecraftListSelectedItem = MinecraftList.FirstOrDefault(item => item.GetMinecraftName() == minecraftItem.GetMinecraftName());
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
            minecraftPathEntry.GetMinecrafts();
            MinecraftList = minecraftList;
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
                minecraftPathEntry.ActiveMinecraftEntryId = item.GetMinecraftName();
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
                MinecraftList = (ObservableCollection<MinecraftItem>)minecraftPathEntry.GetMinecraftItems();
                if (minecraftPathEntry.ActiveMinecraftEntryId != null) {
                    MinecraftListSelectedItem = minecraftPathEntry.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId);
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
                var minecraftItem = minecraftPathEntry.GetMinecraftItem(minecraftPathEntry.ActiveMinecraftEntryId);
                if (minecraftItem != null) {
                    GameEntryName = minecraftItem.GetMinecraftName();
                    GameEntryImage = minecraftItem.MinecraftImage;
                    return;
                }
            }
        }
        GameEntryName = App.GetService<ResourceLoader>().GetString("LaunchPad_LaunchButtonTagDefaultResource");
        GameEntryImage = new BitmapImage() { UriSource = new Uri(@"ms-appx:///Assets/Icons/MinecraftIcons/Drowned.png") };
    }
}
