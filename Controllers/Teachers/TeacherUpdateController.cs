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
    [Route("api/teacher/update")]
    public class TeacherUpdateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpPut("{Id}")]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            if(teacher == null){
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try{
                _teacherRepository.UpdateTeacher(teacher);
                return Ok(new {información =  $"Se ha actualizado correctamente el profesor {teacher.Names}", teacher});
            }catch(Exception e){
                return BadRequest($"El profesor{teacher.Names} tiene datos incorrectos: {e.Message}");
            }
        }
    }
}