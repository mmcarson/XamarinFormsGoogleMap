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
        String imageSource = "default_image.png";
        String message = "I am running";

        public event PropertyChangedEventHandler PropertyChanged;
        public PinView() 
        {
            InitializeComponent();

            BindingContext = this;

            imageSource = "default_image.png";
            message = "I am running";
        }
        public PinView(String imageSrc = "default_image.png", String msg = "I am laughing")
        {
            InitializeComponent();

            imageSource = imageSrc;
            message = msg;

            BindingContext = this;
        }

        public String imgSource
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
