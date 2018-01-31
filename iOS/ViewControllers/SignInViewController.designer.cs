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
using CoreGraphics;
using ParriotWings.Helpers;
using ParriotWings.iOS.Views;
using ParriotWings.iOS.Utilities;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Navigation;

namespace ParriotWings.iOS.ViewControllers
{
    public partial class SignInViewController : UIViewController
    {
        public UITextField EmailTextField { get; } = new RoundedCornerTextfield(UIColor.White, RoundedCornerTextfield.RoundedTopCorners)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UITextField PasswordTextField { get; } = new RoundedCornerTextfield(UIColor.White, RoundedCornerTextfield.RoundedBottomCorners)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton SignInButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton SignUpButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            var nav = (IOSNavigationService)ServiceLocator.Current.GetInstance<IExtendedNavigationService>();
            nav.Initialize(this.NavigationController);
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            // Email text fiels
            this.View.BackgroundColor = UIColor.DarkGray;
            this.Title = LocalizedStrings.SignIn;
            EmailTextField.AttributedPlaceholder = new NSAttributedString(LocalizedStrings.Email,
                                                                          font: UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular),
                                                                          foregroundColor: UIColor.FromRGB(155, 155, 155));
            EmailTextField.Font = UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular);
            EmailTextField.KeyboardType = UIKeyboardType.EmailAddress;
            EmailTextField.AutocapitalizationType = UITextAutocapitalizationType.None;
            EmailTextField.AutocorrectionType = UITextAutocorrectionType.No;
            var clearButton = new UIButton { Frame = new CGRect(0, 0, 20, 20) };
            clearButton.TouchUpInside += (sender, e) => { EmailTextField.Text = string.Empty; };
            clearButton.SetImage(UIImage.FromBundle("IcoClear"), UIControlState.Normal);
            clearButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            EmailTextField.RightView = clearButton;
            EmailTextField.ClearButtonMode = UITextFieldViewMode.Never;
            EmailTextField.RightViewMode = UITextFieldViewMode.WhileEditing;

            // Password text field
            PasswordTextField.AttributedPlaceholder = new NSAttributedString(LocalizedStrings.Password,
                                                                             font: UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular),
                                                                             foregroundColor: UIColor.FromRGB(155, 155, 155));
            PasswordTextField.SecureTextEntry = true;
            PasswordTextField.Font = UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular);
            PasswordTextField.AutocapitalizationType = UITextAutocapitalizationType.None;
            PasswordTextField.AutocorrectionType = UITextAutocorrectionType.No;
            var showPassword = new UIButton { Frame = new CGRect(0, 0, 20, 20) };
            showPassword.TouchUpInside += (sender, e) =>
            {
                PasswordTextField.SecureTextEntry = !PasswordTextField.SecureTextEntry;
            };
            showPassword.SetImage(UIImage.FromBundle("IcoEye"), UIControlState.Normal);
            showPassword.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            PasswordTextField.RightView = showPassword;
            PasswordTextField.ClearButtonMode = UITextFieldViewMode.Never;
            PasswordTextField.RightViewMode = UITextFieldViewMode.Always;

            // SignIn button
            SignInButton.SetTitle(LocalizedStrings.SignIn.ToUpper(), UIControlState.Normal);
            SignInButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            SignInButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            SignInButton.BackgroundColor = UIColor.FromRGB(128, 204, 166);
            SignInButton.Layer.CornerRadius = 5;
            SignInButton.ClipsToBounds = true;

            // SignUp button
            SignUpButton.SetTitle(LocalizedStrings.SignUp.ToUpper(), UIControlState.Normal);
            SignUpButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            SignUpButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            SignUpButton.BackgroundColor = UIColor.FromRGB(128, 166, 204);
            SignUpButton.Layer.CornerRadius = 5;
            SignUpButton.ClipsToBounds = true;

            View.AddSubviews(EmailTextField, PasswordTextField, SignInButton, SignUpButton);
            AddLayoutConstraints();
        }

        private void AddLayoutConstraints()
        {
            var constraints = new[]
            {
              NSLayoutConstraint.Create(EmailTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 152),
              NSLayoutConstraint.Create(EmailTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(EmailTextField, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(EmailTextField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, EmailTextField, NSLayoutAttribute.Bottom, 1, 1.0f),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

              NSLayoutConstraint.Create(SignInButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, PasswordTextField, NSLayoutAttribute.Bottom, 1, 48),
              NSLayoutConstraint.Create(SignInButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(SignInButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(SignInButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, SignInButton, NSLayoutAttribute.Bottom, 1, 8),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

            };
            View.AddConstraints(constraints);
        }
    }
}
