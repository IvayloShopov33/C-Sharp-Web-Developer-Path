namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;

        private Dictionary<string, double> flourTypeCalories;
        private Dictionary<string, double> bakingTechniqueCalories;

        private string flourType;
        private string bakingTechnique;
        private double doughWeight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypeCalories = new Dictionary<string, double>()
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 }
            };

            bakingTechniqueCalories = new Dictionary<string, double>()
            {
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade",1.0 }
            };

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.DoughWeight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!this.flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!this.bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double DoughWeight
        {
            get
            {
                return this.doughWeight;
            }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.doughWeight = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeCalories = this.flourTypeCalories[this.FlourType];
                double bakingTechniqueCalories = this.bakingTechniqueCalories[this.BakingTechnique];

                return BaseDoughCaloriesPerGram * this.DoughWeight * flourTypeCalories * bakingTechniqueCalories;
            }
        }
    }
}
