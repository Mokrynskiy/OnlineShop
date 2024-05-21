using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onlineshop.Services.ProductAPI.Models;
using Onlineshop.Services.ProductAPI.Models.Dto;
using OnlineShop.Services.ProductAPI.Data;


namespace OnlineShop.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]    
    public class ProductApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;
        
        public ProductApiController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Product> result = await _db.Products.ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(result);
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
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Product result = await _db.Products.FirstAsync(x => x.Id == id);
                _response.Result = _mapper.Map<ProductDto>(result);
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
        public async Task<ResponseDto> GetByCode(string name)
        {
            try
            {
                Product result = await _db.Products.FirstAsync(x => x.Name.ToLower().Contains(name.ToLower()));
                _response.Result = _mapper.Map<ProductDto>(result);
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
        public async Task<ResponseDto> Post([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Add(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<ProductDto>(obj);
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
        public async Task<ResponseDto> Put([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Update(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<ProductDto>(obj);
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
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(x => x.Id == id);
                _db.Products.Remove(obj);
                await _db.SaveChangesAsync();
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
