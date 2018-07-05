using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        private readonly IGreetingService _greetingService;
        public FirstViewModel(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        
        #region UserName;
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        #endregion

        #region Greeting;
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            set => SetProperty(ref _greeting, value);
        }
        #endregion


        #region GetGreetingCommand;
        public IMvxCommand GetGreetingCommand => new MvxCommand(GetGreeting);
        private void GetGreeting()
        {
            Greeting = _greetingService.GetGreetingText(UserName);
        }
        #endregion
    }
}
