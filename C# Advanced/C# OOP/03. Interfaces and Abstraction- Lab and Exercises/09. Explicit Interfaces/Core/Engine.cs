using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] input;

            while (true)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                IPerson person = new Citizen(input[0], input[1], int.Parse(input[2]));
                IResident resident = new Citizen(input[0], input[1], int.Parse(input[2]));
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName() + person.GetName());
            }
        }
    }
}
