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
    [Register ("AccountSaveDataView")]
    partial class AccountSaveDataView
    {
        [Outlet]
        UIKit.UILabel lblSaveData { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblSaveData != null) {
                lblSaveData.Dispose ();
                lblSaveData = null;
            }
        }
    }
}