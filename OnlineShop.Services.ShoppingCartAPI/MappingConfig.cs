using AutoMapper;
using OnlineShop.Services.ShoppingCartAPI.Models;
using OnlineShop.Services.ShoppingCartAPI.Models.DTO;

namespace OnlineShop.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<CartDetailsDTO, CartDetails>();
                config.CreateMap<CartHeaderDTO, CartHeader>();
            });
            return mappingConfig;
        }
    }
}
