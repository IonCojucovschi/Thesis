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
    [Register ("AccountCell")]
    partial class AccountCell
    {
        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblValue { get; set; }


        [Outlet]
        UIKit.UIView Root { get; set; }


        [Outlet]
        UIKit.UITextView txt2Value { get; set; }


        [Outlet]
        UIKit.UITextField txtValue { get; set; }


        [Outlet]
        UIKit.UIView viewLine { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (Root != null) {
                Root.Dispose ();
                Root = null;
            }

            if (txt2Value != null) {
                txt2Value.Dispose ();
                txt2Value = null;
            }

            if (viewLine != null) {
                viewLine.Dispose ();
                viewLine = null;
            }
        }
    }
}