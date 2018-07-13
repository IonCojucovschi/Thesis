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
    [Register ("ProductChildCell")]
    partial class ProductChildCell
    {
        [Outlet]
        UIKit.UIImageView imgPdf { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblPdf { get; set; }


        [Outlet]
        UIKit.UILabel lblValue { get; set; }


        [Outlet]
        UIKit.UIView viewCellChild { get; set; }


        [Outlet]
        UIKit.UIView viewLineDoc { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgPdf != null) {
                imgPdf.Dispose ();
                imgPdf = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblPdf != null) {
                lblPdf.Dispose ();
                lblPdf = null;
            }

            if (lblValue != null) {
                lblValue.Dispose ();
                lblValue = null;
            }

            if (viewCellChild != null) {
                viewCellChild.Dispose ();
                viewCellChild = null;
            }

            if (viewLineDoc != null) {
                viewLineDoc.Dispose ();
                viewLineDoc = null;
            }
        }
    }
}