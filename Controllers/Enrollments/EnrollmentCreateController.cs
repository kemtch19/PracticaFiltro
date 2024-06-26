using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Enrollments
{
    [ApiController]
    [Route("api/enrollment/create")]
    public class EnrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        [HttpPost]
        public IActionResult CreateEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _enrollmentRepository.CreateEnrollment(enrollment);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la matrícula: {ex.Message}");
            }
        }
    }
}