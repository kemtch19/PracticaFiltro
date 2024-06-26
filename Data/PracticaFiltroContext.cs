using Microsoft.EntityFrameworkCore;
using PracticaFiltro.Models;

namespace PracticaFiltro.Data
{
    public class PracticaFiltroContext : DbContext
    {
        public PracticaFiltroContext(DbContextOptions<PracticaFiltroContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}