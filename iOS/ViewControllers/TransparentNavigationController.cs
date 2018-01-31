using System;
using UIKit;

namespace ParriotWings.iOS.ViewControllers
{
    public class TransparentNavigationController : UINavigationController
    {
        public TransparentNavigationController(UIViewController root) : base(root)
        {
            NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
            NavigationBar.Translucent = true;
            NavigationBar.TintColor = UIColor.White;
            NavigationBar.BarStyle = UIBarStyle.Black;
        }
    }
}
