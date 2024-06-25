using PracticaFiltro.Data;
using PracticaFiltro.Services.Interfaces;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PracticaFiltroContext _context;
        public StudentRepository(PracticaFiltroContext context)
        {
            _context = context;
        }


        // Listamos todos los estudiantes a una interfaz
        public IEnumerable<Student> GetAll()
        { /* El IEnumerable es como una colección de un modelo que ya existe  */
            return _context.Students.ToList();
        }

        // Todo los crear y actualizar siempre debe de tener un savechanges
    }
}