using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLaunch.Base.Models.Game;

namespace BadMC_Launcher.Models.Datas.MinecraftDatas;
internal static class SingleMinecraftConfig {
    internal static string? targetMinecraftEntryPath;

    internal static bool isFullscreen;

    internal static bool isEnableIndependencyCore;

    internal static int minMemorySize;

    internal static int maxMemorySize;

    internal static JavaEntry? javaPath;

    internal static string? launcherName;

    internal static IEnumerable<string>? jvmArguments;
}
