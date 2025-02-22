using BadMC_Launcher.Servicess.Settings;
using BadMC_Launcher.ViewModels.Pages;

namespace BadMC_Launcher.Views.Pages;

public sealed partial class MainPage : Page {
    private MainPageViewModel viewModel;

    public MainPage() {
        this.InitializeComponent();
        viewModel = App.GetService<MainPageViewModel>();
        DataContext = viewModel;
        viewModel.SetBackground((brush) => MainGrid.Background = brush);

        viewModel.mainSideBarFrame = MainSideBarFrame;
        viewModel.mainSideBarFlyoutFrame = MainSideBarFlyoutFrame;
        viewModel.mainSideBar = MainSideBar;
        viewModel.SetCanGoBack();
    }
}
