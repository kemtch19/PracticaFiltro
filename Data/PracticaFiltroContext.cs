using Microsoft.EntityFrameworkCore;

namespace PracticaFiltro.Data
{
    public class PracticaFiltroContext : DbContext
    {
        public PracticaFiltroContext(DbContextOptions<PracticaFiltroContext> options) : base(options)
        {

        }

        public DbSet<>
    }
}