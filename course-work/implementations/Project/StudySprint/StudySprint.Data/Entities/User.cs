using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudySprint.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Role { get; set; }

        public int Age { get; set; }

        public ICollection<StudySession> StudySessions { get; set; }
            = new List<StudySession>();

        public ICollection<StudyGoal> StudyGoals { get; set; }
            = new List<StudyGoal>();
    }
}
