using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessengerWebAPI.Models
{
    public class Auth
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(60)]
        public string Password { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
