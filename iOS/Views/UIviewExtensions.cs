using System;
using CoreAnimation;
using Foundation;
using UIKit;

namespace ParriotWings.iOS.Views
{
    public static class UIviewExtensions
    {
        public static void Shake(this UIView view)
        {
            var animation = new CAKeyFrameAnimation { KeyPath = "transform.translation.x" };
            animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.Linear);
            animation.Duration = 0.6f;
            animation.Values = new NSNumber[] { -20.0, 20.0, -20.0, 20.0, -10.0, 10.0, -5.0, 5.0, 0.0 };
            view.Layer.AddAnimation(animation, "shake");
        }
    }
}
