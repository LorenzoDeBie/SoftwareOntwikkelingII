using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Blaadjes.Pattern;

namespace Blaadjes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Dictionary<IPicture, List<Point>> _dictionary = new Dictionary<IPicture, List<Point>>();
        private PictureFactory _factory = new PictureFactory();
        private Random _random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 100)
            };
            timer.Tick += TimerEvent;
            timer.Start();

        }

        private void AddLeaf()
        {
            IPicture leaf = _factory.kiesBlad();
            Point p = GetRandomPoint();
            if(!_dictionary.ContainsKey(leaf)) _dictionary.Add(leaf, new List<Point>());
            _dictionary[leaf].Add(p);
        }

        private void AddFeather()
        {
            if(_random.Next(11) == 10) {
                IPicture feather = _factory["pluim"];
                Point p = GetRandomPoint();
                if(!_dictionary.ContainsKey(feather)) _dictionary.Add(feather, new List<Point>());
                _dictionary[feather].Add(p);
            }
        }

        private Point GetRandomPoint()
        {
            return new Point()
            {
                X = _random.Next(0, (int)Width),
                Y = _random.Next(0, (int)Height)
            };
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            AddLeaf();
            AddFeather();
            canvas.Children.Clear();
            foreach (IPicture picture in _dictionary.Keys)
            {
                for(int i = 0; i < _dictionary[picture].Count; i++)
                {
                    Point p = picture.Move(_dictionary[picture][i]);
                    p.X = Math.Min(p.X, Width);
                    p.Y = Math.Min(p.Y, Height);
                    _dictionary[picture][i] = p;
                    Draw(picture, p);
                }
            }
        }

        private void Draw(IPicture picture, Point p)
        {
            Image image = picture.Image;
            canvas.Children.Add(image);
            Canvas.SetLeft(image, p.X);
            Canvas.SetTop(image, p.Y);
        }
    }
}