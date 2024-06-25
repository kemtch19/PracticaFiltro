using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticaFiltro.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id_course")]
        [Required]
        public int Id {get; set;}

        [Column("Name")]
        [Required(ErrorMessage = "Possible null field name course")]
        public string? Name {get; set; }

        [Column("Description")]
        [Required(ErrorMessage = "Possible null field description course")]
        public string? Description {get; set; }

        [Column("Schedule")]
        [Required(ErrorMessage = "Possible null field schedule course")]
        public string? Schedule {get; set; }

        [Column("Duration")]
        [Required(ErrorMessage = "Possible null field duration course")]
        public string? Duration {get; set; }

        [Column("Capacity")]
        [Required(ErrorMessage = "Possible null field capacity course")]
        public int? Capacity {get; set; }

        [Column("TeacherId")]
        [Required(ErrorMessage = "Possible null field TeacherId course")]
        public int? TeacherID {get; set; }
        public Teacher? Teacher {get; set;}

        [JsonIgnore]
        public List<Enrollment>? Enrollments {get; set; }
    }
}