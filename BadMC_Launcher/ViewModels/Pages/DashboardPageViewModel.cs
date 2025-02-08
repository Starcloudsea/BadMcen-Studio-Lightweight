using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.ApplicationModel.Resources;

namespace BadMC_Launcher.ViewModels.Pages;

public partial class DashboardPageViewModel : ObservableObject {

    public DashboardPageViewModel() {
        var ResourceService = AppParameters.Services.GetService<ResourceLoader>();
        if (ResourceService != null) {
            GameEntryName = ResourceService.GetString("DashboardLaunchButtonTagDefault");
        }
        //TODO: 
        GameEntryImage = null ?? @"\Assets\Icons\MinecraftIcons\Drowned.png";
    }

    [ObservableProperty]
    public partial string? GameEntryName { get; set; }

    [ObservableProperty]
    public partial string GameEntryImage { get; set; }


}
