using AwesomeMaps.CustomGoogleMap;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AwesomeMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        DataModel data = new DataModel();
        String img_url = "https://secure.gravatar.com/avatar/d13a1c782170b764688e550b08de8ca7/?default=https%3A%2F%2Fvanillicon.com%2Fd13a1c782170b764688e550b08de8ca7_200.png&rating=g&size=130";

        public MainPage()
		{
			InitializeComponent();
            
			this.BindingContext = data;

		}

        public void AddPin(object sender, System.EventArgs e)
        {
            double latitude = 0, longtitude = 0;
			bool isLat = Double.TryParse(data.lat, out latitude);
            bool isLong = Double.TryParse(data.longt, out longtitude);

            if (isLat && isLong)
            {
                mapView.AddPin(latitude, longtitude);
            }
        }

        public void AddCustomPin(object sender, System.EventArgs e){
			double latitude = 0, longtitude = 0;
			bool isLat = Double.TryParse(data.lat, out latitude);
			bool isLong = Double.TryParse(data.longt, out longtitude);
            
            if (isLat && isLong)
			{
                mapView.AddCustomPinAsync(latitude, longtitude, img_url, data.message);
			}
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();
			///
            /*
			await Task.Delay(1000);

            var hasPermission = await Utils.CheckPermissions(Permission.Location);
            if (!hasPermission)
            {
                Debug.WriteLine("No Permission");
            }*/
            ///mapView.MoveToCurrentPosition();
		}
	}
}
