using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Helpers;
using ParriotWings.iOS.Utilities;
using ParriotWings.iOS.Views;
using ParriotWings.Navigation;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class SignInViewController
    {
        private SignInViewModel vm;
        public SignInViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<SignInViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();

            //test
            EmailTextField.Text = "test1@test.com";
            PasswordTextField.Text = "123";

            // Bindings
            SetupBinding();
        }

        private void SetupBinding()
        {
            EmailTextField.EditingChanged += (s, e) => { };
            Bindings.Add(this.SetBinding(
                () => EmailTextField.Text,
                () => Vm.Email,
                BindingMode.OneWay));

            PasswordTextField.EditingChanged += (s, e) => { };
            Bindings.Add(this.SetBinding(
                () => PasswordTextField.Text,
                () => Vm.Password,
                BindingMode.OneWay));

            Bindings.Add(this
                          .SetBinding(() => Vm.EmailValidationError)
                          .WhenSourceChanges(() =>
                          {
                              if (Vm.EmailValidationError)
                                  EmailTextField.Shake();
                          }));

            Bindings.Add(this
                          .SetBinding(() => Vm.PasswordValidationError)
                          .WhenSourceChanges(() =>
                          {
                              if (Vm.PasswordValidationError)
                                  PasswordTextField.Shake();
                          }));

            SignInButton.TouchUpInside += (s, e) => { };
            SignInButton.SetCommand(
                "TouchUpInside",
                Vm.SignInCommand);
            
            SignUpButton.TouchUpInside += (s, e) => { };
            SignUpButton.SetCommand(
                "TouchUpInside",
                Vm.SignUpCommand);
        }
    }
}

