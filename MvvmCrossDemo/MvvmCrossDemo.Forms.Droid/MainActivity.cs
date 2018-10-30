using Android.App;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MvvmCrossDemo.Forms.Droid
{
    [Activity(Label = "MvvmCrossDemo.Forms.Droid", Theme = "@style/MainTheme", MainLauncher = true)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core.App, UI.App>, Core.App, UI.App>
    {
    }
}