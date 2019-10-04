using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLinks_OnClick(object sender, RoutedEventArgs e)
        {
            rotate(-90);
        }

        private void rotate(int angle)
        {
            ImageRotateTransform.Angle += angle;
        }

        private void BtnRechts_OnClick(object sender, RoutedEventArgs e)
        {
            rotate(90);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog().GetValueOrDefault(false))
            {
                string fileName = openFileDialog.FileName;
                Image.Source = new BitmapImage(new Uri(fileName));
                BtnLinks.IsEnabled = true;
                BtnRechts.IsEnabled = true;
                Bestandsnaam.Text = openFileDialog.SafeFileName;
                ImageRotateTransform.Angle = 0;
            }
        }
    }
}