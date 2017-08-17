using System;
using System.ComponentModel;
using AwesomeMaps;
using AwesomeMaps.iOS.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageCircle), typeof(ImageCircleRenderer))]

namespace AwesomeMaps.iOS.CustomRender
{
    public class ImageCircleRenderer : ImageRenderer
    {
        public ImageCircleRenderer()
        {
        }
		private void CreateCircle()
		{
			try
			{
				double min = Math.Min(Element.Width, Element.Height);
				Control.Layer.CornerRadius = (float)(min / 2.0);
				Control.Layer.MasksToBounds = false;
				Control.Layer.BorderColor = Color.White.ToCGColor();
				Control.Layer.BorderWidth = 3;
				Control.ClipsToBounds = true;
			}
			catch (Exception ex)
			{
                //Debug.WriteLine("Unable to create circle image: " + ex);
		    }
		}
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
				return;

			CreateCircle();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
				e.PropertyName == VisualElement.WidthProperty.PropertyName)
			{
				CreateCircle();
			}
		}
    }
}
