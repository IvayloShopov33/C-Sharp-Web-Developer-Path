namespace Trucks.DataProcessor.ExportDto
{
    public class ClientOutputJsonModel
    {
        public string Name { get; set; } = null!;

        public TruckOutputJsonModel[] Trucks { get; set; } = null!;
    }
}