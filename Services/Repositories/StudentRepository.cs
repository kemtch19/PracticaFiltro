using PracticaFiltro.Data;
using PracticaFiltro.Services.Interfaces;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PracticaFiltroContext _context;
        public StudentRepository(PracticaFiltroContext context)
        {
            _context = context;
        }


        // Listamos todos los estudiantes a una interfaz
        public IEnumerable<Student> GetAll() /* El IEnumerable es como una colección de un modelo que ya existe y nos va a decolver una lista de estudiantes */
        {
            return _context.Students.ToList();
        }

        public Student GetOne(int id) /* Este método nos devuelve un solo estudiante que buscamos en la base de datos y vamos a retornar todo el estudiante con sus datos */
        {
            return _context.Students.Find(id);
        }

        public void CreateStudent(Student student) /* no retornamos nada porque se va a agregar internamente al estudiante en el contexto de la base de datos y luego de ellos lo vamos a guardar en la misma */
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student) /* Se crea la lógica en el controlador para valir que no me llegue un valor nulo en estudiante y ya creame directamente */
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // Todo los crear y actualizar siempre debe de tener un savechanges
    }
}