using System;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinMemeGenerator.Droid
{
	[Activity (Label = "XamarinMemeGenerator.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //Reference to all the View Elements
            Button button = FindViewById<Button>(Resource.Id.myButtonGenerate);
            Spinner memesSpinner = FindViewById<Spinner>(Resource.Id.spinnerMemes);
            EditText editTextTop = FindViewById<EditText>(Resource.Id.editTextTop);
            EditText editTextBottom = FindViewById<EditText>(Resource.Id.editTextBottom);
            ImageView imageViewMeme = FindViewById<ImageView>(Resource.Id.imageViewMeme);

            //Calls the Shared Portable Class Library to get a list with all available meme's.
            ObservableCollection<string> memes = await XamarinMemeGenerator.WantSomeMemesNowClass.ShowMeThoseMemes();

            //Set the list of memes to our Spinner and enable it
            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, memes);
            memesSpinner.Adapter = adapter;

            button.Click += async delegate
            {
                //Calls the Shared Portable Class Library with the values of the Spinner and TextBox's in this View.
                //The returned value is the image in a byte array format 
                byte[] imageBytes = await XamarinMemeGenerator.WantSomeMemesNowClass.GenerateMyMeme(memesSpinner.SelectedItem.ToString(), editTextTop.Text, editTextBottom.Text);

                //Create Image
                Bitmap bmp = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

                //Set image to the Image Placeholder we have on our View
                imageViewMeme.SetImageBitmap(bmp);
            };
		}
	}
}


