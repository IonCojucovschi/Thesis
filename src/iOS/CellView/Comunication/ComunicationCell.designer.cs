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
    [Register ("ComunicationCell")]
    partial class ComunicationCell
    {
        [Outlet]
        UIKit.UILabel lblContent { get; set; }


        [Outlet]
        UIKit.UITextField lblDate { get; set; }


        [Outlet]
        UIKit.UIView viewMain { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblContent != null) {
                lblContent.Dispose ();
                lblContent = null;
            }

            if (lblDate != null) {
                lblDate.Dispose ();
                lblDate = null;
            }

            if (viewMain != null) {
                viewMain.Dispose ();
                viewMain = null;
            }
        }
    }
}