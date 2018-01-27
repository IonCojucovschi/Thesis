// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS.Storyboard
{
    [Register ("Dashboard")]
    partial class Dashboard
    {
        [Outlet]
        UIKit.UIImageView imgRoot { get; set; }


        [Outlet]
        UIKit.UILabel lblNameClient { get; set; }


        [Outlet]
        UIKit.UILabel lblWelcome { get; set; }


        [Outlet]
        UIKit.UIView RootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgRoot != null) {
                imgRoot.Dispose ();
                imgRoot = null;
            }

            if (lblNameClient != null) {
                lblNameClient.Dispose ();
                lblNameClient = null;
            }

            if (lblWelcome != null) {
                lblWelcome.Dispose ();
                lblWelcome = null;
            }

            if (RootView != null) {
                RootView.Dispose ();
                RootView = null;
            }
        }
    }
}