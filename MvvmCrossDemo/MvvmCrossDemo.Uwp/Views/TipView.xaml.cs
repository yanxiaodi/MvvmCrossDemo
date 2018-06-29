using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MvvmCrossDemo.Uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(TipViewModel))]
    public sealed partial class TipView : BaseView
    {
        public TipView()
        {
            this.InitializeComponent();
        }
    }
}
