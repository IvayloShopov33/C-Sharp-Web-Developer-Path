namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 1; i <= lines; i++)
            {
                string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personDetails[0],
                                        personDetails[1],
                                        int.Parse(personDetails[2]),
                                        decimal.Parse(personDetails[3]));

                people.Add(person);
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(parcentage));

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}