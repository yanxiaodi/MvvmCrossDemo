using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCrossDemo.Core
{
    public class CustomMvxAppStart<TViewModel> : MvxAppStart<TViewModel>
        where TViewModel : IMvxViewModel
    {
        public CustomMvxAppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override void NavigateToFirstViewModel(object hint)
        {
            NavigationService.Navigate<TViewModel>();
        }
    }
}
