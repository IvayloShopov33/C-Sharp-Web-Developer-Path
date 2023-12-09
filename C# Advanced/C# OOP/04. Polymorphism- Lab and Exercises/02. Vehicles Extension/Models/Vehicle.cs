namespace VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerOneKilometer;
        private double tankCapacity;

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerOneKilometer
        {
            get
            {
                return this.fuelConsumptionPerOneKilometer;
            }
            set
            {
                this.fuelConsumptionPerOneKilometer = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                this.tankCapacity = value;
            }
        }

        public abstract string Drive(double distance);

        public abstract void Refuel(double fuelAmount);
    }
}
