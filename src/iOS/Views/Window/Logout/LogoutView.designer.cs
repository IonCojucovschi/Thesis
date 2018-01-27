// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS
{
    [Register ("LogoutView")]
    partial class LogoutView
    {
        [Outlet]
        UIKit.UIImageView imgRoot { get; set; }


        [Outlet]
        UIKit.UILabel lblMessage { get; set; }


        [Outlet]
        UIKit.UILabel lblNo { get; set; }


        [Outlet]
        UIKit.UILabel lblYes { get; set; }


        [Outlet]
        UIKit.UIView MainView { get; set; }


        [Outlet]
        UIKit.UIView RootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgRoot != null) {
                imgRoot.Dispose ();
                imgRoot = null;
            }

            if (lblMessage != null) {
                lblMessage.Dispose ();
                lblMessage = null;
            }

            if (lblNo != null) {
                lblNo.Dispose ();
                lblNo = null;
            }

            if (lblYes != null) {
                lblYes.Dispose ();
                lblYes = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (RootView != null) {
                RootView.Dispose ();
                RootView = null;
            }
        }
    }
}