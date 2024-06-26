using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PracticaFiltro.Models
{
    [Table("enrollments")]
    public class Enrollment
    {
        [Key]
        [Required]
        [Column("id_enrollment")]
        public int Id { get; set; }

        [Column("Date_enrollment")]
        [Required(ErrorMessage = "Possible null value for Date_enrollment")]
        public DateOnly? Date_enrollment { get; set; }

        // Cuando la tabla es de muchos a muchos se debe de colocar solo los id de las llaves foraneas ya que en sus respectivas tablas se van a crear las listas para poder recibir los datos que vengan, además de que estoy trayendo un objeto de esa tabla y tiene todos los datos necesarios

        [Column("StudentId")]
        [Required(ErrorMessage = "Possible null value for StudentId")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [Column("CourseId")]
        [Required(ErrorMessage = "Possible null value for CourseId")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [Column("Status")]
        [Required(ErrorMessage = "Possible null value for status code")]
        public string? Status { get; set; }
    }
}