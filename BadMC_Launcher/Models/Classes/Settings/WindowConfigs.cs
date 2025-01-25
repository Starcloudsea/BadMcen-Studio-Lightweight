using Windows.Graphics;

namespace BadMC_Launcher.Models.Classes.Settings;

public static class WindowConfigs {
    //TODO: MinWindowSize
    public static SizeInt32 WindowSize { get; set; } = new SizeInt32() {
        Width = 948,
        Height = 624
        
    };
    public static string WindowName { get; set; } = "BadMC_Launcher";
}
