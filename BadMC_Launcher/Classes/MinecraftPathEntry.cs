using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Servicess.Settings;

namespace BadMC_Launcher.Classes;
public record MinecraftPathEntry() {
    private string minecraftName = string.Empty;
    private string? activeMinecraftEntryId;
    private JsonList<string>? starredMinecraftIds;

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

    public JsonList<string>? StarredMinecraftIds {
        get => starredMinecraftIds;
        set {
            starredMinecraftIds = value;
            OnPropertyChanged();
        }
    }

    protected void OnPropertyChanged() {
        App.GetService<MinecraftConfigService>().SyncSettingSet();
    }
}
