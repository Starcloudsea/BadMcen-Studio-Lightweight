using System.Diagnostics;
using System.Security;
using System.Text.Json;
using BadMC_Launcher.Models.Base;

namespace BadMC_Launcher.Models.Utils.FileUtils;

public static class ConfigFileUtil {
    public static bool ChangeConfigFile(string path, string fileName, AlterationTags tags) {
        if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
            try {
                var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
                switch (tags) {
                    case AlterationTags.Create:
                        rootPath.Create().Dispose();
                        return true;
                    case AlterationTags.Delete:
                        if (rootPath.Exists) {
                            rootPath.Delete();
                            return true;
                        }

                        break;
                }
            }
            catch (Exception ex) {
                switch (ex) {
                    case SecurityException:
                        break;
                        
                }
            }
            
        }
        return false;
    }

    public static FileInfo GetFile(string path, string fileName) {
        if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                return rootPath;
            }
        }
        throw new FileNotFoundException($"{path}\\{fileName} is not found.");
    }

    public static bool ConfigWrite<T>(string path, string fileName, T value) {
        if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                var jsonValue = JsonSerializer.Serialize(value);
                File.WriteAllText(rootPath.FullName, jsonValue);
                return true;
            }
        }
        return false;
    }
    public static bool ConfigRead<T>(string path, string fileName, out T? returnValue) {
        if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
            var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
            if (rootPath.Exists) {
                var jsonText = File.ReadAllText(rootPath.FullName);
                if (jsonText.Length > 0) {
                    var jsonValue = JsonSerializer.Deserialize<T>(jsonText);
                    returnValue = jsonValue;
                    return true;
                }
                returnValue = default;
                return false;
            }
        }
        throw new FileNotFoundException($"{path}\\{fileName} is not found.");
    }
}
