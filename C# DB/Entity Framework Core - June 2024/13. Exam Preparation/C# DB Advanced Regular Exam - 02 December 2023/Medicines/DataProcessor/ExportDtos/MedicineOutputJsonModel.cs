using Medicines.Data.Models;

namespace Medicines.DataProcessor.ExportDtos
{
    public class MedicineOutputJsonModel
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public PharmacyOutputJsonModel Pharmacy { get; set; }
    }
}