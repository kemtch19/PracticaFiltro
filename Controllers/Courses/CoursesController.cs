using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Courses
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            try
            {
                var materias = _coursesRepository.GetAll();
                return Ok(new { informacion = $"Estos son las materias que hay actualmente: {materias.Count()}", materias });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los cursos: {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetCourse(int id)
        {
            try
            {
                var materia = _coursesRepository.GetOne(id);
                if (materia == null)
                {
                    return NotFound($"Error, curso no encontrado con el número de id: {id}");
                }
                return Ok(new { message = $"Esta es la materia que se obtuvo actualmente: \n Nombre: {materia.Name}", materia });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener el curso de la base de datos, posiblemente no exista el curso con id: {id} y el mensaje es: {e.Message}");
            }
        }
    }
}