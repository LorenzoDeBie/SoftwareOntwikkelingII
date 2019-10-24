using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Blaadjes.Pattern
{
    public abstract class APicture : IPicture
    {
        private BitmapImage _bitmapImage;
        protected double w, h;
        public Image Image
        {
            get
            {
                Image obj = new Image()
                {
                    Source = _bitmapImage,
                    Height = w,
                    Width = h
                };
                return obj;
            }
        }

        public APicture(string filename)
        {
            if(!File.Exists(filename)) throw new FileNotFoundException("Image not found!");
            _bitmapImage = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            w = 25; h = 25;
        }

        public abstract Point Move(Point p);
    }
}