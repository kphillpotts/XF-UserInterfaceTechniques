using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NonRectangularHeader : ContentPage
	{
		public NonRectangularHeader ()
		{
			InitializeComponent ();

            string resourceID = "Layouts.ChoreBackground.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                resourceBitmap = SKBitmap.Decode(stream);
            }
        }
        SKBitmap resourceBitmap;


        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            // work out points for the path considering denisity of device
            float densityMultiplier = args.Info.Height / (float)SkiaCanvas.Height;
            var curveAmount = 40 * densityMultiplier;
            float curveStart = args.Info.Height - curveAmount;
            float curveEnd = args.Info.Height + curveAmount;

            args.Surface.Canvas.Clear();

            // create the clipping path
            SKPath path = CreatePath(curveStart, curveEnd, args.Info.Width);
            args.Surface.Canvas.ClipPath(path, antialias: true);

            // render bitmap into clipping rectangle
            using (SKPaint paint = new SKPaint())
            {
                // Create bitmap tiling
                paint.Shader = SKShader.CreateBitmap(resourceBitmap,
                                                     SKShaderTileMode.Repeat,
                                                     SKShaderTileMode.Repeat);
                // Draw background
                args.Surface.Canvas.DrawRect(args.Info.Rect, paint);
            }
        }

        private static SKPath CreatePath(float curveStart, float curveEnd, float width)
        {
            SKPath path = new SKPath();
            SKPoint point0 = new SKPoint(0, curveStart);
            SKPoint point1 = new SKPoint(width / 2, curveEnd);
            SKPoint point2 = new SKPoint(width, curveStart);
            path.MoveTo(0, 0);
            path.LineTo(point0);
            path.ConicTo(point1, point2, (float).5);
            path.LineTo(width, 0);
            path.LineTo(0, 0);
            path.Close();
            return path;
        }
    }
}