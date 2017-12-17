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
using Android.Hardware;

namespace PictureFrame
{
    static class Utility
    {
        public static System.Timers.Timer timer;

        public static System.Timers.Timer reload;

        public static void StartTimer(MainActivity o)
        {

            timer = new System.Timers.Timer();
            reload = new System.Timers.Timer();
            
            reload.Interval = 1000;
            reload.Elapsed += PictureSelect.OnReload;
            //reload.Start();

            timer.Interval = 30000;
            timer.Elapsed += o.OnUpdate;
            timer.Start();
        }

        public static int ConvertRotation(int orientation)
        {
            int rotation = 0;
            switch (orientation)
            {
                case 3:
                    rotation = 180;
                    break;
                case 4:
                    rotation = 180;
                    //matrix.postScale(-1, 1);
                    break;
                case 5:
                    rotation = 90;
                    //matrix.postScale(-1, 1);
                    break;
                case 6:
                    rotation = 90;
                    break;
                case 7:
                    rotation = -90;
                    //matrix.postScale(-1, 1);
                    break;
                case 8:
                    rotation = -90;
                    break;
                default:
                    return rotation;
            }
            return rotation;
        }
    }
}