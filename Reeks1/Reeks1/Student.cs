namespace Reeks1
{
    public class Student : Person
    {
        private int studentNummer;

        public override string WelcomeMessage => base.WelcomeMessage + ", your student number is " + studentNummer;

        public Student(string name, int studentNummer) : base(name)
        {
            this.studentNummer = studentNummer;
        }
    }
}