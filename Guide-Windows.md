# Track 1 - Development with Windows #
You will develop a Windows Phone and Android application.  
It's also possible to create an iOS Application but that would require a Mac Build Host and it's not covered in this Guide.

## Before starting

* This guide applies to Visual Studio, but you shouldn't have any trouble following it with Xamarin Studio. (you can refer to the [Xamarin guides](http://developer.xamarin.com/guides/cross-platform/getting_started/introducing_xamarin_studio/) anyway)
* Make sure you have Xamarin installed (which will also install the Xamarin Visual Studio Plugin)

## Create Project

Open Visual Studio Community.

* 1) File => New => Project

* 2) Choose "Visual C#" => "Mobile Apps" => Blank App (Native Portable) => Give it a name and "Ok"
![](images/CreateProject.png)

Visual Studio will generate a template for Android / iOS / Windows Phone using a Portable Class Library to share code.

> Note: If a "File Modification Detected" window pops up just press "Reload All"

We don't want iOS on this Guide so let's remove the generated iOS Project

* 3) Right-click the Xamarin project and select "Remove"
![](images/DeleteIOS.png)

You Solution Explorer should look like this now:
![](images/SolutionExplorer.png)

> + XamarinMemeGenerator is our Portable Class Library, meant to share code between platforms.
> + XamarinMemeGenerator.Droid is the project specific to the Android platform.
> + XamarinMemeGenerator.WinPhone is the project specific to the Windows Phone platform.

* 4) Login / Create Xamarin Account (this might not be necessary if you have already done it in the past.
	* Tools => Xamarin Account => Login (Create Account if necessary)

## Let's get some work done

So, we want to build an application capable of building [Meme's](http://gizmodo.com/what-exactly-is-a-meme-512058258), for that we'll need to use an API that gives us a list of meme's and then allows us to send it the selected meme, some captions and return a meme image.

### Create shared code that accesses the Meme Generation API

* 1) In the XamarinMemeGenerator Project delete the "MyClass.cs"
	* Right-click the MyClass.cs file and select "Delete"
* 2) Create a new Class called "WantSomeMemesNowClass.cs" (or something else you want, I'm not good with names :)
	* Right-click the XamarinMemeGenerator Project => Add => New item => Choose "Class" from the list, give it a name and click "Add"

* 3) This is definitley cheating, but here goes the code for this class...

		public static class WantSomeMemesNowClass
		{
			//Gets a list of all available memes on this API
			public async static Task<ObservableCollection<string>>  ShowMeThoseMemes()
			{
		
				var client = new HttpClient();
		
				//headers required to call the service (API key and Accept type)
				client.DefaultRequestHeaders.Add("X-Mashape-Key", "4wOkBMq0J3mshTsxRwUGu2H2tP9kp1UK1XGjsnSSX7cxmwWcZL");
				client.DefaultRequestHeaders.Add("Accept", "text/plain");
		
				//Actually calls the service and returns a json string
				string response = await client.GetStringAsync("https://ronreiter-meme-generator.p.mashape.com/images");
		
				//converts json string to na ObservableCollection of strings
				return JsonConvert.DeserializeObject<ObservableCollection<string>>(response);
		
			}
			
			//Given a meme, top and bottom texts this will return an image
			public async static Task<byte[]> GenerateMyMeme(string meme, string topText, string bottomText)
			{
		
				//This Meme Generator Api has a problem with non-ascii chars, so we strip them just to avoid it crashing.
				bottomText = Regex.Replace(bottomText, @"[^\u0000-\u007F]", string.Empty);
				topText = Regex.Replace(topText, @"[^\u0000-\u007F]", string.Empty);
		
				var client = new HttpClient();
		
				//headers required to call the service (API key and Accept type)
				client.DefaultRequestHeaders.Add("X-Mashape-Key", "4wOkBMq0J3mshTsxRwUGu2H2tP9kp1UK1XGjsnSSX7cxmwWcZL");
		
				//Actually calls the service and returns a byte array for the image
				return await client.GetByteArrayAsync("https://ronreiter-meme-generator.p.mashape.com/meme?bottom="+bottomText+"&meme="+meme+"&top="+topText);
		
			}
		}
