using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new();
        }

        public int Capacity { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            var vehicleToRemove = this.Vehicles.FirstOrDefault(x => x.VIN == vin);

            return this.Vehicles.Remove(vehicleToRemove);
        }

        public int GetCount() => this.Vehicles.Count;

        public Vehicle GetLowestMileage() => this.Vehicles.OrderBy(x => x.Mileage).FirstOrDefault();

        public string Report()
        {
            StringBuilder output = new();
            output.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in this.Vehicles)
            {
                output.AppendLine(vehicle.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
