using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Infractructure.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
