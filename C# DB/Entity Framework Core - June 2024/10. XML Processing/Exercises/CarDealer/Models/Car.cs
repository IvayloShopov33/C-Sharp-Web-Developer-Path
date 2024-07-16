using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Car
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Make { get; set; } = null!;

        [StringLength(50)]
        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();    

        public ICollection<PartCar> PartsCars { get; set; } = new List<PartCar>();
    }
}
