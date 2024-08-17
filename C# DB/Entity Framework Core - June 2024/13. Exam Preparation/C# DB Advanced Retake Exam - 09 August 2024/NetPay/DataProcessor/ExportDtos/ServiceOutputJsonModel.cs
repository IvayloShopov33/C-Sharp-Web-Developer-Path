namespace NetPay.DataProcessor.ExportDtos
{
    public class ServiceOutputJsonModel
    {
        public string ServiceName { get; set; } = null!;

        public SupplierOutputJsonModel[] Suppliers { get; set; } = null!;
    }
}