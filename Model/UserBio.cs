using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class UserBio
    {
        public int UserBioID { get; set; }
        [MaxLength(255)]
        public string? Bio { get; set; }
        [Required]
        [Range(50, 210)]
        public int Height { get; set; }
        [Required]
        public string? Gender { get; set; }

        //Foreign Keys
        public int UserID { get; set; }
        public User? User { get; set; }
        public int CityID { get; set; }
        public City? City { get; set; }
    }
}
