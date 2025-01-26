using System.Diagnostics;
using System.Security;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                        //TODO
                        break;
                    case UnauthorizedAccessException:
                        //TODO
                        break;
                    case PathTooLongException:
                        //TODO
                        break;
                    default:
                        throw;
                }
            }
            
        }
        return false;
    }

    public static FileInfo? GetFile(string path, string fileName) {
        if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
            try {
                var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
                if (rootPath.Exists) {
                    return rootPath;
                }
            } 
            catch (Exception ex) {
                switch (ex) {
                    case SecurityException:
                        //TODO
                        break;
                    case UnauthorizedAccessException:
                        //TODO
                        break;
                    case PathTooLongException:
                        //TODO
                        break;
                    default:
                        throw;
                }
                return null;
            }   
        }
        throw new FileNotFoundException($"{path}\\{fileName} is not found.");
    }

    public static bool ConfigWrite<T>(string path, string fileName, T value) {
        // Json Config
        var jsonSerializerOptions = new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
        try {
            // Check Folder
            if (Path.Exists(Path.Combine(GlobalDefinition.ConfigPath, path))) {
                var rootPath = new FileInfo(Path.Combine(GlobalDefinition.ConfigPath, path, fileName));
                if (rootPath.Exists) {
                    // To Json
                    var jsonValue = JsonSerializer.Serialize(value, jsonSerializerOptions);
                    // Write To File
                    File.WriteAllText(rootPath.FullName, jsonValue);
                    return true;
                }
            }
        }
        catch (Exception ex) {
            switch (ex) {
                case SecurityException:
                    //TODO
                    break;
                case UnauthorizedAccessException:
                    //TODO
                    break;
                case PathTooLongException:
                    //TODO
                    break;
                default:
                    throw;
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
