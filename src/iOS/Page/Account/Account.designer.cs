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
    [Register ("Account")]
    partial class Account
    {
        [Outlet]
        UIKit.UILabel btnChangePassword { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint heightTable { get; set; }


        [Outlet]
        UIKit.UITableView TableViewYour { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnChangePassword != null) {
                btnChangePassword.Dispose ();
                btnChangePassword = null;
            }

            if (heightTable != null) {
                heightTable.Dispose ();
                heightTable = null;
            }

            if (TableViewYour != null) {
                TableViewYour.Dispose ();
                TableViewYour = null;
            }
        }
    }
}