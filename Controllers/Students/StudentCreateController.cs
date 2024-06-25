using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Data;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Students
{
    [ApiController]
    [Route("api/student/create")]
    public class StudentCreateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentCreateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try
            {
                _studentRepository.CreateStudent(student);
                return Ok(new {información =  $"Se ha creado correctamente el estudiante ", student});
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error al crear el estudiante {e.Message}"); /* Error de estado 500 solamente cuando se crea */
            }
        }
    }
}