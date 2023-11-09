using ApiClientes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Interfaces
{
    public interface IClienteValidationService
    {
        ValidationResult Validar(ClienteDTO clienteCreacionDto, int? id = 0);
    }
}
