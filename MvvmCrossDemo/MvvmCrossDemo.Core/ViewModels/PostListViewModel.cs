using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class PostListViewModel : MvxViewModel
    {
        private readonly IPostService _postService;
        private readonly IMvxNavigationService _navigationService;

        public PostListViewModel(IPostService postService, IMvxNavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;
        }

        public override void Prepare()
        {
            // This is the first method to be called after construction
            PostList = new MvxObservableCollection<Post>();
            
        }

        public override async Task Initialize()
        {
            // Async initialization, YEY!

            await base.Initialize();
            await GetPostsAsync();

        }


        #region PostList;
        private MvxObservableCollection<Post> _postList;
        public MvxObservableCollection<Post> PostList
        {
            get => _postList;
            set => SetProperty(ref _postList, value);
        }
        #endregion



        //#region GetPostsCommand;
        private async Task GetPostsAsync()
        {
            // Implement your logic here.
            var response = await _postService.GetPosts();
            if (response.IsSuccess)
            {
                PostList.AddRange(response.Result);
            }
        }
        //#endregion



        #region ShowPostDetailAsyncCommand;
        private IMvxAsyncCommand<Post> _showPostDetailAsyncCommand;
        public IMvxAsyncCommand<Post> ShowPostDetailAsyncCommand
        {
            get
            {
                if (_showPostDetailAsyncCommand != null)
                {
                    return _showPostDetailAsyncCommand;
                }
                _showPostDetailAsyncCommand = new MvxAsyncCommand<Post>(async(post) => await ShowPostDetailAAsync(post));
                return _showPostDetailAsyncCommand;
            }
        }
        private async Task ShowPostDetailAAsync(Post post)
        {
            // Implement your logic here.
            await _navigationService.Navigate<PostDetailViewModel, Post>(post);
        }
        #endregion




    }
}
