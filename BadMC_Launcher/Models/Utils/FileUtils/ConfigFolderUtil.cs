using System.Diagnostics;
using System.Security;

namespace BadMC_Launcher.Models.Base;

public static class ConfigFolderUtil {
    
    /// <summary>
    /// This method converts the path parameter to the actual path and then operates on the folder of the path.
    /// </summary>
    /// <param name="path">The path to be registered.</param>
    /// <param name="tags">Different labels represent different ways of operating,
    /// If the value is Create, the folder will be created, if the parent folder does not exist, the parent folder and child folder will be created, and if the folder already exists, it will be skipped.
    /// If the value is Delete, the folder will be deleted, and if the folder does not exist, it will be skipped.</param>
    /// <returns>If the operation succeeds, return true, otherwise return false.</returns>
    /// <exception cref="ArgumentNullException">If the path is empty, this exception will be thrown.</exception>
    /// <exception cref="ArgumentException">This exception is thrown when the path name contains invalid characters.</exception>
    /// <exception cref="PathTooLongException">This exception is thrown when the absolute path after the parameter conversion is too long.</exception>
    /// <exception cref="SecurityException">If there are not enough permissions to operate on the folder, this exception is thrown.</exception>
    public static void ChangeConfigFolder(string path, AlterationTags tags) {

        try {
            var rootPath = new DirectoryInfo(Path.Combine(GlobalDefinition.ConfigPath, path));
            switch (tags) {
                case AlterationTags.Create:
                    if (!rootPath.Exists) {
                        rootPath.Create();
                    }
                    break;
                case AlterationTags.Delete:
                    if (rootPath.Exists) {
                        rootPath.Delete(true);
                    } 
                    break;
            }
        }
        catch (Exception ex) {
            switch (ex) {
                case ArgumentNullException:
                case ArgumentException:
                    //TODO 1
                    break;
                case SecurityException:
                case PathTooLongException:
                    //TODO 2
                    break;
                default:
                    throw;
            }
        }
    }

    
    public static DirectoryInfo GetFolder(string path) {
        var rootPath = new DirectoryInfo(Path.Combine(GlobalDefinition.ConfigPath, path));
        if (rootPath.Exists) {
            return rootPath;
        }
        throw new DirectoryNotFoundException();
    }
}
