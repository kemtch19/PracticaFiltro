using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;

namespace PracticaFiltro.Services.Interfaces
{
    public interface ICoursesRepository 
    {
        public object GetAll([FromQuery] int? page);
        public Course GetOne(int id);
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course);
    }
}