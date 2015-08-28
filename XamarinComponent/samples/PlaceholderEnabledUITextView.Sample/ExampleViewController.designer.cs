// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PlaceholderEnabledUITextView.Sample
{
	[Register ("ExampleViewController")]
	partial class ExampleViewController
	{
		[Outlet]
		UIKit.UIButton btnRemoveFocus { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnRemoveFocus != null) {
				btnRemoveFocus.Dispose ();
				btnRemoveFocus = null;
			}
		}
	}
}
