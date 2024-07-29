using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Trucks.Data.Models;
using static Trucks.Data.ModelsValidationConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType(nameof(Truck))]
    public class TruckInputXmlModel
    {
        [XmlElement(nameof(RegistrationNumber))]
        [Required]
        [MaxLength(TruckRegistrationNumberMaxValue)]
        [RegularExpression(TruckRegistrationNumberRegEx)]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement(nameof(VinNumber))]
        [Required]
        [MinLength(TruckVinNumberMinValue)]
        [MaxLength(TruckVinNumberMaxValue)]
        public string VinNumber { get; set; } = null!;

        [XmlElement(nameof(TankCapacity))]
        [Required]
        [Range(TruckTankCapacityMinValue, TruckTankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [XmlElement(nameof(CargoCapacity))]
        [Required]
        [Range(TruckCargoCapacityMinValue, TruckCargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [XmlElement(nameof(CategoryType))]
        [Required]
        [Range(TruckCategoryTypeMinValue, TruckCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [XmlElement(nameof(MakeType))]
        [Required]
        [Range(TruckMakeTypeMinValue, TruckMakeTypeMaxValue)]
        public int MakeType { get; set; }
    }
}