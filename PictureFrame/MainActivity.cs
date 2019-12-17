namespace PictureFrame
{
    using System;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Views;
    using Android.Widget;

    using Uri = Android.Net.Uri;

    [Activity(
        Label = "PictureFrame",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize)] // This is what controls orientation
    public class MainActivity : Activity
    {
        private DateTime date;

        private TextView dateScreen;

        private ImageView view;

        public void OnClick(object o, EventArgs e)
        {
            this.OnUpdate(this, EventArgs.Empty);
            Utility.timer.Stop();
            Utility.timer.Interval = Utility.DefaultInterval * 4;
            Utility.timer.Start();
        }

        public void OnDateClick(object o, EventArgs e)
        {
            Toast.MakeText(this, "Frohen Advent Oma!", ToastLength.Long).Show();
            this.dateScreen.Visibility = ViewStates.Gone;
        }

        public void OnDrag(object o, EventArgs e)
        {
            this.OnUpdate(this, EventArgs.Empty);
            Utility.timer.Stop();
            Utility.timer.Interval = Utility.DefaultInterval / 30.0;
            Utility.timer.Start();
        }

        public void OnUpdate(object o, EventArgs e)
        {
            var pic = PictureSelect.OnChange();
            PictureSelect.OnReload(this, EventArgs.Empty);
            Utility.timer.Interval = Utility.DefaultInterval;

            this.RunOnUiThread(
                () =>
                    {
                        if (this.date.Day != DateTime.Now.Day && this.date.Month == 12 && this.date.Day <= 24)
                        {
                            this.dateScreen.Text = DateTime.Today.Date.Day.ToString();
                            this.dateScreen.Visibility = ViewStates.Visible;
                            this.date=DateTime.Now;
                        }

                        this.view.SystemUiVisibility =
                            (StatusBarVisibility)SystemUiFlags.HideNavigation;

                        try
                        {
                            this.view.SetImageURI(Uri.Parse(pic.name));
                            
                        }
                        catch (Exception r)
                        {
                            Toast.MakeText(this, r.ToString(), ToastLength.Long).Show();

                            this.OnUpdate(this, EventArgs.Empty);
                        }
                    });
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.RequestWindowFeature(WindowFeatures.NoTitle);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            this.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            this.SetContentView(Resource.Layout.Main);
            this.view = this.FindViewById<ImageView>(Resource.Id.imageView);
            this.dateScreen = this.FindViewById<TextView>(Resource.Id.textView1);

            this.view.SetAdjustViewBounds(true);

            View decorView = this.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = uiOptions;
            newUiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            newUiOptions |= (int)SystemUiFlags.LayoutStable;
            newUiOptions |= (int)SystemUiFlags.LayoutFullscreen;

            // newUiOptions |= (int)SystemUiFlags.Immersive;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            // StartService(new Intent(this, typeof(NotificationListenerService)));
            PictureSelect.OnReload(this, EventArgs.Empty);

            Utility.StartTimer(this);
            this.OnUpdate(this, EventArgs.Empty);

            this.dateScreen.Click += this.OnDateClick;

            // dateScreen.Click += this.OnClick;
            this.view.Click += this.OnClick;
            this.view.Drag += this.OnDrag;

            this.date = DateTime.Now;
            this.dateScreen.Visibility = ViewStates.Gone;
        }
    }
}