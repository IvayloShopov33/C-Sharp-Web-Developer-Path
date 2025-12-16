using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine("Repairs:");

            foreach (IRepair repair in this.Repairs)
            {
                output.AppendLine($"  {repair.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
