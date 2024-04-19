using AutoMapper;
using OnlineShop.Services.OrderAPI.Models;
using OnlineShop.Services.OrderAPI.Models.Dto;
using OnlineShop.Services.OrderAPI.Models.DTO;

namespace OnlineShop.Services.OrderAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<OrderHeaderDTO, CartHeaderDTO>().ForMember(dest => dest.CartTotal, o => o.MapFrom(src => src.OrderTotal))
                .ReverseMap();
                config.CreateMap<CartDetailsDTO, OrderDetailsDTO>().ForMember(dest => dest.ProductName, o => o.MapFrom(src => src.Product.Name));
                config.CreateMap<CartDetailsDTO, OrderDetailsDTO>().ForMember(dest => dest.Price, o => o.MapFrom(src => src.Product.Price));
                
                config.CreateMap<OrderDetailsDTO, CartDetailsDTO>();
                config.CreateMap<OrderHeader, OrderHeaderDTO>().ReverseMap();
                config.CreateMap<OrderDetailsDTO, OrderDetails>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
