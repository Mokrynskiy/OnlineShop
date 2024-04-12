using AutoMapper;
using OnlineShop.Services.DiscountAPI.Models;
using OnlineShop.Services.DiscountAPI.Models.Dto;

namespace OnlineShop.Services.DiscountAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<DiscountDto, Discount>();
                config.CreateMap<Discount, DiscountDto>();
            });
            return mappingConfig;
        }
    }
}
