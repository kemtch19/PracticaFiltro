using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public Student GetOne(int id);
        public void CreateStudent(Student student);
        public void UpdateStudent(Student student);
    }
}