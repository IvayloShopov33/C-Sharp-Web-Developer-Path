using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            this.conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Stamina { get; protected set; }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {          
            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                Stamina -= 2;
            }

            if (Stamina < 0)
            {
                Stamina = 0;
            }
            else
            {
                if (!ConqueredPeaks.Contains(peak.Name))
                {
                    conqueredPeaks.Add(peak.Name);
                }
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");

            if (ConqueredPeaks.Count == 0)
            {
                sb.AppendLine("no peaks conquered");
            }
            else
            {
                sb.AppendLine($"{ConqueredPeaks.Count}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
