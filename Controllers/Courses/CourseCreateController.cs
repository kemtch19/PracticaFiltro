using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Courses
{
    [ApiController]
    [Route("api/course/create")]
    public class CourseCreateController : ControllerBase
    {
        private readonly ICoursesRepository _courseRepository;
        public CourseCreateController(ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            if (course == null) /* Siempre hay que verificar que los datos que me traigan no sean nulos cuando se piden datos desde un parámetro */
            {
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try
            {
                _courseRepository.CreateCourse(course);
                return Ok(new { información = $"Se ha creado correctamente el curso {course.Name}", course });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error al crear el curso {e.Message}");
            }
        }
    }
}