using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Utilities
{
    public class ECommerceProfile: Profile
    {
        public ECommerceProfile()
        {
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailsDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, RegistrationDTO>().ReverseMap()
                .ForMember(dest=>dest.Id,act=>act.Equals(Guid.NewGuid().ToString()))
                .ForMember(dest => dest.Email,act=>act.MapFrom(src=>src.Email.ToLower()))
                .ForMember(dest=> dest.PasswordHash,act=>act.MapFrom(src=>SaltHashAlgorithm.GenerateHash(src.Password,src.PasswordSalt)));
        }
    }
}
