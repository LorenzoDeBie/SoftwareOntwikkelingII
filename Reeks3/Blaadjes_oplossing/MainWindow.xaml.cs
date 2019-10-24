using Blaadjes.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Blaadjes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _random = new Random();
        private Dictionary<IImage, IList<Point>> _dict;
        private ImageFactory _factory;


        public MainWindow()
        {
            InitializeComponent();
            _factory = new ImageFactory();
            _dict = new Dictionary<IImage, IList<Point>>();
            foreach (string soort in ImageFactory.SOORTEN)
            {
                _dict.Add(_factory[soort], new List<Point>());
            }

            
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += timerEvent;
            dispatcherTimer.Interval = new TimeSpan(1000000);
            dispatcherTimer.Start();
        }

        private void addLeaf()
        {
            IImage image = _factory.KiesBlad();
            Point p = new Point(_random.Next((int)Width - 20) + 10, 20);
            _dict[image].Add(p);
        }

        private void addFeather()
        {
            if (_random.Next(10) == 0)
            {
                int aantal = ImageFactory.SOORTEN.Count();
                string type = ImageFactory.SOORTEN[aantal - 1];
              
                IImage image = _factory[type];
                Point p = new Point((int) Width - 50, 20);
                _dict[image].Add(p);
               
            }

        }
        private void timerEvent(object sender, EventArgs e)
        {
            addLeaf();
            addFeather();
            canvas.Children.Clear();
            
            foreach (IImage image in _dict.Keys)
            {
                for(int i = 0; i < _dict[image].Count; i++)
                {
                    Point p = _dict[image][i];
                    p = image.Move(p);
                    p.X = Math.Min(p.X, Width);  //binnen kader Canvas
                    p.Y = Math.Min(p.Y, Height);
                    _dict[image][i] = p;
                    Draw(image, p);
                }
            }
            
        }

        private void Draw(IImage image, Point p)
        {
            Image simpleImage = image.ImageObject;
            canvas.Children.Add(simpleImage);
            Canvas.SetLeft(simpleImage, p.X);
            Canvas.SetTop(simpleImage, p.Y); 
        }
    }
}
