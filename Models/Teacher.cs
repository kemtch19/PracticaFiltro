using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticaFiltro.Models
{
    [Table("teachers")]
    public class Teacher
    {
        [Key]
        [Required]
        [Column("id_teacher")]
        public int Id {get; set;}

        [Column("Names")]
        [Required(ErrorMessage = "Possible null value for Names teacher")]
        public string? Names {get; set;}

        [Column("Specialty")]
        [Required(ErrorMessage = "Possible null value for Specialty teacher")]
        public string? Specialty {get; set;}

        [Column("Phone")]
        [Required(ErrorMessage = "Possible null value for phone teacher")]
        public string? Phone {get; set;}

        [Column("Email")]
        [Required(ErrorMessage = "Possible null value for email teacher")]
        public string? Email {get; set;}

        [Column("YearsExperience")]
        [Required(ErrorMessage = "Possible null value for years experience teacher")]
        public int YearsExperience {get; set;}

        [JsonIgnore]
        public List<Course>? Courses {get; set;}
    }
}