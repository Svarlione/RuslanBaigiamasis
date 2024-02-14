using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuslanAPI.Core.DTO;
using RuslanAPI.Services.Authorization;
using RuslanAPI.Services.Mappers;
using RuslanAPI.Services.UserServices;
using System.Net.Mime;
using System.Security.Claims;

namespace _2._2012.IntroductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;
        private readonly IAuthService _authService;

        public AuthorizationController(IUserService userService, IUserMapper userMapper, IAuthService authService)
        {
            _userService = userService;
            _userMapper = userMapper;
            _authService = authService;

        }

        [HttpPost("login")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginInfoDto request)
        {
            try
            {
                // Преобразовать пароль из byte[] в строку
                string password = request.Password;

                var token = await _authService.LoginAsync(request.UserName, password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("signup")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] SingUpDto request)
        {
            try
            {
                byte[] salt = _authService.GeneratePasswordSalt();
                string personalIndefication = request.PersonalIndefication;
                string email = request.Email;

                var token = await _authService.SignUpAsync(request.UserName, request.Role, request.Password, salt, personalIndefication, email);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("user/delete/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteUser(long userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }


    }
}
