using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;

namespace AluguelCarros.Profiles
{
    public class CarroProfile:Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDTO, Carro>();
            CreateMap<UpdateCarroDTO, Carro>();
            CreateMap<Carro, UpdateCarroDTO>();
            CreateMap<Carro, ReadCarroDTO>();
        }
    }
}
