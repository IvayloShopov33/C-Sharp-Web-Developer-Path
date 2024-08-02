namespace Medicines.Data
{
    public static class ModelsValidationConstraints
    {
        // Pharmacy
        public const byte PharmacyNameMinLength = 2;
        public const byte PharmacyNameMaxLength = 50;
        public const string PharmacyPhoneNumberRegEx = @"^\(\d{3}\) \d{3}-\d{4}$";
        public const string PharmacyIsNonStopRegEx = @"^(true|false)$";

        // Medicine
        public const byte MedicineNameMinLength = 3;
        public const byte MedicineNameMaxLength = 150;
        public const string MedicinePriceMinValue = "0.01";
        public const string MedicinePriceMaxValue = "1000.00";
        public const byte MedicineCategoryMinValue = 0;
        public const byte MedicineCategoryMaxValue = 4;
        public const byte MedicineProducerMinLength = 3;
        public const byte MedicineProducerMaxLength = 100;

        // Patient
        public const byte PatientFullNameMinLength = 5;
        public const byte PatientFullNameMaxLength = 100;
        public const byte PatientAgeGroupMinValue = 0;
        public const byte PatientAgeGroupMaxValue = 2;
        public const byte PatientGenderMinValue = 0;
        public const byte PatientGenderMaxValue = 1;
    }
}