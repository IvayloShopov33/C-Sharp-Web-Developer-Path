namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                try
                {
                    string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(personDetails[0],
                                        personDetails[1],
                                        int.Parse(personDetails[2]),
                                        decimal.Parse(personDetails[3]));

                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new Team("Shopov FC");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}