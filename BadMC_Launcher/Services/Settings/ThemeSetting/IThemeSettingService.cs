using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace BadMC_Launcher.Services.Settings.ThemeSetting;
public interface IThemeSettingService {
    public BackgroundTypeEnum BackgroundType { get; set; }

    public ThemeTypeEnum ThemeType { get; set; }

    public string ImageBackgroundName { get; set; }

    public Stretch BackgroundStretch { get; set; }

    public string SolidColorBackgroundCode { get; set; }

    public string WindowName { get; set; }

    public void SetBackground(Action<Brush>? backgroundChanged);


}     
