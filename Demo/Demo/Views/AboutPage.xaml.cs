using System;
using System.ComponentModel;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;
using TheArtOfDev.HtmlRenderer.XamarinForms;
using Xamarin.Forms;

namespace Demo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            //this.SizeChanged += AboutPage_SizeChanged;
            //this.LayoutChanged += AboutPage_LayoutChanged;

            //StackLayout st = (StackLayout)FindByName("root");
            //st.Children.Add(lbl);

            loadLabel();
        }

        //private void AboutPage_LayoutChanged(object sender, System.EventArgs e)
        //{
        //    throw new System.NotImplementedException();
        //}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ((HtmlLabel)this.Content).MaximumSize = new RSize(this.Width * App.Density, this.Height * App.Density);
        }

        //private void AboutPage_SizeChanged(object sender, System.EventArgs e)
        //{
        //    //((HtmlLabel)this.Content).MaximumSize = new TheArtOfDev.HtmlRenderer.Adapters.Entities.RSize(this.Width, this.Height);
        //}

        private void loadLabel()
        {
            string html = "<div style='font-size:50px;color:#FF8833;background-color:yellow;margin-top:20px;padding:20px;border:solid 10px blue;line-height:40px;'>"
                + "<p>font-size:50px;color:#FF8833;background-color:yellow;</p>"
                + "<p>margin-top:20px;padding:20px;border: solid 10px blue;</p>"
                + "<p>line-height:40px;</p></div>";
            html += "<div style='font-size:40px;padding:20px;border:solid 1px black;'>"
                + "<h1 align='center'>居中</h1>"
                + "<p>hello world!正体<span style='font-style:italic;'>斜体</span><span style='font-weight:bolder;'>粗体</span></p>"
                + "<p><span style='color:red;'>red</span>&nbsp;<span style='color:blue;'>blue</span> <span style='color:yellow;'>yellow</span></p>"
                + "</div>";
            html += "<table style='font-size:100px;border: solid 10px black;margin-top:20px;'><tr><td style='border: solid 10px pink;'>101</td><td style='border: solid 10px green;background-color:blue;'>102</td><td style='border: solid 10px blue;'>103</td></tr></table>";
            html += "<table style='width: 100%; border: solid 3px blue; font-size:50px;'><tr>"
                + "<td style='border:solid 3px green;'>"
                + "<img src='http://image.hnol.net/c/2014-09/27/17/201409271722258313-2282561.png' style='width:400px;' />"
                + "</td><td style='border:solid 3px #393939;'>"
                + "Everything you see on this panel (see samples on the left) is <b>custom-painted</b>"
                + "by the<b>HTML Renderer</b>, including tables, images, links and videos.<br/>"
                + "This project allows you to have the rich format power of HTML on your desktop applications"
                + "without <b>WebBrowser</b> control or <b>MSHTML</b>.<br/>"
                + "The library is <b>100 % managed code</b> without any external dependencies, the only"
                + "requirement is <b>.NET 2.0 or higher</b>, including support for Client Profile."
                + "</td><tr></table>";
            html += "<pre style='font-size:50px;background-color: white'>"
                + "<span style='color: blue'>public class</span> HelloWorld\r\n"
                + "{\r\n"
                + "    <span style = 'color: blue'>public</span> HelloWorld()\r\n"
                + "    {\r\n"
                + "        <span style = 'color: #099'> MessageBox </span >.Show(<span color = 'maroon'>\"Hello World\"</span>);\r\n"
                + "    }\r\n"
                + "}</pre>";
            HtmlLabel lbl = new HtmlLabel() { Text = html, Typeface = App.Typeface };
            Content = lbl;
        }
    }
}