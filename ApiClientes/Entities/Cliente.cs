using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClientes.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }
        public string Cuit {  get; set; }
        public string Domicilio { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }
    }
}
