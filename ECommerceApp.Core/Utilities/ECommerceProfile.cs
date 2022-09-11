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
            CreateMap<User, RegistrationDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
        
    }
}
