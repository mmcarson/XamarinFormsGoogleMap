using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinView : StackLayout, INotifyPropertyChanged
    {
        ImageSource imageSource = new UriImageSource
        {
            Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
            CachingEnabled = true,
            CacheValidity = new TimeSpan(5, 0, 0, 0)
        };
        String message = "I am running";

        public event PropertyChangedEventHandler PropertyChanged;
        public PinView() 
        {
            InitializeComponent();

            BindingContext = this;
            
        }
        public PinView(String imageSrc = "https://xamarin.com/content/images/pages/forms/example-app.png", String msg = "I am laughing")
        {
            InitializeComponent();

            BindingContext = this;

            imgSource = new UriImageSource
            {
                Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(5, 0, 0, 0)
            };
            msgSource = msg;
        }

        public ImageSource imgSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("imgSource"));
                }
            }
        }

        public String msgSource
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("msgSource"));
                }
            }
        }
    }
}
