using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Enum;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Utilities
{
    public class ECommerceProfile: Profile
    {
        public ECommerceProfile()
        {
            CreateMap<User, LoginDTO>();
            CreateMap<OrderDetail, OrderDetailsDTO>();
            CreateMap<AddProductDTO, Product>()
                 .ForMember(dest => dest.ProductImages, act => act.MapFrom(src=>src.ProductImage.Select(x=>x)))
                 .ForMember(dest => dest.CategoryId, act => act.MapFrom(src=>((CategoryEnum)src.CategoryId)
                 .GetType().GetMember(((CategoryEnum)src.CategoryId).ToString()).First().GetCustomAttribute<DisplayAttribute>().Name));
            CreateMap<Product, ProductDTO>()
                .ForMember(dest=>dest.ProductImage,act => act.MapFrom(src=>src.ProductImages.FirstOrDefault()));
            CreateMap<User, RegistrationDTO>().ReverseMap()
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.ToLower()));
        }
    }
}
