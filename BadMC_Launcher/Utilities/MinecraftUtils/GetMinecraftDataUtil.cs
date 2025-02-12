using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Services.Settings.MinecraftConfig;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.Utilities.MinecraftUtils;
public static class GetMinecraftDataUtil {
    public static JsonList<MinecraftEntry> GetMinecrafts() {
        var activeMinecraftPath = App.GetService<MinecraftConfigService>().ActiveMinecraftPath;
        var minecraftList = new JsonList<MinecraftEntry>();
        if (activeMinecraftPath != null) {
            MinecraftParser minecraftParser = activeMinecraftPath.MinecraftPath;
            foreach (var item in minecraftParser.GetMinecrafts()) {
                minecraftList.Add(item);
            }
        }
        return minecraftList;
    }
}
