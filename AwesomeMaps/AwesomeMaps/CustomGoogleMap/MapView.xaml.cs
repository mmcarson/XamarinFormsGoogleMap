using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms.GoogleMaps;
using System.Diagnostics;

namespace AwesomeMaps.CustomGoogleMap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentView
    {
        public MapView()
        {
            InitializeComponent();

            mapContent.MyLocationEnabled = true;
            mapContent.UiSettings.MyLocationButtonEnabled = true;
            mapContent.UiSettings.ZoomControlsEnabled = false;
            //mapContent.MoveCamera
            //getCurrentPosAsync();
            mapContent.MyLocationButtonClicked += (sender, args) =>
            {
                args.Handled = true;
            };

        }
        public async void getCurrentPosAsync()
        {
            var geoCoder = new Xamarin.Forms.GoogleMaps.Geocoder();

            //var positions = await geoCoder.
        }
    }
}