using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public class NumberValidationBehaviour : IValidationBehaviour
	{
		public bool Validate(string s)
		{
			return double.TryParse(s, out double dump);
		}
	}
}
