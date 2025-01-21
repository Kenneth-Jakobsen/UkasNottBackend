using Microsoft.EntityFrameworkCore;

namespace UkasNøttBackend.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options): base (options)
        {

        }
        public DbSet<Student> Students { get; set; }

    }
}
