using BadMC_Launcher.Services.Settings;
using BadMC_Launcher.ViewModels.Pages;

namespace BadMC_Launcher.Views.Pages;

public sealed partial class MainPage : Page {
    private MainPageViewModel viewModel = new MainPageViewModel();

    public MainPage() {
        this.InitializeComponent();
        DataContext = viewModel;
        viewModel.SetInitialPage(MainFrame);
        viewModel.SetBackground((brush) => MainGrid.Background = brush);
    }
}
