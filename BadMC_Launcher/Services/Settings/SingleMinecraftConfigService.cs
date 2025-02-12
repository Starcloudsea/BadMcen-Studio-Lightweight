using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Interface;
using BadMC_Launcher.Services.Settings.MinecraftConfig;
using MinecraftLaunch.Base.Models.Game;

namespace BadMC_Launcher.Services.Settings.SingleMinecraftConfig;
public class SingleMinecraftConfigService : IConfigClass {
    private MinecraftEntry? targetMinecraftEntry;
    private bool isFullscreen;
    private bool isEnableIndependencyCore;
    private int minMemorySize;
    private int maxMemorySize;
    private JavaEntry? javaPath;
    private string? launcherName;
    private IEnumerable<string>? jvmArguments;

    public MinecraftEntry? TargetMinecraftEntry {
        get => targetMinecraftEntry;
        set {
            targetMinecraftEntry = value;

            //Write to Json or other logic
            SyncSettingSet();
        }
    }

    public bool IsFullscreen {
        get => isFullscreen;
        set {
            isFullscreen = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool IsEnableIndependencyCore {
        get => isEnableIndependencyCore;
        set {
            isEnableIndependencyCore = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MinMemorySize {
        get => minMemorySize;
        set {
            minMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public int MaxMemorySize {
        get => maxMemorySize;
        set {
            maxMemorySize = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public JavaEntry? JavaPath {
        get => javaPath;
        set {
            javaPath = value;

            //Write to Json 
            SyncSettingSet();
        }
    }

    public string? LauncherName {
        get => launcherName;
        set {
            launcherName = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public IEnumerable<string>? JvmArguments {
        get => jvmArguments;
        set {
            jvmArguments = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public bool SyncSettingGet() {
        if (TargetMinecraftEntry != null) {
            if (File.Exists(Path.Combine(TargetMinecraftEntry.MinecraftFolderPath, @"BadBCConfigs\MinecraftConfig.json"))) {
                if(App.GetService<FileService>().ReadConfig<SingleMinecraftConfigService>(Path.Combine(TargetMinecraftEntry.MinecraftFolderPath, @"BadBCConfigs\MinecraftConfig.json"), SingleMinecraftConfigServiceContext.Default.SingleMinecraftConfigService, out var jsonClass) && jsonClass != null) {
                    isFullscreen = jsonClass.IsFullscreen;
                    isEnableIndependencyCore = jsonClass.IsEnableIndependencyCore;
                    minMemorySize = jsonClass.MinMemorySize;
                    maxMemorySize = jsonClass.MaxMemorySize;
                    javaPath = jsonClass.JavaPath;
                    launcherName = jsonClass.LauncherName;
                    jvmArguments = jsonClass.JvmArguments;
                    return true;
                }
            }
        }
        //TODO: Toast
        return false;
    }

    public bool SyncSettingSet() {
        if (TargetMinecraftEntry != null) {
            return App.GetService<FileService>().WriteConfig<SingleMinecraftConfigService>(Path.Combine(TargetMinecraftEntry.MinecraftFolderPath, @"BadBCConfigs\MinecraftConfig.json"), this, SingleMinecraftConfigServiceContext.Default.SingleMinecraftConfigService);
        }
        //TODO: Toast
        return false;
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(SingleMinecraftConfigService))]
internal partial class SingleMinecraftConfigServiceContext : JsonSerializerContext;
