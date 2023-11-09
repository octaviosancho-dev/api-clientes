using ApiClientes.DTOs;
using ApiClientes.Entities;
using AutoMapper;

namespace ApiClientes.Utils
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
