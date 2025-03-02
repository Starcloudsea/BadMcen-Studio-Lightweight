using BadMC_Launcher.Constants.Enums;
using BadMC_Launcher.Servicess.Settings;
using BadMC_Launcher.ViewModels.Pages;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Animation;

namespace BadMC_Launcher.Views.Pages;

public sealed partial class MainPage : Page {
    public MainPage() {
        this.InitializeComponent();
        DataContext = new MainPageViewModel();

        //Register NavigationToPage Messengers
        WeakReferenceMessenger.Default.Register<ValueChangedMessage<Type>, string>(this, MessengerTokenEnum.MainPage_PageNavigateToken.ToString(), MainFramePageNavigate);
        WeakReferenceMessenger.Default.Register<ValueChangedMessage<Type>, string>(this, MessengerTokenEnum.MainPage_FlyoutPageNavigateToken.ToString(), MainFlyoutFramePageNavigate);

        //Register Frame Messengers
        WeakReferenceMessenger.Default.Register<RequestMessage<Frame>, string>(this, MessengerTokenEnum.MainPage_MainSideBarFrameToken.ToString(), (r, m) => m.Reply(MainSideBarFrame));
        WeakReferenceMessenger.Default.Register<RequestMessage<Frame>, string>(this, MessengerTokenEnum.MainPage_MainSideBarFlyoutFrameToken.ToString(), (r, m) => m.Reply(MainSideBarFlyoutFrame));
    }

    public void MainFramePageNavigate(object recipient, ValueChangedMessage<Type> message) {
        MainSideBarFlyout.Hide();
        if (MainSideBarFrame.Content != null && MainSideBarFrame.Content.GetType() == message.Value) {
            return;
        }

        if (typeof(Page).IsAssignableFrom(message.Value)) {
            MainSideBarFrame.Navigate(message.Value, null, new EntranceNavigationTransitionInfo());
        }
    }

    public void MainFlyoutFramePageNavigate(object recipient, ValueChangedMessage<Type> message) {
        if (MainSideBarFrame.Content != null && MainSideBarFrame.Content.GetType() == message.Value) {
            return;
        }

        if (typeof(Page).IsAssignableFrom(message.Value)) {
            MainSideBarFlyoutFrame.Navigate(message.Value, null, new SuppressNavigationTransitionInfo());
            FlyoutBase.ShowAttachedFlyout(AppTitleBar);
        }
        Debug.WriteLine(message.Value);
    }
}
