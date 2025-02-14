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
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml.Media.Imaging;
using BadMC_Launcher.Models.Datas.MinecraftDatas;

namespace BadMC_Launcher.Services.Settings;
public class ThemeSettingService : IConfigClass {
    internal bool isSyncEnabled = false;

    public BackgroundTypeEnum BackgroundType {
        get => ThemeSetting.backgroundType;
        set {
            ThemeSetting.backgroundType = value;
            SetBackground();
        }
    }

    public ThemeTypeEnum ThemeType { 
        get => ThemeSetting.themeType;
        set {
            ThemeSetting.themeType = value;
        }
    }

    public string ImageBackgroundName {
        get => ThemeSetting.imageBackgroundName;
        set {
            ThemeSetting.imageBackgroundName = value;
            SetBackground();
        }
    }

    public Stretch BackgroundStretch {
        get => ThemeSetting.backgroundStretch;
        set {
            ThemeSetting.backgroundStretch = value;
            SetBackground();
        }
    }

    public string SolidColorBackgroundCode {
        get => ThemeSetting.solidColorBackgroundCode;
        set {
            ThemeSetting.solidColorBackgroundCode = value;
            SetBackground();
        }
    }

    public string WindowName {
        get => ThemeSetting.windowName;
        set {
            ThemeSetting.windowName = value;
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
        switch (ThemeSetting.backgroundType) {
            case BackgroundTypeEnum.SolidColor:
                var color = ColorTranslator.FromHtml(ThemeSetting.solidColorBackgroundCode);
                    SetBrushAsync(Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B), backgroundChanged);
                break;
            case BackgroundTypeEnum.StaticImage:
                if (string.IsNullOrWhiteSpace(ThemeSetting.imageBackgroundName)) {
                    //TODO :Dialog EXCEPTION
                    return;
                }
                SetBrushAsync(new BitmapImage(new Uri(Path.Combine(AppDataPath.AssetsPath, "Wallpapers", ThemeSetting.imageBackgroundName))), backgroundChanged);
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
            ThemeSetting.backgroundType = jsonClass.BackgroundType;
            ThemeSetting.themeType = jsonClass.ThemeType;
            ThemeSetting.imageBackgroundName = jsonClass.ImageBackgroundName;
            ThemeSetting.backgroundStretch = jsonClass.BackgroundStretch;
            ThemeSetting.solidColorBackgroundCode = jsonClass.SolidColorBackgroundCode;
            ThemeSetting.windowName = jsonClass.WindowName;
            return true;
        }
        return false;
    }

    public bool SyncSettingSet() {
        if (App.GetService<FileService>().WriteConfig(Path.Combine(AppDataPath.ConfigsPath, @"Settings\ThemeSettings.json"), this, ThemeSettingServiceContext.Default.ThemeSettingService)) {
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<ThemeSettingService>(this), "MinecraftConfigChanged");
            return true;
        }
        return false;
    }
    public void SetBrushAsync<T>(T color, Action<Brush> backgroundChanged) {
        if (typeof(T) == typeof(Windows.UI.Color) && color != null) {
            backgroundChanged(new SolidColorBrush((Windows.UI.Color)(object)color));
            return;
        }
        if (typeof(T) == typeof(BitmapImage) && color != null) {
            backgroundChanged(new ImageBrush() {
                ImageSource = (BitmapImage)(object)color,
                Stretch = ThemeSetting.backgroundStretch
            });
            return;
        }
        throw new InvalidOperationException("Unsupported type for SetBrushAsync");
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(ThemeSettingService))]
internal partial class ThemeSettingServiceContext : JsonSerializerContext;
