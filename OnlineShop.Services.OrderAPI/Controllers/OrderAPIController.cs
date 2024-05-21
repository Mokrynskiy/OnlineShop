using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.OrderAPI.Data;
using OnlineShop.Services.OrderAPI.Models;
using OnlineShop.Services.OrderAPI.Models.Dto;
using OnlineShop.Services.OrderAPI.Models.DTO;
using OnlineShop.Services.OrderAPI.Service.IService;
using OnlineShop.Services.OrderAPI.Utility;

namespace OnlineShop.Services.OrderAPI.Controllers
{
    [Route("api/order ")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;
        private IProductService _productService;

        public OrderAPIController(AppDbContext db, IMapper mapper, IProductService productService)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
            _productService = productService;
        }

        [Authorize]
        [HttpGet("GetOrders")]
        public async Task<ResponseDto?> Get(string? userId = "") 
        {
            try
            {
                IEnumerable<OrderHeader> objList;
                if(User.IsInRole(SD.RoleAdmin))
                {
                    objList = await _db.OrderHeaders.Include(x => x.OrderDetails).OrderByDescending(x=>x.OrderHeaderId).ToListAsync();
                }
                else
                {
                    objList = await _db.OrderHeaders.Include(x => x.OrderDetails).Where(x => x.UserId == userId).OrderByDescending(x => x.OrderHeaderId).ToListAsync();
                }

                _response.Result  = _mapper.Map<IEnumerable<OrderHeaderDTO>>(objList);
            }
            catch(Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [Authorize]
        [HttpGet("GetOrder/{id:int}")]
        public async Task<ResponseDto?> Get(int id)
        {
            try
            {
                OrderHeader orderHeader = await _db.OrderHeaders.Include(u=>u.OrderDetails).FirstAsync(u=>u.OrderHeaderId == id);
                _response.Result = _mapper.Map<OrderHeaderDTO>(orderHeader);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<ResponseDto?> CreateOrder([FromBody] CartDTO cartDTO)
        {
            try
            {
                OrderHeaderDTO orderHeaderDTO = _mapper.Map<OrderHeaderDTO>(cartDTO.CartHeaderDTO);
                orderHeaderDTO.OrderTime = DateTime.Now;
                orderHeaderDTO.Status = SD.Status_Pending;
                orderHeaderDTO.OrderDetails = _mapper.Map<IEnumerable<OrderDetailsDTO>>(cartDTO.CartDetails);

                OrderHeader orderCreated = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderHeaderDTO)).Entity;
                await _db.SaveChangesAsync();

                orderHeaderDTO.OrderHeaderId = orderCreated.OrderHeaderId;
                _response.Result = orderHeaderDTO;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [Authorize]
        [HttpPost("UpdateOrderStatus/{orderId:int}")]
        public async Task<ResponseDto> UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                OrderHeader orderHeader = _db.OrderHeaders.First(x => x.OrderHeaderId == orderId);
                if(orderHeader != null)
                {
                    if(newStatus != null)
                    {
                        if (newStatus == SD.Status_Cancelled)
                        {
                            orderHeader.Status = SD.Status_Cancelled;
                        }
                        else
                        {
                            orderHeader.Status = newStatus;
                        }
                        
                        _db.SaveChanges();
                    }
                }

                //_response.Result = orderHeader;

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
