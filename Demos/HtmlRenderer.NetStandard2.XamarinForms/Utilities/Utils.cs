// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using SkiaSharp;
using System;
using System.Drawing;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;

namespace TheArtOfDev.HtmlRenderer.XamarinForms.Utilities
{
    /// <summary>
    /// Utilities for converting WinForms entities to HtmlRenderer core entities.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Convert from WinForms point to core point.
        /// </summary>
        public static RPoint Convert(PointF p)
        {
            return new RPoint(p.X, p.Y);
        }

        /// <summary>
        /// Convert from WinForms point to core point.
        /// </summary>
        public static PointF[] Convert(RPoint[] points)
        {
            PointF[] myPoints = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
                myPoints[i] = Convert(points[i]);
            return myPoints;
        }

        /// <summary>
        /// Convert from core point to WinForms point.
        /// </summary>
        public static PointF Convert(RPoint p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// Convert from core point to WinForms point.
        /// </summary>
        public static Point ConvertRound(RPoint p)
        {
            return new Point((int)Math.Round(p.X), (int)Math.Round(p.Y));
        }

        /// <summary>
        /// Convert from WinForms size to core size.
        /// </summary>
        public static RSize Convert(SizeF s)
        {
            return new RSize(s.Width, s.Height);
        }

        /// <summary>
        /// Convert from core size to WinForms size.
        /// </summary>
        public static SizeF Convert(RSize s)
        {
            return new SizeF((float)s.Width, (float)s.Height);
        }

        /// <summary>
        /// Convert from core size to WinForms size.
        /// </summary>
        public static Size ConvertRound(RSize s)
        {
            return new Size((int)Math.Round(s.Width), (int)Math.Round(s.Height));
        }

        /// <summary>
        /// Convert from WinForms rectangle to core rectangle.
        /// </summary>
        public static RRect Convert(RectangleF r)
        {
            return new RRect(r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Convert from core rectangle to WinForms rectangle.
        /// </summary>
        public static RectangleF Convert(RRect r)
        {
            return new RectangleF((float)r.X, (float)r.Y, (float)r.Width, (float)r.Height);
        }

        public static RRect Convert(SKRect r)
        {
            return new RRect((float)r.Left, (float)r.Top, (float)r.Width, (float)r.Height);
        }

        public static SKRect Convert2SKRect(RRect r)
        {
            return new SKRect((float)r.Left, (float)r.Top, (float)(r.Left + r.Width), (float)(r.Top + r.Height));
        }

        public static RSize Convert2RSize(SKSize r)
        {
            return new RSize(r.Width, r.Height);
        }

        public static SKPoint Convert2SKPoint(RPoint p)
        {
            return new SKPoint((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// Convert from core rectangle to WinForms rectangle.
        /// </summary>
        public static Rectangle ConvertRound(RRect r)
        {
            return new Rectangle((int)Math.Round(r.X), (int)Math.Round(r.Y), (int)Math.Round(r.Width), (int)Math.Round(r.Height));
        }

        /// <summary>
        /// Convert from WinForms color to core color.
        /// </summary>
        public static RColor Convert(Color c)
        {
            return RColor.FromArgb(c.A, c.R, c.G, c.B);
        }

        public static SKColor Convert2SKColor(Color c)
        {
            return new SKColor(c.R, c.G, c.B, c.A);
        }

        /// <summary>
        /// Convert from core color to WinForms color.
        /// </summary>
        public static Color Convert(RColor c)
        {
            return Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        /// <summary>
        /// mono has issue throwing exception for no reason.
        /// </summary>
        /// <param name="control">the control to create graphics object from</param>
        /// <returns>new graphics object or null in mono if failed</returns>
//        public static Graphics CreateGraphics(Control control)
//        {
//#if MONO
//            try
//            {
//                return control.CreateGraphics();
//            }
//            catch
//            {
//                return null;
//            }
//#else
//            return control.CreateGraphics();
//#endif
//        }
    }
}