using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFiltro.Models
{
    [Table("students")]/* Nombre en la base de datos para facilidad con la conexión en la base de datos */
    public class Student
    {
        [Key] /* Se le indica que este campo es la llave primaria */
        [Column("id_student")] /* Para indicar la columna de la tabla */
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Possible null field name")] /* Si este campo el usuario lo devuelve vacío le devuelve que campo le falta,  */
        [Column("Names")] /* Nos sirve para conectar a  conectar con la base de datos y facilitar mas adelante en la base de datos*/
        public string? Names {get; set; } /* Existe para que suponga que se le puede entregar un nulo, es decir, los warnings amarillos no aparezcan */

    
        
    }
}