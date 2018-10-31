using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossDemo.Core.ViewModels;
using System;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard(nameof(FirstView))]
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(txtUserName).For(x => x.Text).To(vm => vm.UserName).TwoWay();
            set.Bind(lblGreeting).For(x => x.Text).To(vm => vm.Greeting);
            set.Bind(btnShowGreeting).To(vm => vm.GetGreetingCommand);
            set.Bind(btnNavToPostList).To(vm => vm.NavToPostListAsyncCommand);
            set.Bind(lblLaunchTime).To(vm => vm.LaunchTime);
            set.Bind(btnSendEmail).To(vm => vm.SendEmailAsyncCommand);
            //set.Bind(tipLabel).To(vm => vm.Tip);
            //set.Bind(totalLabel).To(vm => vm.Total);
            set.Apply();

        }
    }
}