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
    [Register ("ProductHeaderCell")]
    partial class ProductHeaderCell
    {
        [Outlet]
        UIKit.UIImageView imgArrow { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblValue { get; set; }


        [Outlet]
        UIKit.UIView viewCell { get; set; }


        [Outlet]
        UIKit.UIView viewLastView { get; set; }


        [Outlet]
        UIKit.UIView viewLineHeader { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgArrow != null) {
                imgArrow.Dispose ();
                imgArrow = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblValue != null) {
                lblValue.Dispose ();
                lblValue = null;
            }

            if (viewCell != null) {
                viewCell.Dispose ();
                viewCell = null;
            }

            if (viewLastView != null) {
                viewLastView.Dispose ();
                viewLastView = null;
            }

            if (viewLineHeader != null) {
                viewLineHeader.Dispose ();
                viewLineHeader = null;
            }
        }
    }
}