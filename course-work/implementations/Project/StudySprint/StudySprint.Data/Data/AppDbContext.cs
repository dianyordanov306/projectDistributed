using Microsoft.EntityFrameworkCore;
using StudySprint.Data.Entities;

namespace StudySprint.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<StudySession> StudySessions
            => Set<StudySession>();

        public DbSet<StudyGoal> StudyGoals
            => Set<StudyGoal>();
    }
}
