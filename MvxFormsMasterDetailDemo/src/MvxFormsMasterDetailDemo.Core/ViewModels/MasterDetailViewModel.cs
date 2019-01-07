using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxFormsMasterDetailDemo.Core.ViewModels
{
    public class MasterDetailViewModel : MvxViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public MasterDetailViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //public override async Task Initialize()
        //{
        //    await base.Initialize();
        //    await _navigationService.Navigate<MenuViewModel>();
        //    await _navigationService.Navigate<ContactsViewModel>();
        //}

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await _navigationService.Navigate<MenuViewModel>();
            await _navigationService.Navigate<ContactsViewModel>();
            //MvxNotifyTask.Create(async () => await InitializeViewModelsAsync());
        }

        //private async Task InitializeViewModelsAsync()
        //{
        //    await _navigationService.Navigate<MenuViewModel>();
        //    await _navigationService.Navigate<ContactsViewModel>();
        //}
    }
}
