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
    [Route("api/students")] /* Route significa todo el localhost, es decir, esto -> http://localhost:5049 y ya lo que hay en route seria http://localhost:5049/api/students -> eso sería este controlador en principio */
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
                var students = _studentRepository.GetAll();

                return Ok(new { informacion = $"Estos son los estudiantes que hay actualmente: {students.Count()}", students });
                // return Ok( new message = {$"Estos son los estudiantes que hay actualmente:}, _studentRepository.GetAll()");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los estudiantes: \n {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetOne(id); /* mandamos la respuesta que nos devuelve el método si devuelve null es porque no se creo correctamente pero si se creo mandar mensaje de ok con todos los datos que se crearon */

                if (student == null)
                {
                    return NotFound($"Error, estudiante no encontrado con el número de id: {id}");
                }
                // return Ok(student);
                return Ok(new { message = $"Este es el estudiante que se obtuvo actualmente: \n Nombre: {student.Names} \n BirthDate: {student.BirthDate}", student });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener el estudiante de la base de datos, posiblemente no exista el estudiante con id: {id}");
            }
        }
    }
}