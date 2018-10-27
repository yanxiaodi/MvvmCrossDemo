using Foundation;
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard(nameof(PostListView))]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class PostListView : MvxViewController<PostListViewModel>
    {
        public PostListView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //var source = new MvxStandardTableViewSource(TableView, "TitleText");
            //TableView.Source = source;

            var set = this.CreateBindingSet<PostListView, PostListViewModel>();
            ////set.Bind(source).To(vm => vm.PostList);
            set.Apply();

            //TableView.ReloadData();
        }
    }
}