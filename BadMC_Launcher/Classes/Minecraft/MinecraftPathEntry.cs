using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Servicess.Settings;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.Classes.Minecraft;
public class MinecraftPathEntry {
    private MinecraftParser? minecraftParser;
    private string minecraftName = string.Empty;
    private string? activeMinecraftEntryId;
    private ObservableDataList<string> starredMinecraftIds = new();
    private IEnumerable<MinecraftEntry> minecraftList = new List<MinecraftEntry>();

    public MinecraftPathEntry() {
    }
    public required string MinecraftName {
        get => minecraftName;
        set {
            minecraftName = value;
            OnPropertyChanged();
        }
    }

    public required string MinecraftPath { get; init; }

    public string? ActiveMinecraftEntryId {
        get => activeMinecraftEntryId;
        set {
            activeMinecraftEntryId = value;
            OnPropertyChanged();
        }
    }

    public ObservableDataList<string> StarredMinecraftIds {
        get => starredMinecraftIds;
        set {
            starredMinecraftIds = value;
            OnPropertyChanged();
        }
    }

    protected void OnPropertyChanged() {
        App.GetService<MinecraftConfigService>().SyncSettingSet();
    }

    public void SetMinecrafts() {
        if (minecraftParser == null) {
            minecraftParser = new MinecraftParser(MinecraftPath);
        }
        minecraftList = new List<MinecraftEntry>();
        minecraftParser.GetMinecrafts().ForEach(item => ((List<MinecraftEntry>)minecraftList).Add(item));
    }

    public IEnumerable<MinecraftEntry> GetMinecrafts() {
        if (!minecraftList.Any()) {
            if (minecraftParser == null) {
                minecraftParser = new MinecraftParser(MinecraftPath);
            }
            minecraftList = new List<MinecraftEntry>();
            minecraftParser.GetMinecrafts().ForEach(item => ( (List<MinecraftEntry>)minecraftList ).Add(item));
        }
        return minecraftList;
    }

    public MinecraftParser GetMinecraftParser() {
        if (minecraftParser == null) {
            minecraftParser = new MinecraftParser(MinecraftPath);
        }
        return minecraftParser;
    }
}
