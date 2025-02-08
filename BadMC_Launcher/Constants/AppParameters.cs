using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.ApplicationModel.Resources;
using Uno.UI.RemoteControl.Host;
using Windows.Graphics;

namespace BadMC_Launcher.Constants;
public static class AppParameters {
    public readonly static SizeInt32 windowSize = new() {
        Width = 948,
        Height = 624
    };
    public readonly static IServiceProvider Services = App.Current.Host?.Services ?? throw new COMException();
}
