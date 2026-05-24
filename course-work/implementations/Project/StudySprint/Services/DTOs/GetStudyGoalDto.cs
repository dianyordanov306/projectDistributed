using System;
using System.Collections.Generic;
using System.Text;

namespace StudySprint.Services.DTOs
{
    public class GetStudyGoalDto
    {
        public int Id { get; set; }

        public string GoalTitle { get; set; }

        public double TargetHours { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public int Priority { get; set; }

        public int UserId { get; set; }
    }
}