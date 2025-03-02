using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Extensions;
public static class FrameExtension {
    public static void NavigateTo<T>(this Frame frame) where T : Page {
        if (frame == null) {
            throw new InvalidOperationException("Frame is not set.");
        }
        frame.Navigate(typeof(T));
    }
}
