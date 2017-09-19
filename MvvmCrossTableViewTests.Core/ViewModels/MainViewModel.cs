using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;

namespace MvvmCrossTableViewTests.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public IMvxAsyncCommand GoToDynamicHeightObserverCommand => new MvxAsyncCommand(() => Mvx.Resolve<IMvxNavigationService>().Navigate<DynamicHeightObserverViewModel>());
        public IMvxAsyncCommand GoToDynamicHeightViewWillLayoutSubviewsViewModelCommand => new MvxAsyncCommand(() => Mvx.Resolve<IMvxNavigationService>().Navigate<DynamicHeightViewWillLayoutSubviewsViewModel>());
        public IMvxAsyncCommand GoToFixedHeightCommand => new MvxAsyncCommand(() => Mvx.Resolve<IMvxNavigationService>().Navigate<FixedHeightViewModel>());
    }
}