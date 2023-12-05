using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IIdentification> identities = new List<IIdentification>();

            string[] input;
            while (true)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 3)
                {
                    Citizen citizen = new(input[0], int.Parse(input[1]), input[2]);
                    identities.Add(citizen);
                }
                else if (input.Length == 2)
                {
                    Robot robot = new(input[0], input[1]);
                    identities.Add(robot);
                }
            }

            string idValidation = Console.ReadLine();
            foreach (var identity in identities.Where(x => x.Id.EndsWith(idValidation)))
            {
                Console.WriteLine(identity.Id);
            }
        }
    }
}
