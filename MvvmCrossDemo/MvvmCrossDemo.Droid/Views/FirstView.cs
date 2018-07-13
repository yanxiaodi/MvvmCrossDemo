using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MvvmCrossDemo.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "First View")]
    public class FirstView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }

    }
}