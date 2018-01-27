// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS.Views.Window.Menu.CellView
{
    [Register ("MenuViewCell")]
    partial class MenuViewCell
    {
        [Outlet]
        UIKit.UIView rootView { get; set; }


        [Outlet]
        UIKit.UILabel txtMenu { get; set; }


        [Outlet]
        UIKit.UIView viewSelected { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtMenu != null) {
                txtMenu.Dispose ();
                txtMenu = null;
            }

            if (viewSelected != null) {
                viewSelected.Dispose ();
                viewSelected = null;
            }
        }
    }
}