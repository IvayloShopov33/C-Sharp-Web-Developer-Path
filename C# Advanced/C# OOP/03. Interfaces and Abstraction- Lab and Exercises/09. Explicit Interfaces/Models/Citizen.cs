using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IResident.GetName() => "Mr/Ms/Mrs ";

        string IPerson.GetName() => this.Name;
    }
}
