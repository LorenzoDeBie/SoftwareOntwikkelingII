using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public interface IValidationBehaviour
	{
		bool Validate(string s);
	}

	public enum ValidationBehaviours
	{
		BANK,
		EMAIL,
		REKENING
	}
}
