using System.ComponentModel.DataAnnotations;

namespace StudySprint.Services.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Role { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}