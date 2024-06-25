using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticaFiltro.Models
{
    [Table("students")]/* Nombre en la tabla dentro de la base de datos para facilidad con la conexión a la base de datos */
    public class Student
    {
        [Key] /* Se le indica que este campo es la llave primaria */
        [Column("id_student")] /* Para indicar la columna de la tabla */
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Possible null field name")] /* Si este campo el usuario lo devuelve vacío le devuelve que campo le falta  */
        [Column("Names")] /* Nos sirve para conectar con la base de datos y facilitar mas adelante la conexión a la base de datos*/
        public string? Names {get; set; } /* El ? existe para que suponga que se le puede entregar un nulo, es decir, los warnings amarillos no aparezcan */

        [Column("BirthDate")]
        [Required(ErrorMessage = "Possible null field Birthdate ")]
        public DateOnly? BirthDate {get; set; }

        [Required(ErrorMessage = "Possible null field Address ")]
        [Column("Address")]
        public string? Address {get; set; }

        [Required(ErrorMessage = "Possible null field Email ")]
        [Column("Email")]
        public string? Email {get; set; }

        [JsonIgnore]
        public List<Enrollment>? Enrollments {get; set; } /* Recordar que cuando la tabla solamente tiene un 1 hacemos la lista ya que vienen datos de otra tabla y que por el contrario en la otra tabla solamente almacenamos los id de las tablas que se tienen de a muchos    */

        // donde pongo el objeto es donde va a llegar la info y donde pongo la lista es de donde van a salir los datos
    }
}