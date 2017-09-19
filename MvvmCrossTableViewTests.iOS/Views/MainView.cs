using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCrossTableViewTests.Core.ViewModels;
using UIKit;

namespace MvvmCrossTableViewTests.iOS.Views
{
    public class MainView : BaseView<MainViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "MvvmCrossTableViewTests";

            var observerButton = new UIButton() { BackgroundColor = UIColor.Blue };
            observerButton.SetTitle("OBSERVER", UIControlState.Normal);

            var viewWillLayoutSubviewsButton = new UIButton() { BackgroundColor = UIColor.Blue };
            viewWillLayoutSubviewsButton.SetTitle("VIEWWILLLAYOUTSUBVIEWS", UIControlState.Normal);

            var fixedButton = new UIButton() { BackgroundColor = UIColor.Blue };
            fixedButton.SetTitle("FIXED", UIControlState.Normal);

            var bindingSet = this.CreateBindingSet<MainView, MainViewModel>();
            bindingSet.Bind(observerButton).To(vm => vm.GoToDynamicHeightObserverCommand);
            bindingSet.Bind(viewWillLayoutSubviewsButton).To(vm => vm.GoToDynamicHeightViewWillLayoutSubviewsViewModelCommand);
            bindingSet.Bind(fixedButton).To(vm => vm.GoToFixedHeightCommand);
            bindingSet.Apply();

            View.AddSubviews(observerButton, viewWillLayoutSubviewsButton, fixedButton);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                observerButton.WithSameCenterX(View),
                observerButton.WithSameCenterY(View).Minus(30),

                viewWillLayoutSubviewsButton.Below(observerButton, 8),
                viewWillLayoutSubviewsButton.WithSameCenterX(View),

                fixedButton.Below(viewWillLayoutSubviewsButton, 8),
                fixedButton.WithSameCenterX(View)
            );
        }
    }
}