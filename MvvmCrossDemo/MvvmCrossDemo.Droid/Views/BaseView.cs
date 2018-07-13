using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCrossDemo.Droid.Views
{
    public class BaseView : MvxActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
        }
    }
}