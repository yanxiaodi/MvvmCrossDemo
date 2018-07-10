using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        private IMvxCommand _getGreetingCommand;
        public IMvxCommand GetGreetingCommand
        {
            get
            {
                _getGreetingCommand = _getGreetingCommand ?? new MvxCommand(GetGreeting);
                return _getGreetingCommand;
            }
        }
        private void GetGreeting()
        {
            // Implement your logic here.
            _greetingService.GetGreetingText(UserName);
        }
        #endregion


    }
}
