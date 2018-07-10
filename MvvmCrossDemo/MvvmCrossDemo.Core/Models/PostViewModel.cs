using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Models
{
    public class PostViewModel: MvxViewModel
    {

        #region UserId;
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }
        #endregion


        #region Id;
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        #endregion


        #region Title;
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion


        #region Body;
        private string _body;
        public string Body
        {
            get => _body;
            set => SetProperty(ref _body, value);
        }
        #endregion
    }
}
