using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SistemaWebEmpleado.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleado.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        [CheckValidationLegajo]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}
