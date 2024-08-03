namespace TravelAgency.DataProcessor.ExportDtos
{
    public class CustomerOutputJsonModel
    {
        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public BookingOutputJsonModel[] Bookings { get; set; }
    }
}