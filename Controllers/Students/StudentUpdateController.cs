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
    [Route("api/student/update")]
    public class StudentUpdateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentUpdateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateStudentMethod(Student student)
        {
            if (student == null)
            {
                return BadRequest("Se esta creando el estudiante con datos nulos o erroneos");
            }
            try
            {
                _studentRepository.UpdateStudent(student);
                return Ok( new {Correcto = $"El estudiante {student.Names} se ah actualizad correctamente en la base de datos con estos datos: ", student});    
            }
            catch (Exception e)
            {
                return BadRequest($"El estudiante {student.Names} tiene datos incorrectos: {e.Message}");
            }
        }
    }
}