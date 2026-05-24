using System;
using System.Collections.Generic;
using System.Text;
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

        public int DurationMinutes { get; set; }

        public DateTime SessionDate { get; set; }

        public double Difficulty { get; set; }

        public int UserId { get; set; }
    }
}