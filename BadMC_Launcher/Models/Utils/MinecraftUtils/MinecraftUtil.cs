using BadMC_Launcher.Models.Base;
using BadMC_Launcher.Models.Classes.LaunchConfigs;
using BadMC_Launcher.Models.Utils.FileUtils;
using MinecraftLaunch.Classes.Models.Auth;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Resolver;

namespace BadMC_Launcher.Models.Utils.MinecraftUtils;

public class MinecraftUtil {

    private MinecraftFolderInfo? _minecraftFolder;

    private GameWindowConfig _gameWindowSize = new();

    private string _javaPath = "";

    private (int MinMemory, int MaxMemory) _gameMemory = (512, 1024);

    private bool _isCoreDisolated = false;

    private Account? _minecraftAccount;
    
    private ServerConfig? _minecraftServer;
    
    public MinecraftFolderInfo? MinecraftFolder {
        get => _minecraftFolder;
        set {
            _minecraftFolder = value;
            SyncConfigs();
        } 
    }
    public GameWindowConfig GameWindowSize {
        get => _gameWindowSize;
        set {
            _gameWindowSize = value;
            SyncConfigs();
        } 
    }

    public string JavaPath {
        get => _javaPath;
        set {
            _javaPath = value;
            SyncConfigs();
        }
    }

    public (int MinMemory, int MaxMemory) GameMemory {
        get => _gameMemory;
        set {
            _gameMemory = value;
            SyncConfigs();
        }
    }
    
    public bool IsCoreDisolated {
        get => _isCoreDisolated;
        set {
            _isCoreDisolated = value;
            SyncConfigs();
        }
    }
    
    public Account? MinecraftAccount {
        get => _minecraftAccount;
        set {
            _minecraftAccount = value;
            SyncConfigs();
        }
    }
    
    public ServerConfig? MinecraftServer {
        get => _minecraftServer;
        set {
            _minecraftServer = value;
            SyncConfigs();
        } 
    }

    public MinecraftUtil() {
        // Initialize Property
        if (SyncConfigs(out var returnValue) && returnValue != null) {
            _minecraftFolder = returnValue.MinecraftFolder;
            _gameWindowSize = returnValue.GameWindowSize;
            _javaPath = returnValue.JavaPath;
            _gameMemory = returnValue.GameMemory;
            _isCoreDisolated = returnValue.IsCoreDisolated;
            _minecraftAccount = returnValue.MinecraftAccount;
            _minecraftServer = returnValue.MinecraftServer;
        }
    }
    
    /// <summary>
    /// Read Sync
    /// </summary>
    public bool SyncConfigs(out MinecraftUtil? returnValue) { 
        // Check file
        var status = ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"LaunchConfigs.json", AlterationTags.Create);
        if (!status) {
            // Try read
            if (ConfigFileUtil.ConfigRead<MinecraftUtil>("Configs\\MinecraftConfigs", $"LaunchConfigs.json",
                    out var value)) {
                returnValue = value;
                return value != null;
            }
            else {
                // Failed，don't use default value.
                returnValue = null;
                return false;
            }
        }
        // Check failed
        throw new IOException("File Read Error:" + status.ToString());
    }
    
    /// <summary>
    /// Write Sync
    /// </summary>
    public void SyncConfigs() {
        if (ConfigFileUtil.ChangeConfigFile("Configs\\MinecraftConfigs", $"LaunchConfigs.json",
                AlterationTags.Create)) {
            if (ConfigFileUtil.ConfigWrite("Configs\\MinecraftConfigs", $"LaunchConfigs.json", this)) {
                return;
            }
        }
        throw new IOException();
    }

    public async static Task LaunchMinecraft(MinecraftUtil launchConfigs) {
        if (string.IsNullOrWhiteSpace(launchConfigs.JavaPath) || launchConfigs.MinecraftAccount == null || launchConfigs.MinecraftFolder == null) {
            var config = new LaunchConfig {
                Account = launchConfigs.MinecraftAccount,
                GameWindowConfig = new GameWindowConfig {
                    Width = launchConfigs.GameWindowSize.Width,
                    Height = launchConfigs.GameWindowSize.Height,
                    IsFullscreen = launchConfigs.GameWindowSize.IsFullscreen
                },
                JvmConfig = new JvmConfig(launchConfigs.JavaPath) {
                    MaxMemory = launchConfigs.GameMemory.MaxMemory,
                    MinMemory = launchConfigs.GameMemory.MinMemory
                },
                IsEnableIndependencyCore = launchConfigs.IsCoreDisolated
            };
            if (launchConfigs.MinecraftServer != null) {
                config.ServerConfig = launchConfigs.MinecraftServer;
            }
        }
        else {
            //TODO: ErrorList
        }
    }
}
