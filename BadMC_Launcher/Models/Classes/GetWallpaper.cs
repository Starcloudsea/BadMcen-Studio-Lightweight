using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BadMC_Launcher.Models.Classes;
public static class GetWallpaper {
    public static async Task<string> GetBingWallpaperUrl() {
        try {
            var service = AppParameters.Services.GetService<HttpClient>();
            if (service != null) {
                var jsonText = await service.GetStringAsync("https://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=zh-CN");
                using JsonDocument doc = JsonDocument.Parse(jsonText);
                var status = doc.RootElement.TryGetProperty("images", out var imagesjsonElement);
                status = imagesjsonElement[0].TryGetProperty("url", out var urljsonElement);
                if (status == true) {
                    return "https://cn.bing.com" + urljsonElement.GetString() ?? throw new Exception("Can't get Bing wallpapers.");
                }
            }
            
            
        }
        catch (Exception ex) {
            switch (ex) {
                case HttpRequestException:
                case TaskCanceledException:
                    //TODO: Toast Exception
                    break;
                case JsonException:
                    //TODO: Toast Exception
                    break;
                default:
                    throw;
            }
        }
        //TODO: Toast Exception
        throw new Exception("Can't get Bing wallpapers.");
    }
}
