using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.iOS.Utilities;
using ParriotWings.Navigation;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class MainViewController : UIViewController
    {
        private MainViewModel vm;
        public MainViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<MainViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();

            SetupBinding();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            Vm.OnLoadCommand.Execute(null);
        }

        private void SetupBinding()
        {
            Bindings.Add(this.SetBinding(
                () => Vm.UserName,
                () => NameValueLabel.Text,
                BindingMode.OneWay));

            Bindings.Add(this.SetBinding(
                () => Vm.UserEmail,
                () => MailValueLabel.Text,
                BindingMode.OneWay));

            Bindings.Add(this.SetBinding(
                () => Vm.Balance,
                () => BalanceValueLabel.Text,
                BindingMode.OneWay));

            ShowTransactionsButton.TouchUpInside += (s, e) => { };
            ShowTransactionsButton.SetCommand(
                "TouchUpInside",
                Vm.ShowTransactionsCommand);

            NewTransactionButton.TouchUpInside += (s, e) => { };
            NewTransactionButton.SetCommand(
                "TouchUpInside",
                Vm.NewTransactionCommand);
        }
    }
}

