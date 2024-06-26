using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Interfaces
{
    public interface ICoursesRepository 
    {
        public IEnumerable<Course> GetAll();
        public Course GetOne(int id);
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course);
    }
}