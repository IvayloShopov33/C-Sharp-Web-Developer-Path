namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseToppingCaloriesPerGram = 2;

        private Dictionary<string, double> toppingTypeCalories;

        private string toppingType;
        private double toppingWeight;

        public Topping(string toppingType, double toppingWeight)
        {
            toppingTypeCalories = new Dictionary<string, double>()
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

            this.ToppingType = toppingType;
            this.ToppingWeight = toppingWeight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (!this.toppingTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double ToppingWeight
        {
            get
            {
                return this.toppingWeight;
            }
            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.toppingWeight = value;
            }
        }

        public double Calories
        {
            get
            {
                double toppingTypeCalories = this.toppingTypeCalories[this.ToppingType.ToLower()];

                return BaseToppingCaloriesPerGram * this.ToppingWeight * toppingTypeCalories;
            }
        }
    }
}
