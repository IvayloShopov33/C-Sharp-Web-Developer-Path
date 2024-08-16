namespace DefiningClasses
{
    public class Program
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
                people.Add(person);
            }

            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            foreach (Person human in people)
            {
                Console.WriteLine($"{human.Name} - {human.Age}");
            }
        }
    }
}