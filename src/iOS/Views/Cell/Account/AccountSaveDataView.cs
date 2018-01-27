
using System;
using UIKit;

namespace iOS
{
    public partial class AccountSaveDataView : UIView
    {
        public AccountSaveDataView(IntPtr handle) : base(handle) { }

        public UILabel ButtonSave => lblSaveData;
    }
}