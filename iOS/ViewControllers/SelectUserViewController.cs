using System;
using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Entities;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class SelectUserViewController
    {

        private NewTransactionViewModel vm;
        public NewTransactionViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<NewTransactionViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        private ObservableTableViewSource<PWUser> source;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();

            source = Vm.FoundUsers.GetTableViewSource(CreateUserTableViewCell,
                                                      BindUserTableViewCell, "UserCell", factory: null);

            TableView.Source = source;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            source.SelectionChanged += Source_SelectionChanged;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            source.SelectionChanged -= Source_SelectionChanged;
            Vm.CleanUserListCommand.Execute(null);
        }

        void Source_SelectionChanged(object sender, EventArgs e)
        {
            Vm.SetUsernameCommand.Execute(source.SelectedItem.Name);
        }

        private UITableViewCell CreateUserTableViewCell(NSString cellIdentifier)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default,
                                null);
            cell.TextLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            return cell;
        }


        private void BindUserTableViewCell(UITableViewCell cell, PWUser item, NSIndexPath path)
        {
            cell.TextLabel.Text = item.Name;
        }
    }
}

