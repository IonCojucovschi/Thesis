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
    [Register ("SideMenuView")]
    partial class SideMenuView
    {
        [Outlet]
        UIKit.UIImageView ButtonViewMenu { get; set; }


        [Outlet]
        UIKit.UIView FooterView { get; set; }


        [Outlet]
        UIKit.UIImageView ImageLogout { get; set; }


        [Outlet]
        UIKit.UIImageView imgRoot { get; set; }


        [Outlet]
        UIKit.UIImageView LogoView { get; set; }


        [Outlet]
        UIKit.UILabel NameClient { get; set; }


        [Outlet]
        UIKit.UIView RootView { get; set; }


        [Outlet]
        UIKit.UIView RootViewContainer { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }


        [Outlet]
        UIKit.UILabel TextLogout { get; set; }


        [Outlet]
        UIKit.UIImageView viewLineFooter { get; set; }


        [Outlet]
        UIKit.UIImageView viewLineHeader { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FooterView != null) {
                FooterView.Dispose ();
                FooterView = null;
            }

            if (imgRoot != null) {
                imgRoot.Dispose ();
                imgRoot = null;
            }

            if (LogoView != null) {
                LogoView.Dispose ();
                LogoView = null;
            }

            if (RootView != null) {
                RootView.Dispose ();
                RootView = null;
            }

            if (RootViewContainer != null) {
                RootViewContainer.Dispose ();
                RootViewContainer = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (TextLogout != null) {
                TextLogout.Dispose ();
                TextLogout = null;
            }

            if (viewLineFooter != null) {
                viewLineFooter.Dispose ();
                viewLineFooter = null;
            }

            if (viewLineHeader != null) {
                viewLineHeader.Dispose ();
                viewLineHeader = null;
            }
        }
    }
}