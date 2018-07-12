using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using MvvmCross.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvvmCrossDemo.Core;
using MvvmCrossDemo.Core.Infrastructure;

namespace MvvmCrossDemo.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }


        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            RegisterAppCenter();
        }

        private void RegisterAppCenter()
        {
            // This should come before AppCenter.Start() is called
            // Avoid duplicate event registration:
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                  $"\n\tNotification title: {e.Title}" +
                                  $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }

            Push.SetSenderId(AppConfiguration.AndroidFirebaseSenderId);
            AppCenter.Start(AppConfiguration.AppCenterAndroidAppSecret, typeof(Analytics), typeof(Crashes), typeof(Push));


        }
    }
}