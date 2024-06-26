using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaFiltro.Controllers.Mail;
using PracticaFiltro.Data;
using PracticaFiltro.Models;
using PracticaFiltro.Services.Interfaces;

namespace PracticaFiltro.Services.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly PracticaFiltroContext _context;
        public EnrollmentRepository(PracticaFiltroContext context)
        {
            _context = context;
        }
        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ToList();
        }

        public Enrollment GetOne(int id)
        {
            return _context.Enrollments.Include(s => s.Student).Include(c => c.Course).FirstOrDefault(e => e.Id == id);
        }

        public void CreateEnrollment(Enrollment enrollment)
        {
            /* Primero hacemos las funciones normales de crear la matricula */
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            /* Luego de ello vamos a obtener los datos necesarios para pasarle al email y enviar el correo al que escojamos */
            var student = _context.Students.Find(enrollment.StudentId);
            var course = _context.Courses.Find(enrollment.CourseId);
            var teacher = _context.Teachers.Find(course.TeacherID);

            /* Instanciamos el email */
            MailController Email = new MailController();
            Email.SendEmail(student.Email, student.Names, course.Name, course.Description, course.Schedule, course.Duration, course.Capacity, teacher.Names, enrollment.Status);
        }
    }
}