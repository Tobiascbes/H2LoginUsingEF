using System.ComponentModel.DataAnnotations;

namespace DatingAppModelToDatabase.Models
{
    public class Likes
    {
        [Required]
        public int LikesID { get; set; }
        
        public int LikerID { get; set; }
        
        public int LikeeID { get; set; }
        public int Status { get; set; }

        //Foreign Key for likes
        public int UserID { get; set; }
        public User? User { get; set; }



        public virtual User Liker { get; set; } = null!;
        public virtual User Likee { get; set; } = null!;
    }
}
