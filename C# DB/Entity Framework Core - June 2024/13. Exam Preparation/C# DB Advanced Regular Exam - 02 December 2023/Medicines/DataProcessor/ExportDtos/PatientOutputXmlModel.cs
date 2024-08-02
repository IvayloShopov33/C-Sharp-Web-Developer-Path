using System.Xml.Serialization;

using Medicines.Data.Models;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType(nameof(Patient))]
    public class PatientOutputXmlModel
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(AgeGroup))]
        public string AgeGroup { get; set; } = null!;

        [XmlAttribute(nameof(Gender))]
        public string Gender { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        [XmlArrayItem(nameof(Medicine))]
        public MedicineOutputXmlModel[] Medicines { get; set; }

    }
}