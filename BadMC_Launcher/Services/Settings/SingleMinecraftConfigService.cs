using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Datas.MinecraftDatas;
using BadMC_Launcher.Models.Interface;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;

namespace BadMC_Launcher.Services.Settings;
public class SingleMinecraftConfigService : IConfigClass {
    public string? TargetMinecraftEntryPath {
        get => SingleMinecraftConfig.targetMinecraftEntryPath;
        set {
            SingleMinecraftConfig.targetMinecraftEntryPath = value;

            //Write to Json or other logic
            SyncSettingSet();
        }
    }

    public bool IsFullscreen {
        get => SingleMinecraftConfig.isFullscreen;
        set {
            SingleMinecraftConfig.isFullscreen = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool IsEnableIndependencyCore {
        get => SingleMinecraftConfig.isEnableIndependencyCore;
        set {
            SingleMinecraftConfig.isEnableIndependencyCore = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MinMemorySize {
        get => SingleMinecraftConfig.minMemorySize;
        set {
            SingleMinecraftConfig.minMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MaxMemorySize {
        get => SingleMinecraftConfig.maxMemorySize;
        set {
            SingleMinecraftConfig.maxMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public JavaEntry? JavaPath {
        get => SingleMinecraftConfig.javaPath;
        set {
            SingleMinecraftConfig.javaPath = value;

            //Write to Json 
            SyncSettingSet();
        }
    }

    public string? LauncherName {
        get => SingleMinecraftConfig.launcherName;
        set {
            SingleMinecraftConfig.launcherName = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public IEnumerable<string>? JvmArguments {
        get => SingleMinecraftConfig.jvmArguments;
        set {
            SingleMinecraftConfig.jvmArguments = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool SyncSettingGet() {
        if (TargetMinecraftEntryPath != null) {
            if (File.Exists(Path.Combine(TargetMinecraftEntryPath, @"BadBCConfigs\MinecraftConfig.json"))) {
                if(App.GetService<FileService>().ReadConfig<SingleMinecraftConfigService>(Path.Combine(TargetMinecraftEntryPath, @"BadBCConfigs\MinecraftConfig.json"), SingleMinecraftConfigServiceContext.Default.SingleMinecraftConfigService, out var jsonClass) && jsonClass != null) {
                    SingleMinecraftConfig.isFullscreen = jsonClass.IsFullscreen;
                    SingleMinecraftConfig.isEnableIndependencyCore = jsonClass.IsEnableIndependencyCore;
                    SingleMinecraftConfig.minMemorySize = jsonClass.MinMemorySize;
                    SingleMinecraftConfig.maxMemorySize = jsonClass.MaxMemorySize;
                    SingleMinecraftConfig.javaPath = jsonClass.JavaPath;
                    SingleMinecraftConfig.launcherName = jsonClass.LauncherName;
                    SingleMinecraftConfig.jvmArguments = jsonClass.JvmArguments;
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
