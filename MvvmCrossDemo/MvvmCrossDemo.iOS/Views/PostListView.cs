using Foundation;
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard(nameof(PostListView))]
    public partial class PostListView : MvxTableViewController<PostListViewModel>
    {
        public PostListView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var source = new MvxStandardTableViewSource(TableView, "TitleText Post.Title");
            TableView.Source = source;

            var set = this.CreateBindingSet<PostListView, PostListViewModel>();
            set.Bind(source).To(vm => vm.PostList);
            set.Apply();
            TableView.ReloadData();
        }
    }
}