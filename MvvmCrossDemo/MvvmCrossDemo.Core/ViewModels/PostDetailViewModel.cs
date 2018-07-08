using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class PostDetailViewModel : MvxViewModel<Post>
    {
        private readonly IPostService _postService;
        private int _postId;

        public PostDetailViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public override void Prepare(Post post)
        {
            // This is the first method to be called after construction
            CommentList = new MvxObservableCollection<Comment>();
            _postId = post.Id;
        }

        public override async Task Initialize()
        {
            // Async initialization, YEY!

            await base.Initialize();
            await GetPost(_postId);
            await GetComments(_postId);
        }


        #region Post;
        private Post _post;
        public Post Post
        {
            get => _post;
            set => SetProperty(ref _post, value);
        }
        #endregion

        #region CommentList;
        private MvxObservableCollection<Comment> _commentList;
        public MvxObservableCollection<Comment> CommentList
        {
            get => _commentList;
            set => SetProperty(ref _commentList, value);
        }
        #endregion

        private async Task GetPost(int postId)
        {
            var response = await _postService.GetPost(postId);
            if (response.IsSuccess)
            {
                Post = response.Result;
            }
        }

        private async Task GetComments(int postId)
        {
            var response = await _postService.GetComments(postId);
            if (response.IsSuccess)
            {
                CommentList.AddRange(response.Result);
            }
        }
    }
}
