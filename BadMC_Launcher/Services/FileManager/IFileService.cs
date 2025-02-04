using System.Text.Json;

namespace BadMC_Launcher.Services.FileManager;
public interface IFileService {
    public bool CheckFolderAndFile(string path, bool isCheckFile);

    //public bool ChangeFile(string path, bool isDelete);

    public bool ReadConfig<T>(string path, T inputClass, out T? returnValue);

    public bool ReadConfig(string path, out JsonDocument? returnValue);

    public bool WriteConfig<T>(string path, T value);

    //public bool ConfigSet<TJson, TValue>(string path, string propertyName, TValue value);
}
