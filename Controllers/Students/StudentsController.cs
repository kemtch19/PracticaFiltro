using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Students
{
    [ApiController]
    [Route("api/student")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return Ok( _studentRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los estudiantes {e.Message}");
            }
        }
    }
}