using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
     
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public int PlayerId { get; set; }
        
        [Required]
        public Player Player { get; set; }
    }
}
