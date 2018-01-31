// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ParriotWings.iOS.Views
{
    [Register ("TransactionTableViewCell")]
    partial class TransactionTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel AmountLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel AmountValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel BalanceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel BalanceValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel DateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel DateValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel IdLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel IdValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel NameValueLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AmountLabel != null) {
                AmountLabel.Dispose ();
                AmountLabel = null;
            }

            if (AmountValueLabel != null) {
                AmountValueLabel.Dispose ();
                AmountValueLabel = null;
            }

            if (BalanceLabel != null) {
                BalanceLabel.Dispose ();
                BalanceLabel = null;
            }

            if (BalanceValueLabel != null) {
                BalanceValueLabel.Dispose ();
                BalanceValueLabel = null;
            }

            if (DateLabel != null) {
                DateLabel.Dispose ();
                DateLabel = null;
            }

            if (DateValueLabel != null) {
                DateValueLabel.Dispose ();
                DateValueLabel = null;
            }

            if (IdLabel != null) {
                IdLabel.Dispose ();
                IdLabel = null;
            }

            if (IdValueLabel != null) {
                IdValueLabel.Dispose ();
                IdValueLabel = null;
            }

            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (NameValueLabel != null) {
                NameValueLabel.Dispose ();
                NameValueLabel = null;
            }
        }
    }
}