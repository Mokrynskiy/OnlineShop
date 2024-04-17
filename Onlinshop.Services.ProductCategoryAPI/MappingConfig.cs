using AutoMapper;
using Onlineshop.Services.ProductCategoryAPI.Models;
using Onlineshop.Services.ProductCategoryAPI.Models.Dto;

namespace OnlineShop.Services.ProductCategoryAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductCategoryDto, ProductCategory>();
                config.CreateMap<ProductCategory, ProductCategoryDto>();
            });
            return mappingConfig;
        }
    }
}
