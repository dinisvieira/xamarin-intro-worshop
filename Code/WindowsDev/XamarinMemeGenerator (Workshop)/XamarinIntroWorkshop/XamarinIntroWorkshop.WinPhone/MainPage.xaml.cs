using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace XamarinIntroWorkshop.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int count = 1;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Calls the Shared Portable Class Library to get a list with all available meme's.
            ObservableCollection<string> memes = await WantSomeMemesNowClass.ShowMeThoseMemes();

            //Set the list of memes to our ComboBox and enable it
            MemesListView.ItemsSource = memes;
            MemesListView.IsEnabled = true;
        }

        private async void GenerateMyMemeBtn_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (MemesListView.SelectedValue == null) { return; } //make sure we have a selected value

            //Calls the Shared Portable Class Library with the values of the ComboBox and TextBox's in this View.
            //The returned value is the image in a byte array format 
            byte[] imageBytes = await WantSomeMemesNowClass.GenerateMyMeme(MemesListView.SelectedValue.ToString(), TopTextBox.Text, BottomTextBox.Text);

            //Create Image
            var bitmapImage = new BitmapImage();
            var stream = new InMemoryRandomAccessStream();
            await stream.WriteAsync(imageBytes.AsBuffer());
            stream.Seek(0);
            bitmapImage.SetSource(stream);

            //Set image to the Image Placeholder we have on our View
            Image.Source = bitmapImage;
        }
    }
}
