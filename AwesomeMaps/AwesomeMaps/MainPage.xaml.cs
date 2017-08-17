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
        String img_url = "https://thumbs.dreamstime.com/z/female-avatar-icon-young-attractive-woman-smiling-image-to-create-to-represent-person-screen-online-games-chat-92495971.jpg";

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
                mapView.AddCustomPin(latitude, longtitude, img_url, data.message);
			}
        }
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			///
			await Task.Delay(1000);

            var hasPermission = await Utils.CheckPermissions(Permission.Location);
            if (!hasPermission)
            {
                Debug.WriteLine("No Permission");
            }
            ///mapView.MoveToCurrentPosition();
		}
	}
}
