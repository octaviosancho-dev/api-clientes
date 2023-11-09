using ApiClientes.DTOs;
using ApiClientes.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ClienteValidationService clienteValidationService;
        private readonly IMapper mapper;

        public ClientesController(ApplicationDbContext context, ClienteValidationService clienteValidationService, IMapper mapper)
        {
            this.context = context;
            this.clienteValidationService = clienteValidationService;
            this.mapper = mapper;
        }

        // Método para obtener todos los registros de Clientes (GetAll)
        [HttpGet("api/clientes")]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            var clientes = await context.Clientes.ToListAsync();

            if (clientes.Count == 0)
            {
                return Ok("No se encontró ningun Cliente");
            }

            return Ok(clientes);
        }

        // Método para obtener un Cliente por su ID (Get (ID))
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById([FromRoute] int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound($"No se encontro un cliente con ese {id}");
            }

            return Ok(cliente);
        }

        // Método para buscar Clientes que contengan el nombre a buscar (Search)
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Cliente>>> SearchByNombre([FromRoute] string nombre)
        {
            var clientes = await context.Clientes.Where(cliente => cliente.Nombres.Contains(nombre)).ToListAsync();

            return Ok(clientes);
        }

        // Método para agregar un nuevo registro de Cliente (Insert)
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
        {
            ValidationResult resultado = clienteValidationService.Validar(clienteDto);

            if (resultado != ValidationResult.Success)
            {
                return BadRequest(resultado.ErrorMessage);
            }

            var autor = mapper.Map<Cliente>(clienteDto);

            context.Add(autor);

            await context.SaveChangesAsync();

            return Ok("Se agrego un nuevo cliente correctamente");
        }

        // Método para modificar un registro de Cliente (Update)
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute] int id, ClienteDTO clienteDto)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound("No se encontró el cliente");
            }

            ValidationResult resultado = clienteValidationService.Validar(clienteDto, id);

            if (resultado != ValidationResult.Success)
            {
                return BadRequest(resultado.ErrorMessage);
            }

            context.Entry(cliente).CurrentValues.SetValues(clienteDto);

            await context.SaveChangesAsync();

            return Ok("Se guardaron los cambios correctamente");
        }

        // Decidí agregar el metodo Delete aunque no era solicitado en el requerimiento. Considero que podria ser util tenerlo de todos modos.
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound("No se encontró el cliente");
            }

            context.Remove(cliente);

            await context.SaveChangesAsync();

            return Ok($"Se ha eliminado el cliente con id {id}");
        }
    }
}
