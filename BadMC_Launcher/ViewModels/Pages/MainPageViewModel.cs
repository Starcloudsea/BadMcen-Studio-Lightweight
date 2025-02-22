using System.Collections.ObjectModel;
using BadMC_Launcher.Classes;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.Servicess.Settings;
using BadMC_Launcher.Views.Pages;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class MainPageViewModel : ObservableObject {
    internal Frame? mainSideBarFrame;
    internal Frame? mainSideBarFlyoutFrame;
    internal NavigationView? mainSideBar;

    public bool MainSideBarFrameCanGoBack { get; set; }

    public MainPageViewModel() {
        WindowName = App.GetService<ThemeSettingService>().WindowName;
        MainSideBarToolVisibility = Visibility.Collapsed;
        MainSideBarItems = MainSideBarData.MainSideBarItems;
        MainSideBarFooterItems = MainSideBarData.MainSideBarFooterItems;
    }

    [ObservableProperty]
    public partial string? WindowName { get; set; }

    //MainSideBar Items
    [ObservableProperty]
    public partial ObservableCollection<MainSideBarItem> MainSideBarItems { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<MainSideBarItem> MainSideBarFooterItems { get; set; }

    [ObservableProperty]
    public partial MainSideBarItem? MainSideBarSelectedItem { get; set; }

    [ObservableProperty]
    public partial UIElement? MainSideBarFlyoutContent { get; set; }

    [ObservableProperty]
    public partial Visibility MainSideBarToolVisibility { get; set; }

    [RelayCommand]
    public void MainSideBarFrameNavigated(object parameter) {
        var frame = parameter as Frame;
        if (frame != null) {
            if (frame.Content == null) {
                MainSideBarToolVisibility = Visibility.Collapsed;
            }
            else {
                MainSideBarToolVisibility = Visibility.Visible;
            }
        }
    }

    [RelayCommand]
    public void MainSideBarSelected(object parameter) {
        if (parameter is Border appTitleBar && mainSideBar != null && mainSideBar.SelectedItem is MainSideBarItem mainSideBarSelectedItem && mainSideBarFlyoutFrame != null) {
            mainSideBarFlyoutFrame.Navigate(mainSideBarSelectedItem.NavigatePage);
            FlyoutBase.ShowAttachedFlyout(appTitleBar);

        }
    }

    [RelayCommand(CanExecute = nameof(MainSideBarFrameCanGoBack))]
    public void BackButton(Frame parameter) {
        if (parameter.CanGoBack) {
            parameter.GoBack();
        }
    }

    [RelayCommand]
    public void CloseButton(Frame parameter) {
        parameter.Content = null;
    }

    [RelayCommand]
    public void MainSideBarFlyoutClosed() {
        MainSideBarSelectedItem = null;
    }

    public void NavigateTo(Type pageType) {
        if (mainSideBarFrame != null) {
            mainSideBarFrame.Navigate(pageType);
        }
    }

    public void SetBackground(Action<Brush> brushAction) {
        
        var service = App.GetService<ThemeSettingService>();
        if (service == null) {
            //TODO: Exception Dialog
            return;
        }
        service.SetBackground((brush) => {
            if (brush != null) {
                brushAction(brush);
                return;
            }
        });
    }

    internal void SetCanGoBack() {
        if (mainSideBarFrame != null) {
            MainSideBarFrameCanGoBack = mainSideBarFrame.CanGoBack;
        }
    }
}
 
