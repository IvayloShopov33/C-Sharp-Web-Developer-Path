using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using NetPay.Data.Models;

using static NetPay.Data.ModelsValidationConstraints;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType(nameof(Household))]
    public class HouseholdInputXmlModel
    {
        [XmlElement(nameof(ContactPerson))]
        [Required]
        [StringLength(HouseholdContactPersonMaxLength, MinimumLength = HouseholdContactPersonMinLength)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [StringLength(HouseholdEmailMaxLength, MinimumLength = HouseholdEmailMinLength)]
        public string? Email { get; set; }

        [XmlAttribute("phone")]
        [Required]
        [RegularExpression(HouseholdPhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;
    }
}