using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ParriotWings.Helpers;
using ParriotWings.iOS.Utilities;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Navigation;

namespace ParriotWings.iOS.ViewControllers
{
    partial class MainViewController : UIViewController
    {
        public UIView BalanceCard { get; } = new UIView() 
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIView UserInfoCard { get; } = new UIView()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel BalanceLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel BalanceValueLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel NameLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel NameValueLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel MailLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel MailValueLabel { get; } = new UILabel()
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton ShowTransactionsButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIButton NewTransactionButton { get; } = new UIButton(UIButtonType.System)
        { TranslatesAutoresizingMaskIntoConstraints = false };

        private void InitializeComponent()
        {
            var nav = (IOSNavigationService)ServiceLocator.Current.GetInstance<IExtendedNavigationService>();
            nav.Initialize(this.NavigationController);
            // Email text fiels
            this.View.BackgroundColor = UIColor.FromRGB(98, 174, 136);

            this.NavigationItem.SetLeftBarButtonItem(
                new UIBarButtonItem(LocalizedStrings.Exit, UIBarButtonItemStyle.Plain
            , (sender, args) =>
            {
                Vm.LogoutCommand.Execute(null);
            }), true);

            BalanceCard.BackgroundColor = UIColor.White;
            BalanceCard.Layer.CornerRadius = 5;

            UserInfoCard.BackgroundColor = UIColor.White;
            UserInfoCard.Layer.CornerRadius = 5;

            BalanceLabel.Text = LocalizedStrings.Balance;
            BalanceLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            BalanceLabel.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            BalanceLabel.Lines = 1;
            BalanceLabel.TextAlignment = UITextAlignment.Center;

            BalanceValueLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            BalanceValueLabel.Font = UIFont.BoldSystemFontOfSize(48.0f);
            BalanceValueLabel.Lines = 1;
            BalanceValueLabel.TextAlignment = UITextAlignment.Center;

            NameLabel.Text = LocalizedStrings.Name;
            NameLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            NameLabel.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            NameLabel.Lines = 1;
            NameLabel.TextAlignment = UITextAlignment.Left;

            MailLabel.Text = LocalizedStrings.Email;
            MailLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            MailLabel.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            MailLabel.Lines = 1;
            MailLabel.TextAlignment = UITextAlignment.Left;

            NameValueLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            NameValueLabel.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            NameValueLabel.Lines = 1;
            NameValueLabel.TextAlignment = UITextAlignment.Left;

            MailValueLabel.TextColor = UIColor.FromRGB(28, 104, 66);
            MailValueLabel.Font = UIFont.SystemFontOfSize(16.0f, UIFontWeight.Regular);
            MailValueLabel.Lines = 1;
            MailValueLabel.TextAlignment = UITextAlignment.Left;

            NewTransactionButton.SetTitle(LocalizedStrings.NewTransaction, UIControlState.Normal);
            NewTransactionButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            NewTransactionButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            NewTransactionButton.BackgroundColor = UIColor.FromRGB(28, 104, 66);
            NewTransactionButton.Layer.CornerRadius = 5;
            NewTransactionButton.ClipsToBounds = true;

            ShowTransactionsButton.SetTitle(LocalizedStrings.ShowTransactions, UIControlState.Normal);
            ShowTransactionsButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            ShowTransactionsButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(16.0f);
            ShowTransactionsButton.BackgroundColor = UIColor.FromRGB(28, 104, 66);
            ShowTransactionsButton.Layer.CornerRadius = 5;
            ShowTransactionsButton.ClipsToBounds = true;

            View.AddSubviews(BalanceCard, BalanceLabel, BalanceValueLabel, UserInfoCard, 
                             NameLabel, NameValueLabel, MailLabel, MailValueLabel,
                             NewTransactionButton, ShowTransactionsButton);
            AddLayoutConstraints();
        }

        private void AddLayoutConstraints()
        {
            var constraints = new[]
            {
                NSLayoutConstraint.Create(BalanceCard, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 120),
                NSLayoutConstraint.Create(BalanceCard, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(BalanceCard, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(BalanceCard, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 107),

                NSLayoutConstraint.Create(BalanceLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, BalanceCard, NSLayoutAttribute.Top, 1, 8),
                NSLayoutConstraint.Create(BalanceLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(BalanceLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(BalanceLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(BalanceValueLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, BalanceLabel, NSLayoutAttribute.Bottom, 1, 8),
                NSLayoutConstraint.Create(BalanceValueLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(BalanceValueLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(BalanceValueLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 70),

                NSLayoutConstraint.Create(UserInfoCard, NSLayoutAttribute.Top, NSLayoutRelation.Equal, BalanceCard, NSLayoutAttribute.Bottom, 1, 8),
                NSLayoutConstraint.Create(UserInfoCard, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(UserInfoCard, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(UserInfoCard, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 66),

                NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Top, 1, 8),
                NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Left, 1, 8),
                NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.Width, 1, 50),
                NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(NameValueLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, NameLabel, NSLayoutAttribute.Top, 1, 0),
                NSLayoutConstraint.Create(NameValueLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, NameLabel, NSLayoutAttribute.Right, 1, 8),
                NSLayoutConstraint.Create(NameValueLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Right, 1, -8),
                NSLayoutConstraint.Create(NameValueLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(MailLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, NameLabel, NSLayoutAttribute.Bottom, 1, 8),
                NSLayoutConstraint.Create(MailLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Left, 1, 8),
                NSLayoutConstraint.Create(MailLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.Width, 1, 50),
                NSLayoutConstraint.Create(MailLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(MailValueLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, MailLabel, NSLayoutAttribute.Top, 1, 0),
                NSLayoutConstraint.Create(MailValueLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, MailLabel, NSLayoutAttribute.Right, 1, 8),
                NSLayoutConstraint.Create(MailValueLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Right, 1, -8),
                NSLayoutConstraint.Create(MailValueLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 21),

                NSLayoutConstraint.Create(NewTransactionButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, UserInfoCard, NSLayoutAttribute.Bottom, 1, 8),
                NSLayoutConstraint.Create(NewTransactionButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(NewTransactionButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(NewTransactionButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

                NSLayoutConstraint.Create(ShowTransactionsButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, NewTransactionButton, NSLayoutAttribute.Bottom, 1, 8),
                NSLayoutConstraint.Create(ShowTransactionsButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 28),
                NSLayoutConstraint.Create(ShowTransactionsButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -28),
                NSLayoutConstraint.Create(ShowTransactionsButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1, 50),

            };
            View.AddConstraints(constraints);
        }
    }
}
