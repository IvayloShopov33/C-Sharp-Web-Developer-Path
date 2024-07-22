using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ClientOutputXmlModel
    {
        [XmlElement("ClientName")]
        public string Name { get; set; }

        [XmlElement("VatNumber")]
        public string NumberVat { get; set; }

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        [XmlArrayItem("Invoice")]
        public InvoiceOutputXmlModel[] Invoices { get; set; }
    }
}