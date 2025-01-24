using Microsoft.EntityFrameworkCore;

namespace UkasNottBackend.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options): base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .Property(s => s.Id)
                .ValueGeneratedNever();  // Disable identity (auto-increment) behavior
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
