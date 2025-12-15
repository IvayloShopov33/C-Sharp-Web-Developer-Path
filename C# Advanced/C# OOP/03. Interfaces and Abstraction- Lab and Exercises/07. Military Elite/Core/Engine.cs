using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                try
                {
                    string[] soldierDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(soldierDetails));
                }
                catch (Exception ex)
                {

                }
            }
        }

        private string ProcessInput(string[] soldierDetails)
        {
            string soldierType = soldierDetails[0];
            int id = int.Parse(soldierDetails[1]);
            string firstName = soldierDetails[2];
            string lastName = soldierDetails[3];

            ISoldier soldier = null;

            switch (soldierType)
            {
                case "Private":
                    soldier = GetPrivate(id, firstName, lastName, decimal.Parse(soldierDetails[4]));
                    break;
                case "LieutenantGeneral":
                    soldier = GetLieutenantGeneral(id, firstName, lastName, decimal.Parse(soldierDetails[4]), soldierDetails);
                    break;
                case "Engineer":
                    soldier = GetEngineer(id, firstName, lastName, decimal.Parse(soldierDetails[4]), soldierDetails);
                    break;
                case "Commando":
                    soldier = GetCommando(id, firstName, lastName, decimal.Parse(soldierDetails[4]), soldierDetails);
                    break;
                case "Spy":
                    soldier = GetSpy(id, firstName, lastName, int.Parse(soldierDetails[4]));
                    break;
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }

        private ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
            => new Private(id, firstName, lastName, salary);

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] soldierDetails)
        {
            List<IPrivate> privates = new List<IPrivate>();

            for (int i = 5; i < soldierDetails.Length; i++)
            {
                int soldierId = int.Parse(soldierDetails[i]);
                IPrivate soldier = (IPrivate)soldiers[soldierId];
                privates.Add(soldier);
            }

            return new LieutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] soldierDetails)
        {
            bool isValidCorps = Enum.TryParse<Corps>(soldierDetails[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IRepair> repairs = new List<IRepair>();

            for (int i = 6; i < soldierDetails.Length; i += 2)
            {
                string partName = soldierDetails[i];
                int hoursWorked = int.Parse(soldierDetails[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] soldierDetails)
        {
            bool isValidCorps = Enum.TryParse<Corps>(soldierDetails[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IMission> missions = new List<IMission>();

            for (int i = 6; i < soldierDetails.Length; i += 2)
            {
                string codeName = soldierDetails[i];
                string missionState = soldierDetails[i + 1];

                bool isValidMissionState = Enum.TryParse<State>(missionState, out State state);

                if (!isValidMissionState)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
            => new Spy(id, firstName, lastName, codeNumber);
    }
}
