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
    [IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.LowPriority)]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Intent serviceStart = new Intent(context, typeof(MainActivity));
            serviceStart.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(serviceStart);
        }
    }/*/
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
    }*/
}