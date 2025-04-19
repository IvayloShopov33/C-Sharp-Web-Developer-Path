using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IdentityOfAPerson> identitiesOfAPeople = new List<IdentityOfAPerson>();
            InitializePeople(identitiesOfAPeople);
            
            identitiesOfAPeople = SortAndPrintPeople(identitiesOfAPeople);
        }

        static void InitializePeople(List<IdentityOfAPerson> identitiesOfAPeople)
        {
            string[] personInformation = Console.ReadLine().Split();
            while (personInformation[0] != "End")
            {
                string name = personInformation[0];
                string id = personInformation[1];
                int age = int.Parse(personInformation[2]);
                
                IdentityOfAPerson identityOfAPerson = new IdentityOfAPerson(name, id, age);
                bool alreadyHaveThisId = identitiesOfAPeople.Any(x => x.ID == id);
                
                if (alreadyHaveThisId)
                {
                    IdentityOfAPerson person = identitiesOfAPeople.First(g => g.ID == id);
                    person.Name = name;
                    person.Age = age;
                }
                else
                {
                    identitiesOfAPeople.Add(identityOfAPerson);
                }
                
                personInformation = Console.ReadLine().Split();
            }
        }
        
        static List<IdentityOfAPerson> SortAndPrintPeople(List<IdentityOfAPerson> identitiesOfAPeople)
        {
            identitiesOfAPeople = identitiesOfAPeople.OrderBy(h => h.Age).ToList();
            foreach (IdentityOfAPerson person in identitiesOfAPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }

            return identitiesOfAPeople;
        }
    }

    public class IdentityOfAPerson
    {
        public IdentityOfAPerson(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        
        public string Name { get; set; }
        
        public string ID { get; set; }

        public int Age { get; set; }
    }
}
