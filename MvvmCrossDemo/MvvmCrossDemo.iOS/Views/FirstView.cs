using Foundation;
using System;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard("Main")]
    public partial class FirstView : UIViewController
    {
        public FirstView (IntPtr handle) : base (handle)
        {
        }
    }
}