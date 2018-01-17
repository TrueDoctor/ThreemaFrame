

namespace PictureFrame
{
    static class Utility
    {
        public static System.Timers.Timer timer;

        public static System.Timers.Timer reload;

        public static int DefaultIntervall { get; } = 30000; 

        public static void StartTimer(MainActivity o)
        {

            timer = new System.Timers.Timer();
            reload = new System.Timers.Timer();
            
            reload.Interval = 1000;
            reload.Elapsed += PictureSelect.OnReload;
            //reload.Start();

            timer.Interval = DefaultIntervall;
            timer.Elapsed += o.OnUpdate;
            timer.Start();
        }
    }
}