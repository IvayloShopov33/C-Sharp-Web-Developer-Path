namespace Invoices.DataProcessor.ExportDto
{
    public class ProductOutputJsonModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public ClientOutputJsonModel[] Clients { get; set; }
    }
}