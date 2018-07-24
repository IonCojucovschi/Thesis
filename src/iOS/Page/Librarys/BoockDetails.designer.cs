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
    [Register ("BoockDetails")]
    partial class BoockDetails
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel authorText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bookImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel categoryText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView descriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel downloadButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel downloadsText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ratingText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel readButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (authorText != null) {
                authorText.Dispose ();
                authorText = null;
            }

            if (bookImage != null) {
                bookImage.Dispose ();
                bookImage = null;
            }

            if (categoryText != null) {
                categoryText.Dispose ();
                categoryText = null;
            }

            if (descriptionText != null) {
                descriptionText.Dispose ();
                descriptionText = null;
            }

            if (downloadButton != null) {
                downloadButton.Dispose ();
                downloadButton = null;
            }

            if (downloadsText != null) {
                downloadsText.Dispose ();
                downloadsText = null;
            }

            if (ratingText != null) {
                ratingText.Dispose ();
                ratingText = null;
            }

            if (readButton != null) {
                readButton.Dispose ();
                readButton = null;
            }

            if (titleText != null) {
                titleText.Dispose ();
                titleText = null;
            }
        }
    }
}