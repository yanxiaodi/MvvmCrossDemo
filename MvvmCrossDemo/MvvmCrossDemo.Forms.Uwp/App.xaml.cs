using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;

namespace MvvmCrossDemo.Forms.Uwp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : UWPApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }
    }

    public abstract class UWPApplication : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, UI.App>, Core.App, UI.App, MainPage>
    {
    }
}
