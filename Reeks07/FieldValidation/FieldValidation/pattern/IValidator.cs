using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public interface IValidator
	{
		IValidationBehaviour Behaviour { set; }
		bool PerformValidation(string s);
	}
}
