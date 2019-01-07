using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace MvxFormsMasterDetailDemo.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<string>()
            {
                "Contacts",
                "Todo"
            };
        }



        #region MenuItemList;
        private ObservableCollection<string> _menuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }
        #endregion


        #region ShowDetailPageAsyncCommand;
        private IMvxAsyncCommand<string> _showDetailPageAsyncCommand;
        public IMvxAsyncCommand<string> ShowDetailPageAsyncCommand
        {
            get
            {
                _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand<string>(ShowDetailPageAsync);
                return _showDetailPageAsyncCommand;
            }
        }
        private async Task ShowDetailPageAsync(string param)
        {
            // Implement your logic here.
            switch (param)
            {
                case "Contacts":
                    await _navigationService.Navigate<ContactsViewModel>();
                    break;
                case "Todo":
                    await _navigationService.Navigate<TodoViewModel>();
                    break;
                default:
                    break;
            }
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage
                     && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }
        #endregion
    }
}
