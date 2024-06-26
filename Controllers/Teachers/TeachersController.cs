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
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                var teachers = _teacherRepository.GetAll();
                return Ok(new { informacion = $"Estos son los profesores que hay actualmente: {teachers.Count()}", teachers });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los profesores: \n {e.Message}");
            }
        }
    }
}