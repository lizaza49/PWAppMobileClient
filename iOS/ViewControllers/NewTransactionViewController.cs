using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class NewTransactionViewController 
    {
        private NewTransactionViewModel vm;
        public NewTransactionViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<NewTransactionViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();
            SetUpBindings();
        }

        private void SetUpBindings()
        {
            Bindings.Add(this.SetBinding(
                () => Vm.UserName,
                () => SelectUserButtonLabel.Text,
                BindingMode.OneWay));
            
            AmountTextField.EditingChanged += (s, e) => { };
            Bindings.Add(this.SetBinding(
                () => AmountTextField.Text,
                () => Vm.Amount,
                BindingMode.OneWay));
            
            SelectUserButton.TouchUpInside += (s, e) => { };
            SelectUserButton.SetCommand(
                "TouchUpInside",
                Vm.SelectUsernameCommand);

            SendTransactionButton.TouchUpInside += (s, e) => { };
            SendTransactionButton.SetCommand(
                "TouchUpInside",
                Vm.SendTransactionCommand);
        }
    }
}

