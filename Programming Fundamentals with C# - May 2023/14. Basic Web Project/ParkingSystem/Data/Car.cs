using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Data
{
    public class Car
    {
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string PlateNumber { get; set; }
    }
}
