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
using Android.Media;
using Java.Lang;


namespace PictureFrame
{
    class Picture
    {
        public string name { get; private set; }
        public DateTime Date { get; private set; }
        public int orientation { get; private set; }

        public Picture(string name)
        {
            //var ex = new ExifInterface(name);
            //2017:10:06 17:50:19

            //var date = ex.GetAttribute(ExifInterface.TagDatetime);
            //if(date==null)
            //    date = ex.GetAttribute(ExifInterface.TagDatetimeDigitized);
            //if (date == null)
              //  date = ex.GetAttribute(ExifInterface.TagDatetimeOriginal);
            
            //if (date == null)
            //date = ex.GetAttribute(ExifInterface.);
            //if (date == null)
                //throw new System.Exception($"Das Bild {name} hat kein Datum.");

            //Date = DateTime.ParseExact(ex.GetAttribute(ExifInterface.TagDatetime),"yyyy:MM:dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            //date = DateTime.Parse(ex.GetAttribute(ExifInterface.TagDatetime));
            //orientation = ex.GetAttributeInt(ExifInterface.TagOrientation,0);
            this.name = name;
        }
    }
}