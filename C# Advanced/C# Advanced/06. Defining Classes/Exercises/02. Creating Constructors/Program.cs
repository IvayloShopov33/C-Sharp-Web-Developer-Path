namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person zeroArgumentPerson = new Person();
            Person oneArgumentPerson = new Person(17);
            Person twoArgumentsPerson = new Person("Ivaylo", 17);
        }
    }
}