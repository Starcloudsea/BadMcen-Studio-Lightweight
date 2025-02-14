using System.Collections.ObjectModel;
using BadMC_Launcher.Models.Classes.MinecraftClass;
using BadMC_Launcher.Models.Datas.ViewDatas;
using BadMC_Launcher.Services.Settings;
using BadMC_Launcher.Utilities.MinecraftUtils;
using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BadMC_Launcher.Benchmarks;

public class UnitTest1 {
    MinecraftConfigService MinecraftService = new MinecraftConfigService();

    [Benchmark]
    public void Test1() {

        MinecraftService.ActiveMinecraftPath = new MinecraftPathEntry() { MinecraftName = "Test", MinecraftPath = @"C:\Users\stars\AppData\Roaming\.minecraft" };
        //var a = (ObservableCollection<MinecraftItem>)MinecraftItem.GetMinecraftItems(GetMinecraftDataUtil.GetMinecrafts());
    }
}
