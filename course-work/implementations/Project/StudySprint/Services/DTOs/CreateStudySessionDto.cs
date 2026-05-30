using System.ComponentModel.DataAnnotations;

namespace StudySprint.Services.DTOs
{
    public class CreateStudySessionDto
    {
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Subject { get; set; }

        [Range(1, 1000)]
        public int DurationMinutes { get; set; }

        public DateTime SessionDate { get; set; }

        [Range(1, 5)]
        public int Difficulty { get; set; }

        public int UserId { get; set; }
    }
}