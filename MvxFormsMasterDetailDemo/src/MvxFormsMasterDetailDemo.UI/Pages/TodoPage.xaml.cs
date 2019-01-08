using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxFormsMasterDetailDemo.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvxFormsMasterDetailDemo.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Todo Page")]
    public partial class TodoPage : MvxContentPage<TodoViewModel>
    {
		public TodoPage ()
		{
			InitializeComponent ();
		}
	}
}
