using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidation.pattern.Email2State
{
	public class EmailValidation2 : IValidationBehaviour
	{
		private IStatus current;
		private IStatus init, i1, i2, i3, accept;

		public EmailValidation2()
		{
			init = new InitStatus(this);
			i1 = new I1Status(this);
			i2 = new I2Status(this);
			i3 = new I3Status(this);
			accept = new AcceptStatus(this);
			current = init;
		}

		public bool Validate(string s)
		{
			//split s op alle '.' en '@'
			Regex rgx = new Regex(@"[\.@]");
			foreach(string part in rgx.Split(s))
			{
				Console.WriteLine(part);
			}
			throw new NotImplementedException();
		}
	}
}
