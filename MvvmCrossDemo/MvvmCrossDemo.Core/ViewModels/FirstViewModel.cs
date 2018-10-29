using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Core;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Infrastructure.Messages;
using MvvmCrossDemo.Core.Services;
using Xamarin.Essentials;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        private readonly IGreetingService _greetingService;
        private readonly IMvxNavigationService _navigationService;
        private readonly MvxSubscriptionToken _token;
        public FirstViewModel(IGreetingService greetingService, 
            IMvxNavigationService navigationService,
            IMvxMessenger messenger)
        {
            _greetingService = greetingService;
            _navigationService = navigationService;
            _token = messenger.Subscribe<LaunchTimeMessage>((launchTime) =>
                {
                    LaunchTime = $"The App has launched: {launchTime.TimeSpan.Seconds} seconds.";
                });
            
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
                _navToPostListAsyncCommand = 
                    _navToPostListAsyncCommand ?? new MvxAsyncCommand(NavToPostListAsync);
                return _navToPostListAsyncCommand;
            }
        }
        private async Task NavToPostListAsync()
        {
            // Implement your logic here.
            await _navigationService.Navigate<PostListViewModel>();
        }
        #endregion


        #region LaunchTime;
        private string _launchTime;
        public string LaunchTime
        {
            get => _launchTime;
            set => SetProperty(ref _launchTime, value);
        }
        #endregion



        #region SendEmailAsyncCommand;
        private IMvxAsyncCommand _sendEmailAsyncCommand;
        public IMvxAsyncCommand SendEmailAsyncCommand
        {
            get
            {
                _sendEmailAsyncCommand = _sendEmailAsyncCommand ?? new MvxAsyncCommand(SendEmailAsync);
                return _sendEmailAsyncCommand;
            }
        }
        private async Task SendEmailAsync()
        {
            // Implement your logic here.
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Hello Xamarin!",
                    Body = "This is a message from Xamarin.Essentials.",
                    To = new List<string>{"yan_xiaodi@outlook.com"},
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
        #endregion
    }
}
