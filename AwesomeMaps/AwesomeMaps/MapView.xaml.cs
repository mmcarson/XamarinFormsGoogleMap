﻿using System;
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

namespace AwesomeMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentView
    {
        public MapView() : base()
        {
            InitializeComponent();
        }
		public void setMyLocationButtonEnable()
		{
			mapContent.MyLocationEnabled = true;
			mapContent.UiSettings.MyLocationButtonEnabled = true;
		}

        public async void MoveToCurrentPosition(){
            mapContent.MyLocationEnabled = true;

			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync();

			var pos = new Position(position.Latitude, position.Longitude);
            Debug.WriteLine("My Position");
            Debug.WriteLine(position);
			mapContent.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMeters(1000)), true);
        }

        public void AddPin(double latitude, double longtitude)
        {
            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Normal Pin",
                Address = "New position",
                Position = new Position(latitude, longtitude)
            };

            mapContent.Pins.Add(pin);

            mapContent.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(1000)), true);
        }

        public void AddCustomPinAsync(double latitude, double longtitude, string imageSrc, string msg)
        {
            Position temp = new Position(latitude, longtitude);
			mapContent.MoveToRegion(MapSpan.FromCenterAndRadius(temp, Distance.FromMeters(1000)), true);

            PinView newPinView = new PinView(imageSrc, msg);
            
            Pin pin = new Pin()
			{
				Type = PinType.Place,
				Label = "Custom Pin",
				Address = "New Address",
				Position = new Position(latitude, longtitude),
				Icon = BitmapDescriptorFactory.FromView(newPinView),
                Anchor = new Point(0.5, 0.5),
                ZIndex = 1,
                IsVisible = true,
			};

            mapContent.Pins.Add(pin);
        }
    }
}