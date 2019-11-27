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


using System.IO;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;
using TheArtOfDev.HtmlRenderer.Adapters;
using TheArtOfDev.HtmlRenderer.XamarinForms.Utilities;
using Xamarin.Forms;
using HtmlRenderer.NetStandard2.XamarinForms.Z;
using SkiaSharp;

namespace TheArtOfDev.HtmlRenderer.XamarinForms.Adapters
{
    /// <summary>
    /// Adapter for WinForms platforms.
    /// </summary>
    internal sealed class MonoAdapter : RAdapter
    {
        #region Fields and Consts

        /// <summary>
        /// Singleton instance of global adapter.
        /// </summary>
        private static readonly MonoAdapter _instance = new MonoAdapter();

        #endregion


        /// <summary>
        /// Init installed font families and set default font families mapping.
        /// </summary>
        private MonoAdapter()
        {
            AddFontFamilyMapping("monospace", "Courier New");
            AddFontFamilyMapping("Helvetica", "Arial");

            //foreach (var family in FontFamily.Families)
            //{
            //    AddFontFamily(new FontFamilyAdapter(family));
            //}
        }

        /// <summary>
        /// Singleton instance of global adapter.
        /// </summary>
        public static MonoAdapter Instance
        {
            get { return _instance; }
        }

        protected override RColor GetColorInt(string colorName)
        {
            // TODO:
            var color = System.Drawing.Color.FromName(colorName);
            return Utils.Convert(color);
        }

        protected override RPen CreatePen(RColor color)
        {
            return new PenAdapter(new ZPen() { Color = Utils.Convert2SKColor(Utils.Convert(color)) });
        }

        protected override RBrush CreateSolidBrush(RColor color)
        {
            //System.Drawing.Brush bbb = null;
            //System.Drawing.SolidBrush ssb = null;

            ZBrush solidBrush;
            if (color == RColor.White)
                solidBrush = new ZSolidBrush(Color.White);
            else if (color == RColor.Black)
                solidBrush = new ZSolidBrush(Color.Black);
            else if (color.A < 1)
                solidBrush = new ZSolidBrush(Color.Transparent);
            else
                solidBrush = new ZSolidBrush(Utils.Convert(color));

            return new BrushAdapter(solidBrush, false);
        }

        protected override RBrush CreateLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
        {
            // TODO
            return null;
            //return new BrushAdapter(new System.Drawing.Drawing2D.LinearGradientBrush(Utils.Convert(rect), Utils.Convert(color1), Utils.Convert(color2), (float)angle), true);
        }

        protected override RImage ConvertImageInt(object image)
        {
            return image != null ? new ImageAdapter((SKImage)image) : null;
        }

        protected override RImage ImageFromStreamInt(Stream memoryStream)
        {
            SKBitmap bmp = SKBitmap.Decode(memoryStream);
            SKImage img = SKImage.FromBitmap(bmp);
            return new ImageAdapter(img);
        }

        protected override RFont CreateFontInt(string family, double size, RFontStyle style)
        {
            //var fontStyle = (FontStyle)((int)style);
            //Font font = new Font(family, (float)size, fontStyle);
            FontAttributes arrt = FontAttributes.None;
            if ((style | RFontStyle.Italic) > 0)
                arrt |= FontAttributes.Italic;
            if ((style | RFontStyle.Bold) > 0)
                arrt |= FontAttributes.Bold;
            return new FontAdapter(Font.SystemFontOfSize(size, arrt));
        }

        protected override RFont CreateFontInt(RFontFamily family, double size, RFontStyle style)
        {
            //var fontStyle = (FontStyle)((int)style);
            //return new FontAdapter(new Font(((FontFamilyAdapter)family).FontFamily, (float)size, fontStyle));
            FontAttributes arrt = FontAttributes.None;
            if ((style | RFontStyle.Italic) > 0)
                arrt |= FontAttributes.Italic;
            if ((style | RFontStyle.Bold) > 0)
                arrt |= FontAttributes.Bold;
            return new FontAdapter(Font.SystemFontOfSize(size, arrt));
        }

        protected override object GetClipboardDataObjectInt(string html, string plainText)
        {
            //return ClipboardHelper.CreateDataObject(html, plainText);
            return null;
        }

        protected override void SetToClipboardInt(string text)
        {
            //ClipboardHelper.CopyToClipboard(text);
        }

        protected override void SetToClipboardInt(string html, string plainText)
        {
            //ClipboardHelper.CopyToClipboard(html, plainText);
        }

        protected override void SetToClipboardInt(RImage image)
        {
            //Clipboard.SetImage(((ImageAdapter)image).Image);
        }

        protected override RContextMenu CreateContextMenuInt()
        {
            //return new ContextMenuAdapter();
            return null;
        }

        protected override void SaveToFileInt(RImage image, string name, string extension, RControl control = null)
        {
            //using (var saveDialog = new SaveFileDialog())
            //{
            //    saveDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            //    saveDialog.FileName = name;
            //    saveDialog.DefaultExt = extension;

            //    var dialogResult = control == null ? saveDialog.ShowDialog() : saveDialog.ShowDialog(((ControlAdapter)control).Control);
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        ((ImageAdapter)image).Image.Save(saveDialog.FileName);
            //    }
            //}
        }
    }
}