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
    }
}