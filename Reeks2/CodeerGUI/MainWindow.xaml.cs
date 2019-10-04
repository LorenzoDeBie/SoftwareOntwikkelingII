using System.Windows;
using Codering;
using Codering.UML;

namespace CodeerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _input = null;
        private ICodeerbareString _codeerbareString;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(_input))
            {
                _input = txtInput.Text;
                _codeerbareString = new PlainText();
            }
            
            if (radioBlok.IsChecked.GetValueOrDefault(false))
            {
                _codeerbareString = new Blok(_codeerbareString);
            }
            else if (radioCijfer.IsChecked.GetValueOrDefault(false))
            {
                _codeerbareString = new Cijfer(_codeerbareString);
            }
            else if (radioWissel.IsChecked.GetValueOrDefault(false))
            {
                _codeerbareString = new Wissel(_codeerbareString);
            }

            txtOutput.Text = _codeerbareString.GecodeerdeString(_input);
        }
    }
}