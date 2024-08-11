using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);
                Person person = new Person(name, age);
                AddMemberToTheFamily(people, person);
            }
            Person theOldest = GetOldestMember(people);
            Console.WriteLine($"{theOldest.Name} {theOldest.Age}");
        }
        static void AddMemberToTheFamily(List<Person> people, Person person)
        {          
            people.Add(person);
        }

        static Person GetOldestMember(List<Person> people)
        {
            people = people.OrderByDescending(g => g.Age).ToList();
            return people[0];
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
