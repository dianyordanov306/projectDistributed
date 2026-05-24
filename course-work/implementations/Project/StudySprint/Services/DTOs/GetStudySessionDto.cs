using System;
using System.Collections.Generic;
using System.Text;

namespace StudySprint.Services.DTOs
{
    public class GetStudySessionDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public int DurationMinutes { get; set; }

        public DateTime SessionDate { get; set; }

        public double Difficulty { get; set; }

        public int UserId { get; set; }
    }
}
