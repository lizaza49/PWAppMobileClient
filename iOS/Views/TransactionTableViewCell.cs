using System;

using Foundation;
using UIKit;

namespace ParriotWings.iOS.Views
{
    public partial class TransactionTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("TransactionTableViewCell");
        public static readonly UINib Nib;

        static TransactionTableViewCell()
        {
            Nib = UINib.FromName("TransactionTableViewCell", NSBundle.MainBundle);
        }

        protected TransactionTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
