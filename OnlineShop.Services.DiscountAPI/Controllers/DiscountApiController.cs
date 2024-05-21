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
        private ResponseDto _response;
        
        public DiscountApiController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Discount> result = await _db.Discounts.ToListAsync();
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
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Discount result = await _db.Discounts.FirstAsync(x => x.Id == id);
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
        public async Task<ResponseDto> GetByCode(string code)
        {
            try
            {
                Discount result = await _db.Discounts.FirstAsync(x => x.DiscountCode.ToLower() == code.ToLower());
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
        public async Task<ResponseDto> Post([FromBody] DiscountDto discountDto)
        {
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
        public async Task<ResponseDto> Put([FromBody] DiscountDto discountDto)
        {
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
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Discount obj = _db.Discounts.First(x => x.Id == id);
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
