using AutoMapper;
using CommerceApi.DTO;
using CommerceDb.Entities;

namespace CommerceApi
{
    public class CustomMapper:Profile
    {
        public CustomMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
