using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Servicess.Settings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.Utilities.MinecraftUtils;
public static class GetMinecraftDataUtil {
    //public static JsonList<MinecraftEntry> GetMinecrafts(MinecraftPathEntry? minecraftPathEntry = null) {
    //    MinecraftPathEntry minecraftPath;
    //    if (minecraftPathEntry == null) {
    //        minecraftPath = App.GetService<MinecraftConfigService>().ActiveMinecraftPath ?? throw new ArgumentNullException($"ActiveMinecraftPath is null.");
    //    }
    //    else minecraftPath = minecraftPathEntry;
    //    var minecraftList = new JsonList<MinecraftEntry>();
    //    if (minecraftPath != null) {
    //        MinecraftParser minecraftParser = minecraftPath.MinecraftPath;
    //        foreach (var item in minecraftParser.GetMinecrafts()) {
    //            minecraftList.Add(item);
    //        }
    //    }
    //    return minecraftList;
    //}
}
