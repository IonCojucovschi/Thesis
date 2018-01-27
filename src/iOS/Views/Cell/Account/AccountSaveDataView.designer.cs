// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
