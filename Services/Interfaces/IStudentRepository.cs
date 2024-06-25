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
    }
}