using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}
