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
        private PostListTableSource _source;
        public PostListView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //var _source = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Subtitle, new NSString("PostItemViewCell"), "TitleText Post.Title; DetailText Post.Body");
            _source = new PostListTableSource(TableView);
            TableView.Source = _source;

            var set = this.CreateBindingSet<PostListView, PostListViewModel>();
            set.Bind(_source).To(vm => vm.PostList);
            set.Apply();
            TableView.ReloadData();
        }


    }

    public class PostListTableSource : MvxTableViewSource
    {
        private static readonly NSString PostCellIdentifier = new NSString("PostCell");

        public PostListTableSource(UITableView tableView) : base(tableView)
        {
            //tableView.RegisterNibForCellReuse(UINib.FromName("PostCell", NSBundle.MainBundle), PostCellIdentifier);
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            //var cell = (UITableViewCell) TableView.DequeueReusableCell(PostCellIdentifier, indexPath) ?? new UITableViewCell(UITableViewCellStyle.Subtitle, PostCellIdentifier);
            // You must set the identifier of the table cell in the designer. Otherwise, you must register the table cell first in the constructor.
            var cell = TableView.DequeueReusableCell(PostCellIdentifier, indexPath);
            cell.TextLabel.Text = ((WrapperPostViewModel)item).Post.Title;
            cell.DetailTextLabel.Text = ((WrapperPostViewModel)item).Post.Body;
            cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            var item = this.SelectedItem;
            //System.Diagnostics.Debug.WriteLine((item as WrapperPostViewModel)?.Post.Title);
            ((WrapperPostViewModel)item)?.ShowPostDetailAsyncCommand
                .Execute((WrapperPostViewModel)item);
        }

        public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            base.AccessoryButtonTapped(tableView, indexPath);
            var item = this.ItemsSource.Cast<WrapperPostViewModel>().ToList()[indexPath.Row];
            //System.Diagnostics.Debug.WriteLine((item as WrapperPostViewModel)?.Post.Title);
            item?.EditPostAsyncCommand.Execute(item);
            //var controller = UIAlertController.Create((item as WrapperPostViewModel)?.Post.Title,
            //    (item as WrapperPostViewModel)?.Post.Body, UIAlertControllerStyle.Alert);
        }
    }



}