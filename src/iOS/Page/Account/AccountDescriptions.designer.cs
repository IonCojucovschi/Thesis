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
    [Register ("AccountDescriptions")]
    partial class AccountDescriptions
    {
        [Outlet]
        UIKit.UILabel btnConfirm { get; set; }


        [Outlet]
        UIKit.UIImageView imgConfirm { get; set; }


        [Outlet]
        UIKit.UIImageView imgNew { get; set; }


        [Outlet]
        UIKit.UIImageView imgOld { get; set; }


        [Outlet]
        UIKit.UILabel lblHeader { get; set; }


        [Outlet]
        UIKit.UIView mainView { get; set; }


        [Outlet]
        UIKit.UITextField txtConfirm { get; set; }


        [Outlet]
        UIKit.UITextField txtNew { get; set; }


        [Outlet]
        UIKit.UITextField txtOld { get; set; }


        [Outlet]
        UIKit.UIView viewConfirm { get; set; }


        [Outlet]
        UIKit.UIView viewLineNew { get; set; }


        [Outlet]
        UIKit.UIView viewLineOld { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnConfirm != null) {
                btnConfirm.Dispose ();
                btnConfirm = null;
            }

            if (mainView != null) {
                mainView.Dispose ();
                mainView = null;
            }

            if (txtConfirm != null) {
                txtConfirm.Dispose ();
                txtConfirm = null;
            }

            if (txtNew != null) {
                txtNew.Dispose ();
                txtNew = null;
            }

            if (txtOld != null) {
                txtOld.Dispose ();
                txtOld = null;
            }

            if (viewConfirm != null) {
                viewConfirm.Dispose ();
                viewConfirm = null;
            }

            if (viewLineNew != null) {
                viewLineNew.Dispose ();
                viewLineNew = null;
            }

            if (viewLineOld != null) {
                viewLineOld.Dispose ();
                viewLineOld = null;
            }
        }
    }
}