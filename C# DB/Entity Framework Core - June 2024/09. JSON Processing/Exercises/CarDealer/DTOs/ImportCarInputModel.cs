namespace CarDealer.DTOs
{
    public class ImportCarInputModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TraveledDistance { get; set; }

        public IEnumerable<int> PartsId { get; set; }
    }
}