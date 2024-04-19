using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onlineshop.Services.ProductCategoryAPI.Models;
using Onlineshop.Services.ProductCategoryAPI.Models.Dto;
using OnlineShop.Services.ProductCategoryAPI.Data;

namespace OnlineShop.Services.ProductCategoryAPI.Controllers
{
    [Route("api/productCategory")]
    [ApiController]
    public class ProductCategoryApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;
        
        public ProductCategoryApiController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<ProductCategory> result = _db.ProductCategories.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductCategoryDto>>(result);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                ProductCategory result = _db.ProductCategories.First(x => x.Id == id);
                _response.Result = _mapper.Map<ProductCategoryDto>(result);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto GetByCode(string name)
        {
            try
            {
                ProductCategory result = _db.ProductCategories.First(x => x.Name.ToLower().Contains(name.ToLower()));
                _response.Result = _mapper.Map<ProductCategoryDto>(result);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductCategoryDto ProductCategoryDto)
        {
            try
            {
                ProductCategory obj = _mapper.Map<ProductCategory>(ProductCategoryDto);
                _db.ProductCategories.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductCategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductCategoryDto ProductCategoryDto)
        {
            try
            {
                ProductCategory obj = _mapper.Map<ProductCategory>(ProductCategoryDto);
                _db.ProductCategories.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductCategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                ProductCategory obj = _db.ProductCategories.First(x => x.Id == id);
                _db.ProductCategories.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
