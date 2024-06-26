using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Enrollments
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            try
            {
                var matriculas = _enrollmentRepository.GetAll();
                return Ok(new { información = $"Esta es la matricula que hay actualmente: {matriculas.Count()}", matriculas });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al encontrar a las matriculas: {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetOneEnrollment(int id)
        {
            try
            {
                var matriculas = _enrollmentRepository.GetOne(id);
                if (matriculas == null)
                {
                    return NotFound($"Error, curso no encontrado con el número de id: {id}");
                }
                return Ok(new { message = $"Esta es la matricula que se obtuvo actualmente:", matriculas });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener el matricula de la base de datos, posiblemente no exista el curso con id: {id} y el mensaje es: {e.Message}");
            }
        }
    }
}