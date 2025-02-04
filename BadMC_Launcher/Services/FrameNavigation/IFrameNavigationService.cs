using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Services.FrameNavigation;
public interface IFrameNavigationService {
    public void NavigateTo<T>(Frame frame) where T : Page;
}
