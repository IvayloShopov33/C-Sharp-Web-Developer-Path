namespace Equality_Logic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new();
            SortedSet<Person> peopleSortedSet = new();

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person()
                {
                    Name = personDetails[0],
                    Age = int.Parse(personDetails[1])
                };

                peopleHashSet.Add(person);
                peopleSortedSet.Add(person);
            }

            Console.WriteLine(peopleHashSet.Count);
            Console.WriteLine(peopleSortedSet.Count);
        }
    }
}