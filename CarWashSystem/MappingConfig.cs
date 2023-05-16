using AutoMapper;
using CarWashSystem.DTO;
using CarWashSystem.Models;

namespace CarWashSystem
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<User, Userdto>();
            CreateMap<Userdto,User>();
        }
    }
}
