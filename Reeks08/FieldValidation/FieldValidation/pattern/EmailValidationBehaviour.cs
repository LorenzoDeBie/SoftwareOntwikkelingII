using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public class EmailValidationBehaviour : IValidationBehaviour
	{
		public bool Validate(string s)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(s);
				return addr.Address == s;
			}
			catch
			{
				return false;
			}
		}
	}
}
