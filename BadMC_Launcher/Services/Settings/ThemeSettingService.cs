using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Interface;
using BadMC_Launcher.Utilities;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Media.Imaging;

namespace BadMC_Launcher.Services.Settings.ThemeSetting;
public class ThemeSettingService : IConfigClass {
    private BackgroundTypeEnum backgroundType = BackgroundTypeEnum.StaticImage;
    private ThemeTypeEnum themeType = ThemeTypeEnum.Light;
    private string imageBackgroundName = "WALLPAPER.PNG";
    private Stretch backgroundStretch = Stretch.UniformToFill;
    private string solidColorBackgroundCode = "#FFFFFFFF";
    private string windowName = "BadMC Launcher";

    public BackgroundTypeEnum BackgroundType {
        get => backgroundType;
        set {
            backgroundType = value;
            SetBackground();
        }
    }

    public ThemeTypeEnum ThemeType { 
        get => themeType;
        set {
            themeType = value;
        }
    }

    public string ImageBackgroundName {
        get => imageBackgroundName;
        set {
            imageBackgroundName = value;
            SetBackground();
        }
    }

    public Stretch BackgroundStretch {
        get => backgroundStretch;
        set {
            backgroundStretch = value;
            SetBackground();
        }
    }

    public string SolidColorBackgroundCode {
        get => solidColorBackgroundCode;
        set {
            solidColorBackgroundCode = value;
            SetBackground();
        }
    }

    public string WindowName {
        get => windowName;
        set {
            windowName = value;
            if (!SyncSettingSet()) {
                //TODO: Exception Dialog
            }

        }
    }

    public ThemeSettingService() {
        
    }

    public async void SetBackground(Action<Brush>? backgroundChanged = null) {
        if (backgroundChanged == null) {
            //TODO: 这应该得从代码介入了，应该得Dialog(
            return;
        }
        App.GetService<FileService>().CheckFolderAndFile(Path.Combine(AppDataPath.AssetsPath, "Wallpapers"), false);
        switch (backgroundType) {
            case BackgroundTypeEnum.SolidColor:
                var color = ColorTranslator.FromHtml(solidColorBackgroundCode);
                    SetBrushAsync(Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B), backgroundChanged);
                break;
            case BackgroundTypeEnum.StaticImage:
                if (string.IsNullOrWhiteSpace(imageBackgroundName)) {
                    //TODO :Dialog EXCEPTION
                    return;
                }
                SetBrushAsync(new BitmapImage(new Uri(Path.Combine(AppDataPath.AssetsPath, "Wallpapers", imageBackgroundName))), backgroundChanged);
                break;
            case BackgroundTypeEnum.BingWallpaper:
                SetBrushAsync(new BitmapImage(new Uri(await GetWallpaper.GetBingWallpaperUrl())), backgroundChanged);
                break;
            case BackgroundTypeEnum.Acrylic:
                //TODO: Only MacOS
                break;
        }
    }

    public bool SyncSettingGet() {
        if (App.GetService<FileService>().ReadConfig(Path.Combine(AppDataPath.ConfigsPath, @"Settings\ThemeSettings.json"), ThemeSettingServiceContext.Default.ThemeSettingService, out var jsonClass) && jsonClass != null) {
            backgroundType = jsonClass.BackgroundType;
            themeType = jsonClass.ThemeType;
            imageBackgroundName = jsonClass.ImageBackgroundName;
            backgroundStretch = jsonClass.BackgroundStretch;
            solidColorBackgroundCode = jsonClass.SolidColorBackgroundCode;
            windowName = jsonClass.WindowName;
            return true;
        }
        return false;
    }

    public bool SyncSettingSet() {
        return App.GetService<FileService>().WriteConfig<ThemeSettingService>(Path.Combine(AppDataPath.ConfigsPath, @"Settings\ThemeSettings.json"), this, ThemeSettingServiceContext.Default.ThemeSettingService);
    }
    public void SetBrushAsync<T>(T color, Action<Brush> backgroundChanged) {
        if (typeof(T) == typeof(Windows.UI.Color) && color != null) {
            backgroundChanged(new SolidColorBrush((Windows.UI.Color)(object)color));
            return;
        }
        if (typeof(T) == typeof(BitmapImage) && color != null) {
            backgroundChanged(new ImageBrush() {
                ImageSource = (BitmapImage)(object)color,
                Stretch = backgroundStretch
            });
            return;
        }
        throw new InvalidOperationException("Unsupported type for SetBrushAsync");
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(ThemeSettingService))]
internal partial class ThemeSettingServiceContext : JsonSerializerContext;
