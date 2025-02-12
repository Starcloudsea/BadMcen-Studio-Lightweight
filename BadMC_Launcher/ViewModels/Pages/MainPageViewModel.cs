using BadMC_Launcher.Services;
using BadMC_Launcher.Services.Settings.ThemeSetting;
using BadMC_Launcher.Views.Pages;
using Microsoft.UI.Xaml.Media;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class MainPageViewModel : ObservableObject {

    public MainPageViewModel() {
        WindowName = App.GetService<ThemeSettingService>().WindowName;
    }

    [ObservableProperty]
    public partial string? WindowName { get; set; }

    public void SetInitialPage(Frame frame) {
        App.GetService<FrameNavigationService>().NavigateTo<DashboardPage>(frame);
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
}
 
