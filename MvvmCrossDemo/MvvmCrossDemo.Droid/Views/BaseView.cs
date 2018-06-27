using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCrossDemo.Droid.Views
{
    public class BaseView : MvxActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;//TODO put on config
            //Window.SetStatusBarColor(Color.ParseColor(StaticVariables.StatusBarBlue));
        }

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
        }
    }
}