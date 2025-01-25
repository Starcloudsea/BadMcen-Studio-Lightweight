using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using BadMC_Launcher.Models.Base;
using BadMC_Launcher.Models.Classes.LaunchConfigs;
using BadMC_Launcher.Models.Utils.FileUtils;
using MinecraftLaunch.Classes.Models.Auth;

namespace BadMC_Launcher.Models.Utils.MinecraftUtils;



public class MinecraftConfigsListUtil {
    
    // Define and initialize fields
    private ConfigList<MinecraftFolderInfo> _minecraftList = new ConfigList<MinecraftFolderInfo>()
        { ClassName = "MinecraftList" };

    private ConfigList<string> _minecraftJdkList = new ConfigList<string>()
        { ClassName = "MinecraftJdkList" };

    private ConfigList<Account> _minecraftAccounts = new ConfigList<Account>()
        { ClassName = "MinecraftAccounts" };
    
    // Define attributes
    public ConfigList<MinecraftFolderInfo> MinecraftList {
        get => _minecraftList;
        set {
            _minecraftList = value;
        }
    }

    public ConfigList<string> MinecraftJdkList {
        get => _minecraftJdkList;
        set {
            _minecraftJdkList = value;
            SyncConfigs(value, nameof(MinecraftJdkList));
        }
    }

    public ConfigList<Account> MinecraftAccounts {
        get => _minecraftAccounts;
        set {
            _minecraftAccounts = value;
            SyncConfigs(value, nameof(MinecraftAccounts));
        }
    }

    public MinecraftConfigsListUtil() {
        // Initialize Property
        if (SyncConfigs<ConfigList<MinecraftFolderInfo>>(nameof(MinecraftList), out var minecraftListReturnValue)) {
            _minecraftList = new ConfigList<MinecraftFolderInfo>(minecraftListReturnValue)
                { ClassName = "MinecraftList" };
        }
        
        if (SyncConfigs<ConfigList<string>>(nameof(MinecraftJdkList), out var minecraftJdkPathReturnValue)) {
            _minecraftJdkList = new ConfigList<string>(minecraftJdkPathReturnValue)
                { ClassName = "MinecraftJdkList" };
        }

        if (SyncConfigs<ConfigList<Account>>(nameof(MinecraftAccounts), out var minecraftAccountsReturnValue)) {
            _minecraftAccounts = new ConfigList<Account>(minecraftAccountsReturnValue)
                { ClassName = "MinecraftAccounts" };
        }
        
        // Attribute events
        _minecraftList.CollectionChanged += OnCollectionChanged<MinecraftFolderInfo>;
        _minecraftJdkList.CollectionChanged += OnCollectionChanged<string>;
        _minecraftAccounts.CollectionChanged += OnCollectionChanged<Account>;

    }

    /// <summary>
    /// Read Sync
    /// </summary>
    public static bool SyncConfigs<T>(string valueName, out T? returnValue) { 
        // Check file
        var status = ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"{valueName}.json", AlterationTags.Create);
        if (!status) {
            // Try read
            if (ConfigFileUtil.ConfigRead<T>("Configs\\MinecraftConfigs", $"{valueName}.json", out var value)) {
                returnValue = value;
                return value != null;
            }
            else {
                // Failed，don't use default value.
                returnValue = default;
                return false;
            }
        }
        // Check failed
        throw new IOException("File Read Error:" + status.ToString());
    }
    
    /// <summary>
    /// Write Sync
    /// </summary>
    public static void SyncConfigs<T>(T value, string className) {
        if (!ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"{className}.json", AlterationTags.Create)) {
            if (ConfigFileUtil.ConfigWrite("Configs\\MinecraftConfigs", $"{className}.json", value)) {
                return;
            }
        }
        throw new IOException();
    }
    
    /// <summary>
    ///  Sync data
    /// </summary>
    private void OnCollectionChanged<T>(object? sender, NotifyCollectionChangedEventArgs e) {
        
        var value = (ConfigList<T>?)sender;
        if (value != null) {
            SyncConfigs(value, value.ClassName);
        }
        else {
            throw new NullReferenceException("value is null.");
        }
    }
}
