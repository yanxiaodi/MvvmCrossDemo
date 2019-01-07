using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxFormsMasterDetailDemo.Core.ViewModels;

namespace MvxFormsMasterDetailDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}
