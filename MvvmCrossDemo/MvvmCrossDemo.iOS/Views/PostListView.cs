using Foundation;
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Extensions;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.ViewModels;
using UIKit;
using System.Linq;

namespace MvvmCrossDemo.iOS.Views
{
    [MvxFromStoryboard(nameof(PostListView))]
    public partial class PostListView : MvxTableViewController<PostListViewModel>
    {
        private MvxStandardTableViewSource _source;
        public PostListView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _source = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Subtitle, new NSString("SimpleBindableTableViewCell"), "TitleText Post.Title; DetailText Post.Body");
            TableView.Source = _source;

            var set = this.CreateBindingSet<PostListView, PostListViewModel>();
            set.Bind(_source).To(vm => vm.PostList);
            set.Apply();
            TableView.ReloadData();
        }

        
    }
}