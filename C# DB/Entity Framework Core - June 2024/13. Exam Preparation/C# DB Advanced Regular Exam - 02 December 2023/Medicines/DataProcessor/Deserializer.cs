namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var patientDtos = JsonConvert.DeserializeObject<PatientInputJsonModel[]>(jsonString);
            var validPatients = new List<Patient>();

            foreach (var pDto in patientDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient
                {
                    FullName = pDto.FullName,
                    AgeGroup = (AgeGroup)pDto.AgeGroup,
                    Gender = (Gender)pDto.Gender,
                };

                foreach (int medId in pDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine
                    {
                        Patient = patient,
                        MedicineId = medId,
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }
            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(PharmacyInputXmlModel[]),
                new XmlRootAttribute("Pharmacies"));

            var stringReader = new StringReader(xmlString);
            var pharmacies = (PharmacyInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validPharmacies = new List<Pharmacy>();

            foreach (var phDto in pharmacies)
            {
                if (!IsValid(phDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy
                {
                    Name = phDto.Name,
                    PhoneNumber = phDto.PhoneNumber,
                    IsNonStop = bool.Parse(phDto.IsNonStop),
                };

                foreach (var medDto in phDto.Medicines)
                {
                    if (!IsValid(medDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime
                        .TryParseExact(medDto.ProductionDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

                    if (!isProductionDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpityDate;
                    bool isExpityDateValid = DateTime
                        .TryParseExact(medDto.ExpiryDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineExpityDate);

                    if (!isExpityDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpityDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(x => x.Name == medDto.Name && x.Producer == medDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine
                    {
                        Name = medDto.Name,
                        Price = (decimal)medDto.Price,
                        Category = (Category)medDto.Category,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpityDate,
                        Producer = medDto.Producer,
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
