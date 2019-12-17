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
using Java.Security;

using Android.Graphics;
using System.IO;
using System.Drawing;
using System.Linq.Expressions;
using File = Java.IO.File;


namespace PictureFrame
{
    static class PictureSelect
    {
        private static int _id;
        private static List<Picture> _pictures = new List<Picture>();
        private static Queue<Picture> _history = new Queue<Picture>();
        private static List<Picture> _currentPics = new List<Picture>();

        private static void LoadPictures(string path)
        {
            //var files = System.IO.Directory.GetFiles(path, "*.jpg");
            File dir = new File(path);
            var files = dir.ListFiles();

            _pictures.Clear();
            if (files == null) return;

            foreach (File file in files)
            {
                _pictures.Add(new Picture(file.AbsolutePath));
            }

            var last = new Queue<int>();
            /*
            _pictures.Clear();
            foreach (var pic in _pictureList)
            {
                _pictures.Add(new Picture(pic));
            }*/
            //_pictures.Sort((x, y) => DateTime.Compare(x.Date, y.Date));

            //_pictures = _pictures.OrderBy(x => x.ToInt()).ToList();

            _pictures.Reverse();

            var _oldPics = _currentPics;
            _currentPics = _pictures.Take(10).ToList();
            if (!_oldPics.Exists(x => x.name.Equals(_currentPics[0].name)))
            {
                _id = 0;
            }

        }

        public static void OnReload(object o, EventArgs e)
        {
            var three = Android.OS.Environment.ExternalStorageDirectory;//(Environment.ExternalStorageDirectory);
            LoadPictures("/storage/emulated/0/Threema/Threema Pictures");
        }


        public static Picture OnChange()
        {
            Picture pic = null;

            if (_id == _currentPics.Count)
                _id = 0;
            //Uri path2 = Android.Net.Uri.Parse(path + pic);
            if (_currentPics.Count != 0)
                pic = _currentPics[_id++];

            return pic;
        }
    }
}