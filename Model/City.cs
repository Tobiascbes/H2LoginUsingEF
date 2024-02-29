using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class City
    {
        [Required]
        public int CityId { get; set; }
        [Required]
        public string? CityName { get; set; }
    }
}
