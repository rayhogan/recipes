
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace FileSystem
{
	/// <summary>
	/// Sizes the window according to the screen, for iPad as well as iPhone support
	/// </summary>
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		static void Main (string [] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}

		UIWindow window;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			var v = new FileSystemViewController ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.BackgroundColor = UIColor.White;
			window.Bounds = UIScreen.MainScreen.Bounds;
			window.RootViewController = v;

			window.MakeKeyAndVisible ();
			return true;
		}
	}
}