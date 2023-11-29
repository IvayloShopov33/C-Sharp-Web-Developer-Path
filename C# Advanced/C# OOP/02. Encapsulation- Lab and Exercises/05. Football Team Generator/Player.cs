namespace FootballTeamGenerator
{
    public class Player
    {
        private string StatArgumentExceptionMessage = "{0} should be between 0 and 100.";
        private string NameArgumentExceptionMessage = "A name should not be empty.";
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private string name;
        private int endurance;
        private int spint;
        private int dribble;
        private int passing;
        private int shooting;
        private double averageSkillLevel;

        public Player(string name, int endurance, int spint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Spint = spint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
                    throw new ArgumentException(NameArgumentExceptionMessage);
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (this.CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatArgumentExceptionMessage, nameof(this.Endurance)));
                }

                this.endurance = value;
            }
        }

        public int Spint
        {
            get
            {
                return this.spint;
            }
            private set
            {
                if (this.CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatArgumentExceptionMessage, nameof(this.Spint)));
                }

                this.spint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (this.CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatArgumentExceptionMessage, nameof(this.Dribble)));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (this.CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatArgumentExceptionMessage, nameof(this.Passing)));
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (this.CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatArgumentExceptionMessage, nameof(this.Shooting)));
                }

                this.shooting = value;
            }
        }

        public double AverageSkillLevel
        {
            get
            {
                double sumOfStats = this.Endurance + this.Spint + this.Dribble + this.Passing + this.Shooting;
                this.averageSkillLevel = sumOfStats / 5.0;

                return this.averageSkillLevel;
            }
        }

        private bool CheckStatValue(int value) => value < StatMinValue || value > StatMaxValue;

    }
}
