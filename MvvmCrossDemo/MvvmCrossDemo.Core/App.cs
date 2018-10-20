using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<FirstViewModel>();
            //RegisterCustomAppStart<CustomMvxAppStart<PostListViewModel>>();
            ModelMapper.Init();
        }
    }
}
