namespace Medicines.DataProcessor.ExportDtos
{
    public class MedicineOutputJsonModel
    {
        public string Name { get; set; } = null!;

        public string Price { get; set; } = null!;

        public PharmacyOutputJsonModel Pharmacy { get; set; }
    }
}