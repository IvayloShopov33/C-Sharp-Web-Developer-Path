namespace P01_HospitalDatabase.Data
{
    public static class ModelsValidationConstraints
    {
        // Patient
        public const byte PatientFirstNameMaxLength = 50;
        public const byte PatientLastNameMaxLength = 50;
        public const byte PatientAddressMaxLength = 250;
        public const byte PatientEmailMaxLength = 80;

        // Visitation
        public const byte VisitationCommentsMaxLength = 250;

        // Diagnose
        public const byte DiagnoseNameMaxLength = 50;
        public const byte DiagnoseCommentsMaxLength = 250;

        // Medicament
        public const byte MedicamentNameMaxLength = 50;

        // Doctor
        public const byte DoctorNameMaxLength = 100;
        public const byte DoctorSpecialtyMaxLength = 100;
    }
}