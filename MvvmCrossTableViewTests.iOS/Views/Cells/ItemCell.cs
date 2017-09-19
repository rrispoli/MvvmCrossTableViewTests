using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCrossTableViewTests.Core.Entities;
using System;
using UIKit;

namespace MvvmCrossTableViewTests.iOS.Views.Cells
{
    public class ItemCell : MvxTableViewCell
    {
        public UILabel NameLabel;
        public UILabel ObservationsLabel;

        public static readonly NSString Key = new NSString("ItemCell");
        //public static readonly nfloat Height = 30;

        public ItemCell()
        {
            CreateLayout();
            InitializeBindings();
        }

        public ItemCell(IntPtr handle) : base(handle)
        {
            CreateLayout();
            InitializeBindings();
        }

        private void CreateLayout()
        {
            LayoutMargins = UIEdgeInsets.Zero;
            BackgroundColor = UIColor.White;
            SelectionStyle = UITableViewCellSelectionStyle.None;

            NameLabel = new UILabel() { Font = UIFont.SystemFontOfSize(20, UIFontWeight.Bold) };
            ObservationsLabel = new UILabel() { Lines = 0 };

            ContentView.AddSubviews(NameLabel, ObservationsLabel);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(
                NameLabel.AtTopOf(ContentView, 8),
                NameLabel.AtLeftOf(ContentView, 8),
                NameLabel.AtRightOf(ContentView, 8),

                ObservationsLabel.Below(NameLabel, 8),
                ObservationsLabel.WithSameLeft(NameLabel),
                ObservationsLabel.WithSameRight(NameLabel),
                ObservationsLabel.AtBottomOf(ContentView, 8)
            );
        }

        private void InitializeBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ItemCell, Item>();
                set.Bind(NameLabel).To(item => item.Name);
                set.Bind(ObservationsLabel).To(item => item.Observations);
                set.Apply();
            });
        }
    }
}