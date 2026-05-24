using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StudySprint.Data.Entities
{
    public class StudyGoal
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string GoalTitle { get; set; }

        public double TargetHours { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public int Priority { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
