// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOS.Storyboard
{
	[Register ("ProductHeaderCell")]
	partial class ProductHeaderCell
	{
		[Outlet]
		UIKit.UIImageView imgArrow { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UILabel lblValue { get; set; }

		[Outlet]
		UIKit.UIView viewCell { get; set; }

		[Outlet]
		UIKit.UIView viewLastView { get; set; }

		[Outlet]
		UIKit.UIView viewLineHeader { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (lblValue != null) {
				lblValue.Dispose ();
				lblValue = null;
			}

			if (imgArrow != null) {
				imgArrow.Dispose ();
				imgArrow = null;
			}

			if (viewCell != null) {
				viewCell.Dispose ();
				viewCell = null;
			}

			if (viewLineHeader != null) {
				viewLineHeader.Dispose ();
				viewLineHeader = null;
			}

			if (viewLastView != null) {
				viewLastView.Dispose ();
				viewLastView = null;
			}
		}
	}
}
