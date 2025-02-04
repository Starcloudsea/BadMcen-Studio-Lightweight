using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics;

namespace BadMC_Launcher.Constants;
public static class AppReadOnlyParameters {
    public readonly static SizeInt32 windowSize = new() {
        Width = 948,
        Height = 624
    };

    public readonly static HttpClient httpClient = new HttpClient();
}
