// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ParriotWings.Helpers;

namespace ParriotWings.iOS.ViewControllers
{
    partial class TransactionsViewController: UIViewController
    {
        public UITableView TableView { get; } = new UITableView()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            this.Title = LocalizedStrings.Transactions;
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            this.View.BackgroundColor = UIColor.FromRGB(28, 104, 66);
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            TableView.BackgroundColor = UIColor.Clear;
            TableView.AllowsSelection = false;

            this.View.AddSubview(TableView);
            AddLayoutConstraints();
        }

        private void AddLayoutConstraints()
        {
            var constraints = new[]
            {
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1, 0),
            };
            View.AddConstraints(constraints);
        }
    }
}
