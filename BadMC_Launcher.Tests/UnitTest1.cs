using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using BadMC_Launcher.Models.Base;
using BadMC_Launcher.Models.Classes.LaunchConfigs;
using BadMC_Launcher.Models.Utils.FileUtils;
using BadMC_Launcher.Models.Utils.MinecraftUtils;
using MinecraftLaunch.Classes.Models.Auth;
using MinecraftLaunch.Classes.Models.Game;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;

namespace BadMC_Launcher.Tests;

public class UnitTest1 {
    [SetUp]
    public void Setup() {
    }
    private static void InitApp() {
        //CheckFolder
        ConfigFolderUtil.ChangeConfigFolder("Configs\\MinecraftConfigs", AlterationTags.Create);
    }
    [Test]
    public void Test1() {
        
        InitApp();
        Debug.WriteLine(Path.Combine(Path.Combine(GlobalDefinition.ConfigPath, "Configs\\MinecraftConfigs",
            "MinecraftAccounts.json")));
        var a = new MinecraftConfigsListUtil();
        a.MinecraftList.Add(new MinecraftFolderInfo() {
                    MinecraftFolderName = "OwO",
                    MinecraftFolderPath = @"C:\Users\stars\AppData\Roaming\.minecraft"
                });
        Assert.Pass();
    }
}
