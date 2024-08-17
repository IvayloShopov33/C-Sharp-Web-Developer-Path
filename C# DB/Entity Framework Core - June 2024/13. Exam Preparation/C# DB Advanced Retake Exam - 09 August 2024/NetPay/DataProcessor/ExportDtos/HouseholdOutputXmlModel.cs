using System.Xml.Serialization;

using NetPay.Data.Models;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType(nameof(Household))]
    public class HouseholdOutputXmlModel
    {
        [XmlElement(nameof(ContactPerson))]
        public string ContactPerson { get; set; } = null!;

        [XmlElement(nameof(Email))]
        public string? Email { get; set; }

        [XmlElement(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray(nameof(Expenses))]
        [XmlArrayItem(nameof(Expense))]
        public ExpenseOutputXmlModel[] Expenses { get; set; } = null!;
    }
}