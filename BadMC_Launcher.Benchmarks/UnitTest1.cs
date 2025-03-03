using System.Collections.ObjectModel;
using BadMC_Launcher.Classes;
using BadMC_Launcher.Servicess;
using BadMC_Launcher.Servicess.Settings;
using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BadMC_Launcher.Benchmarks;

public class UnitTest1 {

    [Benchmark]
    public async void Test1() {
        await ThemeSettingService.GetBingWallpaperUrl();
    }
}
