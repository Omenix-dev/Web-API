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
            CreateMap<User, LoginDTO>();
            CreateMap<OrderDetail, OrderDetailsDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<User, RegistrationDTO>().ReverseMap()
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.ToLower()));
        }
    }
}
