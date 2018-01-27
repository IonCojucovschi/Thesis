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
	[Register ("ProductChildCell")]
	partial class ProductChildCell
	{
		[Outlet]
		UIKit.UIImageView imgPdf { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UILabel lblPdf { get; set; }

		[Outlet]
		UIKit.UILabel lblValue { get; set; }

		[Outlet]
		UIKit.UIView viewCellChild { get; set; }

		[Outlet]
		UIKit.UIView viewLineDoc { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewCellChild != null) {
				viewCellChild.Dispose ();
				viewCellChild = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (lblValue != null) {
				lblValue.Dispose ();
				lblValue = null;
			}

			if (imgPdf != null) {
				imgPdf.Dispose ();
				imgPdf = null;
			}

			if (viewLineDoc != null) {
				viewLineDoc.Dispose ();
				viewLineDoc = null;
			}

			if (lblPdf != null) {
				lblPdf.Dispose ();
				lblPdf = null;
			}
		}
	}
}
