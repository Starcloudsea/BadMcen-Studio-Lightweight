using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Models.Classes.MinecraftClass;
using Microsoft.Windows.ApplicationModel.Resources;
using MinecraftLaunch.Base.Models.Authentication;
using MinecraftLaunch.Base.Models.Game;

namespace BadMC_Launcher.Models.Datas.MinecraftDatas;
internal static class MinecraftConfig {
    internal static IEnumerable<Account> minecraftAccounts = new JsonList<Account>();

    internal static IEnumerable<string> javaPaths = new JsonList<string>();

    internal static IEnumerable<MinecraftPathEntry> minecraftPaths = new JsonList<MinecraftPathEntry>();

    internal static JavaEntry? activeJavaPath;

    internal static string? activeMinecraftPath;

    internal static Account? activeMinecraftAccount;

    internal static bool isFullscreen = false;

    internal static bool isEnableIndependencyCore = false;

    internal static int minMemorySize = 512;

    internal static int maxMemorySize = 1024;

    internal static string? launcherName = App.GetService<ResourceLoader>().GetString("MinecraftTitleName");

    internal static IEnumerable<string>? jvmArguments;
}
