namespace Trucks.DataProcessor.ExportDto
{
    public class TruckOutputJsonModel
    {
        public string TruckRegistrationNumber { get; set; } = null!;

        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public string CategoryType { get; set; } = null!;

        public string MakeType { get; set; } = null!;
    }
}