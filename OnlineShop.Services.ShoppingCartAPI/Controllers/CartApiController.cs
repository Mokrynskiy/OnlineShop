using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.ShoppingCartAPI.Data;
using OnlineShop.Services.ShoppingCartAPI.Models;
using OnlineShop.Services.ShoppingCartAPI.Service.IService;
using OnlineShop.Services.ShoppingCartAPI.Models.DTO;

namespace OnlineShop.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDTO _response;
        private IProductService _productService;
        private IDiscountCardService _discountCardService;

        public CartApiController(AppDbContext db, IMapper mapper, IProductService productService, IDiscountCardService discountCardService)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
            _productService = productService;
            _discountCardService = discountCardService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartDTO"></param>
        /// <returns></returns>
        [HttpPost("CartAdd")]
        public async Task<ResponseDTO> CartAdd(CartDTO cartDTO) 
        {
            try
            {
                var cartHeaderDb = await _db.CartHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == cartDTO.CartHeaderDTO.UserId);

                if (cartHeaderDb == null)
                {
                    var cartHeader = _mapper.Map<CartHeader>(cartDTO.CartHeaderDTO);
                    _db.CartHeaders.Add(cartHeader);
                   await _db.SaveChangesAsync();

                    cartDTO.CartDetails.First().CartHeaderId = cartHeader.CartHeaderId;
                    _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDTO.CartDetails.First()));
                    await _db.SaveChangesAsync();
                }
                else
                {
                    var cartDetailsDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == cartDTO.CartDetails.First().ProductId 
                    && x.CartHeaderId == cartHeaderDb.CartHeaderId);

                    if(cartDetailsDb == null)
                    {
                        cartDTO.CartDetails.First().CartHeaderId = cartHeaderDb.CartHeaderId;
                        _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDTO.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        cartDTO.CartDetails.First().Count += cartDetailsDb.Count;
                        cartDTO.CartDetails.First().CartHeaderId = cartDetailsDb.CartHeaderId;
                        cartDTO.CartDetails.First().CartDetailsId = cartDetailsDb.CartDetailsId;

                        _db.CartDetails.Update(_mapper.Map<CartDetails>(cartDTO.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                }

                _response.Result = cartDTO;
            }
            catch (Exception exp)
            {
                _response.Message = exp.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartDTO"></param>
        /// <returns></returns>
        [HttpPost("ApplyDiscountCard")]
        public async Task<object> ApplyDiscountCard([FromBody] CartDTO cartDTO)
        {
            try
            {
                var cartDb = _db.CartHeaders.First(x => x.UserId == cartDTO.CartHeaderDTO.UserId);
                cartDb.DiscountCard = cartDTO.CartHeaderDTO.DiscountCard;

                _db.CartHeaders.Update(cartDb);
                await _db.SaveChangesAsync();
                _response.Result = true;
            }
            catch (Exception exp)
            {
                _response.Message = exp.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartDTO"></param>
        /// <returns></returns>
        [HttpPost("RemoveDiscountCard")]
        public async Task<object> RemoveDiscountCard([FromBody] CartDTO cartDTO)
        {
            try
            {
                var cartDb = _db.CartHeaders.First(x => x.UserId == cartDTO.CartHeaderDTO.UserId);
                cartDb.DiscountCard = cartDTO.CartHeaderDTO.DiscountCard;

                _db.CartHeaders.Update(cartDb);
                await _db.SaveChangesAsync();
                _response.Result = true;
            }
            catch (Exception exp)
            {
                _response.Message = exp.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartDetailsId"></param>
        /// <returns></returns>
        [HttpPost("RemoveCart")]
        public async Task<ResponseDTO> RemoveCart(int cartDetailsId)
        {
            try
            {
                var cartDetails = _db.CartDetails.First(x => x.CartDetailsId == cartDetailsId);
                var amountCartItem = _db.CartDetails.Where(x => x.CartHeaderId == cartDetails.CartHeaderId).Count();

                _db.CartDetails.Remove(cartDetails);

                if(amountCartItem == 1)
                {
                    var cartRemove = await _db.CartHeaders.FirstOrDefaultAsync(x => x.CartHeaderId == cartDetails.CartHeaderId);
                    _db.CartHeaders.Remove(cartRemove);
                }

                await _db.SaveChangesAsync();

                _response.Result = true;
            }
            catch (Exception exp)
            {
                _response.Message = exp.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpGet("GetCart")]
        public async Task<ResponseDTO> GetCart(string userId)
        {
            try
            {
                var cart = new CartDTO()
                {
                    CartHeaderDTO = _mapper.Map<CartHeaderDTO>(_db.CartHeaders.First(x => x.UserId == userId))
                };

                cart.CartDetails = _mapper.Map<IEnumerable<CartDetailsDTO>>(_db.CartDetails.Where(x => x.CartHeaderId == cart.CartHeaderDTO.CartHeaderId));
                var productDTO = await _productService.GetProducts();

                foreach (var item in cart.CartDetails)
                {
                    item.Product = productDTO.FirstOrDefault(x => x.Id == item.ProductId);
                    cart.CartHeaderDTO.CartTotal += (decimal)(item.Count * item?.Product?.Price ?? 0.00);
                }

                if(!string.IsNullOrEmpty(cart.CartHeaderDTO.DiscountCard))
                {
                    var discountCard = await _discountCardService.GetDiscount(cart.CartHeaderDTO.DiscountCard);
                    if(discountCard != null && cart.CartHeaderDTO.CartTotal > discountCard.MinAmount)
                    {
                        cart.CartHeaderDTO.CartTotal -= discountCard.DiscountAmount;
                        cart.CartHeaderDTO.Discount = discountCard.DiscountAmount;
                    }
                }

                 _response.Result = cart;
            }
            catch (Exception exp)
            {
                _response.Message = exp.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }
    }
}