using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes;
using BadMC_Launcher.Classes.MainSearch;
using BadMC_Launcher.Constants.Enums;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Interfaces;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.Services.ViewServices;
using BadMC_Launcher.Views.Pages.MainSideBarPages;
using BadMC_Launcher.Views.Pages.SettingsPages;
using CommunityToolkit.Labs.WinUI;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.WinUI.Controls;
using Microsoft.Windows.ApplicationModel.Resources;

namespace BadMC_Launcher.ViewModels.Pages.MainSideBarPages;
public partial class MainMenuPageViewModel : ObservableObject {
    public MainMenuPageViewModel() {
        MainMenuItems = MainMenuData.MainMenuItems;
        SearchFilterItems = MainMenuData.MainMenuSharchFilterItems;
        SearchItems = new();
        SearchFilterSelectedItems = new();
        SearchFilterRealTimeToggleIsOn = true;
        SearchText = string.Empty;
    }

    [ObservableProperty]
    public partial ObservableCollection<IMainMenuSharchFilterItem> SearchFilterItems { get; set; }
    
    [ObservableProperty]
    public partial List<IMainMenuSharchFilterItem> SearchFilterSelectedItems { get; set; }

    [ObservableProperty]
    public partial ObservableDataList<MainMenuSearchResultItem> SearchItems { get; set; }
    
    [ObservableProperty]
    public partial string SearchText { get; set; }
    
    [ObservableProperty]
    public partial bool SearchFilterRealTimeToggleIsOn { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<MainMenuItem> MainMenuItems { get; set; }

    //TODO: 该写Blog了，还能这样的啊？？？Σ(っ °Д °;)っ
    [RelayCommand]
    public void MainMenuSearchButtonClicked(AutoSuggestBoxQuerySubmittedEventArgs args) {
        MainMenuSearch(args.QueryText);
    }
    
    [RelayCommand]
    public void SearchTextChanged(AutoSuggestBoxTextChangedEventArgs args) {
        if (SearchFilterRealTimeToggleIsOn && args.Reason == AutoSuggestionBoxTextChangeReason.UserInput) {
            MainMenuSearch(SearchText);
        }
    }

    [RelayCommand]
    public void MainMenuSearchSuggestionChosen(AutoSuggestBoxSuggestionChosenEventArgs args) {
        if (args.SelectedItem is MainMenuSearchResultItem selectedItem) {
            selectedItem.Navigate.Invoke();
        }
    }
    
    [RelayCommand]
    public void MainMenuSearchFilterTokenViewSelected(TokenView parameter) {
         parameter.SelectedItems.ForEach(item => {
             if (item is IMainMenuSharchFilterItem mainMenuSharchFilterItem) {
                 SearchFilterSelectedItems.Add(mainMenuSharchFilterItem);
             }
         });
    }
    
    [RelayCommand]
    public void SettingsButtonClicked() {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<Type>(typeof(SettingsDashboardPage)), MessengerTokenEnum.MainPage_PageNavigateToken.ToString());
    }

    public void MainMenuSearch(string queryText) {
        var searchItems = new ObservableDataList<MainMenuSearchResultItem>();
        foreach (var item in SearchFilterSelectedItems) {
            foreach (var searchMainMenuSearchResultItem in item.Search(queryText)) {
                searchItems.Add(searchMainMenuSearchResultItem);
            }
        }
        SearchItems = searchItems;
    }
}
