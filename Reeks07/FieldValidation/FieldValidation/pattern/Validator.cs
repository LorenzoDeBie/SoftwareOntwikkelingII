using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public class Validator : IValidator
	{
		public IValidationBehaviour Behaviour { get;  set; }

		public bool PerformValidation(string s)
		{
			return (Behaviour?.Validate(s)).GetValueOrDefault(false);
		}
	}
}
