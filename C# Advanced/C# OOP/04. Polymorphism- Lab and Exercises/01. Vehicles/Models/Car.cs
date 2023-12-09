namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerOneKilometer)
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

                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double fuelAmount) => this.FuelQuantity += fuelAmount;
    }
}
