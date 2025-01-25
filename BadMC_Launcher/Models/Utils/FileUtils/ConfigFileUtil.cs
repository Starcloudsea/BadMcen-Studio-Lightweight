using System.Security;
using System.Text.Json;

namespace BadMC_Launcher.Models.Base;

public static class ConfigFileUtil {
    public static void ChangeConfigFile(string path, string fileName, AlterationTags tags) {
        try {
            if (new DirectoryInfo(path).Exists) {
                var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
                switch (tags) {
                    case AlterationTags.Create:
                        rootPath.Create();
                        break;
                    case AlterationTags.Delete:
                        if (rootPath.Exists) {
                            rootPath.Delete();
                        } 
                        break;
                }
            }
            
        }
        catch (Exception ex) {
            switch (ex) {
                case ArgumentNullException:
                case ArgumentException:
                    //TODO 1
                    break;
                case UnauthorizedAccessException:
                case SecurityException:
                case PathTooLongException:
                    //TODO 2
                    break;
                default:
                    throw;
            }
        }
    }
    
    public static FileInfo GetFile(string path, string fileName) {
        if (new DirectoryInfo(path).Exists) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                return rootPath;
            }
        }
        throw new FileNotFoundException();
    }

    public static void ConfigWrite<T>(string path, string fileName, T value) {
        if (new DirectoryInfo(path).Exists) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                var jsonValue = JsonSerializer.Serialize(value);
                File.WriteAllText(rootPath.FullName, jsonValue);
            }
        }
    }
    public static T? ConfigRead<T>(string path, string fileName) {
        if (new DirectoryInfo(path).Exists) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                var jsonText = File.ReadAllText(rootPath.FullName);
                var jsonValue = JsonSerializer.Deserialize<T>(jsonText);
                return jsonValue;
            }
        }
        return default;
    }
}
