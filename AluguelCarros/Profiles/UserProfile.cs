using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;

namespace AluguelCarros.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, UpdateUserDTO>();
            CreateMap<User, ReadUserDTO>();
        }
    }
}
