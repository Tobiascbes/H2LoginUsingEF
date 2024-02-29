using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class Login
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string? LoginName { get; set; }
        [Required]
        [Length(8, 16)]
        public string? Password { get; set; }


    }
}
