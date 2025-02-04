using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Services.FrameNavigation;
public class FrameNavigationService : IFrameNavigationService {
    public void NavigateTo<T>(Frame frame) where T : Page {
        if (frame == null) {
            throw new InvalidOperationException("Frame is not set.");
        }
        frame.Navigate(typeof(T));
    }
}
