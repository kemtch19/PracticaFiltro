using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Interfaces
{
    public interface IEnrollmentRepository
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetOne(int id);
        public void CreateEnrollment(Enrollment enrollment);
    }
}