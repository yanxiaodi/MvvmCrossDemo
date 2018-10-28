using System;
using System.Timers;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Infrastructure.Messages;
using MvvmCrossDemo.Core.Models;
using MvvmCrossDemo.Core.Services;
using MvvmCrossDemo.Core.ViewModels;

namespace MvvmCrossDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Bulk Registration by Convention
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //// Singleton Registration
            //Mvx.IoCProvider.RegisterSingleton<IPostService>(new PostService());
            //var postService = Mvx.IoCProvider.Resolve<IPostService>();

            ////Lazy Singleton Registration
            //Mvx.IoCProvider.RegisterSingleton<IPostService>(() => new PostService());

            //// Dynamic Registration
            //Mvx.IoCProvider.RegisterType<IPostService, PostService>();


            RegisterAppStart<FirstViewModel>();

            //RegisterCustomAppStart<CustomMvxAppStart<PostListViewModel>>();
            ModelMapper.Init();

            #region Demonstrating how to use Messenger.

            Mvx.IoCProvider.RegisterSingleton<IMvxMessenger>(new MvxMessengerHub());

            var messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();
            DateTime dtStart = DateTime.Now;
            Timer timer = new Timer { Interval = 1000 };
            timer.Elapsed += (s, e) =>
            {
                var message = new LaunchTimeMessage(this, DateTime.Now.Subtract(dtStart));
                messenger.Publish(message);
            };
            timer.Start();

            #endregion

        }
    }
}
