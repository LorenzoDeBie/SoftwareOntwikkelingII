using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidation.pattern
{
	public class RekeningValidationBehaviour : IValidationBehaviour
	{
		public bool Validate(string s)
		{
			bool valid = Regex.IsMatch(s, "\\d{3}-\\d{7}-\\d{2}");
			if (!valid) return false;
			Match numberGroups = Regex.Match(s, "(\\d{3})-(\\d{7})-(\\d{2})");
			string first = numberGroups.Groups[1].Value;
			string second = numberGroups.Groups[2].Value;
			int firstTen = int.Parse(first + second);
			int third = int.Parse(numberGroups.Groups[3].Value);
			int rest = firstTen % 97;
			return rest == 0 ? third == 97 : third == rest;
		}
	}
}
