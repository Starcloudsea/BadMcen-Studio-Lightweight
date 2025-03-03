using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using Uno.UI.RemoteControl.Host;
using Windows.Graphics;

namespace BadMC_Launcher.Models.Datas;

public static class AppParameters {
    public readonly static SizeInt32 windowSize = new() {
        Width = 948,
        Height = 624
    };

    public readonly static JsonSerializerOptions JsonOptions = new JsonSerializerOptions {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    
}
