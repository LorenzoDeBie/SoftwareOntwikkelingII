using Microsoft.Win32;
using SorteerBestanden;
using Sorteren;
using System.IO;
using System.Windows;

namespace SorteerProgramma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _fileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "Comma Seperated Values (.csv)|*.csv";
            bool? res = openFileDialog.ShowDialog();
            if(res == true)
            {
                _fileName = openFileDialog.FileName;
            }
            TxtInputFile.Text = _fileName;
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            //check filename
            if (string.IsNullOrEmpty(_fileName)) return;
            if (!File.Exists(_fileName)) return;

            //do the sorting
            Vergelijker vergelijker = new Vergelijker();
            string fDir = Path.GetDirectoryName(_fileName);
            string fName = Path.GetFileNameWithoutExtension(_fileName);
            string fExt = Path.GetExtension(_fileName);
            string uitvoerbestand = Path.Combine(fDir, string.Concat(fName, "_sorted", fExt));
            if (TypeSchool.IsChecked == true)
            {
                if (SortBubble.IsChecked == true)
                {
                    new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.BubbleSorteer, vergelijker).Parse(_fileName, uitvoerbestand);
                    TxtResult.Text = "Scholen gesorteerd met Bubble Sort";
                }
                else if (SortSelection.IsChecked == true)
                {
                    new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.SelectieSorteer, vergelijker).Parse(_fileName, uitvoerbestand);
                    TxtResult.Text = "Scholen gesorteerd met Selection Sort";
                }
                else
                {
                    TxtResult.Text = "Sorteermethode ongekend!";
                    return;
                }
            }
            else if (TypePark.IsChecked == true)
            {
                if (SortBubble.IsChecked == true)
                {
                    new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.BubbleSorteer, vergelijker).Parse(_fileName, uitvoerbestand);
                    TxtResult.Text = "Parken gesorteerd met Bubble Sort";
                }
                else if (SortSelection.IsChecked == true)
                {
                    new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.SelectieSorteer, vergelijker).Parse(_fileName, uitvoerbestand);
                    TxtResult.Text = "Parken gesorteerd met Selection Sort";
                }
                else
                {
                    TxtResult.Text = "Sorteermethode ongekend!";
                    return;
                }
            }
            else
            {
                TxtResult.Text = "Type ongekend!";
                return;
            }
            TxtResult.Text += " in " + Path.GetFileName(uitvoerbestand);
        }
    }
}
