using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinView : StackLayout, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        String imageUrl = "http://www.mobtowers.com/wp-content/uploads/2014/06/style_imagery_integration_scale1-576x1024.png";
        String Message = "First";

        public PinView() 
        {
            InitializeComponent();
            
        }
        public PinView(String imageSrc, String msg)
        {
            InitializeComponent();

            imageUrl = imageSrc;
            Message = msg;

            BindingContext = this;
        }
        public String iImage
        {
            set
            {
                imageUrl = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,new PropertyChangedEventArgs("iImage"));
            }
            get
            {
                return imageUrl;
            }
        }

        public String iMessage
        {
            set
            {
                Message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("iMessage"));
            }
            get
            {
                return Message;
            }
        }
    }
}
