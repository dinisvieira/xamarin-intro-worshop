﻿using System;
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

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButtonGenerate);
            Spinner memesSpinner = FindViewById<Spinner>(Resource.Id.spinnerMemes);
            EditText editTextTop = FindViewById<EditText>(Resource.Id.editTextTop);
            EditText editTextBottom = FindViewById<EditText>(Resource.Id.editTextBottom);
            ImageView imageViewMeme = FindViewById<ImageView>(Resource.Id.imageViewMeme);

            ObservableCollection<string> memes = await XamarinMemeGenerator.WantSomeMemesNowClass.ShowMeThoseMemes();
            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, memes);
            memesSpinner.Adapter = adapter;
            
			button.Click += async delegate {

                byte[] imageBytes = await XamarinMemeGenerator.WantSomeMemesNowClass.GenerateMyMeme(memesSpinner.SelectedItem.ToString(), editTextTop.Text, editTextBottom.Text);
                Bitmap bmp = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                imageViewMeme.SetImageBitmap(bmp);
			};
		}
	}
}


