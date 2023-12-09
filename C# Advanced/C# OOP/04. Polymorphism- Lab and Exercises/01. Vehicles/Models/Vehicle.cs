namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerOneKilometer { get; set; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double fuelAmount);
    }
}
