using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        public DateOnly? Birthday { get; set; }


        //Foreign key for login:
        public int LoginId { get; set; }
        public Login? Login { get; set; }


        public virtual ICollection<Likes> LikedByUsers { get; set; } = new List<Likes>();
        public virtual ICollection<Likes> LikedUsers { get; set; } = new List<Likes>();

        public virtual ICollection<Message> MsgSender { get; set; } = new List<Message>();
        public virtual ICollection<Message> MsgReciever { get; set; } = new List<Message>();


    }
}
