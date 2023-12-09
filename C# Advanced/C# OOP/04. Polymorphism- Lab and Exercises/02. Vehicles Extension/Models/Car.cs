namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerOneKilometer, double tankCapacity)
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

                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
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
