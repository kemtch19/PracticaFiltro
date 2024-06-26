using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaFiltro.Data;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Services.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly PracticaFiltroContext _context;
        public EnrollmentRepository(PracticaFiltroContext context)
        {
            _context = context;
        }
        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(s => s.Student).Include(c=> c.Course).ToList();
        }
    }
}