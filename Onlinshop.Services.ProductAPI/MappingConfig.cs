using AutoMapper;
using Onlineshop.Services.ProductAPI.Models;
using Onlineshop.Services.ProductAPI.Models.Dto;

namespace OnlineShop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
