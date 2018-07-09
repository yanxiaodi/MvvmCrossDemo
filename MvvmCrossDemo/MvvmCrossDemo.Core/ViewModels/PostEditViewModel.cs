using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Models.Dto;
using MvvmCrossDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class PostEditViewModel : MvxViewModel<PostViewModel>
    {
        private readonly IPostService _postService;
        private readonly IMvxNavigationService _navigationService;

        private int _postId;


        public PostEditViewModel(IPostService postService, IMvxNavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;
        }

        public override void Prepare(PostViewModel post)
        {
            // This is the first method to be called after construction
            _postId = post.Id;
        }

        public override async Task Initialize()
        {
            // Async initialization, YEY!

            await base.Initialize();
            await GetPost(_postId);
        }


        #region Post;
        private PostViewModel _post;
        public PostViewModel Post
        {
            get => _post;
            set => SetProperty(ref _post, value);
        }
        #endregion


        private async Task GetPost(int postId)
        {
            var response = await _postService.GetPost(postId);
            if (response.IsSuccess)
            {
                Post = AutoMapper.Mapper.Map<PostViewModel>(response.Result);
            }
        }


    }
}
