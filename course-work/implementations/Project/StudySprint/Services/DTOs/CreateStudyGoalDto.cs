using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StudySprint.Services.DTOs
{
    public class CreateStudyGoalDto
    {
        [Required]
        [MaxLength(100)]
        public required string GoalTitle { get; set; }

        public double TargetHours { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public int Priority { get; set; }

        public int UserId { get; set; }
    }
}
