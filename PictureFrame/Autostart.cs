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
  /*  
[BroadcastReceiver]
[IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.LowPriority)]
public class BootReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        Intent serviceStart = new Intent(context, typeof(MainActivity));
        serviceStart.AddFlags(ActivityFlags.NewTask);
        context.StartActivity(serviceStart);
    }
}
    public override void OnReceive(Context context, Intent intent)
    {
        if (intent.Action == Intent.ActionBootCompleted)
        {
            bool autoRestart = false;
            var sp = context.GetSharedPreferences("preferences", FileCreationMode.Private);
            autoRestart = sp.GetBoolean("autoRestart", false);
            if (autoRestart)
            {
                Intent serviceStart = new Intent(context, typeof(MainActivity));
                serviceStart.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(serviceStart);
            }
        }
    }
}*//*
public class StartReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Hello - the app has hit the right place -old", ToastLength.Long).Show();
            /*Intent serviceStart = new Intent(context, typeof(MainActivity));
            serviceStart.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(serviceStart);*//*
            
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

            /*
            Intent timerIntent = new Intent(context, typeof(MainActivity));
            timerIntent.PutExtra("latitude", 20.2322);
            timerIntent.PutExtra("longitude", -85.123);
            Application.Context.StartService(timerIntent);*//*
        }
    }*/
}