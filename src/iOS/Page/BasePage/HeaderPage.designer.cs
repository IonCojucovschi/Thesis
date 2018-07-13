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
    [Register ("HeaderPage")]
    partial class HeaderPage
    {
        [Outlet]
        UIKit.UIImageView imgHeader { get; set; }


        [Outlet]
        UIKit.UIImageView imgRightMenu { get; set; }


        [Outlet]
        UIKit.UILabel txtHeader { get; set; }


        [Outlet]
        UIKit.UIView viewTouchArea { get; set; }


        [Outlet]
        UIKit.UIView viewTouchAreRight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgHeader != null) {
                imgHeader.Dispose ();
                imgHeader = null;
            }

            if (imgRightMenu != null) {
                imgRightMenu.Dispose ();
                imgRightMenu = null;
            }

            if (txtHeader != null) {
                txtHeader.Dispose ();
                txtHeader = null;
            }

            if (viewTouchArea != null) {
                viewTouchArea.Dispose ();
                viewTouchArea = null;
            }

            if (viewTouchAreRight != null) {
                viewTouchAreRight.Dispose ();
                viewTouchAreRight = null;
            }
        }
    }
}