using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        private readonly IGreetingService _greetingService;
        private readonly IMvxNavigationService _navigationService;

        public FirstViewModel(IGreetingService greetingService, IMvxNavigationService navigationService)
        {
            _greetingService = greetingService;
            _navigationService = navigationService;
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
            Greeting = _greetingService.GetGreetingText(UserName);
        }
        #endregion


        #region NavToPostListAsyncCommand;
        private IMvxAsyncCommand _navToPostListAsyncCommand;
        public IMvxAsyncCommand NavToPostListAsyncCommand
        {
            get
            {
                _navToPostListAsyncCommand = _navToPostListAsyncCommand ?? new MvxAsyncCommand(NavToPostListAsync);
                return _navToPostListAsyncCommand;
            }
        }
        private async Task NavToPostListAsync()
        {
            // Implement your logic here.
            await _navigationService.Navigate<PostListViewModel>();
        }
        #endregion
    }
}
