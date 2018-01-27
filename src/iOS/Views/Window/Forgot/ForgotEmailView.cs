using System;
using UIKit;

namespace iOS
{
    public partial class ForgotEmailView : UIView
    {
        public ForgotEmailView(IntPtr handle) : base(handle) { }

        public UILabel Cancel
        {
            get => lblCancel;
            set => lblCancel = value;
        }

        public UILabel Send
        {
            get => lblSend;
            set => lblSend = value;
        }

        public UIView MainWin
        {
            get => MainView;
            set => MainView = value;
        }

        public UIView RootView
        {
            get => Root;
            set => Root = value;
        }

        public UIView Underline
        {
            get => viewLine;
            set => viewLine = value;
        }

        public UIImageView ImageMail
        {
            get => imgMail;
            set => imgMail = value;
        }

        public UITextField Mail
        {
            get => txtEmail;
            set => txtEmail = value;
        }
    }
}