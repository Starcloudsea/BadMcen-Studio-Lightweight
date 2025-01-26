using System.Diagnostics;
using BadMC_Launcher.Models.Base;
using BadMC_Launcher.ViewModels.Pages;

namespace BadMC_Launcher.Views.Pages;

public sealed partial class MainPage : Page {
    public MainPage() {
        this.InitializeComponent();
        DataContext = new MainPageViewModel();
    }
}
