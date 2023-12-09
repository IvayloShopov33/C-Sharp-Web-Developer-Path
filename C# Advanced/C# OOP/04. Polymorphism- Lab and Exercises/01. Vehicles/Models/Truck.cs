namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerOneKilometer)
        {
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

        public override void Refuel(double fuelAmount) => this.FuelQuantity += 0.95 * fuelAmount;
    }
}
