using Foundation;
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard(nameof(PostDetailView))]
    public partial class PostDetailView : MvxViewController<PostDetailViewModel>
    {
        public PostDetailView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<PostDetailView, PostDetailViewModel>();
            set.Bind(lblTitle).For(x => x.Text).To(vm => vm.Post.Title);
            set.Bind(lblBody).For(x => x.Text).To(vm => vm.Post.Body);
            set.Apply();
        }
    }
}