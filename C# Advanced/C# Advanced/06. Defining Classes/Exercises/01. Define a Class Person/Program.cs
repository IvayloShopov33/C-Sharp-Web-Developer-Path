namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= peopleCount; i++)
            {
                string[] personDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);
                Person person = new Person(name, age);

                if (person.IsAgeValid())
                {
                    people.Add(person);
                }
            }

            Console.WriteLine($"Count of people with valid age is: {people.Count}");
            foreach (Person human in people)
            {
                Console.WriteLine($"Name: {human.Name}\nAge: {human.Age}\n");
            }
        }
    }
}