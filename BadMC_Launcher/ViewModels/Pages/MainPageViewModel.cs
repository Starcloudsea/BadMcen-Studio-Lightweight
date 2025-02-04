using BadMC_Launcher.Services.FrameNavigation;
using BadMC_Launcher.Services.Settings.ThemeSetting;
using BadMC_Launcher.Views.Pages;
using Microsoft.UI.Xaml.Media;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class MainPageViewModel : ObservableObject {

    public MainPageViewModel() {
        var service = App.Current.Host?.Services.GetService<IThemeSettingService>();
        if (service != null) {
            WindowName = service.WindowName;
        }

    }

    [ObservableProperty]
    public partial string? WindowName { get; set; }

    public void SetInitialPage(Frame frame) {
        var service = App.Current.Host?.Services.GetService<IFrameNavigationService>();
        if (service != null) {
            service.NavigateTo<DashboardPage>(frame);
        }
    }

    public void SetBackground(Action<Brush> brushAction) {
        
        var service = App.Current.Host?.Services.GetService<IThemeSettingService>();
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
