using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxFormsMasterDetailDemo.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace MvxFormsMasterDetailDemo.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "HamburgerMenu Demo")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}
	}
}
