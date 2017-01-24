using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Util;
using Plugin.InAppBilling;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace TrivialDriveSample
{
	[Activity(Label = "Trivial Drive", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			MobileCenter.Start("bb1d7d09-a394-45e0-87ac-57bed83d9904",
					typeof(Analytics), typeof(Crashes));

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);



			LoadData();

			string base64EncodedPublicKey = "CONSTRUCT_YOUR_KEY_AND_PLACE_IT_HERE";

			Log.Debug(TAG, "Creating IAB Helper");

			var connected = await CrossInAppBilling.Current.ConnectAsync();

			System.Console.WriteLine(connected);

		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
		}

		void LoadData()
		{
			var sp = GetPreferences(FileCreationMode.Private);
			tank = sp.GetInt("tank", 2);

			Log.Debug(TAG, $"Loaded the data: tank = {tank}");
		}

		int tank; // current amount of gas in the tank, in unit

		const string TAG = "TrivialDrive";
	}


}

