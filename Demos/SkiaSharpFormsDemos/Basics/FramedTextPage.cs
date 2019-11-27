using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using TheArtOfDev.HtmlRenderer.XamarinForms;

namespace SkiaSharpFormsDemos.Basics
{
    public class FramedTextPage : ContentPage
    {
        public FramedTextPage()
        {
            Title = "Framed Text";

            //SKCanvasView canvasView = new SKCanvasView();
            //canvasView.PaintSurface += OnCanvasViewPaintSurface;
            //Content = canvasView;

            string html = "<div style='font-size:40px'>"
                + "<p>1</p><p>2</p><p>3</p><p>4</p><div>5</div><div>6</div>"
                + "</div><div style='font-size:80px'>"
                + "<p>7</p><p>8</p><p>9</p><p>10</p><div>11</div><div>12</div>"
                + "<p>hello&nbsp;<span style='color:red'>world</span></p><h1>Title</h1>"
                + "<div style='color:#FF8833'>color</div>"
                + "</div>";
            html = "<div style='font-size:100px;padding:100px'>"
                + "<p>hello <span>world</span></p>"
                +"<p style='color:red'>red</p>"
                + "<div style='color:#FF8833'>#FF8833</div>"
                + "</div>";
            HtmlLabel lbl = new HtmlLabel() { Text = html };
            Content = lbl;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            string str = "Hello SkiaSharp!";

            // Create an SKPaint object to display the text
            SKPaint textPaint = new SKPaint
            {
                Color = SKColors.Chocolate
            };

            // Adjust TextSize property so text is 90% of screen width
            float textWidth = textPaint.MeasureText(str);
            textPaint.TextSize = 0.9f * info.Width * textPaint.TextSize / textWidth;

            // Find the text bounds
            SKRect textBounds = new SKRect();
            textPaint.MeasureText(str, ref textBounds);

            // Calculate offsets to center the text on the screen
            float xText = info.Width / 2 - textBounds.MidX;
            float yText = info.Height / 2 - textBounds.MidY;

            // And draw the text
            canvas.DrawText(str, xText, yText, textPaint);

            // Create a new SKRect object for the frame around the text
            SKRect frameRect = textBounds;
            frameRect.Offset(xText, yText);
            frameRect.Inflate(10, 10);

            // Create an SKPaint object to display the frame
            SKPaint framePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 5,
                Color = SKColors.Blue
            };

            // Draw one frame
            canvas.DrawRoundRect(frameRect, 20, 20, framePaint);

            // Inflate the frameRect and draw another
            frameRect.Inflate(10, 10);
            framePaint.Color = SKColors.DarkBlue;
            canvas.DrawRoundRect(frameRect, 30, 30, framePaint);
        }
    }
}
