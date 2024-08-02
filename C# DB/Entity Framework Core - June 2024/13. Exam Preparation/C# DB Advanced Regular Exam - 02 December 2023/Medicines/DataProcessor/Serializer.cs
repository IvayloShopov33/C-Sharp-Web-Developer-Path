namespace Medicines.DataProcessor
{
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var patientsWithTheirMedicines = context.Patients
                .Where(x => x.PatientsMedicines
                    .Any(y => DateTime.Compare(y.Medicine.ProductionDate, DateTime.Parse(date, CultureInfo.InvariantCulture)) > 0))
                .Select(x => new PatientOutputXmlModel
                {
                    Name = x.FullName,
                    AgeGroup = x.AgeGroup.ToString(),
                    Gender = x.Gender.ToString().ToLower(),
                    Medicines = x.PatientsMedicines
                        .Where(y => DateTime.Compare(y.Medicine.ProductionDate, DateTime.Parse(date, CultureInfo.InvariantCulture)) > 0)
                        .OrderByDescending(y => y.Medicine.ExpiryDate)
                        .ThenBy(x => x.Medicine.Price)
                        .Select(y => new MedicineOutputXmlModel
                        {
                            Name = y.Medicine.Name,
                            Price = $"{y.Medicine.Price:f2}",
                            Producer = y.Medicine.Producer,
                            Category = y.Medicine.Category.ToString().ToLower(),
                            ExpiryDate = y.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        })
                        .ToArray(),
                })
                .OrderByDescending(x => x.Medicines.Length)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PatientOutputXmlModel[]), new XmlRootAttribute("Patients"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, patientsWithTheirMedicines, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicinesFromDesiredCategoryInNonStopPharmacies = context.Medicines
                .Where(x => x.Category == (Category)medicineCategory && x.Pharmacy.IsNonStop)
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .Select(x => new MedicineOutputJsonModel
                {
                    Name = x.Name,
                    Price = $"{x.Price:f2}",
                    Pharmacy = new PharmacyOutputJsonModel
                    {
                        Name = x.Pharmacy.Name,
                        PhoneNumber = x.Pharmacy.PhoneNumber,
                    },
                })
                .ToArray();

            return JsonConvert.SerializeObject(medicinesFromDesiredCategoryInNonStopPharmacies, Formatting.Indented);
        }
    }
}
