using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Interfaces
{
    public interface ITeacherRepository
    {
        public IEnumerable<Teacher> GetAll();
        public Teacher GetOne(int id);
        public void CreateTeacher(Teacher teacher); 
        public void UpdateTeacher(Teacher teacher);
    }
}