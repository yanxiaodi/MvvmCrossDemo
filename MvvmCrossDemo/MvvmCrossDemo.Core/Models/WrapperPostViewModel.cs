using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Core.Models
{
    public class WrapperPostViewModel: MvxViewModel
    {
        public PostViewModel Post { get; set; }

        public WrapperPostViewModel(PostViewModel post, Action<PostViewModel> showPostDetailAction, Action<PostViewModel> editPostAction)
        {
            Post = post;
            ShowPostDetailAsyncCommand = new MvxCommand(() => showPostDetailAction(this.Post));
            EditPostAsyncCommand = new MvxCommand(() => editPostAction(this.Post));
        }



        #region ShowPostDetailAsyncCommand;
        public IMvxCommand ShowPostDetailAsyncCommand { get; }

        #endregion

        #region EditPostAsyncCommand;
        public IMvxCommand EditPostAsyncCommand { get; }
        #endregion


    }
}
