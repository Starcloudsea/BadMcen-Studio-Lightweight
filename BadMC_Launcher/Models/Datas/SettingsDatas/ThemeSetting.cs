using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Enums;

namespace BadMC_Launcher.Models.Datas.SettingsDatas;
internal static class ThemeSetting {
    internal static BackgroundTypeEnum backgroundType = BackgroundTypeEnum.StaticImage;

    internal static ThemeTypeEnum themeType = ThemeTypeEnum.Light;

    internal static string imageBackgroundName = "WALLPAPER.PNG";

    internal static Stretch backgroundStretch = Stretch.UniformToFill;

    internal static string solidColorBackgroundCode = "#FFFFFFFF";

    internal static string windowName = "BadMC Launcher";
}
