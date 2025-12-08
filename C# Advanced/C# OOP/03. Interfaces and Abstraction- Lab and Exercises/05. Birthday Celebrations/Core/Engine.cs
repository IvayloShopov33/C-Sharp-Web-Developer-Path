using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBirthable> identities = new List<IBirthable>();
            string[] input;

            while (true)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Citizen" && input.Length == 5)
                {
                    IBirthable citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    identities.Add(citizen);
                }
                else if (input[0] == "Pet" && input.Length == 3)
                {
                    IBirthable pet = new Pet(input[1], input[2]);
                    identities.Add(pet);
                }
            }

            string yearForBirthValidation = Console.ReadLine();
            foreach (IBirthable identity in identities.Where(x => x.BirthDate.EndsWith(yearForBirthValidation)))
            {
                Console.WriteLine(identity.BirthDate);
            }
        }
    }
}
