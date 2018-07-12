using Foundation;
using System;
using System.Drawing;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard("Main")]
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var label = new UILabel(new Rectangle(10, 0, 300, 40))
            {
                Text = "Your Name"
            };
            Add(label);
        }
    }
}