using System.Collections.ObjectModel;
using BadMC_Launcher.Models.Datas.ViewDatas;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls.Primitives;
using BadMC_Launcher.Classes;
using CommunityToolkit.WinUI;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class DashboardPageViewModel : ObservableObject {
    public Frame? mainSideBarFrame;
    public Frame? mainSideBarFlyoutFrame;

    public bool MainSideBarFrameCanGoBack { get; set; }

    public DashboardPageViewModel() {
        MainSideBarToolVisibility = Visibility.Collapsed;
        MainSideBarItems = MainSideBarData.MainSideBarItems;
        MainSideBarFooterItems = MainSideBarData.MainSideBarFooterItems;
    }

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
        if (parameter is NavigationView navigationView && navigationView.SelectedItem is MainSideBarItem mainSideBarItem && mainSideBarFlyoutFrame != null) {
            mainSideBarFlyoutFrame.Navigate(mainSideBarItem.NavigatePage);
            FlyoutBase.ShowAttachedFlyout(navigationView);
            
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

    internal void SetCanGoBack() {
        if (mainSideBarFrame != null) {
            MainSideBarFrameCanGoBack = mainSideBarFrame.CanGoBack;
        }
    }
}
