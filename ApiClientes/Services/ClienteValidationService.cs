using ApiClientes.DTOs;
using ApiClientes.Interfaces;
using ApiClientes;
using System.ComponentModel.DataAnnotations;

public class ClienteValidationService : IClienteValidationService
{
    private readonly ApplicationDbContext context;

    public ClienteValidationService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public ValidationResult Validar(ClienteDTO clienteDto, int? id = 0)
    {
        bool existeCuit = context.Clientes.Any(c => c.Cuit == clienteDto.Cuit && c.Id != id);

        if (existeCuit)
        {
            return new ValidationResult("Ya se encuentra registrado el Cuit");
        }

        bool existeEmail = context.Clientes.Any(c => c.Email == clienteDto.Email && c.Id != id);

        if (existeEmail)
        {
            return new ValidationResult("Ya se encuentra registrado el Email");
        }

        bool existeTelefonoCelular = context.Clientes.Any(c => c.TelefonoCelular == clienteDto.TelefonoCelular && c.Id != id);

        if (existeTelefonoCelular)
        {
            return new ValidationResult("Ya se encuentra registrado el Telefono Celular");
        }

        return ValidationResult.Success;
    }
}
