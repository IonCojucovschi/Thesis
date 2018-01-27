using System;
using UIKit;

namespace iOS
{
    public partial class SideMenuView : UIView
    {
        public SideMenuView(IntPtr handle) : base(handle) { }


        public UIImageView ImageRoot => imgRoot;

        public UIImageView ImageLogo
        {
            get => LogoView;
            set => LogoView = value;
        }

        public UIImageView ImageMenu
        {
            get => ButtonViewMenu;
            set => ButtonViewMenu = value;
        }

        public UIImageView LogoutImage
        {
            get => ImageLogout;
            set => ImageLogout = value;
        }

        public UITableView TableViewW
        {
            get => TableView;
            set => TableView = value;
        }

        public UILabel NameClientW
        {
            get => NameClient;
            set => NameClient = value;
        }

        public UILabel TextLogoutW
        {
            get => TextLogout;
            set => TextLogout = value;
        }

        public UIView FooterViewArea
        {
            get => FooterView;
            set => FooterView = value;
        }


        public UIImageView ViewFooter
        {
            get => viewLineFooter;
            set => viewLineFooter = value;
        }

        public UIImageView ViewHeader
        {
            get => viewLineHeader;
            set => viewLineHeader = value;
        }
    }
}