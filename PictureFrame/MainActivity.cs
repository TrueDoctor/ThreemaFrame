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
    
    [Activity(Label = "PictureFrame", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)] //This is what controls orientation
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

            PictureSelect.OnReload(this, EventArgs.Empty);
            OnUpdate(this, EventArgs.Empty);

            Utility.StartTimer(this);


            view.Click += delegate
            {
                //view.SetImageURI(Uri.Parse(PictureSelect.OnChange().name));
                OnUpdate(this, EventArgs.Empty);
                Utility.timer.Stop();
                Utility.timer.Start();
                
            };
            
        }
        
        public void OnUpdate(object o, EventArgs e)
        {
            
            var pic = PictureSelect.OnChange();
            PictureSelect.OnReload(this, EventArgs.Empty);

            
            RunOnUiThread(() =>
            {
                view.SystemUiVisibility =
                    (StatusBarVisibility)View.SystemUiFlagHideNavigation;

                view.Rotation = Utility.ConvertRotation(pic.orientation);
                view.SetImageURI(Uri.Parse(pic.name));
            });
        }

    }
}