using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FieldValidation.pattern;
using FieldValidation.pattern.Email2State;


namespace FieldValidationTests
{
	[TestClass]
	public class UnitTest1
	{
		private IValidator validator;
		[TestMethod]
		public void TestMethod1()
		{
			validator = new Validator();
			validator.Behaviour = new EmailValidation2();
		}
	}
}
