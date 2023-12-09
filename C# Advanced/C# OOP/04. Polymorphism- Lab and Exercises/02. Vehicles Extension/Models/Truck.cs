namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerOneKilometer, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerOneKilometer = fuelConsumptionPerOneKilometer;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = (this.FuelConsumptionPerOneKilometer + IncreasedFuelConsumption) * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;

                return $"Truck travelled {distance} km";
            }

            return "Truck needs refueling";
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount > 0)
            {
                if (this.FuelQuantity + 0.95 * fuelAmount <= this.TankCapacity)
                {
                    this.FuelQuantity += 0.95 * fuelAmount;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
