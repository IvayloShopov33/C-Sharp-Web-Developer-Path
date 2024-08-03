using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using TravelAgency.Data.Models;
using static TravelAgency.Data.ModelsValidationConstraints;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType(nameof(Customer))]
    public class CustomerInputXmlModel
    {
        [XmlElement(nameof(FullName))]
        [Required]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [Required]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [XmlAttribute("phoneNumber")]
        [Required]
        [MaxLength(CustomerPhoneNumberMaxLength)]
        [RegularExpression(CustomerPhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;
    }
}