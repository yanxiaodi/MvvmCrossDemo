using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core;
using MvvmCrossDemo.Core.Infrastructure;

namespace MvvmCrossDemo.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            // You must register your App in your Apple Developer Account Portal. Then set the Key in AppCenter.
            //RegisterAppCenter();
        }

        private void RegisterAppCenter()
        {
            AppCenter.Start(AppConfiguration.AppCenterIosAppSecret, typeof(Analytics), typeof(Crashes), typeof(Push));
        }
    }
}