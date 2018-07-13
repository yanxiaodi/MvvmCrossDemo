using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace MvvmCrossDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<Core.App>, Core.App>
    {
        // FinishedLaunching is the very first code to be executed in your app. Don't forget to call base!
        //public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        //{
        //    var result = base.FinishedLaunching(application, launchOptions);

        //    return result;
        //}
    }
}


