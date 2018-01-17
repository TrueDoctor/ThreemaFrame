using System;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Linq;
using System.Drawing;
using Android.Accounts;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Java.Security;
using Android.Hardware;
using Android.OS.Storage;
using Uri = Android.Net.Uri;

namespace PictureFrame
{
    using Android.Service.Notification;

    using PictureFrame.Properties;


    using View = Android.Views.View;

    [Activity(Label = "PictureFrame", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize)] //This is what controls orientation
    public class MainActivity : Activity
    {
        private ImageView view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            view = FindViewById<ImageView>(Resource.Id.imageView);

            view.SetAdjustViewBounds(true);

            View decorView = this.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;
            newUiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            newUiOptions |= (int)SystemUiFlags.LayoutStable;
            newUiOptions |= (int)SystemUiFlags.LayoutFullscreen;
            //newUiOptions |= (int)SystemUiFlags.Immersive;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            StartService(new Intent(this, typeof(NotificationListenerService)));

            PictureSelect.OnReload(this, EventArgs.Empty);
            
            Utility.StartTimer(this);
            OnUpdate(this, EventArgs.Empty);


            view.Click += this.OnClick;
            this.view.Drag += OnDrag;
            
        }
        
        public void OnUpdate(object o, EventArgs e)
        {
            var pic = PictureSelect.OnChange();
            PictureSelect.OnReload(this, EventArgs.Empty);
            Utility.timer.Interval = Utility.DefaultIntervall;
            
            this.RunOnUiThread(() =>
            {
                view.SystemUiVisibility =
                    (StatusBarVisibility)View.SystemUiFlagHideNavigation;
                try
                {
                    view.SetImageURI(Uri.Parse(pic.name));
                }
                catch (Exception r)
                {
                    Toast.MakeText(this, r.ToString(), ToastLength.Long).Show();

                    OnUpdate(this, EventArgs.Empty);
                }
            });
        }

        public void OnClick(object o, EventArgs e)
        {
            OnUpdate(this, EventArgs.Empty);
            Utility.timer.Stop();
            Utility.timer.Interval = Utility.DefaultIntervall * 4;
            Utility.timer.Start();
        }

        public void OnDrag(object o, EventArgs e)
        {
            OnUpdate(this, EventArgs.Empty);
            Utility.timer.Stop();
            Utility.timer.Interval = Utility.DefaultIntervall / 30;
            Utility.timer.Start();
        }
    }
}