using BadMC_Launcher.Classes;
using BadMC_Launcher.Services.ViewServices;
using BadMC_Launcher.Servicess;
using BadMC_Launcher.Servicess.Settings;
using BadMC_Launcher.ViewModels.Pages;
using BadMC_Launcher.Views.Pages;
using BadMC_Launcher.Views.Pages.MainSideBarPages;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using Serilog;
using Uno.Resizetizer;

namespace BadMC_Launcher;
public partial class App : Application {
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() {
        this.InitializeComponent();
    }

    public static new App Current => (App)Application.Current;

    protected Window? MainWindow { get; private set; }
    public IHost? Host { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs args) {
        var builder = this.CreateBuilder(args)
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) => {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Information);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging
                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Debug);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                }, enableUnoLogging: true)
                .UseSerilog(consoleLoggingEnabled: true, fileLoggingEnabled: true, (configuration) => {
                    configuration
                        .MinimumLevel.Error()
                        .WriteTo.Console()
                        .WriteTo.File(
                            path: Path.Combine(AppDataPath.LogsPath, "AppLog.log"), // 更改日志文件的存储位置
                            rollingInterval: RollingInterval.Day,
                            retainedFileCountLimit: 10
                        );
                })
                .ConfigureServices((context, services) => {
                    // TODO: Register your services
                    //Register third-party class
                    services.AddSingleton<HttpClient>();
                    services.AddSingleton<ResourceLoader>();

                    //Regist class
                    services.AddSingleton<ExceptionHandlingService>();
                    services.AddSingleton<FileService>();
                    services.AddSingleton<MinecraftConfigService>();
                    services.AddSingleton<ThemeSettingService>();
                    services.AddSingleton<MainSideBarManagerService>();
                    services.AddTransient<SingleMinecraftConfigService>();

                    //Regist ViewModels
                    services.AddSingleton<MainPageViewModel>();
                })
            );
        MainWindow = builder.Window;
        Host = builder.Build();

        //Get Configs
        GetSettings();

        MainWindow.AppWindow.Title = GetService<ThemeSettingService>().WindowName;
        MainWindow.AppWindow.Resize(AppParameters.windowSize);
        MainWindow.AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
        //TODO: 要是Uno Platform 3月还没回信，那自定义拖拽区域估计只能自己写啦（悲）不过Desktop的三大金刚键肯定得自己写啦（大悲）
#if WINDOWS
        MainWindow.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
        MainWindow.AppWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

#endif

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (MainWindow.Content is not Frame rootFrame) {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            // Place the frame in the current Window
            MainWindow.Content = rootFrame;
        }

        if (rootFrame.Content == null) {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage), args.Arguments);
        }

        //Regist Pages
        RegisterPages();

        // Ensure the current window is active
        MainWindow.Activate();
    }

    //Get Service
    public static T GetService<T>() {
        var services = Current.Host?.Services;
        if (services != null) {
            var service = services.GetService<T>();
            if (service != null) {
                return service;
            }
        }
        throw new InvalidOperationException("Service not found.");
    }

    private void GetSettings() {
        GetService<MinecraftConfigService>().SyncSettingGet();
        GetService<MinecraftConfigService>().isSyncEnabled = true;
        GetService<ThemeSettingService>().SyncSettingGet();
        GetService<ThemeSettingService>().isSyncEnabled = true;
    }

    private void RegisterPages() {
        GetService<MainSideBarManagerService>().Register(new MainSideBarItem() {
            ItemName = App.GetService<ResourceLoader>().GetString("MainMenu_PageNameResource"),
            ItemIcon = new FontIcon() { Glyph = "\uE74C" },
            NavigatePage = typeof(MainMenuPage),
        });
    }
}
