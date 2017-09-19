using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCrossTableViewTests.Core.ViewModels;

namespace MvvmCrossTableViewTests.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //RegisterAppStart<FirstViewModel>();
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}