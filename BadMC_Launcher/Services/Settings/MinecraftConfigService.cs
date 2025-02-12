using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Models.Classes.MinecraftClass;
using MinecraftLaunch.Base.Models.Authentication;
using Newtonsoft.Json.Linq;
using MinecraftLaunch.Base.Models.Game;
using Microsoft.Windows.ApplicationModel.Resources;
using BadMC_Launcher.Models.Interface;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace BadMC_Launcher.Services.Settings.MinecraftConfig;
public class MinecraftConfigService : IConfigClass {
    private IEnumerable<Account> minecraftAccounts = new JsonList<Account>();
    private IEnumerable<string> javaPaths = new JsonList<string>();
    private IEnumerable<MinecraftPathEntry> minecraftPaths = new JsonList<MinecraftPathEntry>();
    private MinecraftEntry? activeMinecraftEntry;
    private JavaEntry? activeJavaPath;
    private MinecraftPathEntry? activeMinecraftPath;
    private Account? activeMinecraftAccount;
    private bool isFullscreen = false;
    private bool isEnableIndependencyCore = false;
    private int minMemorySize = 512;
    private int maxMemorySize = 1024;
    private string? launcherName = App.GetService<ResourceLoader>().GetString("MinecraftTitleName");
    private IEnumerable<string>? jvmArguments;

    public MinecraftConfigService() {
        if (minecraftAccounts is JsonList<Account> minecraftAccountsJsonList
            && javaPaths is JsonList<string> javaPathsJsonList
            && minecraftPaths is JsonList<MinecraftPathEntry> minecraftPathsJsonList) {

            //Triggers an event when a property is changed
            minecraftAccountsJsonList.CollectionChanged += OnCollectionChanged<Account>;
            javaPathsJsonList.CollectionChanged += OnCollectionChanged<string>;
            minecraftPathsJsonList.CollectionChanged += OnCollectionChanged<MinecraftPathEntry>;
        }
    }

    public IEnumerable<Account> MinecraftAccounts {
        get => minecraftAccounts;
        set {
            minecraftAccounts = value;

            //Write to Json
            SyncSettingSet();
        }
    }
    public IEnumerable<string> JavaPaths {
        get => javaPaths;
        set {
            javaPaths = value;

            //Write to Json
            SyncSettingSet();
        }
    }
    public IEnumerable<MinecraftPathEntry> MinecraftPaths {
        get => minecraftPaths;
        set {
            minecraftPaths = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public MinecraftEntry? ActiveMinecraftEntry {
        get => activeMinecraftEntry;
        set {
            activeMinecraftEntry = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public JavaEntry? ActiveJavaPath {
        get => activeJavaPath;
        set {
            activeJavaPath = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public MinecraftPathEntry? ActiveMinecraftPath {
        get => activeMinecraftPath;
        set {
            activeMinecraftPath = value;

            //Write to Json
            SyncSettingSet();
        }
    }

    public Account? ActiveMinecraftAccount {
        get => activeMinecraftAccount;
        set {
            activeMinecraftAccount = value;

            //Write to Json
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

    private void OnCollectionChanged<T>(object? sender, NotifyCollectionChangedEventArgs e) {

        if (SyncSettingSet()) {
            //TODO: Dialog
        }
    }

    public bool SyncSettingGet() {
        if (App.GetService<FileService>().ReadConfig<MinecraftConfigService>(Path.Combine(AppDataPath.ConfigsPath, "MinecraftConfigs.json"), MinecraftConfigServiceContext.Default.MinecraftConfigService, out var jsonClass) && jsonClass != null) {
            //TODO: 解蜜
            minecraftAccounts = jsonClass.MinecraftAccounts;
            javaPaths = jsonClass.JavaPaths;
            minecraftPaths = jsonClass.MinecraftPaths;
            activeMinecraftEntry = jsonClass.ActiveMinecraftEntry;
            activeJavaPath = jsonClass.ActiveJavaPath;
            activeMinecraftPath = jsonClass.ActiveMinecraftPath;
            activeMinecraftAccount = jsonClass.ActiveMinecraftAccount;
            isFullscreen = jsonClass.IsFullscreen;
            isEnableIndependencyCore = jsonClass.IsEnableIndependencyCore;
            minMemorySize = jsonClass.MinMemorySize;
            maxMemorySize = jsonClass.MaxMemorySize;
            launcherName = jsonClass.LauncherName;
            jvmArguments = jsonClass.JvmArguments;
            return true;
        }
        return false;
    }

    public bool SyncSettingSet() {
        MinecraftConfigService classValue = this;
        //TODO: 加蜜
        return App.GetService<FileService>().WriteConfig<MinecraftConfigService>(Path.Combine(AppDataPath.ConfigsPath, "MinecraftConfigs.json"), classValue, MinecraftConfigServiceContext.Default.MinecraftConfigService);
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(MinecraftConfigService))]
internal partial class MinecraftConfigServiceContext : JsonSerializerContext;
