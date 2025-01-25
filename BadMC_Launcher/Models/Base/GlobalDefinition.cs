namespace BadMC_Launcher.Models.Base;

public enum AlterationTags {
    Create,
    Delete
}

public static class GlobalDefinition {
    
    public static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BadMC_Launcher");
    
}
