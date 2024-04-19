using AutoMapper;
using OnlineShop.Services.ShoppingCartAPI.Models.DTO;
using OnlineShop.Services.ShoppingCartAPI.Models;

namespace OnlineShop.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<CartDetailsDTO, CartDetails>();
                config.CreateMap<CartDetails, CartDetailsDTO>();
                config.CreateMap<CartHeaderDTO, CartHeader>();
                config.CreateMap<CartHeader, CartHeaderDTO>();

            });
            return mappingConfig;
        }
    }
}
