namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public bool CheckTheGivenNumericValues()
        {
            if (Year >= 1886 && FuelQuantity >= 0 && FuelConsumption >= 0)
            {
                return true;
            }

            return false;
        }

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