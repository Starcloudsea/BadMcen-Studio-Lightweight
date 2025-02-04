using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BadMC_Launcher.Models.Classes;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Media.Imaging;

namespace BadMC_Launcher.Services.Settings.ThemeSetting;
public class ThemeSettingService : IThemeSettingService {
    private IFileService? fileService = App.Current.Host?.Services.GetService<IFileService>();
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
            if (!SyncSettingSet(value)) {
                //TODO: Exception Dialog
            }

        }
    }

    public ThemeSettingService() {
        var fileService = App.Current.Host?.Services.GetService<IFileService>();
        if (fileService != null) {
            fileService.CheckFolderAndFile(Path.Combine(AppDataPath.AssetsPath, "Wallpapers"), false);
        }
        if (!SyncSettingGet()) {
            //TODO: Exception Dialog
        }
    }

    public async void SetBackground(Action<Brush> backgroundChanged = null) {
        if (backgroundChanged == null) {
            //TODO: 这应该得从代码介入了，应该得Dialog(
            return;
        }
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
        if (fileService != null && fileService.ReadConfig<IThemeSettingService>(Path.Combine(AppDataPath.ConfigsPath, @"Settings\WindowSettings.json"), this, out var returnValue) && returnValue != null) {
            return true;
        }
        return false;
    }

    public bool SyncSettingSet<T>(T settingValue) {
        return fileService != null && fileService.WriteConfig(Path.Combine(AppDataPath.ConfigsPath, @"Settings\WindowSettings.json"), this);
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
