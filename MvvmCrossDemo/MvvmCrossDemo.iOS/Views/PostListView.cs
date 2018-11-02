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
using CoreGraphics;

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
        //public static readonly UINib Nib = UINib.FromName("PostCell", NSBundle.MainBundle);

        public PostListTableSource(UITableView tableView) : base(tableView)
        {
            //tableView.RegisterNibForCellReuse(UINib.FromName("PostCell", NSBundle.MainBundle), PostCellIdentifier);
            tableView.RegisterClassForCellReuse(typeof(PostListTableCell), PostCellIdentifier);
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            //var cell = (UITableViewCell) TableView.DequeueReusableCell(PostCellIdentifier, indexPath) ?? new UITableViewCell(UITableViewCellStyle.Subtitle, PostCellIdentifier);
            // If you need to difine a customized table cell, use this method:
            // var cell = (PostListTableCell)TableView.DequeueReusableCell(PostCellIdentifier, indexPath);
            // cell.UpdateData((WrapperPostViewModel)item);

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
        }
    }

    [Register("PostCell")]
    public sealed class PostListTableCell : MvxTableViewCell
    {
        private UILabel lablePostTitle;
        private UILabel lablePostBody;

        public PostListTableCell(IntPtr handle) : base(handle)
        {
            CreateLayout();
            InitializeBindings();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var width = ContentView.Frame.Width;
            lablePostTitle.Frame = new CGRect(20, 7, 100, 30);
        }

        //This method is one-way.
        //public void UpdateData(WrapperPostViewModel post)
        //{
        //    lablePostTitle.Text = post.Post.Title;
        //}

        private void CreateLayout()
        {
            //const int offsetStart = 10;
            Accessory = UITableViewCellAccessory.DisclosureIndicator;
            //lblTest = new UILabel(new RectangleF(offsetStart, 0, 75, 40));
            //lblTest = new UILabel(new RectangleF(UIScreen.MainScreen.Bounds.Right - 85, 0, 55, 40));
            //lblTest.TextAlignment = UITextAlignment.Right;
            //lblTest = new UILabel(new RectangleF(jobId.Frame.Right, 0, UIScreen.MainScreen.Bounds.Width - jobId.Frame.Width - hours.Frame.Width - (3 * offsetStart), 40));
            //lblTest.AdjustsFontSizeToFitWidth = true;
            //lblTest.Lines = 0;
            //lblTest.Font = jobName.Font.WithSize(10);
            //ContentView.AddSubviews(jobId, jobName, hours);
            lablePostTitle = new UILabel();
            lablePostBody = new UILabel();
            Accessory = UITableViewCellAccessory.DisclosureIndicator;
            ContentView.AddSubviews(lablePostTitle, lablePostBody);
        }

        private void InitializeBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PostListTableCell, WrapperPostViewModel>();
                set.Bind(lablePostTitle).To(vm => vm.Post.Title).TwoWay();
                set.Bind(lablePostBody).To(vm => vm.Post.Body).TwoWay();
                set.Apply();
            });
        }

        
    }



}