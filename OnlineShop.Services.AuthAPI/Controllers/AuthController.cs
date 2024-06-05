﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.AuthAPI.Models.Dto;
using OnlineShop.Services.AuthAPI.Service.IService;

namespace OnlineShop.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var _response = new ResponseDto<string>();
            var errorMessage = await _authService.Register(model);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess =   false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var _response = new ResponseDto<LoginResponseDto>();
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Неверное имя пользователя или пароль.";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var _response = new ResponseDto<bool>();
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model?.Role?.ToUpper() ?? "");
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
