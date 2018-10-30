using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace MvvmCrossDemo.Forms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, UI.App>, Core.App, UI.App>
    {
       
    }
}