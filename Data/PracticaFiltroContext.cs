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
    }
}