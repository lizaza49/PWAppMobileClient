using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.iOS.Views;
using ParriotWings.ViewModels;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class SignUpViewController
    {
        private SignUpViewModel vm;
        public SignUpViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<SignUpViewModel>());

        private readonly List<Binding> Bindings = new List<Binding>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InitializeComponent();

            //test
            EmailTextField.Text = "test5@test.com";
            NameTextField.Text = "test5";
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

            NameTextField.EditingChanged += (s, e) => { };
            Bindings.Add(this.SetBinding(
                () => NameTextField.Text,
                () => Vm.UserName,
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
                          .SetBinding(() => Vm.UserNameValidationError)
                          .WhenSourceChanges(() =>
                          {
                              if (Vm.UserNameValidationError)
                                  NameTextField.Shake();
                          }));

            Bindings.Add(this
                          .SetBinding(() => Vm.PasswordValidationError)
                          .WhenSourceChanges(() =>
                          {
                              if (Vm.PasswordValidationError)
                                  PasswordTextField.Shake();
                          }));

            SignUpButton.TouchUpInside += (s, e) => { };
            SignUpButton.SetCommand(
                "TouchUpInside",
                Vm.SignUpCommand);
        }
    }
}

