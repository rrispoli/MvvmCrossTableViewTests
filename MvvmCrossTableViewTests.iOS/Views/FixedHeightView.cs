﻿using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCrossTableViewTests.Core.ViewModels;
using MvvmCrossTableViewTests.iOS.Views.Cells;
using UIKit;

namespace MvvmCrossTableViewTests.iOS.Views
{
    public class FixedHeightView : BaseView<FixedHeightViewModel>
    {
        private UITableView _tableView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "FixedHeightView";
            InitializeScrollView();

            var headerLabel = new UILabel() { Text = "Wait 3 seconds...", TextAlignment = UITextAlignment.Center };
            var blueView = new UIView() { BackgroundColor = UIColor.Blue };

            _tableView = new UITableView() { ScrollEnabled = false };
            _tableView.RowHeight = UITableView.AutomaticDimension;
            _tableView.EstimatedRowHeight = 30;
            _tableView.TableFooterView = new UIView();
            var source = new MvxSimpleTableViewSource(_tableView, typeof(ItemCell), ItemCell.Key);
            _tableView.Source = source;

            var greenView = new UIView() { BackgroundColor = UIColor.Green };
            var footerLabel = new UILabel() { Text = "Footer", TextAlignment = UITextAlignment.Center };

            var bindingSet = this.CreateBindingSet<FixedHeightView, FixedHeightViewModel>();
            bindingSet.Bind(source).To(vm => vm.Items);
            bindingSet.Apply();

            _tableView.ReloadData();

            BaseContentView.AddSubviews(headerLabel, blueView, _tableView, greenView, footerLabel);
            BaseScrollView.AddSubviews(BaseContentView);
            View.AddSubviews(BaseScrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                BaseScrollView.AtTopOf(View),
                BaseScrollView.AtLeftOf(View),
                BaseScrollView.AtRightOf(View),
                BaseScrollView.AtBottomOf(View),

                BaseContentView.WithSameWidth(View)
            );

            BaseScrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            BaseScrollView.AddConstraints(
                BaseContentView.Bottom().EqualTo().BottomOf(BaseScrollView),
                BaseContentView.AtTopOf(BaseScrollView)
            );

            BaseContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            BaseContentView.AddConstraints(
                headerLabel.AtTopOf(BaseContentView, 8),
                headerLabel.AtLeftOf(BaseContentView, 8),
                headerLabel.AtRightOf(BaseContentView, 8),

                blueView.Below(headerLabel, 8),
                blueView.WithSameLeft(headerLabel),
                blueView.WithSameRight(headerLabel),
                blueView.Height().EqualTo(50),

                _tableView.Below(blueView, 8),
                _tableView.WithSameLeft(headerLabel),
                _tableView.WithSameRight(headerLabel),

                //Fixed height with an "expected value", make the UITableView.AutomaticDimension works, but it's impossible to predict what is the correct height with variable cell height
                _tableView.Height().EqualTo(700),

                greenView.Below(_tableView, 8),
                greenView.WithSameLeft(headerLabel),
                greenView.WithSameRight(headerLabel),
                greenView.WithSameHeight(blueView),

                footerLabel.Below(greenView, 8),
                footerLabel.WithSameLeft(headerLabel),
                footerLabel.WithSameRight(headerLabel),
                footerLabel.AtBottomOf(BaseContentView, 8)
            );
        }
    }
}