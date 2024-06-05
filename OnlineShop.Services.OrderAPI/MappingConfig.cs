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
                config.CreateMap<OrderHeaderDto, CartHeaderDto>().ForMember(dest => dest.CartTotal, o => o.MapFrom(src => src.OrderTotal))
                .ReverseMap();
                config.CreateMap<CartDetailsDto, OrderDetailsDto>().ForMember(dest => dest.ProductName, o => o.MapFrom(src => src.Product.Name));
                config.CreateMap<CartDetailsDto, OrderDetailsDto>().ForMember(dest => dest.Price, o => o.MapFrom(src => src.Product.Price));
                
                config.CreateMap<OrderDetailsDto, CartDetailsDto>();
                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
