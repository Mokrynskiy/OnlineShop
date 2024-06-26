﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.DiscountAPI.Data;
using OnlineShop.Services.DiscountAPI.Models;
using OnlineShop.Services.DiscountAPI.Models.Dto;

namespace OnlineShop.Services.DiscountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Discount> result = _db.Discounts.ToList();
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
        public ResponseDto Get(int id)
        {
            try
            {
                Discount result = _db.Discounts.First(x => x.Id == id);
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
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Discount result = _db.Discounts.First(x => x.DiscountCode.ToLower() == code.ToLower());
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
        public ResponseDto Post([FromBody] DiscountDto discountDto)
        {
            try
            {
                Discount obj = _mapper.Map<Discount>(discountDto);
                _db.Discounts.Add(obj);
                _db.SaveChanges();
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
        public ResponseDto Put([FromBody] DiscountDto discountDto)
        {
            try
            {
                Discount obj = _mapper.Map<Discount>(discountDto);
                _db.Discounts.Update(obj);
                _db.SaveChanges();
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
        public ResponseDto Delete(int id)
        {
            try
            {
                Discount obj = _db.Discounts.First(x => x.Id == id);
                _db.Discounts.Remove(obj);
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
