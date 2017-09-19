using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace MvvmCrossTableViewTests.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        private UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.window = new UIWindow(UIScreen.MainScreen.Bounds);

            Setup setup = new Setup(this, this.window);
            setup.Initialize();

            IMvxAppStart startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            this.window.MakeKeyAndVisible();

            ApplyStyle(app);

            return true;
        }

        private void ApplyStyle(UIApplication application)
        {
            //UIStatusBar
            application.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);

            //UINavigationBar
            UINavigationBar.Appearance.BarTintColor = UIColor.Red;
            UINavigationBar.Appearance.BarStyle = UIBarStyle.Default;
            UINavigationBar.Appearance.Translucent = false; //Precisa NavigationBarHidden = true; em cada Tab

            UINavigationBar.Appearance.TintColor = UIColor.White;
            var navigationBarTextAttributes = UINavigationBar.Appearance.GetTitleTextAttributes();
            navigationBarTextAttributes.TextColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(navigationBarTextAttributes);

            //UITableView
            UITableView.Appearance.BackgroundColor = UIColor.White;
            UITableView.Appearance.SeparatorInset = UIEdgeInsets.Zero;

            //UITableViewCell
            //UITableViewCell.Appearance.BackgroundColor = UIColor.White;
        }
    }
}