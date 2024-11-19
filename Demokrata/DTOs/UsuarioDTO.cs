using System.ComponentModel.DataAnnotations;

namespace Demokrata.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El primer nombre no puede contener números.")]
        public string PrimerNombre { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El segundo nombre no puede contener números.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer apellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El primer apellido no puede contener números.")]
        public string PrimerApellido { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El segundo apellido no puede contener números.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor que 0.")]
        public decimal Sueldo { get; set; }
    }
}
