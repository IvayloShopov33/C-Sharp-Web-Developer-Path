namespace _06._Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerOneKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerOneKilometer = fuelConsumptionPerOneKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerOneKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void DriveCar(double distance)
        {
            double remainingFuel = this.FuelAmount - (distance * this.FuelConsumptionPerOneKilometer);

            if (remainingFuel >= 0)
            {
                this.FuelAmount = remainingFuel;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}