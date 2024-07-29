using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Data.ModelsValidationConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType(nameof(Creator))]
    public class CreatorInputXmlModel
    {
        [XmlElement(nameof(FirstName))]
        [Required]
        [MinLength(CreatorFirstNameMinLength)]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [XmlElement(nameof(LastName))]
        [Required]
        [MinLength(CreatorLastNameMinLength)]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [XmlArray(nameof(Boardgames))]
        [XmlArrayItem(nameof(Boardgame))]
        public virtual BoardgameInputXmlModel[] Boardgames { get; set; }
    }
}