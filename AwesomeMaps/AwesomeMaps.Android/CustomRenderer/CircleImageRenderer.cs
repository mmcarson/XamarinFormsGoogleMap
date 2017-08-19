using System;
using Android.Graphics;
using AwesomeMaps.CustomGoogleMap;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AwesomeMaps;
using AwesomeMaps.Droid.CustomRenderer;
using Android.Content;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.IO;

[assembly: ExportRenderer(typeof(Image), typeof(ImageCircleRenderer))]
namespace AwesomeMaps.Droid.CustomRenderer
{
    public class ImageCircleRenderer : ImageRenderer
    {
        public ImageCircleRenderer()
        {
            //Getting();
        }
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;

                //Create path to clip
                var path = new Android.Graphics.Path();
                path.AddCircle(Width / 2, Height / 2, radius, Android.Graphics.Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);
                var uriImageSource = (UriImageSource)Element.Source;
                WebRequest request = HttpWebRequest.Create(uriImageSource.Uri.AbsoluteUri);
                request.Timeout = 10000;

                WebResponse response = request.GetResponse();
                Stream inputStream = response.GetResponseStream();

                Bitmap mainBitmap = BitmapFactory.DecodeStream(inputStream);
                /*
                float ratio = Math.Min(
                    25 / mainBitmap.Width,
                    25 / mainBitmap.Height);
                int width = (int)Math.Round((float)ratio * mainBitmap.Width);
                int height = (int)Math.Round((float)ratio * mainBitmap.Height);
                */
                Bitmap newBitmap = Bitmap.CreateScaledBitmap(mainBitmap, 150,
                        150, true);

                canvas.DrawBitmap(newBitmap, 0, 0, null);

                canvas.Restore();

                // Create path for circle border
                path = new Android.Graphics.Path();
                path.AddCircle(Width / 2, Height / 2, radius, Android.Graphics.Path.Direction.Ccw);

                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = 5;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = global::Android.Graphics.Color.White;
                
                canvas.DrawPath(path, paint);
                
                paint.Dispose();
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            
            if (e.OldElement == null)
            {
                

            }
        }
    }
}