using System.Reflection;
using System.Security;
using System.Text.Encodings.Web;
using System.Text.Json;
using static Uno.UI.RemoteControl.HotReload.ClientHotReloadProcessor;

namespace BadMC_Launcher.Services.FileManager;
public class FileService : IFileService {
    public bool CheckFolderAndFile(string path, bool isCheckFile) {
        if (isCheckFile ? File.Exists(path) : Path.Exists(path)) {
            return true;
        }
        else {
            try {
                if (isCheckFile) {
                    var directory = Path.GetDirectoryName(path);
                    if (directory != null) {
                        Directory.CreateDirectory(directory);
                    }
                    using (File.Create(path)) {
                        return true;
                    }
                }
                else {
                    Directory.CreateDirectory(path);
                    return true;
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
                    case IOException:
                        //TODO
                        break;
                    default:
                        throw;
                }
            }
        }
        return false;
    }
    //计划弃用
    //public bool ChangeFile(string path, bool isDelete) {
    //    if (CheckFolderAndFile(path, true)) {
    //        try {
    //            if (isDelete) {
    //                File.Delete(path);
    //            }
    //            else {
    //                using (File.Create(path)) {
    //                    return true;
    //                }
    //            }
    //        }
    //        catch (Exception ex) {
    //            switch (ex) {
    //                case SecurityException:
    //                    //TODO
    //                    break;
    //                case UnauthorizedAccessException:
    //                    //TODO
    //                    break;
    //                case PathTooLongException:
    //                    //TODO
    //                    break;
    //                case IOException:
    //                    //TODO
    //                    break;
    //                default:
    //                    throw;
    //            }
    //        }
    //    }
    //    return false;
    //}

    public bool ReadConfig<T>(string path, T? inputClass, out T? returnValue) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var fileValue = File.ReadAllText(path);
                if (!String.IsNullOrWhiteSpace(fileValue)) {
                    using (JsonDocument document = JsonDocument.Parse(fileValue)) {
                        JsonElement root = document.RootElement;
                        var status = false;
                        foreach (JsonProperty property in root.EnumerateObject()) {
                            //TODO: 这放个throw不合适哈，到时候改成DialogEx（
                            PropertyInfo propInfo = typeof(T).GetProperty(property.Name) ?? throw new ArgumentException($"Property '{property.Name}' not found.");
                            propInfo.SetValue(inputClass, JsonSerializer.Deserialize(property.Value.GetRawText(), propInfo.PropertyType));
                        }
                        if (inputClass != null) {
                            returnValue = inputClass;
                            status = inputClass != null;
                            return true;
                        }
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
                    case IOException:
                        //TODO
                        break;
                    case JsonException:
                        //TODO
                        break;
                    default:
                        throw;
                }
            }
        }
        returnValue = default;
        return false;
    }

    public bool ReadConfig(string path, out JsonDocument? returnValue) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var fileValue = File.ReadAllText(path);
                if (!String.IsNullOrWhiteSpace(fileValue)) {
                    var jsonValue = JsonDocument.Parse(fileValue);
                    if (jsonValue != null) {
                        returnValue = jsonValue;
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
                    case IOException:
                        //TODO
                        break;
                    case JsonException:
                        //TODO
                        break;
                    default:
                        throw;
                }
            }
        }
        returnValue = default;
        return false;
    }

    public bool WriteConfig<T>(string path, T value) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var options = new JsonSerializerOptions {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                var jsonValue = JsonSerializer.Serialize<T>(value, options);
                File.WriteAllText(path, jsonValue);
                return true;
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
                    case IOException:
                        //TODO
                        break;
                    case JsonException:
                        //TODO
                        break;
                    default:
                        throw;
                }
            }
        }
        return false;
    }
    //public bool ConfigSet<TJson, TValue>(string path, string propertyName, TValue value) {
    //    //Check
    //    if (CheckFolderAndFile(path, true)) {
    //        try {
    //            //Read JSON data from a file and deserialize it.
    //            if (ReadConfig<TJson>(path, out var returnValue) && returnValue != null) {
    //                //Get the property information of the specified property.
    //                PropertyInfo? propertyInfo = typeof(TJson).GetProperty(propertyName);
    //                //Set the value of the specified property.
    //                if (propertyInfo != null && propertyInfo.CanWrite) {
    //                    propertyInfo.SetValue(returnValue, value);
    //                }
    //                else {
    //                    throw new ArgumentException($"Property '{propertyName}' not found or is read-only.");
    //                }
    //                return WriteConfig(path, returnValue);
    //            }
    //        }
    //        catch (Exception ex) {
    //            switch (ex) {
    //                case SecurityException:
    //                    //TODO
    //                    break;
    //                case UnauthorizedAccessException:
    //                    //TODO
    //                    break;
    //                case PathTooLongException:
    //                    //TODO
    //                    break;
    //                case IOException:
    //                    //TODO
    //                    break;
    //                case JsonException:
    //                    //TODO
    //                    break;
    //                default:
    //                    throw;
    //            }
    //        }
    //    }
    //    return false;
    //}
}
