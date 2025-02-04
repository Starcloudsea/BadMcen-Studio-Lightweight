using BadMC_Launcher.ViewModels.Pages;

namespace BadMC_Launcher.Views.Pages;

public sealed partial class MainPage : Page {
    private MainPageViewModel viewModel = new MainPageViewModel();

    public MainPage() {
        this.InitializeComponent();
        DataContext = viewModel;
        viewModel.SetInitialPage(MainFrame);
        SetBackground();
        viewModel.SetBackground((brush) => MainGrid.Background = brush);
    }
    private async void SetBackground() {
        
    }
}
