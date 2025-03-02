using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Extensions;
using Microsoft.Windows.ApplicationModel.Resources;
using MinecraftLaunch.Base.Models.Authentication;
using MinecraftLaunch.Base.Models.Game;
using BadMC_Launcher.Classes.Minecraft;

namespace BadMC_Launcher.Models.Datas.SettingsDatas;
internal static class MinecraftConfig {
    internal static IEnumerable<Account> minecraftAccounts = new ObservableDataList<Account>();

    internal static IEnumerable<string> javaPaths = new ObservableDataList<string>();

    internal static IEnumerable<MinecraftPathEntry> minecraftPaths = new ObservableDataList<MinecraftPathEntry>();

    internal static JavaEntry? activeJavaPath;

    internal static string? activeMinecraftPath;

    internal static Account? activeMinecraftAccount;

    internal static bool isFullscreen = false;

    internal static bool isEnableIndependencyCore = false;

    internal static int minMemorySize = 512;

    internal static int maxMemorySize = 1024;

    internal static string? launcherName = App.GetService<ResourceLoader>().GetString("MinecraftConfig_MinecraftTitleNameResource");

    internal static IEnumerable<string>? jvmArguments;
}
