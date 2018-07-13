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
    [Register ("ContactCell")]
    partial class ContactCell
    {
        [Outlet]
        UIKit.UILabel lblCall { get; set; }


        [Outlet]
        UIKit.UILabel lblLabel { get; set; }


        [Outlet]
        UIKit.UILabel lblValue { get; set; }


        [Outlet]
        UIKit.UIView viewLine { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCall != null) {
                lblCall.Dispose ();
                lblCall = null;
            }

            if (lblLabel != null) {
                lblLabel.Dispose ();
                lblLabel = null;
            }

            if (lblValue != null) {
                lblValue.Dispose ();
                lblValue = null;
            }

            if (viewLine != null) {
                viewLine.Dispose ();
                viewLine = null;
            }
        }
    }
}