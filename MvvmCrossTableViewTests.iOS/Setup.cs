using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;

namespace MvvmCrossTableViewTests.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
        }
    }
}