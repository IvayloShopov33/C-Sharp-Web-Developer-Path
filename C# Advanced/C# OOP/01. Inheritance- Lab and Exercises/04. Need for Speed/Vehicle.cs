﻿namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(int kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
