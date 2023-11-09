using System.ComponentModel.DataAnnotations;

namespace ApiClientes.DTOs
{
    public class ClienteDTO
    {
        // Validamos que los campos Nombres y Apellidos sea obligatorio y que no pueda contener mas de 50 caracteres
        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombres no puede tener mas de 50 caracteres")]
        public string Nombres { get; set; }
        
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Apellidos no puede tener mas de 50 caracteres")]
        public string Apellidos { get; set; }

        // Validamos el correcto formato de FechaNacimiento
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        
        // Validamos que Cuit sea obligatorio, tenga exactamente 11 digitos y que los mismos sean de tipo numerico
        [Required(ErrorMessage = "El campo CUIT es obligatorio")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "El campo CUIT debe tener 11 dígitos numéricos.")]
        public string Cuit { get; set; }
        
        public string Domicilio { get; set; }
        
        // Para TelefonoCelular validamos que sea obligatorio, sea solo caracteres del tipo numero, y que el largo del string esté entre 10 y 14 caracteres (+xx xx-xxxx-xxxx)
        [Required(ErrorMessage = "El campo Telefono Celular es obligatorio")]
        [MinLength(10, ErrorMessage = "El telefono celular debe tener como minimo 10 digitos")]
        [MaxLength(14, ErrorMessage = "El telefono no puede tener mas de 14 digitos")]
        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "El campo de Teléfono Celular debe tener solo valores numéricos")]
        public string TelefonoCelular { get; set; }
        
        // Validamos que el campo Email sea obligatorio y tenga un formato correcto
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Email debe tener un formato válido")]
        public string Email { get; set; }
    }
}
