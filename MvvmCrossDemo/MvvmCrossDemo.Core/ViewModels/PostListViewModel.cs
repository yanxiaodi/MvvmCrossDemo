using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Models.Dto;
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
            PostList = new MvxObservableCollection<WrapperPostViewModel>();
            
        }

        public override async Task Initialize()
        {
            // Async initialization, YEY!

            await base.Initialize();
            await GetPostsAsync();

        }


        #region PostList;
        private MvxObservableCollection<WrapperPostViewModel> _postList;
        public MvxObservableCollection<WrapperPostViewModel> PostList
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
                PostList.AddRange(Mapper.Map<List<PostViewModel>>(response.Result)
                    .Select(x => new WrapperPostViewModel(x, ShowPostDetailAsync, EditPostAsync)));
            }
        }
        //#endregion




        
        private async void ShowPostDetailAsync(PostViewModel post)
        {
            await _navigationService.Navigate<PostDetailViewModel, PostViewModel>(post);
        }


        
        private async void EditPostAsync(PostViewModel post)
        {
            await _navigationService.Navigate<PostEditViewModel, PostViewModel>(post);

        }


    }
}
