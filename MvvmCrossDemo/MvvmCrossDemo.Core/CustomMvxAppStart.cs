using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        protected override Task NavigateToFirstViewModel(object hint)
        {
            return NavigationService.Navigate<TViewModel>();
        }

    }
}
