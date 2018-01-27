using System;
using UIKit;

namespace iOS
{
    public partial class LogoutView : UIView
    {
        public LogoutView(IntPtr handle)
            : base(handle)
        {
        }

        public UILabel Yes
        {
            get => lblYes;
            set => lblYes = value;
        }

        public UILabel No
        {
            get => lblNo;
            set => lblNo = value;
        }

        public UILabel Message
        {
            get => lblMessage;
            set => lblMessage = value;
        }

        public UIView MainWin
        {
            get => MainView;
            set => MainView = value;
        }

        public UIView Root
        {
            get => RootView;
            set => RootView = value;
        }

        public UIView ImageRoot => imgRoot;
    }
}