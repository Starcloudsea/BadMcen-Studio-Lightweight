using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Datas.SettingsDatas;
using BadMC_Launcher.Interfaces;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;

namespace BadMC_Launcher.Servicess.Settings;
public class SingleMinecraftConfigService : IConfigClass {
    private SingleMinecraftConfig singleMinecraftConfigInstance = new();

    public string? TargetMinecraftEntryPath {
        get => singleMinecraftConfigInstance.targetMinecraftEntryPath;
        set {
            singleMinecraftConfigInstance.targetMinecraftEntryPath = value;

            //Write to Json or other logic
            SyncSettingSet();
        }
    }

    public bool IsFullscreen {
        get => singleMinecraftConfigInstance.isFullscreen;
        set {
            singleMinecraftConfigInstance.isFullscreen = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool IsEnableIndependencyCore {
        get => singleMinecraftConfigInstance.isEnableIndependencyCore;
        set {
            singleMinecraftConfigInstance.isEnableIndependencyCore = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MinMemorySize {
        get => singleMinecraftConfigInstance.minMemorySize;
        set {
            singleMinecraftConfigInstance.minMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MaxMemorySize {
        get => singleMinecraftConfigInstance.maxMemorySize;
        set {
            singleMinecraftConfigInstance.maxMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public JavaEntry? JavaPath {
        get => singleMinecraftConfigInstance.javaPath;
        set {
            singleMinecraftConfigInstance.javaPath = value;

            //Write to Json 
            SyncSettingSet();
        }
    }

    public string? LauncherName {
        get => singleMinecraftConfigInstance.launcherName;
        set {
            singleMinecraftConfigInstance.launcherName = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public IEnumerable<string>? JvmArguments {
        get => singleMinecraftConfigInstance.jvmArguments;
        set {
            singleMinecraftConfigInstance.jvmArguments = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool SyncSettingGet() {
        if (TargetMinecraftEntryPath != null) {
            if (File.Exists(Path.Combine(TargetMinecraftEntryPath, @"BadBCConfigs\MinecraftConfig.json"))) {
                if(App.GetService<FileService>().ReadConfig<SingleMinecraftConfigService>(Path.Combine(TargetMinecraftEntryPath, @"BadBCConfigs\MinecraftConfig.json"), SingleMinecraftConfigServiceContext.Default.SingleMinecraftConfigService, out var jsonClass) && jsonClass != null) {
                    singleMinecraftConfigInstance.isFullscreen = jsonClass.IsFullscreen;
                    singleMinecraftConfigInstance.isEnableIndependencyCore = jsonClass.IsEnableIndependencyCore;
                    singleMinecraftConfigInstance.minMemorySize = jsonClass.MinMemorySize;
                    singleMinecraftConfigInstance.maxMemorySize = jsonClass.MaxMemorySize;
                    singleMinecraftConfigInstance.javaPath = jsonClass.JavaPath;
                    singleMinecraftConfigInstance.launcherName = jsonClass.LauncherName;
                    singleMinecraftConfigInstance.jvmArguments = jsonClass.JvmArguments;
                    return true;
                }
            }
        }
        //TODO: Toast
        return false;
    }

    public bool SyncSettingSet() {
        if (TargetMinecraftEntryPath != null) {
            return App.GetService<FileService>().WriteConfig<SingleMinecraftConfigService>(Path.Combine(TargetMinecraftEntryPath, @"BadBCConfigs\MinecraftConfig.json"), this, SingleMinecraftConfigServiceContext.Default.SingleMinecraftConfigService);
        }
        //TODO: Toast
        return false;
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(SingleMinecraftConfigService))]
internal partial class SingleMinecraftConfigServiceContext : JsonSerializerContext;
