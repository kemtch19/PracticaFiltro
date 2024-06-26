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
    public class CoursesRepository : ICoursesRepository
    {
        private readonly PracticaFiltroContext _context;
        public CoursesRepository(PracticaFiltroContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(t => t.Teacher).ToList();
        }

        public Course GetOne(int id)
        {
            return _context.Courses.Include(t => t.Teacher).FirstOrDefault(c => c.Id == id); /* Con este include metemos el objeto de teacher asociado a este curso y lo valida con el id que se nos paso en los parámetros */
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}