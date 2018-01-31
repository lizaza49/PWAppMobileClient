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
    partial class SelectUserViewController : UIViewController
    {
        public UISearchBar SearchBar { get; } = new UISearchBar()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UITableView TableView { get; } = new UITableView()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            this.Title = LocalizedStrings.SelectUser;
            this.View.BackgroundColor = UIColor.White;

            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.FromRGB(28, 104, 66) };
            this.NavigationController.NavigationBar.TintColor = UIColor.FromRGB(28, 104, 66);
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;

            //Search
            SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
            SearchBar.Placeholder = LocalizedStrings.SelectUser;
            SearchBar.AutocorrectionType = UITextAutocorrectionType.No;
            SearchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            SearchBar.EnablesReturnKeyAutomatically = false;
            SearchBar.SearchButtonClicked += SearchBar_SearchButtonClicked;
            SearchBar.TextChanged += SearchBar_TextChanged;
            SearchBar.OnEditingStarted += SearchBar_OnEditingStarted;
            SearchBar.CancelButtonClicked += SearchBar_CancelButtonClicked;
            SearchBar.EnablesReturnKeyAutomatically = true;

            this.View.AddSubviews(SearchBar, TableView);
            AddLayoutConstraints();
        }

        private void AddLayoutConstraints()
        {
            var constraints = new[]
            {
                NSLayoutConstraint.Create(SearchBar, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 64),
                NSLayoutConstraint.Create(SearchBar, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0),
                NSLayoutConstraint.Create(SearchBar, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, 0),
                NSLayoutConstraint.Create(SearchBar, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),
            
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, SearchBar, NSLayoutAttribute.Bottom, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, 0),
                NSLayoutConstraint.Create(TableView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1, 0),
            };
            View.AddConstraints(constraints);
        }

        void SearchBar_SearchButtonClicked(object sender, EventArgs e)
        {
            Vm.GetUserListCommand.Execute(null);
            SearchBar.EndEditing(true);
        }

        void SearchBar_TextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            Vm.SearchQuiry = e.SearchText;
        }

        void SearchBar_OnEditingStarted(object sender, EventArgs e)
        {
            SearchBar.ShowsCancelButton = true;
            Vm.CleanUserListCommand.Execute(null);
        }

        void SearchBar_CancelButtonClicked(object sender, EventArgs e)
        {
            SearchBar.ShowsCancelButton = false;
            Vm.SearchQuiry = String.Empty;
            Vm.CleanUserListCommand.Execute(null);
            SearchBar.Text = String.Empty;
            SearchBar.EndEditing(true);
        }
    }
}
