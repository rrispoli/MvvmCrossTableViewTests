using CoreGraphics;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCrossTableViewTests.iOS.Views
{
    public class BaseView<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected UIScrollView BaseScrollView;
        protected UIView BaseContentView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.Yellow;
        }

        protected void InitializeScrollView()
        {
            BaseScrollView = new UIScrollView()
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
                TranslatesAutoresizingMaskIntoConstraints = true
            };

            BaseContentView = new UIView();
        }
    }
}