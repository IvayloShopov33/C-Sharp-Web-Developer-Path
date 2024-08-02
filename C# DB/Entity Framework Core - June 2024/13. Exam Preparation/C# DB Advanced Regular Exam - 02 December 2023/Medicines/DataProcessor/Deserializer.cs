namespace Medicines.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using static Medicines.Data.ModelsValidationConstraints;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var output = new StringBuilder();
            var patients = JsonConvert.DeserializeObject<PatientInputJsonModel[]>(jsonString);
            var validPatients = new List<Patient>();

            foreach (var currentPatient in patients)
            {
                if (!IsValid(currentPatient))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var isAgeGroupValid = int.TryParse(currentPatient.AgeGroup, out int ageGroup);
                var isGenderValid = int.TryParse(currentPatient.Gender, out int gender);

                if (!isAgeGroupValid || ageGroup < PatientAgeGroupMinValue || ageGroup > PatientAgeGroupMaxValue ||
                    !isGenderValid || gender < PatientGenderMinValue || gender > PatientGenderMaxValue)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient
                {
                    FullName = currentPatient.FullName,
                    AgeGroup = (AgeGroup)ageGroup,
                    Gender = (Gender)gender,
                };

                foreach (var medicineId in currentPatient.MedicineIds)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medicineId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    patient.PatientsMedicines.Add(new PatientMedicine
                    {
                        MedicineId = medicineId,
                        Patient = patient,
                    });
                }

                validPatients.Add(patient);
                output.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(PharmacyInputXmlModel[]), new XmlRootAttribute("Pharmacies"));
            var stringReader = new StringReader(xmlString);

            var pharmacies = (PharmacyInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validPharmacies = new List<Pharmacy>();

            foreach (var currentPharmacy in pharmacies)
            {
                if (!IsValid(currentPharmacy))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var pharmacy = new Pharmacy
                {
                    Name = currentPharmacy.Name,
                    PhoneNumber = currentPharmacy.PhoneNumber,
                    IsNonStop = bool.Parse(currentPharmacy.IsNonStop),
                };

                foreach (var currentMedicine in currentPharmacy.Medicines)
                {
                    if (!IsValid(currentMedicine))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isCategoryAnInteger = int.TryParse(currentMedicine.Category, out int category);
                    var isProductionDateValid = DateTime.TryParseExact(currentMedicine.ProductionDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime productionDate);
                    var isExpiryDateValid = DateTime.TryParseExact(currentMedicine.ExpiryDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime expiryDate);

                    if (!isCategoryAnInteger || category < MedicineCategoryMinValue || category > MedicineCategoryMaxValue)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!isProductionDateValid || !isExpiryDateValid || DateTime.Compare(productionDate, expiryDate) >= 0)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(x => x.Name == currentMedicine.Name && x.Producer == currentMedicine.Producer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new Medicine
                    {
                        Name = currentMedicine.Name,
                        Price = currentMedicine.Price,
                        Category = (Category)category,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = currentMedicine.Producer,
                        PharmacyId = pharmacy.Id,
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                output.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
