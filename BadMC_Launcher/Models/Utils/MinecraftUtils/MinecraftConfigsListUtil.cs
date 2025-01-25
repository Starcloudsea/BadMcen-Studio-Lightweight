using BadMC_Launcher.Models.Base;
using BadMC_Launcher.Models.Classes.LaunchConfigs;
using BadMC_Launcher.Models.Utils.FileUtils;
using MinecraftLaunch.Classes.Models.Auth;

namespace BadMC_Launcher.Models.LaunchConfigs.MinecraftLaunch;

public class MinecraftConfigsListUtil {

    private HashSet<MinecraftListConfig> _minecraftList;

    private HashSet<string> _minecraftJdkPath;

    private HashSet<Account> _minecraftAccounts;
    
    public required HashSet<MinecraftListConfig> MinecraftList {
        get {
            return _minecraftList;
        }
        set {
            _minecraftList = value;
            SyncConfigs(value);
        }
    }

    public required HashSet<string> MinecraftJdkPath {
        get {
            return _minecraftJdkPath;
        }
        set {
            _minecraftJdkPath = value;
            SyncConfigs(value);
        }
    }

    public required HashSet<Account> MinecraftAccounts {
        get {
            return _minecraftAccounts;
        }
        set {
            _minecraftAccounts = value;
            SyncConfigs(value);
        }
    }

    public MinecraftConfigsListUtil() {
        _minecraftList = new HashSet<MinecraftListConfig>(SyncConfigs<HashSet<MinecraftListConfig>>(nameof(MinecraftList)));
        _minecraftJdkPath = new HashSet<string>(SyncConfigs<HashSet<string>>(nameof(MinecraftJdkPath)));
        _minecraftAccounts = new HashSet<Account>(SyncConfigs<HashSet<Account>>(nameof(MinecraftAccounts)));
    }

    public T SyncConfigs<T>(string valueName) { 
        var status = ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"{valueName}.json", AlterationTags.Create);
        if (status) { 
            var value = ConfigFileUtil.ConfigRead<T>("Configs\\MinecraftConfigs", $"{valueName}.json");
            return value ?? Activator.CreateInstance<T>();
        }
        throw new IOException();
    }
    
    public void SyncConfigs<T>(T value) {
        string jsonKey = nameof(value);
        if (ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"{jsonKey}.json", AlterationTags.Create)) {
            if (ConfigFileUtil.ConfigWrite("Configs\\MinecraftConfigs", $"{jsonKey}.json", value)) {
                return;
            }
        }
        throw new IOException();
    }
}
