namespace CarDealer.DTOs
{
    public class ImportSaleInputModel
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public decimal Discount { get; set; }
    }
}