using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Courses
{
    [ApiController]
    [Route("api/course/update")]
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        public CourseUpdateController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateCourseMethod(Course course)
        {
            if (course == null)
            {
                return BadRequest("Se esta creando el estudiante con datos nulos o erroneos");
            }

            try
            {
                _coursesRepository.UpdateCourse(course);
                return Ok(new { Correcto = $"El curso {course.Name} se ah actualizad correctamente en la base de datos con estos datos: ", course });
            }
            catch (Exception e)
            {
                return BadRequest($"El curso {course.Name} tiene datos incorrectos: {e.Message}");
            }
        }
    }
}