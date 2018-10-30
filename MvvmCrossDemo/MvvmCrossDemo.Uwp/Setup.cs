using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Push;
using MvvmCross.Platforms.Uap.Core;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Infrastructure;

namespace MvvmCrossDemo.Uwp
{
    public class Setup : MvxWindowsSetup<Core.App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            // You must associate your App with Windows Store and copy the SID
            // and Application Secret from the Microsoft Application Registration Portal
            // then set them in AppCenter.
            // RegisterAppCenter();
        }

        private void RegisterAppCenter()
        {
            AppCenter.Start(AppConfiguration.AppCenterUwpAppSecret, typeof(Analytics), typeof(Push));
        }
    }
}
