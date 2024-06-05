using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.DiscountAPI.Data;
using OnlineShop.Services.DiscountAPI.Models;
using OnlineShop.Services.DiscountAPI.Models.Dto;

namespace OnlineShop.Services.DiscountAPI.Controllers
{
    [Route("api/discount")]
    [ApiController]
    [Authorize]
    public class DiscountApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        
        public DiscountApiController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<DiscountDto>>> Get()
        {
            var _response = new ResponseDto<IEnumerable<DiscountDto>>();
            try
            {
                IEnumerable <Discount> result = await _db.Discounts.ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<DiscountDto>>(result);
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
        public async Task<ResponseDto<DiscountDto>> Get(int id)
        {
            var _response = new ResponseDto<DiscountDto>();
            try
            {
                var result = await _db.Discounts.FirstAsync(x => x.Id == id);
                _response.Result = _mapper.Map<DiscountDto>(result);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ResponseDto<DiscountDto>> GetByCode(string code)
        {
            var _response = new ResponseDto<DiscountDto>();
            try
            {
                var result = await _db.Discounts.FirstAsync(x => x.DiscountCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<DiscountDto>(result);
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
        public async Task<ResponseDto<DiscountDto>> Post([FromBody] DiscountDto discountDto)
        {
            var _response = new ResponseDto<DiscountDto>();
            try
            {
                Discount obj = _mapper.Map<Discount>(discountDto);
                _db.Discounts.Add(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<DiscountDto>(obj);
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
        public async Task<ResponseDto<DiscountDto>> Put([FromBody] DiscountDto discountDto)
        {
            var _response = new ResponseDto<DiscountDto>();

            try
            {
                Discount obj = _mapper.Map<Discount>(discountDto);
                _db.Discounts.Update(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<DiscountDto>(obj);
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
        public async Task<ResponseDto<int>> Delete(int id)
        {
            var _response = new ResponseDto<int>();
            _response.Result = id;
            try
            {
                var obj = _db.Discounts.First(x => x.Id == id);
                _db.Discounts.Remove(obj);
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
