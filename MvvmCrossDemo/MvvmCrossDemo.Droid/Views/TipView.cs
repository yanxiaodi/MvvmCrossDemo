
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCrossDemo.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Tip Calculator", MainLauncher = false)]
    public class TipView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TipView);
        }
    }
}