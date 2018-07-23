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

namespace iOS
{
    [Register ("BookCell")]
    partial class BookCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel authorName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bookImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bookName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detailsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView Root { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (authorName != null) {
                authorName.Dispose ();
                authorName = null;
            }

            if (bookImage != null) {
                bookImage.Dispose ();
                bookImage = null;
            }

            if (bookName != null) {
                bookName.Dispose ();
                bookName = null;
            }

            if (detailsButton != null) {
                detailsButton.Dispose ();
                detailsButton = null;
            }

            if (Root != null) {
                Root.Dispose ();
                Root = null;
            }
        }
    }
}