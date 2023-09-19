using System;
using System.ComponentModel.DataAnnotations;

namespace MessengerWebApi.Models
{
    public class RefreshToken
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Token { get; set; }

        public long AuthId { get; set; }
        public Auth Auth { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
