using System;
using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.iOS.Views;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class TransactionsViewController
    {
        private const string ReuseId = "TransactionTableViewCellID";

        private TransactionsViewModel vm;
        public TransactionsViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<TransactionsViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        private ObservableTableViewSource<Transaction> source;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();

            source = Vm.Transactions.GetTableViewSource(BindTestTableViewCell, ReuseId, null);
            TableView.RegisterNibForCellReuse(TransactionTableViewCell.Nib, ReuseId);
            TableView.Source = source;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Vm.OnLoadCommand.Execute(null);
        }

        private void BindTestTableViewCell(UITableViewCell cell, Transaction item, NSIndexPath path)
        {
            var castedCell = cell as TransactionTableViewCell;
            if (castedCell == null) { return; }

            castedCell.IdLabel.Text = LocalizedStrings.Id;
            castedCell.DateLabel.Text = LocalizedStrings.Date;
            castedCell.NameLabel.Text = LocalizedStrings.Name;
            castedCell.AmountLabel.Text = LocalizedStrings.Amount;
            castedCell.BalanceLabel.Text = LocalizedStrings.Balance;

            castedCell.IdValueLabel.Text = item.Id.ToString();
            castedCell.DateValueLabel.Text = item.Date;
            castedCell.NameValueLabel.Text = item.Name;
            castedCell.AmountValueLabel.Text = item.Amount.ToString();
            castedCell.BalanceValueLabel.Text = item.Balance.ToString();

        }

    }
}

