using System.ComponentModel.DataAnnotations;

namespace StudySprint.Services.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Role { get; set; }

        public int Age { get; set; }
    }
}