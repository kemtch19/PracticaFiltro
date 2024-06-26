using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Data;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Services.Repositories
{
    public class TeacherRepository: ITeacherRepository
    {
        private readonly PracticaFiltroContext _context;
        public TeacherRepository(PracticaFiltroContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }
    }
}