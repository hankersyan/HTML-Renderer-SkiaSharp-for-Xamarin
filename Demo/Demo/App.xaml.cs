using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demo.Services;
using Demo.Views;

namespace Demo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        public static SkiaSharp.SKTypeface Typeface { get; set; }
        public static string HTML { get; set; }
        public static float Density { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
