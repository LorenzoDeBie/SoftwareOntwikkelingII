using FieldValidation.pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FieldValidation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IValidator validator;

		public MainWindow()
		{
			InitializeComponent();
			validator = new Validator();
		}

		private void ValidateText(object sender, RoutedEventArgs args)
		{
			string textToValidate = txtInput.Text;
			string textTypeValidation = cmbType.Text;
			if (textTypeValidation.Equals("Bank"))
			{
				validator.Behaviour = new RekeningValidationBehaviour();
			}
			else if (textTypeValidation.Equals("Number"))
			{
				validator.Behaviour = new NumberValidationBehaviour();
			}
			else if (textTypeValidation.Equals("Email"))
			{
				validator.Behaviour = new EmailValidationBehaviour();
			}
			else return;

			if(validator.PerformValidation(textToValidate))
			{
				//alert met goed
				MessageBox.Show("Validation succeeded.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				//allert met bad
				MessageBox.Show("Validation Failed!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}

		}

	}
}
