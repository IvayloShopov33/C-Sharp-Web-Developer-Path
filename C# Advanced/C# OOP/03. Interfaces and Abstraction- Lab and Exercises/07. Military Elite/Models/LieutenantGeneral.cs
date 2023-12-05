using MilitaryElite.Models.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine("Privates:");
            foreach (IPrivate currentPrivate in this.Privates)
            {
                output.AppendLine($"  {currentPrivate.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
