namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int familyMembersCount = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= familyMembersCount; i++)
            {
                string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);
                
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestFamilyMember = family.GetOldestMember();
            Console.WriteLine($"{oldestFamilyMember.Name} {oldestFamilyMember.Age}");
        }
    }
}
