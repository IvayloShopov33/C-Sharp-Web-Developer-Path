using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models.Divers
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> @catch;
        private double competitionPoints;
        private bool hasHealthIssues;

        protected Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.@catch = new List<string>();
            this.competitionPoints = 0;
            this.hasHealthIssues = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get
            {
                return this.oxygenLevel;
            }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get
            {
                return this.@catch.AsReadOnly();
            }
        }

        public double CompetitionPoints
        {
            get
            {
                return Math.Round(this.competitionPoints, 1);
            }
            private set
            {
                this.competitionPoints = Math.Round(value, 1);
            }
        }

        public bool HasHealthIssues => this.hasHealthIssues;

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.@catch.Add(fish.Name);
            this.competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (this.hasHealthIssues)
            {
                this.hasHealthIssues = false;
            }
            else
            {
                this.hasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {this.CompetitionPoints} ]";
        }
    }
}
