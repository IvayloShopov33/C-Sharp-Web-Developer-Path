using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class PatientOutputXmlModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("AgeGroup")]
        public string AgeGroup { get; set; }

        [XmlAttribute("Gender")]
        public string Gender { get; set; }

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public PatientMedicineOutputXmlModel[] Medicines { get; set; }
    }
}