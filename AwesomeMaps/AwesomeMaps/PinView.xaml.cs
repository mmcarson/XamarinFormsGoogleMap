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
    public partial class PinView : StackLayout
    {
        StackLayout mainContent;

        public PinView() 
        {
            InitializeComponent();
            
        }
        public PinView(String imageSrc, String msg)
        {
            InitializeComponent();

            InitializeControlAsync(imageSrc, msg);
        }
        public void InitializeControlAsync(String imgUrl, String msg)
        {
            mainContent = new StackLayout();
            mainContent.WidthRequest = 150;
            mainContent.HeightRequest = 50;
            mainContent.Orientation = StackOrientation.Horizontal;

            var avatarImage = new ImageCircle { Aspect = Aspect.AspectFit };

            avatarImage.WidthRequest = 50;
            avatarImage.HeightRequest = 50;

            //avatarImage.Source = ImageSource.FromUri(new Uri(imgUrl));
            avatarImage.Source = new UriImageSource
            {
                Uri = new Uri(imgUrl),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(5, 0, 0, 0)
            };
            while (avatarImage.IsLoading){
                
            }

            Label message = new Label();
            message.WidthRequest = 100;
            message.HeightRequest = 40;
            message.Margin = new Thickness(0, 10, 0, 0);
            message.Text = msg;

            mainContent.Children.Add(avatarImage);
            mainContent.Children.Add(message);

            Debug.WriteLine("Image Source of Avatar");
            //Debug.WriteLine(avatarImage.);

            this.Children.Add(mainContent);
        }
    }
}
