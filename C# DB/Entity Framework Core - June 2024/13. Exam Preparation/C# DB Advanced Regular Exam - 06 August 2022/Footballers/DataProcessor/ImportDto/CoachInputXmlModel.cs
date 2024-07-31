using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Footballers.Data.Models;
using static Footballers.Data.ModelsValidationConstraints;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType(nameof(Coach))]
    public class CoachInputXmlModel
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(CoachNameMinLength)]
        [MaxLength(CoachNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Nationality))]
        [Required]
        public string Nationality { get; set; } = null!;

        [XmlArray(nameof(Footballers))]
        [XmlArrayItem(nameof(Footballer))]
        public virtual FootballerInputXmlModel[] Footballers { get; set; }
    }
}