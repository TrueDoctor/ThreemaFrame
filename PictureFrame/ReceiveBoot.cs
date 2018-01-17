using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PictureFrame
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted },
        Categories = new[] { Android.Content.Intent.CategoryDefault }
    )]
    public class ReceiveBoot : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Toast.MakeText(context, “Received intent!”, ToastLength.Short).Show();

            if ((intent.Action != null) &&
                (intent.Action ==
                 Android.Content.Intent.ActionBootCompleted))
            { // Start the service or activity
                //context.ApplicationContext.StartService(new Intent(context, typeof(MainActivity)));

                Toast.MakeText(context, "Hello - the app has hit the right place - now to launch the app", ToastLength.Long).Show();

                Intent serviceStart = new Intent(context, typeof(MainActivity));
                serviceStart.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(serviceStart);

                Android.Content.Intent start = new Android.Content.Intent(context, typeof(MainActivity));

                // my activity name is MainActivity replace it with yours
                start.AddFlags(ActivityFlags.NewTask);
                context.ApplicationContext.StartActivity(start);
            }
        }
    }
}
