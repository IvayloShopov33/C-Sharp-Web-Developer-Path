namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ClientInputXmlModel[]), new XmlRootAttribute("Clients"));
            var stringReader = new StringReader(xmlString);
            var clients = (ClientInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validClients = new List<Client>();

            foreach (var currentClient in clients)
            {
                if (!IsValid(currentClient))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client
                {
                    Name = currentClient.Name,
                    NumberVat = currentClient.NumberVat,
                };

                foreach (var currentAddress in currentClient.Addresses)
                {
                    if (!IsValid(currentAddress))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var address = new Address
                    {
                        StreetName = currentAddress.StreetName,
                        StreetNumber = currentAddress.StreetNumber,
                        PostCode = currentAddress.PostCode,
                        City = currentAddress.City,
                        Country = currentAddress.Country,
                        ClientId = client.Id,
                    };

                    client.Addresses.Add(address);
                }

                output.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
                validClients.Add(client);
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var output = new StringBuilder();
            var invoices = JsonConvert.DeserializeObject<InvoiceInputJsonModel[]>(jsonString);
            var validInvoices = new List<Invoice>();

            foreach (var currentInvoice in invoices)
            {
                if (!IsValid(currentInvoice))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime invoiceIssueDate;
                bool isIssueDateValid = DateTime
                    .TryParseExact(currentInvoice.IssueDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out invoiceIssueDate);

                if (!isIssueDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime invoiceDueDate;
                bool isDueDateValid = DateTime
                    .TryParseExact(currentInvoice.DueDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out invoiceDueDate);

                if (!isDueDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceIssueDate > invoiceDueDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                decimal invoiceAmount;
                bool isAmountValid = decimal.TryParse(currentInvoice.Amount.ToString(), out invoiceAmount);

                if (!isAmountValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Clients.Any(x => x.Id == currentInvoice.ClientId))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var invoice = new Invoice
                {
                    Number = currentInvoice.Number,
                    IssueDate = invoiceIssueDate,
                    DueDate = invoiceDueDate,
                    Amount = invoiceAmount,
                    CurrencyType = (CurrencyType)currentInvoice.CurrencyType,
                    ClientId = currentInvoice.ClientId,
                };

                validInvoices.Add(invoice);
                output.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var output = new StringBuilder();
            var products = JsonConvert.DeserializeObject<ProductInputJsonModel[]>(jsonString);
            var validProducts = new List<Product>();

            foreach (var currentProduct in products)
            {
                if (!IsValid(currentProduct))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product
                {
                    Name = currentProduct.Name,
                    Price = currentProduct.Price,
                    CategoryType = (CategoryType)currentProduct.CategoryType,
                };

                foreach (var currentClientId in currentProduct.Clients.Distinct())
                {
                    if (!context.Clients.Any(x => x.Id == currentClientId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient
                    {
                        ClientId = currentClientId,
                        Product = product
                    });
                }

                validProducts.Add(product);
                output.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
