namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var patientsWithTheirMedicines = context.Patients
                .Where(x => x.PatientsMedicines
                    .Any(y => y.Medicine.ProductionDate >= DateTime.Parse(date, CultureInfo.InvariantCulture)))
                .Select(x => new PatientOutputXmlModel
                {
                    Name = x.FullName,
                    AgeGroup = x.AgeGroup.ToString(),
                    Gender = x.Gender.ToString().ToLower(),
                    Medicines = x.PatientsMedicines
                        .Where(y => y.Medicine.ProductionDate >= DateTime.Parse(date, CultureInfo.InvariantCulture))
                        .OrderByDescending(y => y.Medicine.ExpiryDate)
                        .ThenBy(y => y.Medicine.Price)
                        .Select(y => new PatientMedicineOutputXmlModel
                        {
                            Name = y.Medicine.Name,
                            Price = $"{y.Medicine.Price:f2}",
                            Producer = y.Medicine.Producer,
                            Category = y.Medicine.Category.ToString().ToLower(),
                            BestBefore = y.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Medicines.Length)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PatientOutputXmlModel[]), new XmlRootAttribute("Patients"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
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
                        PhoneNumber = x.Pharmacy.PhoneNumber
                    },
                })
                .ToList();

            return JsonConvert.SerializeObject(medicinesFromDesiredCategoryInNonStopPharmacies, Formatting.Indented);
        }
    }
}
