namespace Reeks1
{
    public abstract class Person
    {
        string name;

        public string Name => name;
        public virtual string WelcomeMessage => "Hello " + name;

        public Person(string name)
        {
            this.name = name;
        }
        
    }
}