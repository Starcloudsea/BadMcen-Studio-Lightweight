using System.Reflection;
using System.Security;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Microsoft.UI.Xaml.Controls;
using MinecraftLaunch.Extensions;

namespace BadMC_Launcher.Servicess;
public class FileService {
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

    public bool ReadConfig<T>(string path, JsonTypeInfo<T> jsonTypeInfo, out T? returnValue) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var fileValue = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(fileValue)) {

                    returnValue = fileValue.Deserialize(jsonTypeInfo);
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

    public bool ReadConfig(string path, out JsonElement? returnValue) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var fileValue = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(fileValue)) {
                    var jsonValue = JsonDocument.Parse(fileValue);
                    if (jsonValue != null) {
                        returnValue = jsonValue.RootElement;
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

    public bool WriteConfig<T>(string path, T value, JsonTypeInfo<T> jsonTypeInfo) {
        if (CheckFolderAndFile(path, true)) {
            try {
                var jsonValue = value.Serialize(jsonTypeInfo);
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
