using System;
using System.Drawing;
using CoreAnimation;
using UIKit;

namespace ParriotWings.iOS.Views
{
    public class RoundedCornerTextfield : CustomTextfield
    {
        private const float CornerRadius = 5.0f;
        private float cornerRadius;
        private UIRectCorner roundedCorners;

        public RoundedCornerTextfield() : base(UIColor.White)
        {
            cornerRadius = CornerRadius;
            roundedCorners = UIRectCorner.AllCorners;
        }

        public RoundedCornerTextfield(UIColor backgroundColor) : base(backgroundColor)
        {
            cornerRadius = CornerRadius;
            roundedCorners = UIRectCorner.AllCorners;
        }

        public RoundedCornerTextfield(UIColor backgroundColor, UIRectCorner cornerFlags) : base(backgroundColor)
        {
            cornerRadius = CornerRadius;
            roundedCorners = cornerFlags;
        }

        private void UpdateMask()
        {
            // Add a layer that holds the rounded corners.
            UIBezierPath maskPath = UIBezierPath.FromRoundedRect(this.Bounds, roundedCorners,
                                                                 new SizeF(cornerRadius, cornerRadius));

            var maskLayer = new CAShapeLayer();
            maskLayer.Frame = this.Bounds;
            maskLayer.Path = maskPath.CGPath;

            // Set the newly created shape layer as the mask for the image view's layer
            this.Layer.Mask = maskLayer;
        }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            UpdateMask();
        }

        public static UIRectCorner RoundedTopCorners = UIRectCorner.TopLeft | UIRectCorner.TopRight;
        public static UIRectCorner RoundedBottomCorners = UIRectCorner.BottomLeft | UIRectCorner.BottomRight;
        public static UIRectCorner RoundedLeftCorners = UIRectCorner.TopLeft | UIRectCorner.BottomLeft;
        public static UIRectCorner RoundedRightCorners = UIRectCorner.TopRight | UIRectCorner.BottomRight;
        public static UIRectCorner NotRoundedCorners;
    }
}
