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

namespace ParriotWings.iOS.ViewControllers
{
    partial class NewTransactionViewController : UIViewController
    {
        public UILabel SelectUserLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel SetAmountLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel SelectUserButtonLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton SelectUserButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UITextField AmountTextField { get; } = new RoundedCornerTextfield(UIColor.FromRGB(240, 240, 240))
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton SendTransactionButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            this.Title = LocalizedStrings.NewTransaction;
            this.View.BackgroundColor = UIColor.White;

            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.FromRGB(28, 104, 66) };
            this.NavigationController.NavigationBar.TintColor = UIColor.FromRGB(28, 104, 66);
            this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;

            SelectUserLabel.Text = LocalizedStrings.SelectUser;
            SelectUserLabel.Font = UIFont.SystemFontOfSize(16.0f);
            SelectUserLabel.TextColor = UIColor.FromRGB(28, 104, 66);

            SetAmountLabel.Text = LocalizedStrings.SetAmount;
            SetAmountLabel.Font = UIFont.SystemFontOfSize(16.0f);
            SetAmountLabel.TextColor = UIColor.FromRGB(28, 104, 66);

            SelectUserButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            SelectUserButton.TitleLabel.Font = UIFont.SystemFontOfSize(16.0f);
            SelectUserButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            SelectUserButton.Layer.CornerRadius = 5;
            SelectUserButton.ClipsToBounds = true;

            AmountTextField.AttributedPlaceholder = new NSAttributedString($"{0}",
                                                                          font: UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular),
                                                                          foregroundColor: UIColor.FromRGB(155, 155, 155));
            AmountTextField.KeyboardType = UIKeyboardType.DecimalPad;
            AmountTextField.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            AmountTextField.AutocapitalizationType = UITextAutocapitalizationType.None;

            SendTransactionButton.SetTitle(LocalizedStrings.Send.ToUpper(), UIControlState.Normal);
            SendTransactionButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            SendTransactionButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            SendTransactionButton.BackgroundColor = UIColor.FromRGB(28, 104, 66);
            SendTransactionButton.Layer.CornerRadius = 5;
            SendTransactionButton.ClipsToBounds = true;

            View.AddSubviews(SelectUserButton, SelectUserLabel, SelectUserButtonLabel,
                             SetAmountLabel, AmountTextField,
                             SendTransactionButton);
            AddLayoutConstraints();
        }

        private void AddLayoutConstraints()
        {
            var constraints = new[]
            {
                NSLayoutConstraint.Create(SelectUserButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 120),
                NSLayoutConstraint.Create(SelectUserButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(SelectUserButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(SelectUserButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

                NSLayoutConstraint.Create(SelectUserButtonLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, SelectUserButton, NSLayoutAttribute.CenterY, 1, 0),
                NSLayoutConstraint.Create(SelectUserButtonLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, SelectUserButton, NSLayoutAttribute.Left, 1, 16),
                NSLayoutConstraint.Create(SelectUserButtonLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, SelectUserButton, NSLayoutAttribute.Right, 1, -16),
                NSLayoutConstraint.Create(SelectUserButtonLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(SelectUserLabel, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, SelectUserButton, NSLayoutAttribute.Top, 1, -4),
                NSLayoutConstraint.Create(SelectUserLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(SelectUserLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(SelectUserLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),
            
                NSLayoutConstraint.Create(SetAmountLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, SelectUserButton, NSLayoutAttribute.Bottom, 1, 4),
                NSLayoutConstraint.Create(SetAmountLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(SetAmountLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(SetAmountLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),
            
                NSLayoutConstraint.Create(AmountTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, SetAmountLabel, NSLayoutAttribute.Bottom, 1, 4),
                NSLayoutConstraint.Create(AmountTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(AmountTextField, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(AmountTextField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),
            
                NSLayoutConstraint.Create(SendTransactionButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, AmountTextField, NSLayoutAttribute.Bottom, 1, 16),
                NSLayoutConstraint.Create(SendTransactionButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(SendTransactionButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(SendTransactionButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),
            
            };
            View.AddConstraints(constraints);
        }
    }
}
