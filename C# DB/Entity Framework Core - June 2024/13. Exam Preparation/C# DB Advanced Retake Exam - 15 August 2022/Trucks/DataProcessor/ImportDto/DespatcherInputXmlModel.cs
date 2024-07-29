using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Trucks.Data.Models;
using static Trucks.Data.ModelsValidationConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType(nameof(Despatcher))]
    public class DespatcherInputXmlModel
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(DespatcherNameMinLength)]
        [MaxLength(DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Position))]
        [Required]
        public string Position { get; set; } = null!;

        [XmlArray(nameof(Trucks))]
        [XmlArrayItem(nameof(Truck))]
        public TruckInputXmlModel[] Trucks { get; set; } = null!;
    }
}