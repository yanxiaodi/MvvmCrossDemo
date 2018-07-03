using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class PostListViewModel : MvxViewModel
    {
        private readonly IPostService _postService;

        public PostListViewModel(IPostService postService)
        {
            _postService = postService;
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
            PostList.Add(new Post(){ Title = "test"});
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            PostList.Add(new Post() { Title = "test" });
            var response = await _postService.GetPostList();
            if (response.IsSuccess)
            {
                PostList.AddRange(response.Result);
            }
            else
            {
                // TODO； Show some error messages.
            }
        }


        #region PostList;
        private MvxObservableCollection<Post> _postList;
        public MvxObservableCollection<Post> PostList
        {
            get => _postList;
            set => SetProperty(ref _postList, value);
        }
        #endregion



        #region MyCommandCommand;
        public IMvxCommand MyCommandCommand => new MvxCommand(MyCommand);
        private void MyCommand()
        {
            // Implement your logic here.
        }
        #endregion

    }
}
