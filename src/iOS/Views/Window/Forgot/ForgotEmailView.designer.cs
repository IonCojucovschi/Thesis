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
    [Register ("ForgotEmailView")]
    partial class ForgotEmailView
    {
        [Outlet]
        UIKit.UIImageView imgMail { get; set; }


        [Outlet]
        UIKit.UILabel lblCancel { get; set; }


        [Outlet]
        UIKit.UILabel lblSend { get; set; }


        [Outlet]
        UIKit.UIView MainView { get; set; }


        [Outlet]
        UIKit.UIView Root { get; set; }


        [Outlet]
        UIKit.UITextField txtEmail { get; set; }


        [Outlet]
        UIKit.UIView viewLine { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCancel != null) {
                lblCancel.Dispose ();
                lblCancel = null;
            }

            if (lblSend != null) {
                lblSend.Dispose ();
                lblSend = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (Root != null) {
                Root.Dispose ();
                Root = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (viewLine != null) {
                viewLine.Dispose ();
                viewLine = null;
            }
        }
    }
}