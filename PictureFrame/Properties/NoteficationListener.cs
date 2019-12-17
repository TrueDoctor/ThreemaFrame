using System;
using Android.App;

namespace PictureFrame.Properties
{
    using Android.Content;
    using Android.Service.Notification;
    using Android.Util;
    using Android.Widget;

    [Service(Label = "ThreemaFrameService", Permission = "android.permission.BIND_NOTIFICATION_LISTENER_SERVICE")]
    [IntentFilter(new[] { "android.service.notification.NotificationListenerService" })]
    public class NotificationListener : NotificationListenerService
    {
        private String TAG = "ThreemaListener";

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Info(TAG, "Servico Criado");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Log.Info(TAG, "Servico Destruido");
        }

        


        public override void OnNotificationRemoved(StatusBarNotification sbn)
        {
            Log.Info(TAG, "********** onNOtificationRemoved");
            Log.Info(TAG, "ID :" + sbn.Id + "t" + sbn.Notification.TickerText + "t" + sbn.PackageName);
        }
    }
}
