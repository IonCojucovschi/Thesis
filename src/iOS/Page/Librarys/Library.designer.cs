// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOS.Storyboard
{
    [Register ("Library")]
    partial class Library
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableLibrary { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tableLibrary != null) {
                tableLibrary.Dispose ();
                tableLibrary = null;
            }
        }
    }
}