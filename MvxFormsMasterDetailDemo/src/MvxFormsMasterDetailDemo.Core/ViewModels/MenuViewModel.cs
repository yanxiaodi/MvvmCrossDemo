using System.Collections.ObjectModel;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

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
    }
}
