using Microsoft.EntityFrameworkCore;
using PracticaFiltro.Models;

namespace PracticaFiltro.Data
{
    public class PracticaFiltroContext : DbContext
    {
        public PracticaFiltroContext(DbContextOptions<PracticaFiltroContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; } /* indicamos el nombre del contexto para conectarse en la base de datos y nuestra API */
    }
}