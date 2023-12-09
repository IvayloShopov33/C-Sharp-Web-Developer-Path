namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double IncreasedFuelConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerOneKilometer, double tankCapacity)
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

                return $"Bus travelled {distance} km";
            }

            return "Bus needs refueling";
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = this.FuelConsumptionPerOneKilometer * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;

                return $"Bus travelled {distance} km";
            }

            return "Bus needs refueling";
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount > 0)
            {
                if (this.FuelQuantity + fuelAmount <= this.TankCapacity)
                {
                    this.FuelQuantity += fuelAmount;
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
