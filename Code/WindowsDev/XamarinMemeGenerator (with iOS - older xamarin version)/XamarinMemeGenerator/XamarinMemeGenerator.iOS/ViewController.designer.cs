// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinMemeGenerator.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField BottomTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton GetMemeButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView MemeImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView MemePicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TopTextField { get; set; }

		[Action ("GetMemeButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void GetMemeButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (BottomTextField != null) {
				BottomTextField.Dispose ();
				BottomTextField = null;
			}
			if (GetMemeButton != null) {
				GetMemeButton.Dispose ();
				GetMemeButton = null;
			}
			if (MemeImageView != null) {
				MemeImageView.Dispose ();
				MemeImageView = null;
			}
			if (MemePicker != null) {
				MemePicker.Dispose ();
				MemePicker = null;
			}
			if (TopTextField != null) {
				TopTextField.Dispose ();
				TopTextField = null;
			}
		}
	}
}
