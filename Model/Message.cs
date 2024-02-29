using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        [Required]
        public int SenderID { get; set; }
        [Required]
        public int RecieverID { get; set; }
        [Required, MaxLength(255)]
        public string? MessageContent { get; set; }

        //Foreign Keys
        public int UserID { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Reciever { get; set; }
    }
}
