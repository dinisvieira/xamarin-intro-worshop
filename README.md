# Xamarin Introduction (Workshop)
The objective with this workshop is to serve as a quick introduction to the Xamarin world.

* What **will be** covered
	* Creating Xamarin Project for Android / iOS / Windows Phone (the last two depend on the development platform)
	* Using simple "shared" Portable Class Library to share code between two different projects/platforms
	* Using native UI controls (iOS/Android/Windows Phone)
	* Creating an app that actually runs!
* What **won't be** covered
	* Xamarin.Forms
	* Deploying apps to the store
	* Sharing ViewModel code for additional code-sharing between platforms.
	* Developing for iOS platform with a Windows machine (using a Mac Build Host)



## Requirements ##

* Get your Mashape API Key from [here](https://www.mashape.com/ronreiter/meme-generator) (Will be used to access the API we'll use on this workshop).

* Windows PC (Windows 8.1 / 10)

	* 1 - [Xamarin.Android](http://developer.xamarin.com/guides/android/getting_started/installation/windows/ "Xamarin.Android") (and Visual Studio Community 2015)

	* 2 - [Xamarin Android Player](https://xamarin.com/android-player "Xamarin Android Player") or [Genymotion](https://www.genymotion.com/#%21/ "Genymotion") or the [default Android Emulator with some speed "boost"](http://developer.xamarin.com/guides/android/getting_started/installation/accelerating_android_emulators/)

	* 3 - [Visual Studio Community 2015](https://www.visualstudio.com/downloads/download-visual-studio-vs "Visual Studio Community 2015") (should already be installed due to step 1)

	* 4 - [Windows Mobile SDK](https://dev.windows.com/en-us/develop/downloads "Windows Mobile 10 SDK") (Only if you didn't download it during the Visual Studio installation)
	
* Mac

	* 1 - [Xamarin.Android Installation Guide](http://developer.xamarin.com/guides/android/getting_started/installation/mac/ "Xamarin.Android") (you can also install Xamarin iOS and Xamarin Studio in this step, so you can skip 4 and 5)
		
	* 2 - [XCode IDE](https://itunes.apple.com/us/app/xcode/id497799835?mt=12 "XCode IDE")
		
	* 3 - [Genymotion Android Emulator](https://www.genymotion.com/#%21/ "Genymotion Android Emulator") (or other Android Emulator)
		
	* 4 - [Xamarin Studio IDE Download](http://xamarin.com/download "Xamarin Studio IDE")

	* 5 - [Xamarin iOS Installation Guide](http://developer.xamarin.com/guides/ios/getting_started/installation/mac/)


## Workshop Guide ##

### [Track 1 - Development with Windows](Guide-Windows.md) ###
You will develop a Windows Phone and Android application.  
It's also possible to create an iOS Application but that would require a Mac Build Host and it's not covered in this guide.


### [Track 2 - Development with Mac](Guide-Mac.md) ###
You will develop an iOS and Android application.  
