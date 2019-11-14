using FieldValidation.pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestEvaluation
{
    [TestClass]
    public class EvaluatorTest
    {
		private IValidator validator;

        //vul deze methode aan
        public void Controleer(string invoer, bool assert, IValidator validator)
        {
			Assert.AreEqual(assert, validator.PerformValidation(invoer));
        }


        [TestMethod]
        public void NumberTesten()
        {
			validator = new Validator() { Behaviour = new NumberValidationBehaviour() };
            Controleer("123", true, validator);
            Controleer("0.123", true, validator);
            Controleer("0,123", true, validator);
            Controleer("1.123E33", true, validator);
            Controleer("0", true, validator);
            Controleer("-0.0", true, validator);
            Controleer("", false, validator);
            Controleer("-", false, validator);
            Controleer("0.123a", false, validator);
        }
       
        [TestMethod]
        public void EmailTesten()
        {
			validator = new Validator() { Behaviour = new EmailValidationBehaviour() };
			Controleer("user@host", true, validator);
            Controleer("first.last@host", true, validator);
            Controleer("first.last@host.domain", true, validator);
            Controleer("user", false, validator);
            Controleer(" ", false, validator);
            Controleer("first.last", false, validator);
            Controleer("user.", false, validator);
            Controleer("user@", false, validator);
            Controleer("user@.", false, validator);
            Controleer("user.@", false, validator);
            Controleer("first.last@.domain", false, validator);
        }



        [TestMethod]
        public void BankTesten()
        {
			validator = new Validator() { Behaviour = new RekeningValidationBehaviour() };
			Controleer("123-4567890-02", true, validator);
            Controleer("abc-defghij-kl", false, validator);
            Controleer("12-34-70", false, validator);
            Controleer("1234-567890-02", false, validator);
            Controleer("123-4567890-12", false, validator);
        }

    }
}
