using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;
using CarouselView.FormsPlugin.Android;

namespace Playground.Droid
{
    [Activity(Label = "Playground", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CarouselViewRenderer.Init();

            Push.SetSenderId("739468080346");
            AppCenter.Start("39060f0c-d59c-4a13-a921-4957fb4cadc1", typeof(Push));

            LoadApplication(new App());
        }
    }
}

