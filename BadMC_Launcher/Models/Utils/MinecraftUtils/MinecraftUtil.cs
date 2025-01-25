using MinecraftLaunch.Classes.Models.Auth;
using MinecraftLaunch.Classes.Models.Launch;

namespace BadMC_Launcher.Models.Utils.MinecraftUtils;

public class MinecraftConfigsUtil {

    private GameWindowConfig _gameWindowSize = new GameWindowConfig();

    private string _javaPath = "";

    private (int MinMemory, int MaxMemory) _gameMemory = new();

    private bool _isCoreDisolated = false;

    private Account _minecraftAccount;
    
    public required GameWindowConfig GameWindowSize {
        get => _gameWindowSize;
        set {
            
        } 
    }

    public string JavaPath { get; set; }
    
    public (int MinMemory, int MaxMemory) GameMemory { get; set; }
    
    public bool IsCoreDisolated { get; set; }
    
    public required Account MinecraftAccount { get; set; }
    
    
}
