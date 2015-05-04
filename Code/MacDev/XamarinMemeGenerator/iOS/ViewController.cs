using System;
		
using UIKit;
using Foundation;
using System.Collections.ObjectModel;

namespace XamarinMemeGenerator.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{		
		}


		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Calls the Shared Portable Class Library to get a list with all available meme's.
			ObservableCollection<string> memes = await XamarinMemeGenerator.WantSomeMemesNowClass.ShowMeThoseMemes ();

			//Set the list of memes we got to our PickerView (using the pickerViewModel we created)
			MemePicker.Model = new MemesPickerViewModel (memes);
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		async partial void GetMemeButton_TouchUpInside (UIButton sender)
		{
			//Get current selected meme from the ViewPicker
			var rowSel = MemePicker.SelectedRowInComponent(new nint(0));
			var memeString = (MemePicker.Model as MemesPickerViewModel).GetTitle(rowSel);

			//Calls the Shared Portable Class Library with the values of the PickerView and TextFields’s in this View.
			//The returned value is the image in a byte array format 
			byte[] imageByteArr = await XamarinMemeGenerator.WantSomeMemesNowClass.GenerateMyMeme(memeString, TopTextField.Text, BottomTextField.Text);
			//Create image
			var img = new UIImage(NSData.FromArray(imageByteArr));

			//Set image to the Image Placeholder we have on our View
			MemeImageView.Image = img;
		}
	}

	public class MemesPickerViewModel : UIPickerViewModel
	{

		private string[] _memesArr;

		public MemesPickerViewModel(ObservableCollection<string> memes){
			_memesArr = new string[memes.Count];
			memes.CopyTo (_memesArr, 0);
		}

		public string GetTitle (nint row)
		{
			return _memesArr[row];
		}

		public override nint GetComponentCount (UIPickerView pickerView)
		{
			return 1;
		}

		public override string GetTitle (UIPickerView pickerView, nint row, nint component)
		{
			return _memesArr[row];
		}

		public override nint GetRowsInComponent (UIPickerView pickerView, nint component)
		{
			return _memesArr.Length;
		}
	}
}
