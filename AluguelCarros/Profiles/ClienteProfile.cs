using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;

namespace AluguelCarros.Profiles
{
    public class ClienteProfile:Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDTO, Cliente>();
            CreateMap<UpdateClienteDTO, Cliente>();
            CreateMap<Cliente, UpdateClienteDTO>();
            CreateMap<Cliente, ReadClienteDTO>();
        }
    }
}
