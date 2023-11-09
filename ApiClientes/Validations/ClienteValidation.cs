using ApiClientes.DTOs;
using ApiClientes.Entities;
using ApiClientes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Validations
{
    public class ClienteValidation : ValidationAttribute
    {
        private readonly IClienteValidationService clienteValidationService;

        public ClienteValidation(IClienteValidationService clienteValidationService)
        {
            this.clienteValidationService = clienteValidationService;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is ClienteDTO clienteDto)
            {
                ValidationResult resultadoValidacion = clienteValidationService.Validar(clienteDto);

                return resultadoValidacion;
            }

            return ValidationResult.Success;
        }
    }
}
