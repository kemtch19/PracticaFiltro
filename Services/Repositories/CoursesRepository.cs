using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFiltro.Data;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Services.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly PracticaFiltroContext _context;
        private readonly int records = 2;
        public CoursesRepository(PracticaFiltroContext context)
        {
            _context = context;
        }

        public object GetAll([FromQuery] int? page)
    {
        int _page = page ?? 1;
        decimal totalRecords = _context.Courses.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
        
        var cursos = _context.Courses
            .Skip((_page - 1) * records)
            .Take(records)
            .ToList();
    
        var data = new { pages = totalPages,
                        currentPage = _page,
                        data = cursos};
        
        return data;
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