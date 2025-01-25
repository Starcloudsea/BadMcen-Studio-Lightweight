using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Text.Json;

namespace BadMC_Launcher.Models.Base;

public enum AlterationTags {
    Create,
    Delete
}

public class ConfigList<T> : ObservableCollection<T> {
    
    public required string ClassName { get; set; }
    
    public ConfigList(IEnumerable<T> initialData) : base(initialData) {
        
    }
    public ConfigList() {
        
    }
    protected override void InsertItem(int index, T item) {
        if (!Contains(item)) {
            base.InsertItem(index, item);
            
        }
    }
    protected override void SetItem(int index, T item) {
        if (!Contains(item)) {
            base.SetItem(index, item);
            
        }
    }
    public override string ToString() {
        return JsonSerializer.Serialize(base.Items);
    }
}

public static class GlobalDefinition {
    
    public static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BadMC_Launcher");
    
}
