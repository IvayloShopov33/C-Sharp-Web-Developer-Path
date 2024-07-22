namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clientsWithTheirInvoices = context.Clients
                .Where(x => x.Invoices.Any(y => y.IssueDate > date))
                .Select(x => new ClientOutputXmlModel
                {
                    Name = x.Name,
                    NumberVat = x.NumberVat,
                    InvoicesCount = x.Invoices.Count,
                    Invoices = x.Invoices
                        .OrderBy(y => y.IssueDate)
                        .ThenByDescending(y => y.DueDate)
                        .Select(y => new InvoiceOutputXmlModel
                        {
                            Number = y.Number,
                            Amount = (double)y.Amount,
                            DueDate = y.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            Currency = y.CurrencyType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.InvoicesCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ClientOutputXmlModel[]), new XmlRootAttribute("Clients"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(stringWriter, clientsWithTheirInvoices, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var productsWithMostClients = context.Products
                .Where(x => x.ProductsClients
                    .Where(y => y.Client.Name.Length >= nameLength).Count() > 0)
                .Select(x => new ProductOutputJsonModel
                {
                    Name = x.Name,
                    Price = (double)x.Price,
                    Category = x.CategoryType.ToString(),
                    Clients = x.ProductsClients
                        .Select(y => new ClientOutputJsonModel
                        {
                            Name = y.Client.Name,
                            NumberVat = y.Client.NumberVat,
                        })
                        .Where(y => y.Name.Length >= nameLength)
                        .OrderBy(x => x.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Clients.Where(y => y.Name.Length >= nameLength).Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(productsWithMostClients, Formatting.Indented);
        }
    }
}