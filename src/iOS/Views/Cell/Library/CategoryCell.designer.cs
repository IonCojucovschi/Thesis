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
    [Register ("CategoryCell")]
    partial class CategoryCell
    {
        [Outlet]
        UIKit.UIImageView categoryImage { get; set; }

        [Outlet]
        UIKit.UILabel categoryName { get; set; }

        [Outlet]
        UIKit.UILabel categoryQantity { get; set; }

        [Outlet]
        UIKit.UIView Root { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (categoryImage != null) {
                categoryImage.Dispose ();
                categoryImage = null;
            }

            if (categoryName != null) {
                categoryName.Dispose ();
                categoryName = null;
            }

            if (categoryQantity != null) {
                categoryQantity.Dispose ();
                categoryQantity = null;
            }

            if (Root != null) {
                Root.Dispose ();
                Root = null;
            }
        }
    }
}