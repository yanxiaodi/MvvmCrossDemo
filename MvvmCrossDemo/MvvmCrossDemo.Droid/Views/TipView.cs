
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MvvmCrossDemo.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Tip Calculator", MainLauncher = false)]
    public class TipView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TipView);
        }
    }
}