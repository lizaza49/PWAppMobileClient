using System;
using CoreGraphics;
using UIKit;

namespace ParriotWings.iOS.Views
{
    public class CustomTextfield : UITextField
    {
        private readonly float padding = 16;

        public CustomTextfield(UIColor background)
        {
            this.BackgroundColor = background;
            this.BorderStyle = UITextBorderStyle.None;
            this.ShouldReturn = (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
        }

        public override CGRect TextRect(CGRect forBounds)
        {
            //return forBounds.Inset(16, 0);

            var bounds = base.TextRect(forBounds);
            var newbounds = bounds.Inset(16, 0);
            return newbounds;

        }


        public override CGRect EditingRect(CGRect forBounds)
        {
            var bounds = base.EditingRect(forBounds);
            var newbounds = bounds.Inset(16, 0);
            return newbounds;
        }

        public override CGRect RightViewRect(CGRect forBounds)
        {
            var x = forBounds.Size.Width - RightView.Bounds.Width - padding;
            var rightBounds = new CGRect(x: x, y: forBounds.Y, width: RightView.Bounds.Width, height: forBounds.Height);
            return rightBounds;
        }
    }
}
