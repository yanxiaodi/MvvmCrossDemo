using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxFormsMasterDetailDemo.Core.ViewModels.Home;

namespace MvxFormsMasterDetailDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}
