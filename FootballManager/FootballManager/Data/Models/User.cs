using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(20,MinimumLength =5)]
        public string Username { get; set; }
        [Required]
        [StringLength(60,MinimumLength =10)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();

    }
}
