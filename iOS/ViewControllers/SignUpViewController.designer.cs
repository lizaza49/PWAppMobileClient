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
using ParriotWings.iOS.Views;
using CoreGraphics;

namespace ParriotWings.iOS.ViewControllers
{
    partial class SignUpViewController : UIViewController
    {

        public UITextField EmailTextField { get; } = new RoundedCornerTextfield(UIColor.White, RoundedCornerTextfield.RoundedTopCorners)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UITextField NameTextField { get; } = new RoundedCornerTextfield(UIColor.White, RoundedCornerTextfield.NotRoundedCorners)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UITextField PasswordTextField { get; } = new RoundedCornerTextfield(UIColor.White, RoundedCornerTextfield.RoundedBottomCorners)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton SignUpButton { get; } = new UIButton(UIButtonType.System) { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            // Email text fiels
            this.View.BackgroundColor = UIColor.FromRGB(98, 136, 174);
            this.Title = LocalizedStrings.SignUp;
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            // Email text field
            EmailTextField.AttributedPlaceholder = new NSAttributedString(LocalizedStrings.Email,
                                                                          font: UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular),
                                                                          foregroundColor: UIColor.FromRGB(155, 155, 155));
            EmailTextField.Font = UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular);
            EmailTextField.KeyboardType = UIKeyboardType.EmailAddress;
            EmailTextField.AutocapitalizationType = UITextAutocapitalizationType.None;
            EmailTextField.AutocorrectionType = UITextAutocorrectionType.No;
            var clearButtonEmail = new UIButton { Frame = new CGRect(0, 0, 20, 20) };
            clearButtonEmail.TouchUpInside += (sender, e) => { EmailTextField.Text = string.Empty; };
            clearButtonEmail.SetImage(UIImage.FromBundle("IcoClear"), UIControlState.Normal);
            clearButtonEmail.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            EmailTextField.RightView = clearButtonEmail;
            EmailTextField.ClearButtonMode = UITextFieldViewMode.Never;
            EmailTextField.RightViewMode = UITextFieldViewMode.WhileEditing;

            // Name text field
            NameTextField.AttributedPlaceholder = new NSAttributedString(LocalizedStrings.Name,
                                                                              font: UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular),
                                                                              foregroundColor: UIColor.FromRGB(155, 155, 155));
            NameTextField.Font = UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular);
            NameTextField.AutocorrectionType = UITextAutocorrectionType.No;
            var clearButtonName = new UIButton { Frame = new CGRect(0, 0, 20, 20) };
            clearButtonName.TouchUpInside += (sender, e) => { NameTextField.Text = string.Empty; };
            clearButtonName.SetImage(UIImage.FromBundle("IcoClear"), UIControlState.Normal);
            clearButtonName.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            NameTextField.RightView = clearButtonName;
            NameTextField.ClearButtonMode = UITextFieldViewMode.Never;
            NameTextField.RightViewMode = UITextFieldViewMode.WhileEditing;

            // Password text field
            PasswordTextField.AttributedPlaceholder = new NSAttributedString(LocalizedStrings.Password,
                                                                             font: UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular),
                                                                             foregroundColor: UIColor.FromRGB(155, 155, 155));
            PasswordTextField.SecureTextEntry = true;
            PasswordTextField.Font = UIFont.SystemFontOfSize(14.0f, UIFontWeight.Regular);
            PasswordTextField.AutocapitalizationType = UITextAutocapitalizationType.None;
            PasswordTextField.AutocorrectionType = UITextAutocorrectionType.No;
            var showPasword = new UIButton { Frame = new CGRect(0, 0, 26, 15) };
            showPasword.TouchUpInside += (sender, e) =>
            {
                PasswordTextField.SecureTextEntry = !PasswordTextField.SecureTextEntry;
            };
            showPasword.SetImage(UIImage.FromBundle("IcoEye"), UIControlState.Normal);
            showPasword.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            PasswordTextField.RightView = showPasword;
            PasswordTextField.ClearButtonMode = UITextFieldViewMode.Never;
            PasswordTextField.RightViewMode = UITextFieldViewMode.Always;

            // SignUp button
            SignUpButton.SetTitle(LocalizedStrings.SignUp.ToUpper(), UIControlState.Normal);
            SignUpButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            SignUpButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            SignUpButton.BackgroundColor = UIColor.FromRGB(128, 204, 166);
            SignUpButton.Layer.CornerRadius = 5;
            SignUpButton.ClipsToBounds = true;

            View.AddSubviews(EmailTextField, NameTextField, PasswordTextField, SignUpButton);
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

              NSLayoutConstraint.Create(NameTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, EmailTextField, NSLayoutAttribute.Bottom, 1, 1.0f),
              NSLayoutConstraint.Create(NameTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(NameTextField, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(NameTextField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, NameTextField, NSLayoutAttribute.Bottom, 1, 1.0f),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(PasswordTextField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),
              
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, PasswordTextField, NSLayoutAttribute.Bottom, 1, 48),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
              NSLayoutConstraint.Create(SignUpButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

            };
            View.AddConstraints(constraints);
        }
    }
}
