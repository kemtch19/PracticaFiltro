using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Controllers.Teachers
{
    [ApiController]
    [Route("api/teacher/create")]
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher){
            if(teacher == null){
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try{
                _teacherRepository.CreateTeacher(teacher);
                return Ok(new {información =  $"Se ha creado correctamente el profesor {teacher.Names}", teacher});
            }catch(Exception e){
                return StatusCode(500, $"Error al crear el estudiante {e.Message}");
            }
        }
    }
}