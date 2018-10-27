// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [Register ("FirstView")]
    partial class FirstView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNavToPostList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnShowGreeting { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblGreeting { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnNavToPostList != null) {
                btnNavToPostList.Dispose ();
                btnNavToPostList = null;
            }

            if (btnShowGreeting != null) {
                btnShowGreeting.Dispose ();
                btnShowGreeting = null;
            }

            if (lblGreeting != null) {
                lblGreeting.Dispose ();
                lblGreeting = null;
            }

            if (txtUserName != null) {
                txtUserName.Dispose ();
                txtUserName = null;
            }
        }
    }
}