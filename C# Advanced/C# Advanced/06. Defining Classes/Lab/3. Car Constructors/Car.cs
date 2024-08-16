namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int yearOfProduction) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = yearOfProduction;
        }

        public Car(string make, string model, int yearOfProduction, double fuelQuantity, double fuelConsumption) : this(make, model, yearOfProduction)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double result = this.FuelQuantity - (distance * this.FuelConsumption);
            if (result >= 0)
            {
                this.FuelQuantity = result;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
        }
    }
}
